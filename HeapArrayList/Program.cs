﻿using System;

class Program {
    static void Main(string[] args) {
        HeapArrayList h = new HeapArrayList(3);
        h.Insert(2);
        h.Insert(7);
        h.Insert(4);
        h.Insert(8);
        h.Insert(1);
        h.ShowTree();
    }
}
