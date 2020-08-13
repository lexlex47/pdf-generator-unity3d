using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

struct Company
{
    public string m_company;
    public string m_abn;
    public string m_bsb;
    public string m_accountNo;
    public string m_accountName;
    public string m_people;
    public string m_address1;
    public string m_address2;
    public string m_website;
    public string m_phone;
    public string m_email;
    public string m_logourl;
}

public class main : MonoBehaviour {

    public Button SubmitButton;
    public Text label;
    public Text label2;
    string fileName;

    public Dropdown logo;
    public GameObject logo_label;
    public Dropdown status;

    public InputField no_text;
    public InputField date;
    public InputField due_date;

    public InputField to_company;
    public InputField to_people;
    public InputField to_address1;
    public InputField to_address2;

    public InputField des_1;
    public InputField price_1;
    public InputField des_2;
    public InputField price_2;
    public InputField des_3;
    public InputField price_3;
    public InputField des_4;
    public InputField price_4;
    public InputField des_5;
    public InputField price_5;

    public InputField subtotal;
    public InputField gst;
    public InputField credit;
    public InputField discount;
    public InputField total;
    public InputField other;

    public InputField transdate;
    public InputField transway;
    public InputField transid;
    public InputField transtotal;
    public InputField transbalance;

    //公司
    Company []m_company = new Company[2];
    //状态
    string[] m_status = new string[3];
    //装载信息
    public void SetCompanyDetials()
    {
        //状态
        m_status[0] = "QUOTE.png";
        m_status[1] = "UNPAID.png";
        m_status[2] = "PAID.png";

        //smartidea
        m_company[0].m_company = "SMART IDEA GROUP PTY LTD";
        m_company[0].m_abn = "531 6651 4576";
        m_company[0].m_bsb = "083-961";
        m_company[0].m_accountNo = "3956 33979";
        m_company[0].m_accountName = "SMART IDEA";
        m_company[0].m_people = "SMART IDEA";
        m_company[0].m_address1 = "Unit 2/34 Efficient Drive";
        m_company[0].m_address2 = "Truganina VIC 3029 Australia";
        m_company[0].m_website = "smartidea.net.au";
        m_company[0].m_email = "sales@smartidea.net.au";
        m_company[0].m_phone = "+61 (0)3 8353 2760";
        m_company[0].m_logourl = "sm_logo.png";

        //baoguo
        m_company[1].m_company = "BAOGUO PTY LTD";
        m_company[1].m_abn = "531 6651 4576";
        m_company[1].m_bsb = "083-961";
        m_company[1].m_accountNo = "3956 33979";
        m_company[1].m_accountName = "SMART IDEA";
        m_company[1].m_people = "SMART IDEA";
        m_company[1].m_address1 = "Unit 2/34 Efficient Drive";
        m_company[1].m_address2 = "Truganina VIC 3029 Australia";
        m_company[1].m_website = "baoguo.com.au";
        m_company[1].m_email = "sales@smartidea.net.au";
        m_company[1].m_phone = "+61 (0)3 8353 2760";
        m_company[1].m_logourl = "baoguo_Logo.png";
    }

    public void Click()
    {
        try
        {
            //实用TTF字体
            BaseFont bold_text = BaseFont.CreateFont("C:/Windows/Fonts/Bahnschrift.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            //创建PDF文档
            Document doc = new Document(PageSize.LETTER, 10, 10, 30, 5);
            //创建写入实例，PDF文档保存位置
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(fileName, FileMode.Create));
            //打开文档
            doc.Open();
            //创建摘要
            doc.AddTitle("");
            doc.AddAuthor("Smartidea");
            doc.AddSubject("Smartidea PDF");
            doc.AddCreator("Smartidea PDF");
            //创建字体
            iTextSharp.text.Font bold_18 = new iTextSharp.text.Font(bold_text, 15, 1);
            iTextSharp.text.Font simple_12 = new iTextSharp.text.Font(bold_text, 10);
            iTextSharp.text.Font bold_12 = new iTextSharp.text.Font(bold_text, 10, 1);

            //开始写PDF
            WritePdf(doc, logo.value, status.value, bold_18, simple_12, bold_12);

            //关闭文档
            doc.Close();
            //打开pdf文件
            System.Diagnostics.Process.Start(fileName);
        }
        catch (Exception e)
        {
            label2.text = e.Message;
        }
    }

