import java.io.BufferedReader;
import java.io.FileReader;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Scanner;

class Main {
  public static void main(String[] args) {
    Map<String, List<String>> adjacenyList = new HashMap<>();
    BufferedReader reader;
    int edgeCounter = 0;
    String scanInput;
    try {
      reader = new BufferedReader(new FileReader("data.txt"));
      int index = 0;
      System.out.println("Source:");
      while ((scanInput = reader.readLine()) != null) {
        System.out.println(scanInput);
        List<String> adjacenies = new ArrayList<>();
        int secondIndex = 0;
        for (String value : (scanInput.trim()).split(" ")) {
          if (value.equals("1")) {
            adjacenies.add("" + secondIndex);
            edgeCounter++;
          }
          secondIndex++;
        }
        adjacenyList.put("" + index++, adjacenies);
      }
      reader.close();
    } catch (Exception e) {
      System.out.println("Dont Acces to file!");
    }
    System.out.println("\n\nGraph have " + edgeCounter + " edge:");
    for (Entry<String, List<String>> entry : adjacenyList.entrySet()) {
      System.out.print("From " + entry.getKey() + " to ");
      for (String edge : entry.getValue())
        System.out.print(edge + " ");
      System.out.println("");
    }

    Scanner scanner = new Scanner(System.in);
    System.out.println("Enter a node number for search the count of its edges");
    while (!(scanInput = scanner.nextLine()).isEmpty()) {
      if (adjacenyList.containsKey(scanInput)) {
        int enterCounter = 0;
        for (List<String> exits : adjacenyList.values())
          if (exits.contains(scanInput))
            enterCounter++;
        System.out.println("The query node has " + adjacenyList.get(scanInput).size() + " exit edges and "
            + enterCounter + " enter edges");
      } else
        System.out.println("We can not found node in this graph");
      System.out.println("Send empty input for exit");
    }
    scanner.close();
    System.out.println("Exited");
    System.out.println("Start BFS");
    BFS(adjacenyList, null, null, 0);
    System.out.println("\nStart DFS");
    DFS(adjacenyList, null, null, "");
  }

  /*
   * Node Status: - > true is discovered and processed - > false is discovered but
   * to be or being processed - > is not contains key not discovered yet
   */
  public static void BFS(Map<String, List<String>> graph, String root, Map<String, Boolean> nodeStatus, int level) {
    if (root == null) {
      System.out.print("Start: 0 (root) ");
      nodeStatus = new HashMap<>();
      nodeStatus.put("0", true);
      BFS(graph, "0", nodeStatus, 1);
    } else {
      for (String toNode : graph.get(root)) {
        if (!nodeStatus.containsKey(toNode)) {
          System.out.print(toNode + "(Level: " + level + ") ");
          nodeStatus.put(toNode, false);
        }
      }
      for (String toNode : graph.get(root)) {
        if (!nodeStatus.getOrDefault(toNode, true)) {
          nodeStatus.put(toNode, true);
          BFS(graph, toNode, nodeStatus, ++level);
        }
      }
    }
  }

  /*
   * Node Status: - > true is discovered - > false or is not contains key not
   * discovered yet
   */
  public static void DFS(Map<String, List<String>> graph, String root, List<String> travelledNodes, String path) {
    if (root == null) {
      System.out.print("Start: 0 (root) ");
      travelledNodes = new ArrayList<>();
      travelledNodes.add("0");
      DFS(graph, "0", travelledNodes, "0");
    } else {
      for (String toNode : graph.get(root)) {
        if (travelledNodes.contains(toNode))
          continue;
        else {
          System.out.print(toNode + "(path: " + path + ") ");
          travelledNodes.add(toNode);
          DFS(graph, toNode, travelledNodes, path + "-" + toNode);
        }
      }
    }
  }
}

/*
data.txt example input 

0 1 0 1 0 0 0
0 0 1 0 0 1 0
0 0 0 0 1 0 1
0 0 0 0 0 1 0
0 1 0 0 0 1 0
1 0 0 0 0 0 0
0 0 0 0 1 0 0

*/