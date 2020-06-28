using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MEO.Domain.DomainObjects
{
    public abstract class Enumeration : IComparable
    {
        public string Descricao { get; private set; }

        public int Id { get; private set; }

        protected Enumeration(int id, string name)
        {
            Id = id;
            Descricao = name;
        }

        public override string ToString() => Descricao;

        public static IEnumerable<T> ObterTodos<T>() where T : Enumeration
        {
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }

        public override bool Equals(object obj)
        {
            var otherValue = obj as Enumeration;

            if (otherValue == null)
                return false;

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }

        public override int GetHashCode() => Id.GetHashCode();

        public static T FromValue<T>(int value) where T : Enumeration
        {
            try
            {
                var matchingItem = Parse<T, int>(value, "value", item => item.Id == value);
                return matchingItem;
            }
            catch
            {
                throw new InvalidCastException($"Erro ao converter o valor {value} para o tipo {nameof(T) } ");
            }
        }

        public static T FromDisplayName<T>(string displayName) where T : Enumeration
        {
            var matchingItem = Parse<T, string>(displayName, "display name", item => item.Descricao == displayName);
            return matchingItem;
        }

        private static T Parse<T, K>(K value, string description, Func<T, bool> predicate) where T : Enumeration
        {
            var matchingItem = ObterTodos<T>().FirstOrDefault(predicate);

            if (matchingItem is null)
            {
                throw new InvalidOperationException($"O valor '{value}' não é válido para o tipo {typeof(T)}");
            }

            return matchingItem;
        }

        public int CompareTo(object other) => Id.CompareTo(((Enumeration)other).Id);
    }
}
