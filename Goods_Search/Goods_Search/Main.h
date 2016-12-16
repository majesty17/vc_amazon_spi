#pragma once



namespace Goods_Search {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	using namespace System::IO;
	using namespace System::Threading;


using namespace HtmlAgilityPack;
	/// <summary>
	/// Form1 ժҪ
	///
	/// ����: ������Ĵ�������ƣ�����Ҫ����
	///          ����������������� .resx �ļ��������й���Դ���������ߵ�
	///          ����Դ�ļ��������ԡ�����
	///          �������������˴���Ĺ���
	///          ���ػ���Դ��ȷ������
	/// </summary>
	public ref class Form1 : public System::Windows::Forms::Form
	{
	public:
		Form1(void)
		{
			InitializeComponent();
			//
			//TODO: �ڴ˴���ӹ��캯������
			//
		}

	protected:
		/// <summary>
		/// ������������ʹ�õ���Դ��
		/// </summary>
		~Form1()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::MenuStrip^  menuStrip1;
	protected:
	private: System::Windows::Forms::ToolStripMenuItem^  �ļ�ToolStripMenuItem;

	private: System::Windows::Forms::ToolStripMenuItem^  ����ToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  ����ToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  �˳�ToolStripMenuItem;
	private: System::Windows::Forms::ListView^  listView_main;

	private: System::Windows::Forms::TextBox^  textBox_kword;
	private: System::Windows::Forms::Button^  button_search;
	private: System::Windows::Forms::ColumnHeader^  columnHeader1;
	private: System::Windows::Forms::ColumnHeader^  columnHeader2;
	private: System::Windows::Forms::ColumnHeader^  columnHeader3;
	private: System::Windows::Forms::Label^  label_total;

	private: System::Windows::Forms::ColumnHeader^  columnHeader4;
	private: System::Windows::Forms::ToolStripMenuItem^  ����ToolStripMenuItem;
	private: System::Windows::Forms::StatusStrip^  statusStrip1;
	private: System::Windows::Forms::ToolStripStatusLabel^  toolStripStatusLabel1;






	private:
		/// <summary>
		/// ����������������
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// �����֧������ķ��� - ��Ҫ
		/// ʹ�ô���༭���޸Ĵ˷��������ݡ�
		/// </summary>
		void InitializeComponent(void)
		{
		this->menuStrip1 = (gcnew System::Windows::Forms::MenuStrip());
		this->�ļ�ToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
		this->����ToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
		this->�˳�ToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
		this->����ToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
		this->����ToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
		this->listView_main = (gcnew System::Windows::Forms::ListView());
		this->columnHeader1 = (gcnew System::Windows::Forms::ColumnHeader());
		this->columnHeader2 = (gcnew System::Windows::Forms::ColumnHeader());
		this->columnHeader3 = (gcnew System::Windows::Forms::ColumnHeader());
		this->columnHeader4 = (gcnew System::Windows::Forms::ColumnHeader());
		this->textBox_kword = (gcnew System::Windows::Forms::TextBox());
		this->button_search = (gcnew System::Windows::Forms::Button());
		this->label_total = (gcnew System::Windows::Forms::Label());
		this->statusStrip1 = (gcnew System::Windows::Forms::StatusStrip());
		this->toolStripStatusLabel1 = (gcnew System::Windows::Forms::ToolStripStatusLabel());
		this->menuStrip1->SuspendLayout();
		this->statusStrip1->SuspendLayout();
		this->SuspendLayout();
		// 
		// menuStrip1
		// 
		this->menuStrip1->Items->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(2) {this->�ļ�ToolStripMenuItem, 
			this->����ToolStripMenuItem});
		this->menuStrip1->Location = System::Drawing::Point(0, 0);
		this->menuStrip1->Name = L"menuStrip1";
		this->menuStrip1->Size = System::Drawing::Size(767, 24);
		this->menuStrip1->TabIndex = 0;
		this->menuStrip1->Text = L"menuStrip1";
		// 
		// �ļ�ToolStripMenuItem
		// 
		this->�ļ�ToolStripMenuItem->DropDownItems->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(2) {this->����ToolStripMenuItem, 
			this->�˳�ToolStripMenuItem});
		this->�ļ�ToolStripMenuItem->Name = L"�ļ�ToolStripMenuItem";
		this->�ļ�ToolStripMenuItem->Size = System::Drawing::Size(43, 20);
		this->�ļ�ToolStripMenuItem->Text = L"�ļ�";
		// 
		// ����ToolStripMenuItem
		// 
		this->����ToolStripMenuItem->Name = L"����ToolStripMenuItem";
		this->����ToolStripMenuItem->Size = System::Drawing::Size(107, 22);
		this->����ToolStripMenuItem->Text = L"����...";
		this->����ToolStripMenuItem->Click += gcnew System::EventHandler(this, &Form1::����ToolStripMenuItem_Click);
		// 
		// �˳�ToolStripMenuItem
		// 
		this->�˳�ToolStripMenuItem->Name = L"�˳�ToolStripMenuItem";
		this->�˳�ToolStripMenuItem->Size = System::Drawing::Size(107, 22);
		this->�˳�ToolStripMenuItem->Text = L"�˳�";
		// 
		// ����ToolStripMenuItem
		// 
		this->����ToolStripMenuItem->DropDownItems->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(1) {this->����ToolStripMenuItem});
		this->����ToolStripMenuItem->Name = L"����ToolStripMenuItem";
		this->����ToolStripMenuItem->Size = System::Drawing::Size(43, 20);
		this->����ToolStripMenuItem->Text = L"����";
		// 
		// ����ToolStripMenuItem
		// 
		this->����ToolStripMenuItem->Name = L"����ToolStripMenuItem";
		this->����ToolStripMenuItem->Size = System::Drawing::Size(107, 22);
		this->����ToolStripMenuItem->Text = L"����...";
		// 
		// listView_main
		// 
		this->listView_main->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom) 
			| System::Windows::Forms::AnchorStyles::Left) 
			| System::Windows::Forms::AnchorStyles::Right));
		this->listView_main->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
		this->listView_main->Columns->AddRange(gcnew cli::array< System::Windows::Forms::ColumnHeader^  >(4) {this->columnHeader1, 
			this->columnHeader2, this->columnHeader3, this->columnHeader4});
		this->listView_main->FullRowSelect = true;
		this->listView_main->GridLines = true;
		this->listView_main->Location = System::Drawing::Point(0, 56);
		this->listView_main->Name = L"listView_main";
		this->listView_main->Size = System::Drawing::Size(767, 359);
		this->listView_main->TabIndex = 1;
		this->listView_main->UseCompatibleStateImageBehavior = false;
		this->listView_main->View = System::Windows::Forms::View::Details;
		// 
		// columnHeader1
		// 
		this->columnHeader1->Text = L"Name";
		this->columnHeader1->Width = 565;
		// 
		// columnHeader2
		// 
		this->columnHeader2->Text = L"Price";
		this->columnHeader2->Width = 80;
		// 
		// columnHeader3
		// 
		this->columnHeader3->Text = L"Orders";
		this->columnHeader3->Width = 101;
		// 
		// columnHeader4
		// 
		this->columnHeader4->Text = L"Seller";
		// 
		// textBox_kword
		// 
		this->textBox_kword->Location = System::Drawing::Point(13, 29);
		this->textBox_kword->Name = L"textBox_kword";
		this->textBox_kword->Size = System::Drawing::Size(549, 21);
		this->textBox_kword->TabIndex = 2;
		this->textBox_kword->Text = L"http://www.aliexpress.com/category/200000139/earrings/2.html";
		// 
		// button_search
		// 
		this->button_search->FlatStyle = System::Windows::Forms::FlatStyle::Popup;
		this->button_search->Location = System::Drawing::Point(568, 29);
		this->button_search->Name = L"button_search";
		this->button_search->Size = System::Drawing::Size(75, 21);
		this->button_search->TabIndex = 3;
		this->button_search->Text = L"����";
		this->button_search->UseVisualStyleBackColor = true;
		this->button_search->Click += gcnew System::EventHandler(this, &Form1::button_search_Click);
		// 
		// label_total
		// 
		this->label_total->AutoSize = true;
		this->label_total->Location = System::Drawing::Point(678, 38);
		this->label_total->Name = L"label_total";
		this->label_total->Size = System::Drawing::Size(89, 12);
		this->label_total->TabIndex = 4;
		this->label_total->Text = L"0 items found!";
		// 
		// statusStrip1
		// 
		this->statusStrip1->Items->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(1) {this->toolStripStatusLabel1});
		this->statusStrip1->Location = System::Drawing::Point(0, 418);
		this->statusStrip1->Name = L"statusStrip1";
		this->statusStrip1->Size = System::Drawing::Size(767, 22);
		this->statusStrip1->TabIndex = 5;
		this->statusStrip1->Text = L"statusStrip1";
		// 
		// toolStripStatusLabel1
		// 
		this->toolStripStatusLabel1->Name = L"toolStripStatusLabel1";
		this->toolStripStatusLabel1->Size = System::Drawing::Size(223, 17);
		this->toolStripStatusLabel1->Text = L"�ҵ�Լ 1,280,000 ����� ����ʱ 0.27 �룩";
		// 
		// Form1
		// 
		this->AutoScaleDimensions = System::Drawing::SizeF(6, 12);
		this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
		this->ClientSize = System::Drawing::Size(767, 440);
		this->Controls->Add(this->statusStrip1);
		this->Controls->Add(this->label_total);
		this->Controls->Add(this->button_search);
		this->Controls->Add(this->textBox_kword);
		this->Controls->Add(this->menuStrip1);
		this->Controls->Add(this->listView_main);
		this->MainMenuStrip = this->menuStrip1;
		this->Name = L"Form1";
		this->Text = L"��Ʒ����";
		this->menuStrip1->ResumeLayout(false);
		this->menuStrip1->PerformLayout();
		this->statusStrip1->ResumeLayout(false);
		this->statusStrip1->PerformLayout();
		this->ResumeLayout(false);
		this->PerformLayout();

			}
