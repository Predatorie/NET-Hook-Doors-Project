// <copyright file="Result.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Shared.Models
{
    using System;

    /// <summary> A result. </summary>
    public class Result
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class.</summary>
        ///
        /// <exception cref="InvalidOperationException"> Thrown when the requested operation is invalid. </exception>
        ///
        /// <param name="isSuccess"> True if this object is success. </param>
        /// <param name="error">The error. </param>
        protected Result(bool isSuccess, string error)
        {
            if (isSuccess && error != string.Empty)
            {
                throw new InvalidOperationException();
            }

            if (!isSuccess && error == string.Empty)
            {
                throw new InvalidOperationException();
            }

            this.IsSuccess = isSuccess;
            this.Error = error;
        }

        /// <summary> Gets a value indicating whether this object is success./ </summary>
        ///
        /// <value> True if this object is success, false if not. </value>
        public bool IsSuccess { get; }

        /// <summary> Gets the error./ </summary>
        ///
        /// <value> The error. </value>
        public string Error { get; }

        /// <summary> True if this object is failure. </summary>
        public bool IsFailure => !this.IsSuccess;

        /// <summary> Fails. </summary>
        ///
        /// <param name="message"> The message. </param>
        ///
        /// <returns> A Result. </returns>
        public static Result Fail(string message) => new Result(false, message);

        /// <summary> Fails. </summary>
        ///
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="message"> The message. </param>
        ///
        /// <returns> A Result. </returns>/
        public static Result<T> Fail<T>(string message) => new Result<T>(default(T), false, message);

        /// <summary> Gets the ok. </summary>
        ///
        /// <returns> A Result. </returns>
        public static Result Ok() => new Result(true, string.Empty);

        /// <summary> Gets the ok. </summary>
        ///
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="value"> The value. </param>
        ///
        /// <returns> A Result. </returns>
        public static Result<T> Ok<T>(T value) => new Result<T>(value, true, string.Empty);
    }

    public class Result<T> : Result
    {
        /// <summary> The value. </summary>
        private readonly T result;

        /// <summary> Initializes a new instance of the MDFDoors.Models.Result&lt;T&gt; class. </summary>
        ///
        /// <param name="value">	 The value. </param>
        /// <param name="isSuccess"> True if this object is success. </param>
        /// <param name="error">	 The error. </param>
        protected internal Result(T value, bool isSuccess, string error)
            : base(isSuccess, error) => this.result = value;

        /// <summary> Gets the value. </summary>
        ///
        /// <exception cref="InvalidOperationException"> Thrown when the requested operation is invalid. </exception>
        ///
        /// <value> The value. </value>
        public T Value
        {
            get
            {
                if (!this.IsSuccess)
                {
                    throw new InvalidOperationException();
                }

                return this.result;
            }
        }
    }
}