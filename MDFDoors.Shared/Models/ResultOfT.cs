// <copyright file="ResultOfT.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Shared.Models
{
    using System;

    /// <summary> A result of t. </summary>
	///
	/// <typeparam name="T"> Generic type parameter. </typeparam>
	public class ResultOfT<T> : Result
	{
		/// <summary> The value. </summary>
		private readonly T result;

		/// <summary> Initializes a new instance of the MDFDoors.Models.Result&lt;T&gt; class. </summary>
		///
		/// <param name="value">	 The value. </param>
		/// <param name="isSuccess"> True if this object is success. </param>
		/// <param name="error">	 The error. </param>
		protected internal ResultOfT(T value, bool isSuccess, string error)
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