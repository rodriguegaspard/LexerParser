using System;
using System.Collections.Generic;

namespace LexerParser {

  public enum identifier {
      number,
      arithmetic_operator,
      left_parenthesis,
      right_parenthesis
  }

  public class Token {
    private identifier _identifier { get; }
    private String _value { get; }

    public override String ToString(){
      return "[ " + _identifier + " ; \'" + _value + "\' ]\n";
    }

    public Token(identifier i, String v){
      _identifier = i;
      _value = v;
    }
  }

  public class Lexer {
    private ICollection<Token> _tokenList { get; }

    public Lexer(){
      _tokenList = new List<Token>();
    }

    public Lexer(ICollection<Token> t){
      _tokenList = t;
    }

    public override String ToString(){
      String result = "Lexer : \n";
      foreach (Token token in _tokenList){
        result += token;
      }
      return result;
    }

    public void parseText(String expression){
      parseText(expression.GetEnumerator());
    }

    public void parseText(IEnumerator<char> expression){
      while (expression.MoveNext()){
        var tokenCharacter = expression.Current;
        String tokenValue = "";
        if(Char.IsDigit(tokenCharacter)){
          do {
            tokenValue += tokenCharacter;
            if(expression.MoveNext())
              tokenCharacter = expression.Current;
            else break;
          } while(Char.IsDigit(tokenCharacter));
          _tokenList.Add(new Token(identifier.number, tokenValue));
        }
          switch(tokenCharacter){
            case '+':
            case '-':
            case '*':
            case '/':
              _tokenList.Add(new Token(identifier.arithmetic_operator, tokenCharacter.ToString()));
              break;
            case '(':
              _tokenList.Add(new Token(identifier.left_parenthesis, tokenCharacter.ToString()));
              break;
            case ')':
              _tokenList.Add(new Token(identifier.right_parenthesis, tokenCharacter.ToString()));
              break;
        }
      }
    }
  }
}
