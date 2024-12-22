﻿namespace Ordering.Domain.ValueObjects
{
    public record OrderName
    {
        private const int DefaultLength = 7;

        public string Value { get; } = default!;

        private OrderName(string value) => Value = value;

        public static OrderName Of(string value)
        {
            ArgumentNullException.ThrowIfNull(value);
            ArgumentOutOfRangeException.ThrowIfNotEqual(value.Length, DefaultLength);
            return new OrderName(value);
        }
    }
}
