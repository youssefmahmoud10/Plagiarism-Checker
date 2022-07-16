using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using F23.StringSimilarity;
using HtmlAgilityPack;

namespace CopyCheck_v2
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void CheckButton_Click(object sender, EventArgs e)
        {
            List<DocumentClass> docList = Upload_files();
            string first_input = Receive_input();

            if (first_input == "") 
            {
                return;
            }

            //calculate Jaccard Similarity of Files Uploaded and get the maximum value(MOST SIMILAR)
            if (docList != null) 
            {
                Calc_jaccard(docList, first_input);
                var max_jacc_index = docList.Max(x => x.getJacc_index());
                var max_jacc_index_percentage = max_jacc_index * 100;
                max_jacc_index_percentage = Math.Round(max_jacc_index_percentage, 2);
                Result.Text = max_jacc_index_percentage.ToString() + "%";
            }
        }
        protected void CheckButton2_Click(object sender, EventArgs e)
        {
            List<DocumentClass> docList = Upload_files();
            string first_input = Receive_input();

            if (first_input == "")
            {
                return;
            }

            //calculate Cosine Similarity of Files Uploaded and get the maximum value(MOST SIMILAR)
            if (docList != null)
            {
                Calc_cosine(docList, first_input);
                var max_cos_index = docList.Max(x => x.getCos_index());
                var max_cos_index_percentage = max_cos_index * 100;
                max_cos_index_percentage = Math.Round(max_cos_index_percentage, 2);
                Result.Text = max_cos_index_percentage.ToString() + "%";
            }
        }
        protected List<DocumentClass> Upload_files() 
        {
            //Create a new list for the uploaded documents to be compared against
            List<DocumentClass> docList = new List<DocumentClass>();

            // && RadioButtonList1.SelectedItem != null

            if (file2.PostedFile.ContentLength > 0)
            { 
                int i;
                if (RadioButtonList1.SelectedItem.Text.ToLower() == "text") 
                {
                    i = 0;
                }
                for (i = 1; i < Request.Files.Count; i++)
                {
                    HttpPostedFile uploadedFile = Request.Files[i];
                    string doc_content = new StreamReader(uploadedFile.InputStream).ReadToEnd();
                    docList.Add(new DocumentClass(i, uploadedFile.FileName, doc_content));
                }
                return docList;
            }
            return null;
        }
        protected string Receive_input() 
        {
            string first_input = "";

            if (RadioButtonList1.SelectedItem == null) 
            {
                return first_input;
            }
            else if (RadioButtonList1.SelectedItem.Text.ToLower() == "text" && !String.IsNullOrEmpty(text_source.Value))
            {
                first_input = text_source.Value;
            }
            else if (RadioButtonList1.SelectedItem.Text.ToLower() == "file" && file1.PostedFile != null)
            {
                first_input = new StreamReader(file1.PostedFile.InputStream).ReadToEnd();
            }

            return first_input;
        }
        protected void Calc_jaccard(List<DocumentClass> docList, string first_input) 
        {
            if (docList != null)
            {
                Jaccard jacc = new Jaccard();

                foreach (DocumentClass doc in docList)
                {
                    double sim = jacc.Similarity(first_input , doc.getContent());
                    doc.setJacc_index(sim);
                }
            }
        }
        protected void Calc_cosine(List<DocumentClass> docList, string first_input) 
        {
            if (docList != null)
            {
                Cosine cos = new Cosine();

                foreach (DocumentClass doc in docList)
                {
                    double sim = cos.Similarity(first_input, doc.getContent());
                    doc.setCos_index(sim);
                }
            }
        }
        
        //protected string Read_site_content()
        //{
        //    if (!String.IsNullOrEmpty(url_source.Value))
        //    {
        //        // The url you want to grab
        //        string url = url_source.Value;

        //        bool isUri = Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute);
        //        if (isUri)
        //        {
        //            // We will store the html response of the request here
        //            string siteContent = string.Empty;

        //            // Here we're creating our request, we haven't actually sent the request to the site yet...
        //            // we're simply building our HTTP request to shoot off to google...
        //            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        //            request.AutomaticDecompression = DecompressionMethods.GZip;

        //            // Wrap everything that can be disposed in using blocks... 
        //            // They dispose of objects and prevent them from lying around in memory...
        //            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())  // Go query google
        //            using (Stream responseStream = response.GetResponseStream())               // Load the response stream
        //            using (StreamReader streamReader = new StreamReader(responseStream))       // Load the stream reader to read the response
        //            {
        //                siteContent = streamReader.ReadToEnd(); // Read the entire response and store it in the siteContent variable
        //            }

        //            string siteText ="";

        //            //convert HTML to TEXT
        //            HtmlWeb web = new HtmlWeb();

        //            HtmlDocument doc = web.Load(url);
        //            //doc.LoadHtml(url);

        //            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//text()"))
        //            {
        //                siteText += node.InnerText;
        //            }

        //            //Pass the filepath and filename to the StreamWriter Constructor
        //            StreamWriter sw = new StreamWriter("F:\\Test Documents\\Test.txt");
        //            //Write a line of text
        //            sw.WriteLine(siteText);
        //            //Close the file
        //            sw.Close();

        //            return siteText;
        //        }
        //        return null;
        //        // magic...
        //    }
        //    else
        //        return null;
        //}
        //protected double Site_similarity(string siteContent, string first_input) 
        //{
        //    if (siteContent != null)
        //    {
        //        Jaccard jacc = new Jaccard();
        //        double jacc_index = jacc.Similarity(siteContent, first_input);
        //        return jacc_index;
        //    }
        //    else
        //        return -1.0f;
        //}
    }
}