﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

//
// コガネブログさんからアルゴリズムをいただいております。
// http://baba-s.hatenablog.com/entry/2014/09/25/141450
//
public static class IEnumerableExtensions
{
	/// <summary>
	/// 最小値を持つ要素を返します
	/// </summary>
	public static TSource FindMin<TSource, TResult>( this IEnumerable<TSource> self, Func<TSource, TResult> selector ) {
		return self.First( c => selector( c ).Equals( self.Min( selector ) ) );
	}

	/// <summary>
	/// 最大値を持つ要素を返します
	/// </summary>
	public static TSource FindMax<TSource, TResult>( this IEnumerable<TSource> self, Func<TSource, TResult> selector ) {
		return self.First( c => selector( c ).Equals( self.Max( selector ) ) );
	}
}
