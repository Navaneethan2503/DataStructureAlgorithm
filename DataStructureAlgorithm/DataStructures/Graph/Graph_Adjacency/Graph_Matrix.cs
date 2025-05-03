using System;
using System.Collections.Generic;
/**
**/
namespace AdjacencyMatrixGraph{
    class AdjacencyMatrixGraphClass{
        class Graph{
            int Vertices;
            int[,] graph;
            int[] visitedDFS;

            public Graph(int n){
                Vertices = n;
                graph = new int[n,n];
                visitedDFS = new int[Vertices];
            }

            public void InsertEdge(int u, int v, int w){
                graph[u,v] = w;
            }

            public void RemoveEdge(int u, int v){
                graph[u,v] = 0;
            }

            public bool ExistEdge(int u, int v){
                return graph[u,v] != 0;
            }

            public int VerticesCount(){
                return Vertices;
            }

            public int EdgeCount(){
                int count = 0;
                for(int i = 0; i<Vertices; i++){
                    for(int j = 0; j< Vertices; j++){
                        if(graph[i,j] != 0){
                            count = count + 1;
                        }
                    }
                }
                return count;
            }

            public void Edges(){
                for(int i = 0; i<Vertices; i++){
                    for(int j = 0; j<Vertices; j++){
                        if(graph[i,j] != 0){
                            Console.WriteLine(i+"--"+j);
                        }
                    }
                }
            }

            public int Degree(int v){
                int count = 0;
                for(int i = 0; i<Vertices; i++){
                    for(int j = 0; j < Vertices; j++){
                        if(i == v && graph[i,j] != 0){
                            count = count + 1;
                        }
                        else if(j == v && graph[i,j] != 0){
                            count = count + 1;
                        }
                    }
                }
                return count;
            }

            public int OutDegree(int u){
                int count = 0;
                for(int j = 0; j<Vertices; j++){
                    if(graph[u,j] != 0){
                        count = count + 1;
                    }
                }
                return count;
            }

            public int InDegree(int u){
                int count = 0;
                for(int i = 0; i<Vertices; i++){
                    if(graph[i,u] != 0){
                        count = count + 1;
                    }
                }
                return count;
            }

            public void Display(){
                for(int i = 0; i<Vertices; i++){
                    for(int j = 0; j < Vertices; j++){
                        Console.Write(graph[i,j]+"\t");
                    }
                    Console.WriteLine();
                }
            }

            public void BFS(int s){
                int i = s;
                Queue<int> queue = new Queue<int>();
                Console.Write("BFS : "+i+",");
                queue.Enqueue(i);
                int[] visited = new int[Vertices];
                visited[i] = 1;
                while(queue.Count > 0){
                    i = queue.Dequeue();
                    for(int j = 0; j < Vertices; j++){
                        if(graph[i,j] == 1 && visited[j] == 0){
                            visited[j] = 1;
                            queue.Enqueue(j);
                            Console.Write(j+",");
                        }
                    }
                }
                Console.WriteLine();
            }

