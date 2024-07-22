using Aspose.Pdf;
using Aspose.Pdf.Text;

class Program
{
    static void Main()
    {
        // Define the path to the input and output PDF files
        string dataDir = @"C:\Users\Anthony\OneDrive\Bureau\Recherche d'alternance\YRLES_Anthony_CV.pdf";
        string outputDir = @"C:\Users\Anthony\OneDrive\Bureau\Recherche d'alternance\New_YRLES_Anthony_CV.pdf";
        
        try
        {
            // Open the PDF document
            Document pdfDocument = new Document(dataDir);
            
            // Decrypt the PDF document if it is protected by a password
            pdfDocument.Decrypt();

            // Modify the text content of the PDF
            pdfDocument = AbsorbAndModifyText(pdfDocument);

            // Save the updated PDF document
            pdfDocument.Save(outputDir);

            Console.WriteLine("PDF decrypted and modified successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }

    static Document AbsorbAndModifyText(Document pdfDocument) {
        Page page = pdfDocument.Pages[1];
        
        // Create a TextFragmentAbsorber to extract all text fragments
        TextFragmentAbsorber textFragmentAbsorber = new TextFragmentAbsorber();
        page.Accept(textFragmentAbsorber);
        TextFragmentCollection textFragmentCollection = textFragmentAbsorber.TextFragments;

        // Iterate through each text fragment and modify its content
        foreach (TextFragment textFragment in textFragmentCollection)
        {
            textFragment.Text = HashText(textFragment.Text);
        }

        return pdfDocument;
    }

    static string HashText(string text) {
        // Hash the text content
        return text.GetHashCode().ToString();
    }
}
