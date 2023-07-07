
// CLASS HEAP
public class Heap {

    Node root;
    Node last_node;
    private int len = 0;

    public Heap(object key) {
        this.root = new Node(null, key);
        this.len++;
        this.last_node = root;
    }


    public int Size() {
        return len;
    }


    public bool IsEmpty() {
        return len == 0;
    }
    
    // TESTE COM A Height
    // public bool IsExternal(Node node) {
    //     return node.GetLeftChild() == null && node.GetRightChild() == null;
    // }

    // public int Height(Node no) { // Retorna a Height
    //     if (IsExternal(no)) {
    //         return 0;
    //     } else {
    //         int height = 0;
    //         int child_height; 
    //         if (no.GetLeftChild() != null) {
    //             child_height = Height(no.GetLeftChild());
    //             height = Math.Max(height, child_height);
    //         } 
    //         if (no.GetRightChild() != null) {
    //             child_height = Height(no.GetRightChild());
    //             height = Math.Max(height, child_height);
    //         }
    //         return height + 1;
    //     }
    // }

    public bool IsRoot(Node node) {
        return node == root;
    }


    public object Min() {
        return root.GetKey();
    }


    public object Key(Node node) {
        return node.GetKey();
    }


    public object Value(Node node) {
        return node.GetValue();
    }


    public Node Insert(object key) {
        Node old_last_node = NextNode();
        Node new_node;

        if (!IsRoot(old_last_node) && old_last_node.GetParent().GetRightChild() == null) {
            new_node = new Node(old_last_node.GetParent(), key);
            old_last_node.GetParent().SetRightChild(new_node);
        } else {
            new_node = new Node(old_last_node, key);
            old_last_node.SetLeftChild(new_node);
        }

        old_last_node.AddChildren(); // questionável esse atributo
        this.last_node = new_node;
        this.len++;
        return new_node;
    }


    private Node NextNode() {
        Node atual = last_node;
        
        if (IsRoot(atual)) {
            atual = root;
            return atual;
        }

        while (!IsRoot(atual) || atual.GetParent().GetRightChild() == null) {
            atual = atual.GetParent();

            if (IsRoot(atual)) { 
                break; 
            } 
        }

        if (!IsRoot(atual)) {
            atual = atual.GetParent().GetRightChild();
        } 
        // else if (Height(atual) - Height(atual.GetRightChild()) == 2) { // problema tá aqui
        //     atual = atual.GetRightChild();
        // }

        while (atual.GetLeftChild() != null) {
            atual = atual.GetLeftChild();
        }

        return atual;
    }


    public object RemoveMin() {
        return root.GetKey();
    }

    // PERGUNTAR SOBRE COMPARADOR 
    // PERGUNTAR SOBRE ORDENAÇÃO DA FILA 'PQ-SORT'

}


// CLASS NODE 
public class Node {
    private Node parent;
    private Node leftChild = null;
    private Node rightChild = null;
    private int children = 0;
    private object key;
    private object value;

    public Node(Node parent, object key) {
        this.parent = parent;
        this.key = key;
        this.value = key;
    }

    public object GetKey() {
        return key;
    }

    public object GetValue() {
        return value;
    }

    public Node GetParent() {
        return parent;
    }

    public Node GetLeftChild() {
        return leftChild;
    }

    public Node GetRightChild() {
        return rightChild;
    }

    public int GetChildren() {
        return children;
    }

    public void SetKey(object key) {
        this.key = key;
        this.value = key;
    }

    public void SetLeftChild(Node node) {
        this.leftChild = node;
    }
    
    public void SetRightChild(Node node) {
        this.rightChild = node;
    }

    public void AddChildren() {
        this.children++;
    }
}