    //空行
    public void AddBlank(Document doc)
    {
        Paragraph blank = new Paragraph(" ");
        doc.Add(blank);
    }

    //写PDF
    public void WritePdf(Document doc, int logonum, int statusnum, iTextSharp.text.Font bold_18, iTextSharp.text.Font simple_12, iTextSharp.text.Font bold_12)
    {
        //logo图片
        iTextSharp.text.Image IMG = iTextSharp.text.Image.GetInstance(System.Environment.CurrentDirectory + @"\Assets\Pic\" + m_company[logonum].m_logourl);
        doc.Add(IMG);

        //状态图片
        iTextSharp.text.Image IMG2 = iTextSharp.text.Image.GetInstance(System.Environment.CurrentDirectory + @"\Assets\Pic\" + m_status[statusnum]);
        IMG2.ScalePercent(20f);
        IMG2.SetAbsolutePosition(doc.PageSize.Width - 200f, doc.PageSize.Height - 200f);
        doc.Add(IMG2);

        //公司信息
        Paragraph company_details = new Paragraph(m_company[logonum].m_company + "\n" +
                                                  m_company[logonum].m_email + "\n" +
                                                  m_company[logonum].m_phone + "\n" +
                                                  m_company[logonum].m_website + "\n" +
                                                  "------------------------------------" + "\n" +
                                                  "ABN : " + m_company[logonum].m_abn + "\n" +
                                                  "BSB : " + m_company[logonum].m_bsb + "\n" +
                                                  "Account No : " + m_company[logonum].m_accountNo + "\n" +
                                                  "Account Name : " + m_company[logonum].m_accountName + "\n"
                                                  , simple_12);
        company_details.Alignment = iTextSharp.text.Element.ALIGN_RIGHT;
        doc.Add(company_details);
        AddBlank(doc);

        //账单基本信息
        PdfPTable T1 = new PdfPTable(1);

        PdfPCell invoce1 = new PdfPCell(new Phrase("Invoice # " + no_text.text, bold_18));
        invoce1.HorizontalAlignment = 0;
        invoce1.Border = 0;
        invoce1.PaddingBottom = 5f;
        invoce1.BackgroundColor = new iTextSharp.text.BaseColor(233, 233, 233);
        T1.AddCell(invoce1);

        PdfPCell invoce2 = new PdfPCell(new Phrase("Invoice Date : " + date.text, simple_12));
        invoce2.HorizontalAlignment = 0;
        invoce2.Border = 0;
        invoce2.PaddingBottom = 5f;
        invoce2.BackgroundColor = new iTextSharp.text.BaseColor(233, 233, 233);
        T1.AddCell(invoce2);

        PdfPCell invoce3 = new PdfPCell(new Phrase("Due Date : " + due_date.text, simple_12));
        invoce3.HorizontalAlignment = 0;
        invoce3.Border = 0;
        invoce3.PaddingBottom = 5f;
        invoce3.BackgroundColor = new iTextSharp.text.BaseColor(233, 233, 233);
        T1.AddCell(invoce3);

        doc.Add(T1);
        AddBlank(doc);

        //账单人信息
        PdfPTable T2 = new PdfPTable(1);

        PdfPCell details1 = new PdfPCell(new Phrase("Invoiced To : ", bold_18));
        details1.HorizontalAlignment = 0;
        details1.Border = 0;
        details1.PaddingBottom = 3f;
        T2.AddCell(details1);

        PdfPCell details2 = new PdfPCell(new Phrase(to_company.text, simple_12));
        details2.HorizontalAlignment = 0;
        details2.Border = 0;
        details2.PaddingBottom = 3f;
        T2.AddCell(details2);

        PdfPCell details3 = new PdfPCell(new Phrase("ATTN : " + to_people.text, simple_12));
        details3.HorizontalAlignment = 0;
        details3.Border = 0;
        details3.PaddingBottom = 3f;
        T2.AddCell(details3);

        PdfPCell details4 = new PdfPCell(new Phrase(to_address1.text, simple_12));
        details4.HorizontalAlignment = 0;
        details4.Border = 0;
        details4.PaddingBottom = 3f;
        T2.AddCell(details4);

        PdfPCell details5 = new PdfPCell(new Phrase(to_address2.text, simple_12));
        details5.HorizontalAlignment = 0;
        details5.Border = 0;
        details5.PaddingBottom = 3f;
        T2.AddCell(details5);

        doc.Add(T2);
        AddBlank(doc);

        //账单明细
        PdfPTable T3 = new PdfPTable(4);
        
        PdfPCell des_title1 = new PdfPCell(new Phrase("Description", bold_18));
        des_title1.Colspan = 3;
        des_title1.HorizontalAlignment = 1;
        des_title1.PaddingBottom = 5f;
        des_title1.BackgroundColor = new iTextSharp.text.BaseColor(233, 233, 233);
        des_title1.Border = 0;
        T3.AddCell(des_title1);

        PdfPCell des_title2 = new PdfPCell(new Phrase("Total (AUD)", bold_18));
        des_title2.Colspan = 1;
        des_title2.HorizontalAlignment = 1;
        des_title2.PaddingBottom = 5f;
        des_title2.BackgroundColor = new iTextSharp.text.BaseColor(233, 233, 233);
        des_title2.Border = 0;
        T3.AddCell(des_title2);

        if(des_1.text != null)
        {
            PdfPCell des1_1 = new PdfPCell(new Phrase(des_1.text, simple_12));
            des1_1.Colspan = 3;
            des1_1.HorizontalAlignment = 0;
            des1_1.PaddingBottom = 5f;
            T3.AddCell(des1_1);

            PdfPCell des1_2 = new PdfPCell(new Phrase("$" + price_1.text, simple_12));
            des1_2.Colspan = 1;
            des1_2.HorizontalAlignment = 2;
            des1_2.PaddingBottom = 5f;
            T3.AddCell(des1_2);
        }

        if (des_2.text != null)
        {
            PdfPCell des2_1 = new PdfPCell(new Phrase(des_2.text, simple_12));
            des2_1.Colspan = 3;
            des2_1.HorizontalAlignment = 0;
            des2_1.PaddingBottom = 5f;
            T3.AddCell(des2_1);

            PdfPCell des2_2 = new PdfPCell(new Phrase("$" + price_2.text, simple_12));
            des2_2.Colspan = 1;
            des2_2.HorizontalAlignment = 2;
            des2_2.PaddingBottom = 5f;
            T3.AddCell(des2_2);
        }

        if (des_3.text != null)
        {
            PdfPCell des3_1 = new PdfPCell(new Phrase(des_3.text, simple_12));
            des3_1.Colspan = 3;
            des3_1.HorizontalAlignment = 0;
            des3_1.PaddingBottom = 5f;
            T3.AddCell(des3_1);

            PdfPCell des3_2 = new PdfPCell(new Phrase("$" + price_3.text, simple_12));
            des3_2.Colspan = 1;
            des3_2.HorizontalAlignment = 2;
            des3_2.PaddingBottom = 5f;
            T3.AddCell(des3_2);
        }

        if (des_4.text != null)
        {
            PdfPCell des4_1 = new PdfPCell(new Phrase(des_4.text, simple_12));
            des4_1.Colspan = 3;
            des4_1.HorizontalAlignment = 0;
            des4_1.PaddingBottom = 5f;
            T3.AddCell(des4_1);

            PdfPCell des4_2 = new PdfPCell(new Phrase("$" + price_4.text, simple_12));
            des4_2.Colspan = 1;
            des4_2.HorizontalAlignment = 2;
            des4_2.PaddingBottom = 5f;
            T3.AddCell(des4_2);
        }

        if (des_5.text != null)
        {
            PdfPCell des5_1 = new PdfPCell(new Phrase(des_5.text, simple_12));
            des5_1.Colspan = 3;
            des5_1.HorizontalAlignment = 0;
            des5_1.PaddingBottom = 5f;
            T3.AddCell(des5_1);

            PdfPCell des5_2 = new PdfPCell(new Phrase("$" + price_5.text, simple_12));
            des5_2.Colspan = 1;
            des5_2.HorizontalAlignment = 2;
            des5_2.PaddingBottom = 5f;
            T3.AddCell(des5_2);
        }

        PdfPCell total1_1 = new PdfPCell(new Phrase("Sub Total ", bold_12));
        total1_1.Colspan = 3;
        total1_1.HorizontalAlignment = 2;
        total1_1.PaddingBottom = 5f;
        total1_1.Border = 0;
        total1_1.BackgroundColor = new iTextSharp.text.BaseColor(233, 233, 233);
        T3.AddCell(total1_1);

        PdfPCell total1_2 = new PdfPCell(new Phrase("$" + subtotal.text, bold_12));
        total1_2.Colspan = 1;
        total1_2.HorizontalAlignment = 1;
        total1_2.PaddingBottom = 5f;
        total1_2.Border = 0;
        total1_2.BackgroundColor = new iTextSharp.text.BaseColor(233, 233, 233);
        T3.AddCell(total1_2);

        PdfPCell total2_1 = new PdfPCell(new Phrase("GST(10%) ", bold_12));
        total2_1.Colspan = 3;
        total2_1.HorizontalAlignment = 2;
        total2_1.PaddingBottom = 5f;
        total2_1.Border = 0;
        total2_1.BackgroundColor = new iTextSharp.text.BaseColor(233, 233, 233);
        T3.AddCell(total2_1);

        PdfPCell total2_2 = new PdfPCell(new Phrase("$" + gst.text, bold_12));
        total2_2.Colspan = 1;
        total2_2.HorizontalAlignment = 1;
        total2_2.PaddingBottom = 5f;
        total2_2.Border = 0;
        total2_2.BackgroundColor = new iTextSharp.text.BaseColor(233, 233, 233);
        T3.AddCell(total2_2);

        PdfPCell total3_1 = new PdfPCell(new Phrase("Credit ", bold_12));
        total3_1.Colspan = 3;
        total3_1.HorizontalAlignment = 2;
        total3_1.PaddingBottom = 5f;
        total3_1.Border = 0;
        total3_1.BackgroundColor = new iTextSharp.text.BaseColor(233, 233, 233);
        T3.AddCell(total3_1);

        PdfPCell total3_2 = new PdfPCell(new Phrase("$" + credit.text, bold_12));
        total3_2.Colspan = 1;
        total3_2.HorizontalAlignment = 1;
        total3_2.PaddingBottom = 5f;
        total3_2.Border = 0;
        total3_2.BackgroundColor = new iTextSharp.text.BaseColor(233, 233, 233);
        T3.AddCell(total3_2);

        PdfPCell total4_1 = new PdfPCell(new Phrase("Discount ", bold_12));
        total4_1.Colspan = 3;
        total4_1.HorizontalAlignment = 2;
        total4_1.PaddingBottom = 5f;
        total4_1.Border = 0;
        total4_1.BackgroundColor = new iTextSharp.text.BaseColor(233, 233, 233);
        T3.AddCell(total4_1);

        PdfPCell total4_2 = new PdfPCell(new Phrase("$" + discount.text, bold_12));
        total4_2.Colspan = 1;
        total4_2.HorizontalAlignment = 1;
        total4_2.PaddingBottom = 5f;
        total4_2.Border = 0;
        total4_2.BackgroundColor = new iTextSharp.text.BaseColor(233, 233, 233);
        T3.AddCell(total4_2);

        PdfPCell total5_1 = new PdfPCell(new Phrase("Total ", bold_12));
        total5_1.Colspan = 3;
        total5_1.HorizontalAlignment = 2;
        total5_1.PaddingBottom = 5f;
        total5_1.Border = 0;
        total5_1.BackgroundColor = new iTextSharp.text.BaseColor(233, 233, 233);
        T3.AddCell(total5_1);

        PdfPCell total5_2 = new PdfPCell(new Phrase("$" + total.text, bold_12));
        total5_2.Colspan = 1;
        total5_2.HorizontalAlignment = 1;
        total5_2.PaddingBottom = 5f;
        total5_2.Border = 0;
        total5_2.BackgroundColor = new iTextSharp.text.BaseColor(233, 233, 233);
        T3.AddCell(total5_2);

        doc.Add(T3);
        AddBlank(doc);

        //转账信息
        PdfPTable T4 = new PdfPTable(4);

        PdfPCell trans_title = new PdfPCell(new Phrase("Transactions", bold_18));
        trans_title.Colspan = 4;
        trans_title.HorizontalAlignment = 0;
        trans_title.Border = 0;
        trans_title.PaddingBottom = 10f;
        T4.AddCell(trans_title);

        PdfPCell trans1_1 = new PdfPCell(new Phrase("Transaction Date", bold_12));
        trans1_1.HorizontalAlignment = 1;
        trans1_1.PaddingBottom = 5f;
        trans1_1.Border = 0;
        trans1_1.BackgroundColor = new iTextSharp.text.BaseColor(233, 233, 233);
        T4.AddCell(trans1_1);

        PdfPCell trans1_2 = new PdfPCell(new Phrase("Gateway", bold_12));
        trans1_2.HorizontalAlignment = 1;
        trans1_2.PaddingBottom = 5f;
        trans1_2.Border = 0;
        trans1_2.BackgroundColor = new iTextSharp.text.BaseColor(233, 233, 233);
        T4.AddCell(trans1_2);

        PdfPCell trans1_3 = new PdfPCell(new Phrase("Transaction ID", bold_12));
        trans1_3.HorizontalAlignment = 1;
        trans1_3.PaddingBottom = 5f;
        trans1_3.Border = 0;
        trans1_3.BackgroundColor = new iTextSharp.text.BaseColor(233, 233, 233);
        T4.AddCell(trans1_3);

        PdfPCell trans1_4 = new PdfPCell(new Phrase("Amount (AUD)", bold_12));
        trans1_4.HorizontalAlignment = 1;
        trans1_4.PaddingBottom = 5f;
        trans1_4.Border = 0;
        trans1_4.BackgroundColor = new iTextSharp.text.BaseColor(233, 233, 233);
        T4.AddCell(trans1_4);

        PdfPCell trans2_1 = new PdfPCell(new Phrase(transdate.text, simple_12));
        trans2_1.HorizontalAlignment = 1;
        trans2_1.PaddingBottom = 5f;
        T4.AddCell(trans2_1);

        PdfPCell trans2_2 = new PdfPCell(new Phrase(transway.text, simple_12));
        trans2_2.HorizontalAlignment = 1;
        trans2_2.PaddingBottom = 5f;
        T4.AddCell(trans2_2);

        PdfPCell trans2_3 = new PdfPCell(new Phrase(transid.text, simple_12));
        trans2_3.HorizontalAlignment = 1;
        trans2_3.PaddingBottom = 5f;
        T4.AddCell(trans2_3);

        PdfPCell trans2_4 = new PdfPCell(new Phrase("$" + transtotal.text, simple_12));
        trans2_4.HorizontalAlignment = 1;
        trans2_4.PaddingBottom = 5f;
        T4.AddCell(trans2_4);

        PdfPCell trans3_1 = new PdfPCell(new Phrase("Balance ", bold_12));
        trans3_1.Colspan = 3;
        trans3_1.HorizontalAlignment = 2;
        trans3_1.PaddingBottom = 5f;
        trans3_1.Border = 0;
        trans3_1.BackgroundColor = new iTextSharp.text.BaseColor(233, 233, 233);
        T4.AddCell(trans3_1);

        PdfPCell trans3_2 = new PdfPCell(new Phrase("$" + transbalance.text, bold_12));
        trans3_2.HorizontalAlignment = 1;
        trans3_2.PaddingBottom = 5f;
        trans3_2.Border = 0;
        trans3_2.BackgroundColor = new iTextSharp.text.BaseColor(233, 233, 233);
        T4.AddCell(trans3_2);

        doc.Add(T4);
        AddBlank(doc);

        //备注
        PdfPTable T5 = new PdfPTable(1);

        PdfPCell notes_title = new PdfPCell(new Phrase("Notes", bold_18));
        notes_title.HorizontalAlignment = 0;
        notes_title.Border = 0;
        notes_title.PaddingBottom = 10f;
        T5.AddCell(notes_title);

        PdfPCell notes1 = new PdfPCell(new Phrase(other.text, simple_12));
        notes1.HorizontalAlignment = 0;
        notes1.PaddingBottom = 5f;
        T5.AddCell(notes1);

        doc.Add(T5);
    }

    // Use this for initialization
    void Start () {

        //装载数据
        SetCompanyDetials();

        string pdfPath = System.Environment.CurrentDirectory + @"\PDF";

        //显示保存文件位置
        label.text = pdfPath;
        //文件名为当前时间，精确到秒，确保不重名
        DateTime dt = DateTime.Now;
        fileName = " Invoiced " + "-" + dt.Year + "-" + dt.Month + "-" + dt.Day + "-" + dt.Hour + dt.Minute + dt.Second + ".pdf";

        SubmitButton.onClick.AddListener(Click);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
