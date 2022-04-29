using System;

namespace LexerParser {
  public class HelloWorld {
      public static void Main() 
      {
          Lexer lex = new Lexer();
          Console.WriteLine("--- Lexer Parser ---");
          Console.WriteLine("Veuillez entrer un calcul.");
          String result = Console.ReadLine();
          lex.parseText(result);
          Console.WriteLine(lex.ToString());
      }
  }
}
