using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NodeManager : MonoBehaviour {

	private RelationMatrix RelationMatrix = null;
	private List<Node> Nodes = null;
	private List<Node> OldNodes = null;
	public int NodeCount = 50;
	public GameObject GameNode;
	public GameObject GameEdge;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < NodeCount; ++i){
			Instantiate(GameNode, Util.RandomVector2(2), Quaternion.identity );
		}

		RelationMatrix = new RelationMatrix(GameObject.FindObjectsOfType<Node>());
		Nodes = new List<Node>(GameObject.FindObjectsOfType<Node>());
		OldNodes = new List<Node>(GameObject.FindObjectsOfType<Node>());
		Nodes[0].friction = 0;
		OldNodes[0].friction = 0;
		for(int i = 1; i < Nodes.Count; ++i){ 
			Nodes[i].friction = OldNodes[i].friction = 0.05f * NodeCount;
		}
	}
	
	// Update is called once per frame
	void Update () {
//		Nodes[0].velocity += Nodes[0].RepulsiveForce(Nodes[1]);
//		Nodes[0].velocity += Nodes[0].RepulsiveForce(Nodes[2]);
		for (int i = 1; i < Nodes.Count; ++i) {
			Node node = Nodes[i];
			for(int j = 0; j < OldNodes.Count; ++j) {
				node.velocity += node.RepulsiveForce(OldNodes[j]);	
				if(RelationMatrix[i,j])
					node.velocity += node.AttractiveForce(OldNodes[j]);
			}
		};
		//OldNodes.Clear();
		for(int i = 0; i < Nodes.Count; ++i)
			OldNodes[i] = Nodes[i];

//		Edges = Edges ?? new List<Edge>();
//		for(int i = Edges.Count - 1; i >= 0; --i)
//			if(Edges[i] != null)
//				GameObject.Destroy(Edges[i].gameObject);

//		Edges.Clear();
//		for (int i = 0; i < Nodes.Count; ++i)
//			for(int j = i+1; j < Nodes.Count; ++j)
//			{
//				if(RelationMatrix[i,j]){
//					GameObject obj = (GameObject)GameObject.Instantiate(GameEdge);
//					Edge edge = obj.GetComponent<Edge>();
//					if(edge != null) {
////						Edges.Add(edge);
//						edge.FirstParent = Nodes[i];
//						edge.SecondParent = Nodes[j];
//					}
//				}
//			}
	}
}

