using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class RelationMatrix {
	List<List<bool>> Relations;
	int size;
	int nGroups = 3;
	int nGroupSize = 4;

	public RelationMatrix(int n) {
		Relations = new List<List<bool>>();
		for(int i = n-1; i >= 0; --i){
//			System.Linq.Enumerable.Repeat(false,i);
			Relations.Add(new List<bool>(new bool[i]));
		}
		size = n;
		for(int i = 0; i < n-1; ++i)
			Relations[0][i] = true;

		List<int> indicies = new List<int>();
		for(int i = 1; i < n - 1; ++i)
			indicies.Add(i);

		for(int i = 0; i < nGroups; ++i){
			List<int> groupIndexs = new List<int>();
			for(int j = 0; j < nGroupSize; ++j) {
				int index = (int)(UnityEngine.Random.value * (indicies.Count - 1));
				groupIndexs.Add(indicies[index]);
				indicies.RemoveAt(index);
			}
			for(int j = 0; j < groupIndexs.Count; ++j)
				for(int k = 0; k < groupIndexs.Count; ++k)
					this[j, k] = true;
		}
	}

	public bool this [int i, int j] {
		get { 
			//Debug.Log(string.Format("{0}, {1}, {2}, {3}", Relations.Count, Relations[Math.Max(i,j)].Count, j, i));
			if(i > j) {
				return Relations[j][i-j-1];
			}
			else if (i == j) {
				return true;
			}
			else {
				return Relations[i][j-i-1];
			}
		}
		set { 
			if(i > j) {
				if( i > size || i < 0 || j > size || j < 0)
					throw new IndexOutOfRangeException();
				Relations[j][i] = value;
			}
			else {
				if( i > size || i < 0 || j > size || j < 0)
					throw new IndexOutOfRangeException();
				Relations[i][j] = value;
			}
		}
	}
}