#pragma endregion


//������
private: System::Void button_search_Click(System::Object^  sender, System::EventArgs^  e) {
	listView_main->Items->Clear();
	String^ next=addHtmlToList(textBox_kword->Text);
	int count=2;
	while(next!="" && count--){
		next=addHtmlToList(next);
	}

	/*
	array<Thread^>^ pth=gcnew array<Thread^>(4);
	for(int i=0;i<4;i++){
		pth[i]=gcnew Thread(gcnew ParameterizedThreadStart(&Goods_Search::Form1::addHtmlToListVoid));
		pth[i]->Start("http://www.aliexpress.com/category/200000139/earrings/"+(i+1)+".html");
	}*/




}

//ץȡҳ�沢����listview
private: String^ addHtmlToList(String^ html){
	//MessageBox::Show(html);
	HtmlAgilityPack::HtmlWeb ^htmlweb=gcnew HtmlAgilityPack::HtmlWeb();
	HtmlAgilityPack::HtmlDocument ^doc=gcnew HtmlAgilityPack::HtmlDocument();


	doc=htmlweb->Load(html);
	if(!doc){
		MessageBox::Show("url error!");
		return "";
	}
	HtmlAgilityPack::HtmlNode^ allnode=doc->DocumentNode;

	while(1){
		HtmlAgilityPack::HtmlNode ^anode=allnode->SelectSingleNode("//li[@qrdata]");
		if(!anode)
			break;
		String ^data_order=anode->SelectSingleNode("//em[@title='Total Orders']")->InnerText;
		String ^data_name=anode->SelectSingleNode("//a[@class='product ']")->InnerText;
		String ^data_price=anode->SelectSingleNode("//span[@itemprop='price']")->InnerText;
		String ^data_seller=anode->SelectSingleNode("//a[@class='store']")->GetAttributeValue("title","");


		ListViewItem ^lvi=gcnew ListViewItem(data_name);
		lvi->SubItems->Add(data_price);
		lvi->SubItems->Add(data_order);
		lvi->SubItems->Add(data_seller);
		listView_main->Items->Add(lvi);

		anode->Remove();

	}
	String^ next=allnode->SelectSingleNode("//a[@class='page-next ui-pagination-next']")->GetAttributeValue("href","");
	return next;
}
//���߳�ץȡ�ص�����
private: static System::Void addHtmlToListVoid(System::Object^ html){
	//MessageBox::Show(html);
	HtmlAgilityPack::HtmlWeb ^htmlweb=gcnew HtmlAgilityPack::HtmlWeb();
	HtmlAgilityPack::HtmlDocument ^doc=gcnew HtmlAgilityPack::HtmlDocument();


	doc=htmlweb->Load((String^)html);
	if(!doc){
		MessageBox::Show("url error!");
	}
	HtmlAgilityPack::HtmlNode^ allnode=doc->DocumentNode;

	while(1){
		HtmlAgilityPack::HtmlNode ^anode=allnode->SelectSingleNode("//li[@qrdata]");
		if(!anode)
			break;
		String ^data_order=anode->SelectSingleNode("//em[@title='Total Orders']")->InnerText;
		String ^data_name=anode->SelectSingleNode("//a[@class='product ']")->InnerText;
		String ^data_price=anode->SelectSingleNode("//span[@itemprop='price']")->InnerText;
		String ^data_seller=anode->SelectSingleNode("//a[@class='store']")->GetAttributeValue("title","");


		ListViewItem ^lvi=gcnew ListViewItem(data_name);
		lvi->SubItems->Add(data_price);
		lvi->SubItems->Add(data_order);
		lvi->SubItems->Add(data_seller);
		listView_main->Items->Add(lvi);

		anode->Remove();

	}
	label_total->Text=""+listView_main->Items->Count+" items found!";
}
//����Ϊexcel
private: System::Void ����ToolStripMenuItem_Click(System::Object^  sender, System::EventArgs^  e) {

	int count=listView_main->Items->Count;
	if(count==0){
		MessageBox::Show("�б�Ϊ�գ�");
		return;
	}


	System::Windows::Forms::SaveFileDialog^ sfd=gcnew SaveFileDialog();
	sfd->Filter="TSV�ļ�|*.tsv";

	sfd->RestoreDirectory=true;
	if(sfd->ShowDialog()==System::Windows::Forms::DialogResult::OK){
		String^ fName=sfd->FileName;
		FileStream^ fs = gcnew FileStream(fName,FileMode::CreateNew);
		StreamWriter^ sw=gcnew StreamWriter(fs);

		sw->Write("Name\tPrice\tOrders\tSeller\n");
		for(int i=0;i<count;i++){
			ListViewItem::ListViewSubItemCollection^ item=listView_main->Items[i]->SubItems;
			sw->Write( item[0]->Text+"\t");
			sw->Write( item[1]->Text+"\t");
			sw->Write( item[2]->Text+"\t");
			sw->Write( item[3]->Text+"\n");
		}

		sw->Close();
		fs->Close();

	}

}



};
}

