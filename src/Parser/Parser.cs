using System;
using System.Collections.Generic;

namespace LexerParser {

  public abstract class Node {
    public Node _parent { get; set; }
    public Node _leftChild { get; set; }
    public Node _rightChild { get; set; }
  }

  public class BinaryExpression : Node {
    private Token _operator;
    public BinaryExpression(Token op, Node lc, Node rc){
      _operator = op;
      _leftChild = lc;
      _rightChild = rc;
    }
  }

  public class UnaryExpression : Node {
    private Token _operator;
    public BinaryExpression(Token op, Node c){
      _operator = op;
      _leftChild = c;
    }
  }

  public class NumberExpression : Node {
	  private Token _value;
    public BinaryExpression(Token op){
      _operator = op;
    }
  }

  public class Parser {
    private Node _tree;

    public Node parse(IEnumerable<Token> tokens){
      Node tree = null;
      Node currentNode = null;
      foreach(token in tokens){
        switch(token.identifier){
          case identifier.number:
            currentNode = new NumberExpression(token); 
            break;
          case identifier.arithmetic_operator:
            if()
            break;
        }
      return tree;
    }
  }

}