            public void DFS(int s){
                
                if(visitedDFS[s] == 0){
                    Console.Write(s+",");
                    visitedDFS[s] = 1;
                    for(int j = 0; j<Vertices; j++){
                        if(graph[s,j] == 1 && visitedDFS[j] == 0){
                            DFS(j);
                        }
                    }
                }
            }

        }
        public static void Main(){
            Console.WriteLine("Graph Adjacency Matrix Representation.");
            Graph undirectedGraph = new Graph(4);
            undirectedGraph.Display();
            Console.WriteLine("Vertices :"+ undirectedGraph.VerticesCount());
            Console.WriteLine("Edge Count :"+ undirectedGraph.EdgeCount());
            undirectedGraph.InsertEdge(0,1,1);
            undirectedGraph.InsertEdge(0,2,1);
            undirectedGraph.InsertEdge(1,0,1);
            undirectedGraph.InsertEdge(1,2,1);
            undirectedGraph.InsertEdge(2,0,1);
            undirectedGraph.InsertEdge(2,1,1);
            undirectedGraph.InsertEdge(2,3,1);
            undirectedGraph.InsertEdge(3,2,1);
            Console.WriteLine("Graph Adjacency Matrix Representation.");
            undirectedGraph.Display();
            Console.WriteLine("Vertices :"+ undirectedGraph.VerticesCount());
            Console.WriteLine("Edge Count :"+ undirectedGraph.EdgeCount());

            Console.WriteLine("Exist Edge 0 -- 1 :"+ undirectedGraph.ExistEdge(0,1));
            Console.WriteLine("Degree of Vertices - (0) :"+ undirectedGraph.Degree(0));
            Console.WriteLine("InDegree of Vertices - (0) :"+ undirectedGraph.InDegree(0));
            Console.WriteLine("OutDegree of Vertices - (0) :"+ undirectedGraph.OutDegree(0));

            Console.Clear();
            //Weighted Undirected Graph

            Console.WriteLine("Weighted Undirected Graph Adjacency Matrix Representation.");
            Graph weightUndirectedGraph = new Graph(4);
            weightUndirectedGraph.Display();
            Console.WriteLine("Vertices :"+ weightUndirectedGraph.VerticesCount());
            Console.WriteLine("Edge Count :"+ weightUndirectedGraph.EdgeCount());
            weightUndirectedGraph.InsertEdge(0,1,26);
            weightUndirectedGraph.InsertEdge(0,2,16);
            weightUndirectedGraph.InsertEdge(1,0,26);
            weightUndirectedGraph.InsertEdge(1,2,12);
            weightUndirectedGraph.InsertEdge(2,0,16);
            weightUndirectedGraph.InsertEdge(2,1,12);
            weightUndirectedGraph.InsertEdge(2,3,8);
            weightUndirectedGraph.InsertEdge(3,2,8);
            Console.WriteLine("Graph Adjacency Matrix Representation.");
            weightUndirectedGraph.Display();
            Console.WriteLine("Vertices :"+ weightUndirectedGraph.VerticesCount());
            Console.WriteLine("Edge Count :"+ weightUndirectedGraph.EdgeCount());

            Console.WriteLine("Exist Edge 0 -- 1 :"+ weightUndirectedGraph.ExistEdge(0,1));
            Console.WriteLine("Degree of Vertices - (0) :"+ weightUndirectedGraph.Degree(0));
            Console.WriteLine("InDegree of Vertices - (0) :"+ weightUndirectedGraph.InDegree(0));
            Console.WriteLine("OutDegree of Vertices - (0) :"+ weightUndirectedGraph.OutDegree(0));

            //Directed Graph
            Console.Clear();
            Console.WriteLine("Directed Graph Adjacency Matrix Representation.");
            Graph directedGraph = new Graph(4);
            directedGraph.Display();
            Console.WriteLine("Vertices :"+ directedGraph.VerticesCount());
            Console.WriteLine("Edge Count :"+ directedGraph.EdgeCount());
            directedGraph.InsertEdge(0,1,26);
            directedGraph.InsertEdge(0,2,16);
            directedGraph.InsertEdge(1,2,12);
            directedGraph.InsertEdge(2,3,8);
            Console.WriteLine("Directed Graph Adjacency Matrix Representation.");
            directedGraph.Display();
            Console.WriteLine("Vertices :"+ directedGraph.VerticesCount());
            Console.WriteLine("Edge Count :"+ directedGraph.EdgeCount());

            Console.WriteLine("Exist Edge 0 -- 1 :"+ directedGraph.ExistEdge(0,1));
            Console.WriteLine("Exist Edge 1 -- 0 :"+ directedGraph.ExistEdge(1,0));
            Console.WriteLine("InDegree of Vertices - (0) :"+ directedGraph.InDegree(0));
            Console.WriteLine("OutDegree of Vertices - (0) :"+ directedGraph.OutDegree(0));

            //BFS
            Console.WriteLine("BFS Traversal :");
            undirectedGraph.BFS(0);
            directedGraph.BFS(0);

            //DFS
            Console.WriteLine("DFS Traversal :");
            undirectedGraph.DFS(0);
        }
    }
}