using System;

namespace FactoryMethodPatternExample
{
  public interface IDocument
  {
    void Open();
    void Save();
  }

  public class WordDocument : IDocument
  {
    public void Open()
    {
      Console.WriteLine("Opening Word document");
    }

    public void Save()
    {
      Console.WriteLine("Saving Word document");
    }
  }

  public class PdfDocument : IDocument
  {
    public void Open()
    {
      Console.WriteLine("Opening PDF document");
    }

    public void Save()
    {
      Console.WriteLine("Saving PDF document");
    }
  }

  public class ExcelDocument : IDocument
  {
    public void Open()
    {
      Console.WriteLine("Opening Excel document");
    }

    public void Save()
    {
      Console.WriteLine("Saving Excel document");
    }
  }

  public abstract class DocumentFactory
  {
    public abstract IDocument CreateDocument();

    public void ProcessDocument()
    {
      var doc = CreateDocument();
      doc.Open();
      doc.Save();
    }
  }

  public class WordDocumentFactory : DocumentFactory
  {
    public override IDocument CreateDocument()
    {
      return new WordDocument();
    }
  }

  public class PdfDocumentFactory : DocumentFactory
  {
    public override IDocument CreateDocument()
    {
      return new PdfDocument();
    }
  }

  public class ExcelDocumentFactory : DocumentFactory
  {
    public override IDocument CreateDocument()
    {
      return new ExcelDocument();
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Creating Word document:");
      DocumentFactory wordFactory = new WordDocumentFactory();
      wordFactory.ProcessDocument();

      Console.WriteLine("\nCreating PDF document:");
      DocumentFactory pdfFactory = new PdfDocumentFactory();
      pdfFactory.ProcessDocument();

      Console.WriteLine("\nCreating Excel document:");
      DocumentFactory excelFactory = new ExcelDocumentFactory();
      excelFactory.ProcessDocument();
    }
  }
}