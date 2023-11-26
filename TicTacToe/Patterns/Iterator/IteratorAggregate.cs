﻿using System.Collections;

namespace TicTacToe.Patterns.Iterator
{
    public abstract class IteratorAggregate : IEnumerable
    {
        // Returns an Iterator or another IteratorAggregate for the implementing object.
        public abstract IEnumerator GetEnumerator();
    }
}
