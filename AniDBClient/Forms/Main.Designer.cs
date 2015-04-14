using ZedGraph;

namespace AniDBClient.Forms
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.MainTab = new System.Windows.Forms.TabControl();
            this.MainTab_IndexPage = new System.Windows.Forms.TabPage();
            this.WEB = new System.Windows.Forms.WebBrowser();
            this.MainTab_SettinsPage = new System.Windows.Forms.TabPage();
            this.Options_GR06 = new System.Windows.Forms.GroupBox();
            this.Options_LaunchWebServerOnStartupCheckBox = new System.Windows.Forms.CheckBox();
            this.Options_MpcHcPortLabel = new System.Windows.Forms.Label();
            this.Options_WebServerPortLabel = new System.Windows.Forms.Label();
            this.WebServer_MPCHC = new System.Windows.Forms.NumericUpDown();
            this.WebServer_Port = new System.Windows.Forms.NumericUpDown();
            this.Options_GR05 = new System.Windows.Forms.GroupBox();
            this.Options_CheckUnknownFilesLabel = new System.Windows.Forms.Label();
            this.Options_CheckNewMangaChaptersLabel = new System.Windows.Forms.Label();
            this.Options_DeleteDbLabel = new System.Windows.Forms.Label();
            this.Options_ForceDbUpdateLabel = new System.Windows.Forms.Label();
            this.Options_RestoreBackupLabel = new System.Windows.Forms.Label();
            this.Options_CompactAndRepairDbLabel = new System.Windows.Forms.Label();
            this.Options_CreateBackupLabel = new System.Windows.Forms.Label();
            this.Options_DeleteDuplicatesLabel = new System.Windows.Forms.Label();
            this.Options_DownloadAllFilesLabel = new System.Windows.Forms.Label();
            this.Options_DownloadAllAnimeEpisodesLabel = new System.Windows.Forms.Label();
            this.Options_GR03 = new System.Windows.Forms.GroupBox();
            this.Options_Color01 = new System.Windows.Forms.Button();
            this.Options_Color02 = new System.Windows.Forms.Button();
            this.Options_Color03 = new System.Windows.Forms.Button();
            this.Options_Color04 = new System.Windows.Forms.Button();
            this.Options_Color10 = new System.Windows.Forms.Button();
            this.Options_Color05 = new System.Windows.Forms.Button();
            this.Options_Color06 = new System.Windows.Forms.Button();
            this.Options_Color07 = new System.Windows.Forms.Button();
            this.Options_Color09 = new System.Windows.Forms.Button();
            this.Options_Color08 = new System.Windows.Forms.Button();
            this.Options_GR02 = new System.Windows.Forms.GroupBox();
            this.Options_SaveSettingsOnExitCheckBox = new System.Windows.Forms.CheckBox();
            this.Options_DetectMyListStatusCheckBox = new System.Windows.Forms.CheckBox();
            this.Options_ShowAdultOnWelcomeScreenCheckBox = new System.Windows.Forms.CheckBox();
            this.Options_MinimizeToTrayCheckBox = new System.Windows.Forms.CheckBox();
            this.Options_SaveLogsToFilesCheckBox = new System.Windows.Forms.CheckBox();
            this.Options_AddSameFilesMultipleTimesCheckBox = new System.Windows.Forms.CheckBox();
            this.Options_FlatStyleCheckBox = new System.Windows.Forms.CheckBox();
            this.Options_DontGenerateWelcomeSceenCheckBox = new System.Windows.Forms.CheckBox();
            this.Options_ClassicFolderSelectDialogCheckBox = new System.Windows.Forms.CheckBox();
            this.Watcher_List = new System.Windows.Forms.ComboBox();
            this.Options_GR01 = new System.Windows.Forms.GroupBox();
            this.Options_WatchedCheckbox = new System.Windows.Forms.CheckBox();
            this.Options_OtherLabel = new System.Windows.Forms.Label();
            this.Options_StorageLabel = new System.Windows.Forms.Label();
            this.Options_SourceLabel = new System.Windows.Forms.Label();
            this.Options_StatusLabel = new System.Windows.Forms.Label();
            this.Options_MylistOther = new System.Windows.Forms.TextBox();
            this.Options_MylistStorage = new System.Windows.Forms.TextBox();
            this.Options_AutoAddToMyListCheckBox = new System.Windows.Forms.CheckBox();
            this.Options_MylistSource = new System.Windows.Forms.TextBox();
            this.Options_MylistState = new System.Windows.Forms.ComboBox();
            this.Options_NetworkLabel = new System.Windows.Forms.Label();
            this.Watcher_CH01 = new System.Windows.Forms.CheckBox();
            this.Options_ServerLabel = new System.Windows.Forms.Label();
            this.Options_Network = new System.Windows.Forms.ComboBox();
            this.Options_Delay = new System.Windows.Forms.NumericUpDown();
            this.Options_Password = new System.Windows.Forms.TextBox();
            this.Options_Reset = new System.Windows.Forms.NumericUpDown();
            this.Options_ServerPort = new System.Windows.Forms.NumericUpDown();
            this.Options_PortLabel = new System.Windows.Forms.Label();
            this.Options_Backup = new System.Windows.Forms.NumericUpDown();
            this.Options_LocalPort = new System.Windows.Forms.NumericUpDown();
            this.Options_User = new System.Windows.Forms.TextBox();
            this.Options_UserNameLabel = new System.Windows.Forms.Label();
            this.Options_Hash_WatcherLabel = new System.Windows.Forms.Label();
            this.Options_LocalPortLabel = new System.Windows.Forms.Label();
            this.Options_PasswordLabel = new System.Windows.Forms.Label();
            this.Options_FileTypesLabel = new System.Windows.Forms.Label();
            this.Options_TimeoutLabel = new System.Windows.Forms.Label();
            this.Options_DbBackupCountLabel = new System.Windows.Forms.Label();
            this.Options_Language = new System.Windows.Forms.ComboBox();
            this.Options_TimeOut = new System.Windows.Forms.NumericUpDown();
            this.Options_DelayLabel = new System.Windows.Forms.Label();
            this.Options_ResetCountLabel = new System.Windows.Forms.Label();
            this.Options_ServerName = new System.Windows.Forms.TextBox();
            this.Options_ExtensionList = new System.Windows.Forms.ComboBox();
            this.MainTab_RulesPage = new System.Windows.Forms.TabPage();
            this.Rules_DeleteSourceIfEmptyCheckBox = new System.Windows.Forms.CheckBox();
            this.Rules_TagsButton = new System.Windows.Forms.Button();
            this.Rules_ReplaceExistingCheckBox = new System.Windows.Forms.CheckBox();
            this.Rules_DontCopyToAnotherDiskCheckBox = new System.Windows.Forms.CheckBox();
            this.Rules_AutomaticRenamingCheckBox = new System.Windows.Forms.CheckBox();
            this.Rules_RulesForCharacterReplacingGroupBox = new System.Windows.Forms.GroupBox();
            this.Rules_Replace = new System.Windows.Forms.DataGridView();
            this.Rules_Replace_Mn01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rules_Replace_Mn02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rules_ExportInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.Rules_InfoRenameDoNothingRadioButton = new System.Windows.Forms.RadioButton();
            this.Rules_InfoExportRadioButton = new System.Windows.Forms.RadioButton();
            this.Rules_InfoC = new System.Windows.Forms.ComboBox();
            this.Rules_Info = new System.Windows.Forms.TextBox();
            this.Rules_RulesForGeneratingDirectoriesGroupBox = new System.Windows.Forms.GroupBox();
            this.Rules_FilesRulesMove_RB03 = new System.Windows.Forms.RadioButton();
            this.Rules_FilesRulesMove_RB01 = new System.Windows.Forms.RadioButton();
            this.Rules_FilesRulesMove_RB02 = new System.Windows.Forms.RadioButton();
            this.Rules_FilesRulesMoveC = new System.Windows.Forms.ComboBox();
            this.Rules_FilesRulesMove = new System.Windows.Forms.TextBox();
            this.Rules_RulesForFileRenamingGroupBox = new System.Windows.Forms.GroupBox();
            this.Rules_Position = new System.Windows.Forms.ComboBox();
            this.Rules_RulesNumberPositionLabel = new System.Windows.Forms.Label();
            this.Rules_FilesRulesRename_DoNothingRadioButton = new System.Windows.Forms.RadioButton();
            this.Rules_FilesRulesRename_RenameRadioButton = new System.Windows.Forms.RadioButton();
            this.Rules_FilesRulesRenameC = new System.Windows.Forms.ComboBox();
            this.Rules_FilesRulesRename = new System.Windows.Forms.TextBox();
            this.MainTab_HashPage = new System.Windows.Forms.TabPage();
            this.Hash_GR01 = new System.Windows.Forms.GroupBox();
            this.Hash_ProgressBar_Total_Percent = new System.Windows.Forms.Label();
            this.Hash_ProgressBar_Percent = new System.Windows.Forms.Label();
            this.Hash_ProgressBar_Total = new System.Windows.Forms.ProgressBar();
            this.Hash_Nazvy_Souboru = new System.Windows.Forms.ListBox();
            this.Hash_LB03 = new System.Windows.Forms.Label();
            this.Hash_ProgressBar = new System.Windows.Forms.ProgressBar();
            this.Hash_LB02 = new System.Windows.Forms.Label();
            this.Hash_Waiting = new System.Windows.Forms.NumericUpDown();
            this.Hash_CH03 = new System.Windows.Forms.CheckBox();
            this.Hash_CH02 = new System.Windows.Forms.CheckBox();
            this.Hash_CH01 = new System.Windows.Forms.CheckBox();
            this.MainTab_AnimePage = new System.Windows.Forms.TabPage();
            this.MainTabData = new System.Windows.Forms.TabControl();
            this.MainTabData_MyListTabPage = new System.Windows.Forms.TabPage();
            this.Options_GR04 = new System.Windows.Forms.GroupBox();
            this.MyListAnime = new System.Windows.Forms.DataGridView();
            this.MainTabData_FilesTabPage = new System.Windows.Forms.TabPage();
            this.DataFilesTree_CH04 = new System.Windows.Forms.CheckBox();
            this.DataFilesTree_CH03 = new System.Windows.Forms.CheckBox();
            this.DataFilesTree_CH02 = new System.Windows.Forms.CheckBox();
            this.DataFilesTree_CH01 = new System.Windows.Forms.CheckBox();
            this.DataFiles_LB06 = new System.Windows.Forms.Label();
            this.DataFiles_LB05 = new System.Windows.Forms.Label();
            this.DataFiles_LB04 = new System.Windows.Forms.Label();
            this.DataFiles_LB03 = new System.Windows.Forms.Label();
            this.DataFiles_LB02 = new System.Windows.Forms.Label();
            this.DataFiles_LB01 = new System.Windows.Forms.Label();
            this.DataFiles_Filtr04 = new System.Windows.Forms.TextBox();
            this.DataFiles_Filtr03 = new System.Windows.Forms.TextBox();
            this.DataFiles_Filtr02 = new System.Windows.Forms.TextBox();
            this.DataFiles_Filtr01 = new System.Windows.Forms.TextBox();
            this.DataFilesTree = new System.Windows.Forms.TreeView();
            this.DataFilesTree_Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DataFilesTree_Mn01 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataFilesTree_Mn01_Mn01 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataFilesTree_Mn01_Mn02 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataFilesTree_Mn02 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataFilesTree_Mn02_Mn01 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataFilesTree_Mn02_Mn02 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataFilesTree_Mn02_Mn03 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataFilesTree_Mn03 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataFilesTree_Mn03_Mn01 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataFilesTree_Mn07 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataFilesTree_Mn07_Mn01 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataFilesTree_Mn07_Mn02 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataFilesTree_Mn07_Mn03 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataFilesTree_Mn07_Mn04 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataFilesTree_Mn07_Mn05 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataFilesTree_Mn06 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataFilesTree_Mn04 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataFilesTree_Mn05 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataFilesTree_Mn08 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataFilesTreeImages = new System.Windows.Forms.ImageList(this.components);
            this.DataFiles_RB05 = new System.Windows.Forms.RadioButton();
            this.DataFiles_RB04 = new System.Windows.Forms.RadioButton();
            this.DataFiles_Year = new System.Windows.Forms.NumericUpDown();
            this.DataFiles_Month = new System.Windows.Forms.NumericUpDown();
            this.DataFiles_Day = new System.Windows.Forms.NumericUpDown();
            this.DataFiles_RB03 = new System.Windows.Forms.RadioButton();
            this.DataFiles_RB02 = new System.Windows.Forms.RadioButton();
            this.DataFiles_RB01 = new System.Windows.Forms.RadioButton();
            this.DataFiles_Page = new System.Windows.Forms.NumericUpDown();
            this.DataFiles_Rows = new System.Windows.Forms.NumericUpDown();
            this.DataFiles = new System.Windows.Forms.DataGridView();
            this.DataFiles_Mn00 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataFiles_Mn01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataFiles_Mn02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataFiles_Mn03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataFiles_Mn04 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataFiles_Mn05 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataFiles_Mn06 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataFiles_Mn07 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataFiles_Mn08 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataFiles_Mn09 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataFiles_Mn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataFiles_Mn11 = new System.Windows.Forms.DataGridViewImageColumn();
            this.DataFiles_Mn12 = new System.Windows.Forms.DataGridViewImageColumn();
            this.DataFiles_Mn13 = new System.Windows.Forms.DataGridViewImageColumn();
            this.DataFiles_Mn14 = new System.Windows.Forms.DataGridViewImageColumn();
            this.DataFiles_Mn15 = new System.Windows.Forms.DataGridViewImageColumn();
            this.DataFiles_Mn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataFiles_Mn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataFiles_Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DataFiles_Menu_Mn01 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataFiles_Menu_Mn01_Mn01 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataFiles_Menu_Mn01_Mn02 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataFiles_Menu_Mn01_Mn03 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataFiles_Menu_Mn02 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataFiles_Menu_Mn02_Mn01 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataFiles_Menu_Mn05 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataFiles_Menu_Mn05_Mn01 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataFiles_Menu_Mn05_Mn02 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataFiles_Menu_Mn05_Mn03 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataFiles_Menu_Mn05_Mn04 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataFiles_Menu_Mn05_Mn05 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataFiles_Menu_Mn06 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataFiles_Menu_Mn06_Mn01 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataFiles_Menu_Mn06_Mn02 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataFiles_Menu_Mn06_Mn03 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataFiles_Menu_Mn06_Mn04 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataFiles_Menu_Mn03 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataFiles_Menu_Mn04 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataFiles_Menu_Mn07 = new System.Windows.Forms.ToolStripMenuItem();
            this.MainTabData_AnimeTabPage = new System.Windows.Forms.TabPage();
            this.DataAnime_Page = new System.Windows.Forms.NumericUpDown();
            this.DataAnime_Rows = new System.Windows.Forms.NumericUpDown();
            this.DataAnime = new System.Windows.Forms.DataGridView();
            this.DataAnime_Mn00 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataAnime_Mn01 = new System.Windows.Forms.DataGridViewImageColumn();
            this.DataAnime_Mn02 = new System.Windows.Forms.DataGridViewImageColumn();
            this.DataAnime_Mn03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataAnime_Mn04 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataAnime_Mn05 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataAnime_Mn06 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataAnime_Mn08 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataAnime_Mn09 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataAnime_Mn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataAnime_Mn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataAnime_Mn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataAnime_Mn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataAnime_Mn14 = new System.Windows.Forms.DataGridViewImageColumn();
            this.DataAnime_Mn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataAnime_Mn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataAnime_Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DataAnime_Menu_Expand = new System.Windows.Forms.ToolStripMenuItem();
            this.DataAnime_Menu_Expand_Anime = new System.Windows.Forms.ToolStripMenuItem();
            this.DataAnime_Menu_Expand_Episodes = new System.Windows.Forms.ToolStripMenuItem();
            this.DataAnime_Menu_Expand_All = new System.Windows.Forms.ToolStripMenuItem();
            this.DataAnime_Menu_Expand_CollapseEpisodes = new System.Windows.Forms.ToolStripMenuItem();
            this.DataAnime_Menu_Expand_CollapseAllEpisodes = new System.Windows.Forms.ToolStripMenuItem();
            this.DataAnime_Menu_Expand_CollapseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.DataAnime_Menu_MyList = new System.Windows.Forms.ToolStripMenuItem();
            this.DataAnime_Menu_MyList_AddModify = new System.Windows.Forms.ToolStripMenuItem();
            this.DataAnime_Menu_MyList_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.DataAnime_Menu_MyList_Watched = new System.Windows.Forms.ToolStripMenuItem();
            this.DataAnime_Menu_Database = new System.Windows.Forms.ToolStripMenuItem();
            this.DataAnime_Menu_Database_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.DataAnime_Menu_Mn04 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataAnime_Menu_Mn04_Mn01 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataAnime_Menu_Mn04_Mn02 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataAnime_Menu_Mn04_Mn03 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataAnime_Menu_Mn04_Mn04 = new System.Windows.Forms.ToolStripMenuItem();
            this.DataAnime_Menu_Mn04_Mn05 = new System.Windows.Forms.ToolStripMenuItem();
            this.MainTabData_Anime2TabPage = new System.Windows.Forms.TabPage();
            this.Anime_RelDel = new System.Windows.Forms.Button();
            this.AnimeTree_CH02 = new System.Windows.Forms.CheckBox();
            this.AnimeTree_CH01 = new System.Windows.Forms.CheckBox();
            this.Anime_GR01 = new System.Windows.Forms.GroupBox();
            this.Anime_CB01 = new System.Windows.Forms.ComboBox();
            this.Anime_CB02 = new System.Windows.Forms.ComboBox();
            this.Anime_Seen = new System.Windows.Forms.MaskedTextBox();
            this.Anime_Rat = new System.Windows.Forms.NumericUpDown();
            this.Anime_LB11 = new System.Windows.Forms.Label();
            this.Anime_RelationTree = new System.Windows.Forms.TreeView();
            this.Anime_LB08 = new System.Windows.Forms.LinkLabel();
            this.Anime_OP07 = new System.Windows.Forms.Label();
            this.Anime_OP06 = new System.Windows.Forms.Label();
            this.Anime_OP04 = new System.Windows.Forms.Label();
            this.Anime_OP03 = new System.Windows.Forms.Label();
            this.Anime_OP02 = new System.Windows.Forms.Label();
            this.Anime_OP01 = new System.Windows.Forms.Label();
            this.Anime_LB04 = new System.Windows.Forms.Label();
            this.Anime_LB07 = new System.Windows.Forms.Label();
            this.Anime_LB05 = new System.Windows.Forms.Label();
            this.Anime_LB10 = new System.Windows.Forms.Label();
            this.Anime_LB09 = new System.Windows.Forms.Label();
            this.Anime_LB06 = new System.Windows.Forms.Label();
            this.Anime_LB03 = new System.Windows.Forms.Label();
            this.AnimeData = new System.Windows.Forms.DataGridView();
            this.AnimeData_Mn01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnimeData_Mn02 = new System.Windows.Forms.DataGridViewImageColumn();
            this.AnimeData_Mn03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnimeData_Mn04 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnimeData_Mn05 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnimeData_Mn06 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnimeData_Mn07 = new System.Windows.Forms.DataGridViewImageColumn();
            this.AnimeData_Mn08 = new System.Windows.Forms.DataGridViewImageColumn();
            this.AnimeData_Mn09 = new System.Windows.Forms.DataGridViewImageColumn();
            this.AnimeData_Mn10 = new System.Windows.Forms.DataGridViewImageColumn();
            this.AnimeData_Mn11 = new System.Windows.Forms.DataGridViewImageColumn();
            this.AnimeData_Mn12 = new System.Windows.Forms.DataGridViewImageColumn();
            this.AnimeData_Mn13 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Anime_LB02 = new System.Windows.Forms.LinkLabel();
            this.Anime_LB01 = new System.Windows.Forms.LinkLabel();
            this.AnimeTree = new System.Windows.Forms.TreeView();
            this.AnimeTree_Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AnimeTree_Menu_Mn01 = new System.Windows.Forms.ToolStripMenuItem();
            this.AnimeTree_Menu_Mn01_Mn01 = new System.Windows.Forms.ToolStripMenuItem();
            this.AnimeTree_Menu_Mn01_Mn02 = new System.Windows.Forms.ToolStripMenuItem();
            this.AnimeTree_Menu_Mn01_Mn03 = new System.Windows.Forms.ToolStripMenuItem();
            this.AnimeTree_Menu_Mn01_Mn04 = new System.Windows.Forms.ToolStripMenuItem();
            this.AnimeTree_Menu_Mn01_Mn05 = new System.Windows.Forms.ToolStripMenuItem();
            this.AnimeTree_Menu_Mn02 = new System.Windows.Forms.ToolStripMenuItem();
            this.MainTabData_GenresTabPage = new System.Windows.Forms.TabPage();
            this.DataGenres_Page = new System.Windows.Forms.NumericUpDown();
            this.DataGenres_Rows = new System.Windows.Forms.NumericUpDown();
            this.DataGenres = new System.Windows.Forms.DataGridView();
            this.DataGenres_Mn01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGenres_Mn02 = new System.Windows.Forms.DataGridViewImageColumn();
            this.DataGenres_Mn03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGenres_Mn04 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGenres_Mn05 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGenres_Mn06 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGenres_Mn07 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MainTabData_GroupsTabPage = new System.Windows.Forms.TabPage();
            this.DataGroups_Page = new System.Windows.Forms.NumericUpDown();
            this.DataGroups_Rows = new System.Windows.Forms.NumericUpDown();
            this.DataGroups = new System.Windows.Forms.DataGridView();
            this.DataGroups_Mn01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGroups_Mn02 = new System.Windows.Forms.DataGridViewImageColumn();
            this.DataGroups_Mn03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGroups_Mn04 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGroups_Mn05 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGroups_Mn06 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGroups_Mn07 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MainTabData_SearchTabPage = new System.Windows.Forms.TabPage();
            this.DataSearch_CH02 = new System.Windows.Forms.CheckBox();
            this.DataSearch_CH01 = new System.Windows.Forms.CheckBox();
            this.DataSearch_NM05 = new System.Windows.Forms.NumericUpDown();
            this.DataSearch_NM04 = new System.Windows.Forms.NumericUpDown();
            this.DataSearch_NM03 = new System.Windows.Forms.NumericUpDown();
            this.DataSearch_NM02 = new System.Windows.Forms.NumericUpDown();
            this.DataSearch_NM01 = new System.Windows.Forms.NumericUpDown();
            this.DataSearch_CB01 = new System.Windows.Forms.ComboBox();
            this.DataSearch_CB02 = new System.Windows.Forms.ComboBox();
            this.DataSearch_TX05 = new System.Windows.Forms.TextBox();
            this.DataSearch_TX04 = new System.Windows.Forms.TextBox();
            this.DataSearch_TX08 = new System.Windows.Forms.TextBox();
            this.DataSearch_TX03 = new System.Windows.Forms.TextBox();
            this.DataSearch_TX07 = new System.Windows.Forms.TextBox();
            this.DataSearch_TX02 = new System.Windows.Forms.TextBox();
            this.DataSearch_TX06 = new System.Windows.Forms.TextBox();
            this.DataSearch_TX01 = new System.Windows.Forms.TextBox();
            this.DataSearch_LB15 = new System.Windows.Forms.Label();
            this.DataSearch_LB10 = new System.Windows.Forms.Label();
            this.DataSearch_LB05 = new System.Windows.Forms.Label();
            this.DataSearch_LB14 = new System.Windows.Forms.Label();
            this.DataSearch_LB09 = new System.Windows.Forms.Label();
            this.DataSearch_LB04 = new System.Windows.Forms.Label();
            this.DataSearch_LB13 = new System.Windows.Forms.Label();
            this.DataSearch_LB08 = new System.Windows.Forms.Label();
            this.DataSearch_LB03 = new System.Windows.Forms.Label();
            this.DataSearch_LB12 = new System.Windows.Forms.Label();
            this.DataSearch_LB07 = new System.Windows.Forms.Label();
            this.DataSearch_LB02 = new System.Windows.Forms.Label();
            this.DataSearch_LB11 = new System.Windows.Forms.Label();
            this.DataSearch_LB06 = new System.Windows.Forms.Label();
            this.DataSearch_LB01 = new System.Windows.Forms.Label();
            this.DataSearch_LB16 = new System.Windows.Forms.Label();
            this.DataSearch_Genres = new System.Windows.Forms.CheckedListBox();
            this.DataSearch_Clear = new System.Windows.Forms.Button();
            this.DataSearch_Select = new System.Windows.Forms.Button();
            this.DataSearch = new System.Windows.Forms.DataGridView();
            this.DataSearch_Mn01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataSearch_Mn02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataSearch_Mn03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataSearch_Mn04 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataSearch_Mn05 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MainTabData_OthersTabPage = new System.Windows.Forms.TabPage();
            this.AnimeSeen = new System.Windows.Forms.TreeView();
            this.AnimeRating = new System.Windows.Forms.TreeView();
            this.AnimeTags = new System.Windows.Forms.TreeView();
            this.MainTabData_GraphsTabPage = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Zgc_Graph = new ZedGraph.ZedGraphControl();
            this.MainTabData_ExportTabPage = new System.Windows.Forms.TabPage();
            this.Anime_ExportLB01 = new System.Windows.Forms.Label();
            this.Anime_ExportBT02 = new System.Windows.Forms.Button();
            this.Anime_ExportBT01 = new System.Windows.Forms.Button();
            this.Anime_ExportCH18 = new System.Windows.Forms.CheckBox();
            this.Anime_ExportCH17 = new System.Windows.Forms.CheckBox();
            this.Anime_ExportCH16 = new System.Windows.Forms.CheckBox();
            this.Anime_ExportCH15 = new System.Windows.Forms.CheckBox();
            this.Anime_ExportCH14 = new System.Windows.Forms.CheckBox();
            this.Anime_ExportCH13 = new System.Windows.Forms.CheckBox();
            this.Anime_ExportCH12 = new System.Windows.Forms.CheckBox();
            this.Anime_ExportCH11 = new System.Windows.Forms.CheckBox();
            this.Anime_ExportCH10 = new System.Windows.Forms.CheckBox();
            this.Anime_ExportCH09 = new System.Windows.Forms.CheckBox();
            this.Anime_ExportCH08 = new System.Windows.Forms.CheckBox();
            this.Anime_ExportCH07 = new System.Windows.Forms.CheckBox();
            this.Anime_ExportCH06 = new System.Windows.Forms.CheckBox();
            this.Anime_ExportCH05 = new System.Windows.Forms.CheckBox();
            this.Anime_ExportCH04 = new System.Windows.Forms.CheckBox();
            this.Anime_ExportCH03 = new System.Windows.Forms.CheckBox();
            this.Anime_ExportCH02 = new System.Windows.Forms.CheckBox();
            this.Anime_ExportCH01 = new System.Windows.Forms.CheckBox();
            this.MainTab_MangaPage = new System.Windows.Forms.TabPage();
            this.MainTabManga = new System.Windows.Forms.TabControl();
            this.MainTabManga_Mn01 = new System.Windows.Forms.TabPage();
            this.Manga_Gr04 = new System.Windows.Forms.GroupBox();
            this.Options_MangaLabel = new System.Windows.Forms.Label();
            this.Options_LB65 = new System.Windows.Forms.Label();
            this.Options_VolumesLabel = new System.Windows.Forms.Label();
            this.Options_LB54 = new System.Windows.Forms.Label();
            this.Options_ReadLabel = new System.Windows.Forms.Label();
            this.Options_LB56 = new System.Windows.Forms.Label();
            this.Options_ChaptersLabel = new System.Windows.Forms.Label();
            this.Options_LB64 = new System.Windows.Forms.Label();
            this.Options_TotalPagesLabel = new System.Windows.Forms.Label();
            this.Options_LB62 = new System.Windows.Forms.Label();
            this.Options_AdultLabel = new System.Windows.Forms.Label();
            this.Options_LB58 = new System.Windows.Forms.Label();
            this.Options_ReadLabel2 = new System.Windows.Forms.Label();
            this.Options_LB60 = new System.Windows.Forms.Label();
            this.Options_FileSizeLabel = new System.Windows.Forms.Label();
            this.Options_LB52 = new System.Windows.Forms.Label();
            this.MangaTree_CH01 = new System.Windows.Forms.CheckBox();
            this.Manga_Gr01 = new System.Windows.Forms.GroupBox();
            this.Manga_CB01 = new System.Windows.Forms.ComboBox();
            this.Manga_RelationTree = new System.Windows.Forms.TreeView();
            this.Manga_LB14 = new System.Windows.Forms.LinkLabel();
            this.Manga_LB53 = new System.Windows.Forms.LinkLabel();
            this.Manga_LB45 = new System.Windows.Forms.LinkLabel();
            this.Manga_LB52 = new System.Windows.Forms.LinkLabel();
            this.Manga_LB13 = new System.Windows.Forms.LinkLabel();
            this.Manga_LB40 = new System.Windows.Forms.Label();
            this.Manga_LB10 = new System.Windows.Forms.Label();
            this.Manga_LB12 = new System.Windows.Forms.Label();
            this.Manga_LB38 = new System.Windows.Forms.Label();
            this.Manga_LB08 = new System.Windows.Forms.Label();
            this.Manga_LB06 = new System.Windows.Forms.Label();
            this.Manga_LB04 = new System.Windows.Forms.Label();
            this.Manga_LB05 = new System.Windows.Forms.Label();
            this.Manga_LB25 = new System.Windows.Forms.Label();
            this.Manga_LB39 = new System.Windows.Forms.Label();
            this.Manga_LB15 = new System.Windows.Forms.Label();
            this.Manga_LB37 = new System.Windows.Forms.Label();
            this.Manga_LB07 = new System.Windows.Forms.Label();
            this.Manga_LB01 = new System.Windows.Forms.Label();
            this.Manga_LB09 = new System.Windows.Forms.Label();
            this.Manga_LB03 = new System.Windows.Forms.Label();
            this.Manga_Data = new System.Windows.Forms.DataGridView();
            this.Manga_Data_Mn01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manga_Data_Mn02 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Manga_Data_Mn03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manga_Data_Mn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manga_Data_Mn04 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manga_Data_Mn05 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manga_Data_Mn08 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manga_Data_Mn09 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manga_Data_Mn06 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Manga_Data_Mn07 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Manga_Tree = new System.Windows.Forms.TreeView();
            this.Manga_Tree_Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Manga_Tree_Menu_Mn01 = new System.Windows.Forms.ToolStripMenuItem();
            this.MainTabManga_Mn02 = new System.Windows.Forms.TabPage();
            this.Manga_Gr03 = new System.Windows.Forms.GroupBox();
            this.Manga_Tx20 = new System.Windows.Forms.NumericUpDown();
            this.Manga_ChaptersDT = new System.Windows.Forms.DataGridView();
            this.Manga_ChaptersCM01 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Manga_ChaptersCM02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manga_ChaptersCM03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manga_ChaptersCM04 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Manga_ChaptersCM05 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manga_ChaptersCM06 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manga_Tx21 = new System.Windows.Forms.ComboBox();
            this.Manga_Tx19 = new System.Windows.Forms.TextBox();
            this.Manga_Tx12 = new System.Windows.Forms.TextBox();
            this.Manga_LB41 = new System.Windows.Forms.Label();
            this.Manga_LB42 = new System.Windows.Forms.Label();
            this.Manga_LB43 = new System.Windows.Forms.Label();
            this.Manga_Gr02 = new System.Windows.Forms.GroupBox();
            this.Manga_LB48 = new System.Windows.Forms.Label();
            this.Manga_LB47 = new System.Windows.Forms.Label();
            this.Manga_LB49 = new System.Windows.Forms.Label();
            this.Manga_LB46 = new System.Windows.Forms.Label();
            this.Manga_Tx07 = new System.Windows.Forms.NumericUpDown();
            this.Manga_Tx04 = new System.Windows.Forms.NumericUpDown();
            this.Manga_CH01 = new System.Windows.Forms.CheckBox();
            this.Manga_Manga = new System.Windows.Forms.CheckedListBox();
            this.Manga_Anime = new System.Windows.Forms.CheckedListBox();
            this.Manga_Genres = new System.Windows.Forms.CheckedListBox();
            this.Manga_LB24 = new System.Windows.Forms.Label();
            this.Manga_LB44 = new System.Windows.Forms.Label();
            this.Manga_LB36 = new System.Windows.Forms.Label();
            this.Manga_LB22 = new System.Windows.Forms.Label();
            this.Manga_LB23 = new System.Windows.Forms.Label();
            this.Manga_LB35 = new System.Windows.Forms.Label();
            this.Manga_LB51 = new System.Windows.Forms.Label();
            this.Manga_LB21 = new System.Windows.Forms.Label();
            this.Manga_LB50 = new System.Windows.Forms.Label();
            this.Manga_LB20 = new System.Windows.Forms.Label();
            this.Manga_LB19 = new System.Windows.Forms.Label();
            this.Manga_LB18 = new System.Windows.Forms.Label();
            this.Manga_LB17 = new System.Windows.Forms.Label();
            this.Manga_LB16 = new System.Windows.Forms.Label();
            this.Manga_Tx22 = new System.Windows.Forms.TextBox();
            this.Manga_Tx18 = new System.Windows.Forms.TextBox();
            this.Manga_Tx17 = new System.Windows.Forms.TextBox();
            this.Manga_Tx24 = new System.Windows.Forms.TextBox();
            this.Manga_Tx06 = new System.Windows.Forms.TextBox();
            this.Manga_Tx23 = new System.Windows.Forms.TextBox();
            this.Manga_Tx05 = new System.Windows.Forms.TextBox();
            this.Manga_Tx03 = new System.Windows.Forms.TextBox();
            this.Manga_Tx02 = new System.Windows.Forms.TextBox();
            this.Manga_Tx08 = new System.Windows.Forms.TextBox();
            this.Manga_Tx00 = new System.Windows.Forms.TextBox();
            this.Manga_Tx01 = new System.Windows.Forms.TextBox();
            this.MainTabManga_Mn03 = new System.Windows.Forms.TabPage();
            this.MangaSearch_NM04 = new System.Windows.Forms.NumericUpDown();
            this.MangaSearch_NM03 = new System.Windows.Forms.NumericUpDown();
            this.MangaSearch_NM02 = new System.Windows.Forms.NumericUpDown();
            this.MangaSearch_NM01 = new System.Windows.Forms.NumericUpDown();
            this.MangaSearch_TX05 = new System.Windows.Forms.TextBox();
            this.MangaSearch_TX04 = new System.Windows.Forms.TextBox();
            this.MangaSearch_TX03 = new System.Windows.Forms.TextBox();
            this.MangaSearch_TX02 = new System.Windows.Forms.TextBox();
            this.MangaSearch_TX01 = new System.Windows.Forms.TextBox();
            this.MangaSearch_LB10 = new System.Windows.Forms.Label();
            this.MangaSearch_LB05 = new System.Windows.Forms.Label();
            this.MangaSearch_LB04 = new System.Windows.Forms.Label();
            this.MangaSearch_LB09 = new System.Windows.Forms.Label();
            this.MangaSearch_LB03 = new System.Windows.Forms.Label();
            this.MangaSearch_LB08 = new System.Windows.Forms.Label();
            this.MangaSearch_LB02 = new System.Windows.Forms.Label();
            this.MangaSearch_LB07 = new System.Windows.Forms.Label();
            this.MangaSearch_LB01 = new System.Windows.Forms.Label();
            this.MangaSearch_LB06 = new System.Windows.Forms.Label();
            this.MangaSearch_Genres = new System.Windows.Forms.CheckedListBox();
            this.MangaSearch_New = new System.Windows.Forms.Button();
            this.MangaSearch_Search = new System.Windows.Forms.Button();
            this.MangaSearch = new System.Windows.Forms.DataGridView();
            this.MangaSearch_Mn01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MangaSearch_Mn02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MangaSearch_Mn03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MangaSearch_Mn04 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MainTab_LogPage = new System.Windows.Forms.TabPage();
            this.MainTabLog = new System.Windows.Forms.TabControl();
            this.MainTabLog_AniDbTabPage = new System.Windows.Forms.TabPage();
            this.Log = new System.Windows.Forms.TextBox();
            this.MainTabLog_SqlTabPage = new System.Windows.Forms.TabPage();
            this.LogSQL = new System.Windows.Forms.TextBox();
            this.MainTabLog_ErrorTabPage = new System.Windows.Forms.TabPage();
            this.LogError = new System.Windows.Forms.TextBox();
            this.MainTabLog_TasksTabPage = new System.Windows.Forms.TabPage();
            this.Add_Text02 = new System.Windows.Forms.ComboBox();
            this.Add_Text01 = new System.Windows.Forms.TextBox();
            this.Add_LB01 = new System.Windows.Forms.Label();
            this.LogTasks = new System.Windows.Forms.ListBox();
            this.MainTab_SqlPage = new System.Windows.Forms.TabPage();
            this.DataSql_CheckGroupBox = new System.Windows.Forms.GroupBox();
            this.DataSql_FilesButton = new System.Windows.Forms.Button();
            this.DataSql_MyListButton = new System.Windows.Forms.Button();
            this.DataSql_EpisodesButton = new System.Windows.Forms.Button();
            this.DataSql_AnimeButton = new System.Windows.Forms.Button();
            this.DataSQL_Text = new System.Windows.Forms.ComboBox();
            this.DataSQL_Columns = new System.Windows.Forms.ListBox();
            this.DataSQL_Tables = new System.Windows.Forms.ListBox();
            this.DataSQL = new System.Windows.Forms.DataGridView();
            this.ComunicationW = new System.ComponentModel.BackgroundWorker();
            this.ComunicationRec = new System.Windows.Forms.Timer(this.components);
            this.Hash_W = new System.ComponentModel.BackgroundWorker();
            this.Adresar_Broswer = new System.Windows.Forms.FolderBrowserDialog();
            this.AnimeData_Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AnimeData_Menu_Mn01 = new System.Windows.Forms.ToolStripMenuItem();
            this.AnimeData_Menu_Mn01_Mn01 = new System.Windows.Forms.ToolStripMenuItem();
            this.AnimeData_Menu_Mn01_Mn02 = new System.Windows.Forms.ToolStripMenuItem();
            this.AnimeData_Menu_Mn02 = new System.Windows.Forms.ToolStripMenuItem();
            this.AnimeData_Menu_Mn02_Mn01 = new System.Windows.Forms.ToolStripMenuItem();
            this.AnimeData_Menu_Mn02_Mn02 = new System.Windows.Forms.ToolStripMenuItem();
            this.AnimeData_Menu_Mn02_Mn03 = new System.Windows.Forms.ToolStripMenuItem();
            this.AnimeData_Menu_Mn03 = new System.Windows.Forms.ToolStripMenuItem();
            this.AnimeData_Menu_Mn03_Mn01 = new System.Windows.Forms.ToolStripMenuItem();
            this.AnimeData_Menu_Mn05 = new System.Windows.Forms.ToolStripMenuItem();
            this.AnimeData_Menu_Mn05_Mn01 = new System.Windows.Forms.ToolStripMenuItem();
            this.AnimeData_Menu_Mn05_Mn02 = new System.Windows.Forms.ToolStripMenuItem();
            this.AnimeData_Menu_Mn05_Mn03 = new System.Windows.Forms.ToolStripMenuItem();
            this.AnimeData_Menu_Mn05_Mn04 = new System.Windows.Forms.ToolStripMenuItem();
            this.AnimeData_Menu_Mn05_Mn05 = new System.Windows.Forms.ToolStripMenuItem();
            this.AnimeData_Menu_Mn04 = new System.Windows.Forms.ToolStripMenuItem();
            this.AnimeData_Menu_Mn06 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.FRename_W = new System.ComponentModel.BackgroundWorker();
            this.Manga_Data_Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Manga_Data_Menu_Mn02 = new System.Windows.Forms.ToolStripMenuItem();
            this.Manga_Data_Menu_Mn03 = new System.Windows.Forms.ToolStripMenuItem();
            this.Manga_Data_Menu_Mn04 = new System.Windows.Forms.ToolStripMenuItem();
            this.Database_W = new System.ComponentModel.BackgroundWorker();
            this.StatusBar_ConnectLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.StatusBar_ProgressBar = new System.Windows.Forms.ProgressBar();
            this.StatusBar_Mn06 = new System.Windows.Forms.Label();
            this.StatusBar_Mn05 = new System.Windows.Forms.Label();
            this.StatusBar_Mn04 = new System.Windows.Forms.Label();
            this.StatusBar_Mn03 = new System.Windows.Forms.Label();
            this.StatusBar_Mn02 = new System.Windows.Forms.Label();
            this.StatusBar_TasksRemainingLabel = new System.Windows.Forms.Label();
            this.ToolTipAnimeRel = new System.Windows.Forms.ToolTip(this.components);
            this.Notify = new System.Windows.Forms.NotifyIcon(this.components);
            this.StatusBar_Connect = new System.Windows.Forms.Button();
            this.StatusBar_Hash = new System.Windows.Forms.Button();
            this.StatusBar_Refresh = new System.Windows.Forms.Button();
            this.Options_CH13BT = new System.Windows.Forms.Button();
            this.Options_CH11BT = new System.Windows.Forms.Button();
            this.Options_CH12BT = new System.Windows.Forms.Button();
            this.Options_CH10BT = new System.Windows.Forms.Button();
            this.Options_CH09BT = new System.Windows.Forms.Button();
            this.Options_CH07BT = new System.Windows.Forms.Button();
            this.Options_CH08BT = new System.Windows.Forms.Button();
            this.Options_CH06BT = new System.Windows.Forms.Button();
            this.Options_CH05BT = new System.Windows.Forms.Button();
            this.Options_CH04BT = new System.Windows.Forms.Button();
            this.Options_CH03BT = new System.Windows.Forms.Button();
            this.Watcher_Delete = new System.Windows.Forms.Button();
            this.Watcher_Add = new System.Windows.Forms.Button();
            this.Options_ExtensionRem = new System.Windows.Forms.Button();
            this.Options_AccountChange = new System.Windows.Forms.Button();
            this.Options_ExtensionAdd = new System.Windows.Forms.Button();
            this.Options_w8Hack = new System.Windows.Forms.Button();
            this.Options_SetingsDefault = new System.Windows.Forms.Button();
            this.Options_SetingsLoad = new System.Windows.Forms.Button();
            this.Options_SetingsSave = new System.Windows.Forms.Button();
            this.Options_StartComunication = new System.Windows.Forms.Button();
            this.Rules_InfoDell = new System.Windows.Forms.Button();
            this.Rules_InfoAdd = new System.Windows.Forms.Button();
            this.Rules_FilesRulesMoveDel = new System.Windows.Forms.Button();
            this.Rules_FilesRulesMoveAdd = new System.Windows.Forms.Button();
            this.Rules_FilesRulesRenameDel = new System.Windows.Forms.Button();
            this.Rules_FilesRulesRenameAdd = new System.Windows.Forms.Button();
            this.Hash = new System.Windows.Forms.Button();
            this.Hash_Cesta = new System.Windows.Forms.Button();
            this.Hash_Stop_Total = new System.Windows.Forms.Button();
            this.Hash_Files = new System.Windows.Forms.Button();
            this.Hash_Delete = new System.Windows.Forms.Button();
            this.Hash_DeleteAll = new System.Windows.Forms.Button();
            this.Options_MyListRefreshMin = new System.Windows.Forms.Button();
            this.Options_MyListRefresh = new System.Windows.Forms.Button();
            this.DataFiles_Bt21 = new System.Windows.Forms.Button();
            this.DataFiles_Bt22 = new System.Windows.Forms.Button();
            this.DataFiles_Bt20 = new System.Windows.Forms.Button();
            this.DataFiles_Bt19 = new System.Windows.Forms.Button();
            this.DataFiles_Bt00 = new System.Windows.Forms.Button();
            this.DataFiles_Bt01 = new System.Windows.Forms.Button();
            this.DataFiles_Bt18 = new System.Windows.Forms.Button();
            this.DataFiles_Bt17 = new System.Windows.Forms.Button();
            this.DataFiles_Bt16 = new System.Windows.Forms.Button();
            this.DataFiles_Bt15 = new System.Windows.Forms.Button();
            this.DataFiles_Bt14 = new System.Windows.Forms.Button();
            this.DataFiles_Bt13 = new System.Windows.Forms.Button();
            this.DataFiles_Bt12 = new System.Windows.Forms.Button();
            this.DataFiles_Bt11 = new System.Windows.Forms.Button();
            this.DataFiles_Bt10 = new System.Windows.Forms.Button();
            this.DataFiles_Bt09 = new System.Windows.Forms.Button();
            this.DataFiles_Bt08 = new System.Windows.Forms.Button();
            this.DataFiles_Bt07 = new System.Windows.Forms.Button();
            this.DataFiles_Bt06 = new System.Windows.Forms.Button();
            this.DataFiles_Bt05 = new System.Windows.Forms.Button();
            this.DataFiles_Bt04 = new System.Windows.Forms.Button();
            this.DataFiles_Bt03 = new System.Windows.Forms.Button();
            this.DataFiles_Bt02 = new System.Windows.Forms.Button();
            this.Anime_Rel = new System.Windows.Forms.PictureBox();
            this.Anime_DateOK = new System.Windows.Forms.PictureBox();
            this.Anime_RatImg = new System.Windows.Forms.PictureBox();
            this.Anime_BT01 = new System.Windows.Forms.Button();
            this.Anime_Img = new System.Windows.Forms.PictureBox();
            this.Anime_Lang03 = new System.Windows.Forms.Button();
            this.Anime_Lang02 = new System.Windows.Forms.Button();
            this.Anime_Lang01 = new System.Windows.Forms.Button();
            this.Zgc_GraphB06 = new System.Windows.Forms.Button();
            this.Zgc_GraphB05 = new System.Windows.Forms.Button();
            this.Zgc_GraphB04 = new System.Windows.Forms.Button();
            this.Zgc_GraphB03 = new System.Windows.Forms.Button();
            this.Zgc_GraphB02 = new System.Windows.Forms.Button();
            this.Zgc_GraphB01 = new System.Windows.Forms.Button();
            this.Options_MyListRefreshManga = new System.Windows.Forms.Button();
            this.Manga_Chapter = new System.Windows.Forms.Button();
            this.Manga_Edit = new System.Windows.Forms.Button();
            this.Manga_Picture = new System.Windows.Forms.PictureBox();
            this.Manga_Lang03 = new System.Windows.Forms.Button();
            this.Manga_Lang02 = new System.Windows.Forms.Button();
            this.Manga_Lang01 = new System.Windows.Forms.Button();
            this.Manga_EditCh = new System.Windows.Forms.Button();
            this.Manga_Obr_CHD = new System.Windows.Forms.Button();
            this.Manga_Insert_CHD = new System.Windows.Forms.Button();
            this.Manga_Delete = new System.Windows.Forms.Button();
            this.Manga_Update = new System.Windows.Forms.Button();
            this.Manga_Insert = new System.Windows.Forms.Button();
            this.Manga_Download_MAL = new System.Windows.Forms.Button();
            this.Manga_Download_MU = new System.Windows.Forms.Button();
            this.Manga_Download_MugiMugi = new System.Windows.Forms.Button();
            this.Manga_Download = new System.Windows.Forms.Button();
            this.Manga_Obr = new System.Windows.Forms.Button();
            this.Add_Add = new System.Windows.Forms.Button();
            this.LogTasksDelAll = new System.Windows.Forms.Button();
            this.LogTasksDel = new System.Windows.Forms.Button();
            this.DataSQL_Select = new System.Windows.Forms.Button();
            this.MainTab.SuspendLayout();
            this.MainTab_IndexPage.SuspendLayout();
            this.MainTab_SettinsPage.SuspendLayout();
            this.Options_GR06.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WebServer_MPCHC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WebServer_Port)).BeginInit();
            this.Options_GR05.SuspendLayout();
            this.Options_GR03.SuspendLayout();
            this.Options_GR02.SuspendLayout();
            this.Options_GR01.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Options_Delay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Options_Reset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Options_ServerPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Options_Backup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Options_LocalPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Options_TimeOut)).BeginInit();
            this.MainTab_RulesPage.SuspendLayout();
            this.Rules_RulesForCharacterReplacingGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Rules_Replace)).BeginInit();
            this.Rules_ExportInfoGroupBox.SuspendLayout();
            this.Rules_RulesForGeneratingDirectoriesGroupBox.SuspendLayout();
            this.Rules_RulesForFileRenamingGroupBox.SuspendLayout();
            this.MainTab_HashPage.SuspendLayout();
            this.Hash_GR01.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Hash_Waiting)).BeginInit();
            this.MainTab_AnimePage.SuspendLayout();
            this.MainTabData.SuspendLayout();
            this.MainTabData_MyListTabPage.SuspendLayout();
            this.Options_GR04.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MyListAnime)).BeginInit();
            this.MainTabData_FilesTabPage.SuspendLayout();
            this.DataFilesTree_Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataFiles_Year)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataFiles_Month)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataFiles_Day)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataFiles_Page)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataFiles_Rows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataFiles)).BeginInit();
            this.DataFiles_Menu.SuspendLayout();
            this.MainTabData_AnimeTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataAnime_Page)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataAnime_Rows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataAnime)).BeginInit();
            this.DataAnime_Menu.SuspendLayout();
            this.MainTabData_Anime2TabPage.SuspendLayout();
            this.Anime_GR01.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Anime_Rat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnimeData)).BeginInit();
            this.AnimeTree_Menu.SuspendLayout();
            this.MainTabData_GenresTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGenres_Page)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGenres_Rows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGenres)).BeginInit();
            this.MainTabData_GroupsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGroups_Page)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGroups_Rows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGroups)).BeginInit();
            this.MainTabData_SearchTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataSearch_NM05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSearch_NM04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSearch_NM03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSearch_NM02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSearch_NM01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSearch)).BeginInit();
            this.MainTabData_OthersTabPage.SuspendLayout();
            this.MainTabData_GraphsTabPage.SuspendLayout();
            this.panel1.SuspendLayout();
            this.MainTabData_ExportTabPage.SuspendLayout();
            this.MainTab_MangaPage.SuspendLayout();
            this.MainTabManga.SuspendLayout();
            this.MainTabManga_Mn01.SuspendLayout();
            this.Manga_Gr04.SuspendLayout();
            this.Manga_Gr01.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Manga_Data)).BeginInit();
            this.Manga_Tree_Menu.SuspendLayout();
            this.MainTabManga_Mn02.SuspendLayout();
            this.Manga_Gr03.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Manga_Tx20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Manga_ChaptersDT)).BeginInit();
            this.Manga_Gr02.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Manga_Tx07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Manga_Tx04)).BeginInit();
            this.MainTabManga_Mn03.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MangaSearch_NM04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MangaSearch_NM03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MangaSearch_NM02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MangaSearch_NM01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MangaSearch)).BeginInit();
            this.MainTab_LogPage.SuspendLayout();
            this.MainTabLog.SuspendLayout();
            this.MainTabLog_AniDbTabPage.SuspendLayout();
            this.MainTabLog_SqlTabPage.SuspendLayout();
            this.MainTabLog_ErrorTabPage.SuspendLayout();
            this.MainTabLog_TasksTabPage.SuspendLayout();
            this.MainTab_SqlPage.SuspendLayout();
            this.DataSql_CheckGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataSQL)).BeginInit();
            this.AnimeData_Menu.SuspendLayout();
            this.Manga_Data_Menu.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Anime_Rel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Anime_DateOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Anime_RatImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Anime_Img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Manga_Picture)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTab
            // 
            this.MainTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTab.Controls.Add(this.MainTab_IndexPage);
            this.MainTab.Controls.Add(this.MainTab_SettinsPage);
            this.MainTab.Controls.Add(this.MainTab_RulesPage);
            this.MainTab.Controls.Add(this.MainTab_HashPage);
            this.MainTab.Controls.Add(this.MainTab_AnimePage);
            this.MainTab.Controls.Add(this.MainTab_MangaPage);
            this.MainTab.Controls.Add(this.MainTab_LogPage);
            this.MainTab.Controls.Add(this.MainTab_SqlPage);
            this.MainTab.Enabled = false;
            this.MainTab.Location = new System.Drawing.Point(12, 12);
            this.MainTab.Name = "MainTab";
            this.MainTab.SelectedIndex = 0;
            this.MainTab.Size = new System.Drawing.Size(1127, 706);
            this.MainTab.TabIndex = 0;
            this.MainTab.SelectedIndexChanged += new System.EventHandler(this.MainTab_SelectedIndexChanged);
            // 
            // MainTab_IndexPage
            // 
            this.MainTab_IndexPage.BackColor = System.Drawing.Color.White;
            this.MainTab_IndexPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MainTab_IndexPage.Controls.Add(this.WEB);
            this.MainTab_IndexPage.Location = new System.Drawing.Point(4, 22);
            this.MainTab_IndexPage.Name = "MainTab_IndexPage";
            this.MainTab_IndexPage.Size = new System.Drawing.Size(1119, 680);
            this.MainTab_IndexPage.TabIndex = 0;
            this.MainTab_IndexPage.Text = "0";
            // 
            // WEB
            // 
            this.WEB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WEB.Location = new System.Drawing.Point(0, 0);
            this.WEB.MinimumSize = new System.Drawing.Size(20, 20);
            this.WEB.Name = "WEB";
            this.WEB.Size = new System.Drawing.Size(1119, 680);
            this.WEB.TabIndex = 0;
            this.WEB.WebBrowserShortcutsEnabled = false;
            this.WEB.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.WEB_Navigating);
            // 
            // MainTab_SettinsPage
            // 
            this.MainTab_SettinsPage.AutoScroll = true;
            this.MainTab_SettinsPage.AutoScrollMargin = new System.Drawing.Size(20, 20);
            this.MainTab_SettinsPage.BackColor = System.Drawing.Color.White;
            this.MainTab_SettinsPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MainTab_SettinsPage.Controls.Add(this.Options_GR06);
            this.MainTab_SettinsPage.Controls.Add(this.Options_GR05);
            this.MainTab_SettinsPage.Controls.Add(this.Options_GR03);
            this.MainTab_SettinsPage.Controls.Add(this.Options_GR02);
            this.MainTab_SettinsPage.Controls.Add(this.Watcher_List);
            this.MainTab_SettinsPage.Controls.Add(this.Options_GR01);
            this.MainTab_SettinsPage.Controls.Add(this.Options_NetworkLabel);
            this.MainTab_SettinsPage.Controls.Add(this.Watcher_CH01);
            this.MainTab_SettinsPage.Controls.Add(this.Options_ServerLabel);
            this.MainTab_SettinsPage.Controls.Add(this.Options_Network);
            this.MainTab_SettinsPage.Controls.Add(this.Watcher_Delete);
            this.MainTab_SettinsPage.Controls.Add(this.Options_Delay);
            this.MainTab_SettinsPage.Controls.Add(this.Options_Password);
            this.MainTab_SettinsPage.Controls.Add(this.Options_Reset);
            this.MainTab_SettinsPage.Controls.Add(this.Watcher_Add);
            this.MainTab_SettinsPage.Controls.Add(this.Options_ServerPort);
            this.MainTab_SettinsPage.Controls.Add(this.Options_PortLabel);
            this.MainTab_SettinsPage.Controls.Add(this.Options_Backup);
            this.MainTab_SettinsPage.Controls.Add(this.Options_ExtensionRem);
            this.MainTab_SettinsPage.Controls.Add(this.Options_LocalPort);
            this.MainTab_SettinsPage.Controls.Add(this.Options_User);
            this.MainTab_SettinsPage.Controls.Add(this.Options_AccountChange);
            this.MainTab_SettinsPage.Controls.Add(this.Options_UserNameLabel);
            this.MainTab_SettinsPage.Controls.Add(this.Options_Hash_WatcherLabel);
            this.MainTab_SettinsPage.Controls.Add(this.Options_LocalPortLabel);
            this.MainTab_SettinsPage.Controls.Add(this.Options_PasswordLabel);
            this.MainTab_SettinsPage.Controls.Add(this.Options_FileTypesLabel);
            this.MainTab_SettinsPage.Controls.Add(this.Options_ExtensionAdd);
            this.MainTab_SettinsPage.Controls.Add(this.Options_w8Hack);
            this.MainTab_SettinsPage.Controls.Add(this.Options_SetingsDefault);
            this.MainTab_SettinsPage.Controls.Add(this.Options_SetingsLoad);
            this.MainTab_SettinsPage.Controls.Add(this.Options_TimeoutLabel);
            this.MainTab_SettinsPage.Controls.Add(this.Options_DbBackupCountLabel);
            this.MainTab_SettinsPage.Controls.Add(this.Options_Language);
            this.MainTab_SettinsPage.Controls.Add(this.Options_TimeOut);
            this.MainTab_SettinsPage.Controls.Add(this.Options_DelayLabel);
            this.MainTab_SettinsPage.Controls.Add(this.Options_SetingsSave);
            this.MainTab_SettinsPage.Controls.Add(this.Options_StartComunication);
            this.MainTab_SettinsPage.Controls.Add(this.Options_ResetCountLabel);
            this.MainTab_SettinsPage.Controls.Add(this.Options_ServerName);
            this.MainTab_SettinsPage.Controls.Add(this.Options_ExtensionList);
            this.MainTab_SettinsPage.Location = new System.Drawing.Point(4, 22);
            this.MainTab_SettinsPage.Name = "MainTab_SettinsPage";
            this.MainTab_SettinsPage.Padding = new System.Windows.Forms.Padding(3);
            this.MainTab_SettinsPage.Size = new System.Drawing.Size(1119, 680);
            this.MainTab_SettinsPage.TabIndex = 0;
            this.MainTab_SettinsPage.Text = "1";
            this.MainTab_SettinsPage.UseVisualStyleBackColor = true;
            // 
            // Options_GR06
            // 
            this.Options_GR06.Controls.Add(this.Options_LaunchWebServerOnStartupCheckBox);
            this.Options_GR06.Controls.Add(this.Options_MpcHcPortLabel);
            this.Options_GR06.Controls.Add(this.Options_WebServerPortLabel);
            this.Options_GR06.Controls.Add(this.Options_CH13BT);
            this.Options_GR06.Controls.Add(this.WebServer_MPCHC);
            this.Options_GR06.Controls.Add(this.WebServer_Port);
            this.Options_GR06.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_GR06.Location = new System.Drawing.Point(604, 722);
            this.Options_GR06.Margin = new System.Windows.Forms.Padding(10);
            this.Options_GR06.Name = "Options_GR06";
            this.Options_GR06.Size = new System.Drawing.Size(476, 142);
            this.Options_GR06.TabIndex = 7;
            this.Options_GR06.TabStop = false;
            this.Options_GR06.Text = "groupBox1";
            // 
            // Options_LaunchWebServerOnStartupCheckBox
            // 
            this.Options_LaunchWebServerOnStartupCheckBox.ForeColor = System.Drawing.Color.Black;
            this.Options_LaunchWebServerOnStartupCheckBox.Location = new System.Drawing.Point(9, 80);
            this.Options_LaunchWebServerOnStartupCheckBox.Name = "Options_LaunchWebServerOnStartupCheckBox";
            this.Options_LaunchWebServerOnStartupCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Options_LaunchWebServerOnStartupCheckBox.Size = new System.Drawing.Size(435, 17);
            this.Options_LaunchWebServerOnStartupCheckBox.TabIndex = 2;
            this.Options_LaunchWebServerOnStartupCheckBox.Text = "checkBox1";
            this.Options_LaunchWebServerOnStartupCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Options_LaunchWebServerOnStartupCheckBox.UseVisualStyleBackColor = true;
            // 
            // Options_MpcHcPortLabel
            // 
            this.Options_MpcHcPortLabel.AutoSize = true;
            this.Options_MpcHcPortLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_MpcHcPortLabel.Location = new System.Drawing.Point(6, 57);
            this.Options_MpcHcPortLabel.Name = "Options_MpcHcPortLabel";
            this.Options_MpcHcPortLabel.Size = new System.Drawing.Size(41, 13);
            this.Options_MpcHcPortLabel.TabIndex = 0;
            this.Options_MpcHcPortLabel.Text = "label1";
            // 
            // Options_WebServerPortLabel
            // 
            this.Options_WebServerPortLabel.AutoSize = true;
            this.Options_WebServerPortLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_WebServerPortLabel.Location = new System.Drawing.Point(6, 31);
            this.Options_WebServerPortLabel.Name = "Options_WebServerPortLabel";
            this.Options_WebServerPortLabel.Size = new System.Drawing.Size(41, 13);
            this.Options_WebServerPortLabel.TabIndex = 0;
            this.Options_WebServerPortLabel.Text = "label1";
            // 
            // WebServer_MPCHC
            // 
            this.WebServer_MPCHC.BackColor = System.Drawing.Color.White;
            this.WebServer_MPCHC.ForeColor = System.Drawing.Color.Black;
            this.WebServer_MPCHC.Location = new System.Drawing.Point(140, 55);
            this.WebServer_MPCHC.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.WebServer_MPCHC.Minimum = new decimal(new int[] {
            1025,
            0,
            0,
            0});
            this.WebServer_MPCHC.Name = "WebServer_MPCHC";
            this.WebServer_MPCHC.Size = new System.Drawing.Size(304, 20);
            this.WebServer_MPCHC.TabIndex = 0;
            this.WebServer_MPCHC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WebServer_MPCHC.Value = new decimal(new int[] {
            12345,
            0,
            0,
            0});
            // 
            // WebServer_Port
            // 
            this.WebServer_Port.BackColor = System.Drawing.Color.White;
            this.WebServer_Port.ForeColor = System.Drawing.Color.Black;
            this.WebServer_Port.Location = new System.Drawing.Point(140, 29);
            this.WebServer_Port.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.WebServer_Port.Minimum = new decimal(new int[] {
            1025,
            0,
            0,
            0});
            this.WebServer_Port.Name = "WebServer_Port";
            this.WebServer_Port.Size = new System.Drawing.Size(304, 20);
            this.WebServer_Port.TabIndex = 0;
            this.WebServer_Port.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WebServer_Port.Value = new decimal(new int[] {
            11011,
            0,
            0,
            0});
            // 
            // Options_GR05
            // 
            this.Options_GR05.Controls.Add(this.Options_CheckUnknownFilesLabel);
            this.Options_GR05.Controls.Add(this.Options_CH11BT);
            this.Options_GR05.Controls.Add(this.Options_CH12BT);
            this.Options_GR05.Controls.Add(this.Options_CheckNewMangaChaptersLabel);
            this.Options_GR05.Controls.Add(this.Options_CH10BT);
            this.Options_GR05.Controls.Add(this.Options_DeleteDbLabel);
            this.Options_GR05.Controls.Add(this.Options_CH09BT);
            this.Options_GR05.Controls.Add(this.Options_ForceDbUpdateLabel);
            this.Options_GR05.Controls.Add(this.Options_CH07BT);
            this.Options_GR05.Controls.Add(this.Options_RestoreBackupLabel);
            this.Options_GR05.Controls.Add(this.Options_CH08BT);
            this.Options_GR05.Controls.Add(this.Options_CompactAndRepairDbLabel);
            this.Options_GR05.Controls.Add(this.Options_CH06BT);
            this.Options_GR05.Controls.Add(this.Options_CreateBackupLabel);
            this.Options_GR05.Controls.Add(this.Options_CH05BT);
            this.Options_GR05.Controls.Add(this.Options_CH04BT);
            this.Options_GR05.Controls.Add(this.Options_DeleteDuplicatesLabel);
            this.Options_GR05.Controls.Add(this.Options_CH03BT);
            this.Options_GR05.Controls.Add(this.Options_DownloadAllFilesLabel);
            this.Options_GR05.Controls.Add(this.Options_DownloadAllAnimeEpisodesLabel);
            this.Options_GR05.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_GR05.Location = new System.Drawing.Point(604, 363);
            this.Options_GR05.Margin = new System.Windows.Forms.Padding(10);
            this.Options_GR05.Name = "Options_GR05";
            this.Options_GR05.Size = new System.Drawing.Size(476, 351);
            this.Options_GR05.TabIndex = 6;
            this.Options_GR05.TabStop = false;
            this.Options_GR05.Text = "groupBox1";
            // 
            // Options_CheckUnknownFilesLabel
            // 
            this.Options_CheckUnknownFilesLabel.AutoSize = true;
            this.Options_CheckUnknownFilesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_CheckUnknownFilesLabel.Location = new System.Drawing.Point(6, 31);
            this.Options_CheckUnknownFilesLabel.Name = "Options_CheckUnknownFilesLabel";
            this.Options_CheckUnknownFilesLabel.Size = new System.Drawing.Size(41, 13);
            this.Options_CheckUnknownFilesLabel.TabIndex = 0;
            this.Options_CheckUnknownFilesLabel.Text = "label1";
            // 
            // Options_CheckNewMangaChaptersLabel
            // 
            this.Options_CheckNewMangaChaptersLabel.AutoSize = true;
            this.Options_CheckNewMangaChaptersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_CheckNewMangaChaptersLabel.Location = new System.Drawing.Point(6, 292);
            this.Options_CheckNewMangaChaptersLabel.Name = "Options_CheckNewMangaChaptersLabel";
            this.Options_CheckNewMangaChaptersLabel.Size = new System.Drawing.Size(41, 13);
            this.Options_CheckNewMangaChaptersLabel.TabIndex = 0;
            this.Options_CheckNewMangaChaptersLabel.Text = "label1";
            // 
            // Options_DeleteDbLabel
            // 
            this.Options_DeleteDbLabel.AutoSize = true;
            this.Options_DeleteDbLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_DeleteDbLabel.Location = new System.Drawing.Point(6, 264);
            this.Options_DeleteDbLabel.Name = "Options_DeleteDbLabel";
            this.Options_DeleteDbLabel.Size = new System.Drawing.Size(41, 13);
            this.Options_DeleteDbLabel.TabIndex = 0;
            this.Options_DeleteDbLabel.Text = "label1";
            // 
            // Options_ForceDbUpdateLabel
            // 
            this.Options_ForceDbUpdateLabel.AutoSize = true;
            this.Options_ForceDbUpdateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_ForceDbUpdateLabel.Location = new System.Drawing.Point(6, 235);
            this.Options_ForceDbUpdateLabel.Name = "Options_ForceDbUpdateLabel";
            this.Options_ForceDbUpdateLabel.Size = new System.Drawing.Size(41, 13);
            this.Options_ForceDbUpdateLabel.TabIndex = 0;
            this.Options_ForceDbUpdateLabel.Text = "label1";
            // 
            // Options_RestoreBackupLabel
            // 
            this.Options_RestoreBackupLabel.AutoSize = true;
            this.Options_RestoreBackupLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_RestoreBackupLabel.Location = new System.Drawing.Point(6, 206);
            this.Options_RestoreBackupLabel.Name = "Options_RestoreBackupLabel";
            this.Options_RestoreBackupLabel.Size = new System.Drawing.Size(41, 13);
            this.Options_RestoreBackupLabel.TabIndex = 0;
            this.Options_RestoreBackupLabel.Text = "label1";
            // 
            // Options_CompactAndRepairDbLabel
            // 
            this.Options_CompactAndRepairDbLabel.AutoSize = true;
            this.Options_CompactAndRepairDbLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_CompactAndRepairDbLabel.Location = new System.Drawing.Point(6, 148);
            this.Options_CompactAndRepairDbLabel.Name = "Options_CompactAndRepairDbLabel";
            this.Options_CompactAndRepairDbLabel.Size = new System.Drawing.Size(41, 13);
            this.Options_CompactAndRepairDbLabel.TabIndex = 0;
            this.Options_CompactAndRepairDbLabel.Text = "label1";
            // 
            // Options_CreateBackupLabel
            // 
            this.Options_CreateBackupLabel.AutoSize = true;
            this.Options_CreateBackupLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_CreateBackupLabel.Location = new System.Drawing.Point(6, 177);
            this.Options_CreateBackupLabel.Name = "Options_CreateBackupLabel";
            this.Options_CreateBackupLabel.Size = new System.Drawing.Size(41, 13);
            this.Options_CreateBackupLabel.TabIndex = 0;
            this.Options_CreateBackupLabel.Text = "label1";
            // 
            // Options_DeleteDuplicatesLabel
            // 
            this.Options_DeleteDuplicatesLabel.AutoSize = true;
            this.Options_DeleteDuplicatesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_DeleteDuplicatesLabel.Location = new System.Drawing.Point(6, 119);
            this.Options_DeleteDuplicatesLabel.Name = "Options_DeleteDuplicatesLabel";
            this.Options_DeleteDuplicatesLabel.Size = new System.Drawing.Size(41, 13);
            this.Options_DeleteDuplicatesLabel.TabIndex = 0;
            this.Options_DeleteDuplicatesLabel.Text = "label1";
            // 
            // Options_DownloadAllFilesLabel
            // 
            this.Options_DownloadAllFilesLabel.AutoSize = true;
            this.Options_DownloadAllFilesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_DownloadAllFilesLabel.Location = new System.Drawing.Point(6, 90);
            this.Options_DownloadAllFilesLabel.Name = "Options_DownloadAllFilesLabel";
            this.Options_DownloadAllFilesLabel.Size = new System.Drawing.Size(41, 13);
            this.Options_DownloadAllFilesLabel.TabIndex = 0;
            this.Options_DownloadAllFilesLabel.Text = "label1";
            // 
            // Options_DownloadAllAnimeEpisodesLabel
            // 
            this.Options_DownloadAllAnimeEpisodesLabel.AutoSize = true;
            this.Options_DownloadAllAnimeEpisodesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_DownloadAllAnimeEpisodesLabel.Location = new System.Drawing.Point(6, 61);
            this.Options_DownloadAllAnimeEpisodesLabel.Name = "Options_DownloadAllAnimeEpisodesLabel";
            this.Options_DownloadAllAnimeEpisodesLabel.Size = new System.Drawing.Size(41, 13);
            this.Options_DownloadAllAnimeEpisodesLabel.TabIndex = 0;
            this.Options_DownloadAllAnimeEpisodesLabel.Text = "label1";
            // 
            // Options_GR03
            // 
            this.Options_GR03.Controls.Add(this.Options_Color01);
            this.Options_GR03.Controls.Add(this.Options_Color02);
            this.Options_GR03.Controls.Add(this.Options_Color03);
            this.Options_GR03.Controls.Add(this.Options_Color04);
            this.Options_GR03.Controls.Add(this.Options_Color10);
            this.Options_GR03.Controls.Add(this.Options_Color05);
            this.Options_GR03.Controls.Add(this.Options_Color06);
            this.Options_GR03.Controls.Add(this.Options_Color07);
            this.Options_GR03.Controls.Add(this.Options_Color09);
            this.Options_GR03.Controls.Add(this.Options_Color08);
            this.Options_GR03.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_GR03.Location = new System.Drawing.Point(604, 214);
            this.Options_GR03.Margin = new System.Windows.Forms.Padding(10);
            this.Options_GR03.Name = "Options_GR03";
            this.Options_GR03.Size = new System.Drawing.Size(476, 63);
            this.Options_GR03.TabIndex = 6;
            this.Options_GR03.TabStop = false;
            this.Options_GR03.Text = "groupBox1";
            // 
            // Options_Color01
            // 
            this.Options_Color01.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(234)))), ((int)(((byte)(252)))));
            this.Options_Color01.Location = new System.Drawing.Point(161, 19);
            this.Options_Color01.Name = "Options_Color01";
            this.Options_Color01.Size = new System.Drawing.Size(23, 23);
            this.Options_Color01.TabIndex = 0;
            this.Options_Color01.UseVisualStyleBackColor = false;
            this.Options_Color01.Click += new System.EventHandler(this.Options_Color01_Click);
            // 
            // Options_Color02
            // 
            this.Options_Color02.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(254)))));
            this.Options_Color02.Location = new System.Drawing.Point(190, 19);
            this.Options_Color02.Name = "Options_Color02";
            this.Options_Color02.Size = new System.Drawing.Size(23, 23);
            this.Options_Color02.TabIndex = 0;
            this.Options_Color02.UseVisualStyleBackColor = false;
            this.Options_Color02.Click += new System.EventHandler(this.Options_Color01_Click);
            // 
            // Options_Color03
            // 
            this.Options_Color03.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(237)))), ((int)(((byte)(182)))));
            this.Options_Color03.Location = new System.Drawing.Point(218, 19);
            this.Options_Color03.Name = "Options_Color03";
            this.Options_Color03.Size = new System.Drawing.Size(23, 23);
            this.Options_Color03.TabIndex = 0;
            this.Options_Color03.UseVisualStyleBackColor = false;
            this.Options_Color03.Click += new System.EventHandler(this.Options_Color01_Click);
            // 
            // Options_Color04
            // 
            this.Options_Color04.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Options_Color04.Location = new System.Drawing.Point(247, 19);
            this.Options_Color04.Name = "Options_Color04";
            this.Options_Color04.Size = new System.Drawing.Size(23, 23);
            this.Options_Color04.TabIndex = 0;
            this.Options_Color04.UseVisualStyleBackColor = false;
            this.Options_Color04.Click += new System.EventHandler(this.Options_Color01_Click);
            // 
            // Options_Color10
            // 
            this.Options_Color10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(219)))), ((int)(((byte)(58)))));
            this.Options_Color10.Location = new System.Drawing.Point(421, 19);
            this.Options_Color10.Name = "Options_Color10";
            this.Options_Color10.Size = new System.Drawing.Size(23, 23);
            this.Options_Color10.TabIndex = 0;
            this.Options_Color10.UseVisualStyleBackColor = false;
            this.Options_Color10.Click += new System.EventHandler(this.Options_Color01_Click);
            // 
            // Options_Color05
            // 
            this.Options_Color05.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Options_Color05.Location = new System.Drawing.Point(276, 19);
            this.Options_Color05.Name = "Options_Color05";
            this.Options_Color05.Size = new System.Drawing.Size(23, 23);
            this.Options_Color05.TabIndex = 0;
            this.Options_Color05.UseVisualStyleBackColor = false;
            this.Options_Color05.Click += new System.EventHandler(this.Options_Color01_Click);
            // 
            // Options_Color06
            // 
            this.Options_Color06.BackColor = System.Drawing.Color.Black;
            this.Options_Color06.Location = new System.Drawing.Point(305, 19);
            this.Options_Color06.Name = "Options_Color06";
            this.Options_Color06.Size = new System.Drawing.Size(23, 23);
            this.Options_Color06.TabIndex = 0;
            this.Options_Color06.UseVisualStyleBackColor = false;
            this.Options_Color06.Click += new System.EventHandler(this.Options_Color01_Click);
            // 
            // Options_Color07
            // 
            this.Options_Color07.BackColor = System.Drawing.Color.Black;
            this.Options_Color07.Location = new System.Drawing.Point(334, 19);
            this.Options_Color07.Name = "Options_Color07";
            this.Options_Color07.Size = new System.Drawing.Size(23, 23);
            this.Options_Color07.TabIndex = 0;
            this.Options_Color07.UseVisualStyleBackColor = false;
            this.Options_Color07.Click += new System.EventHandler(this.Options_Color01_Click);
            // 
            // Options_Color09
            // 
            this.Options_Color09.BackColor = System.Drawing.Color.White;
            this.Options_Color09.Location = new System.Drawing.Point(392, 19);
            this.Options_Color09.Name = "Options_Color09";
            this.Options_Color09.Size = new System.Drawing.Size(23, 23);
            this.Options_Color09.TabIndex = 0;
            this.Options_Color09.UseVisualStyleBackColor = false;
            this.Options_Color09.Click += new System.EventHandler(this.Options_Color01_Click);
            // 
            // Options_Color08
            // 
            this.Options_Color08.BackColor = System.Drawing.Color.White;
            this.Options_Color08.Location = new System.Drawing.Point(363, 19);
            this.Options_Color08.Name = "Options_Color08";
            this.Options_Color08.Size = new System.Drawing.Size(23, 23);
            this.Options_Color08.TabIndex = 0;
            this.Options_Color08.UseVisualStyleBackColor = false;
            this.Options_Color08.Click += new System.EventHandler(this.Options_Color01_Click);
            // 
            // Options_GR02
            // 
            this.Options_GR02.Controls.Add(this.Options_SaveSettingsOnExitCheckBox);
            this.Options_GR02.Controls.Add(this.Options_DetectMyListStatusCheckBox);
            this.Options_GR02.Controls.Add(this.Options_ShowAdultOnWelcomeScreenCheckBox);
            this.Options_GR02.Controls.Add(this.Options_MinimizeToTrayCheckBox);
            this.Options_GR02.Controls.Add(this.Options_SaveLogsToFilesCheckBox);
            this.Options_GR02.Controls.Add(this.Options_AddSameFilesMultipleTimesCheckBox);
            this.Options_GR02.Controls.Add(this.Options_FlatStyleCheckBox);
            this.Options_GR02.Controls.Add(this.Options_DontGenerateWelcomeSceenCheckBox);
            this.Options_GR02.Controls.Add(this.Options_ClassicFolderSelectDialogCheckBox);
            this.Options_GR02.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_GR02.Location = new System.Drawing.Point(13, 363);
            this.Options_GR02.Margin = new System.Windows.Forms.Padding(10);
            this.Options_GR02.Name = "Options_GR02";
            this.Options_GR02.Size = new System.Drawing.Size(476, 351);
            this.Options_GR02.TabIndex = 6;
            this.Options_GR02.TabStop = false;
            this.Options_GR02.Text = "groupBox1";
            // 
            // Options_SaveSettingsOnExitCheckBox
            // 
            this.Options_SaveSettingsOnExitCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_SaveSettingsOnExitCheckBox.ForeColor = System.Drawing.Color.Black;
            this.Options_SaveSettingsOnExitCheckBox.Location = new System.Drawing.Point(9, 19);
            this.Options_SaveSettingsOnExitCheckBox.Name = "Options_SaveSettingsOnExitCheckBox";
            this.Options_SaveSettingsOnExitCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Options_SaveSettingsOnExitCheckBox.Size = new System.Drawing.Size(435, 17);
            this.Options_SaveSettingsOnExitCheckBox.TabIndex = 0;
            this.Options_SaveSettingsOnExitCheckBox.Text = "checkBox3";
            this.Options_SaveSettingsOnExitCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Options_SaveSettingsOnExitCheckBox.UseVisualStyleBackColor = true;
            // 
            // Options_DetectMyListStatusCheckBox
            // 
            this.Options_DetectMyListStatusCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_DetectMyListStatusCheckBox.ForeColor = System.Drawing.Color.Black;
            this.Options_DetectMyListStatusCheckBox.Location = new System.Drawing.Point(9, 226);
            this.Options_DetectMyListStatusCheckBox.Name = "Options_DetectMyListStatusCheckBox";
            this.Options_DetectMyListStatusCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Options_DetectMyListStatusCheckBox.Size = new System.Drawing.Size(435, 17);
            this.Options_DetectMyListStatusCheckBox.TabIndex = 0;
            this.Options_DetectMyListStatusCheckBox.Text = "checkBox3";
            this.Options_DetectMyListStatusCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Options_DetectMyListStatusCheckBox.UseVisualStyleBackColor = true;
            // 
            // Options_ShowAdultOnWelcomeScreenCheckBox
            // 
            this.Options_ShowAdultOnWelcomeScreenCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_ShowAdultOnWelcomeScreenCheckBox.ForeColor = System.Drawing.Color.Black;
            this.Options_ShowAdultOnWelcomeScreenCheckBox.Location = new System.Drawing.Point(9, 180);
            this.Options_ShowAdultOnWelcomeScreenCheckBox.Name = "Options_ShowAdultOnWelcomeScreenCheckBox";
            this.Options_ShowAdultOnWelcomeScreenCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Options_ShowAdultOnWelcomeScreenCheckBox.Size = new System.Drawing.Size(435, 17);
            this.Options_ShowAdultOnWelcomeScreenCheckBox.TabIndex = 0;
            this.Options_ShowAdultOnWelcomeScreenCheckBox.Text = "checkBox3";
            this.Options_ShowAdultOnWelcomeScreenCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Options_ShowAdultOnWelcomeScreenCheckBox.UseVisualStyleBackColor = true;
            // 
            // Options_MinimizeToTrayCheckBox
            // 
            this.Options_MinimizeToTrayCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_MinimizeToTrayCheckBox.ForeColor = System.Drawing.Color.Black;
            this.Options_MinimizeToTrayCheckBox.Location = new System.Drawing.Point(9, 111);
            this.Options_MinimizeToTrayCheckBox.Name = "Options_MinimizeToTrayCheckBox";
            this.Options_MinimizeToTrayCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Options_MinimizeToTrayCheckBox.Size = new System.Drawing.Size(435, 17);
            this.Options_MinimizeToTrayCheckBox.TabIndex = 0;
            this.Options_MinimizeToTrayCheckBox.Text = "checkBox3";
            this.Options_MinimizeToTrayCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Options_MinimizeToTrayCheckBox.UseVisualStyleBackColor = true;
            // 
            // Options_SaveLogsToFilesCheckBox
            // 
            this.Options_SaveLogsToFilesCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_SaveLogsToFilesCheckBox.ForeColor = System.Drawing.Color.Black;
            this.Options_SaveLogsToFilesCheckBox.Location = new System.Drawing.Point(9, 318);
            this.Options_SaveLogsToFilesCheckBox.Name = "Options_SaveLogsToFilesCheckBox";
            this.Options_SaveLogsToFilesCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Options_SaveLogsToFilesCheckBox.Size = new System.Drawing.Size(435, 17);
            this.Options_SaveLogsToFilesCheckBox.TabIndex = 0;
            this.Options_SaveLogsToFilesCheckBox.Text = "checkBox3";
            this.Options_SaveLogsToFilesCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Options_SaveLogsToFilesCheckBox.UseVisualStyleBackColor = true;
            this.Options_SaveLogsToFilesCheckBox.CheckedChanged += new System.EventHandler(this.Options_CH21_CheckedChanged);
            // 
            // Options_AddSameFilesMultipleTimesCheckBox
            // 
            this.Options_AddSameFilesMultipleTimesCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_AddSameFilesMultipleTimesCheckBox.ForeColor = System.Drawing.Color.Black;
            this.Options_AddSameFilesMultipleTimesCheckBox.Location = new System.Drawing.Point(9, 272);
            this.Options_AddSameFilesMultipleTimesCheckBox.Name = "Options_AddSameFilesMultipleTimesCheckBox";
            this.Options_AddSameFilesMultipleTimesCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Options_AddSameFilesMultipleTimesCheckBox.Size = new System.Drawing.Size(435, 17);
            this.Options_AddSameFilesMultipleTimesCheckBox.TabIndex = 0;
            this.Options_AddSameFilesMultipleTimesCheckBox.Text = "checkBox3";
            this.Options_AddSameFilesMultipleTimesCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Options_AddSameFilesMultipleTimesCheckBox.UseVisualStyleBackColor = true;
            // 
            // Options_FlatStyleCheckBox
            // 
            this.Options_FlatStyleCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_FlatStyleCheckBox.ForeColor = System.Drawing.Color.Black;
            this.Options_FlatStyleCheckBox.Location = new System.Drawing.Point(9, 88);
            this.Options_FlatStyleCheckBox.Name = "Options_FlatStyleCheckBox";
            this.Options_FlatStyleCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Options_FlatStyleCheckBox.Size = new System.Drawing.Size(435, 17);
            this.Options_FlatStyleCheckBox.TabIndex = 0;
            this.Options_FlatStyleCheckBox.Text = "checkBox3";
            this.Options_FlatStyleCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Options_FlatStyleCheckBox.UseVisualStyleBackColor = true;
            this.Options_FlatStyleCheckBox.CheckedChanged += new System.EventHandler(this.Options_CH17_CheckedChanged);
            // 
            // Options_DontGenerateWelcomeSceenCheckBox
            // 
            this.Options_DontGenerateWelcomeSceenCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_DontGenerateWelcomeSceenCheckBox.ForeColor = System.Drawing.Color.Black;
            this.Options_DontGenerateWelcomeSceenCheckBox.Location = new System.Drawing.Point(9, 157);
            this.Options_DontGenerateWelcomeSceenCheckBox.Name = "Options_DontGenerateWelcomeSceenCheckBox";
            this.Options_DontGenerateWelcomeSceenCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Options_DontGenerateWelcomeSceenCheckBox.Size = new System.Drawing.Size(435, 17);
            this.Options_DontGenerateWelcomeSceenCheckBox.TabIndex = 0;
            this.Options_DontGenerateWelcomeSceenCheckBox.Text = "checkBox3";
            this.Options_DontGenerateWelcomeSceenCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Options_DontGenerateWelcomeSceenCheckBox.UseVisualStyleBackColor = true;
            this.Options_DontGenerateWelcomeSceenCheckBox.CheckedChanged += new System.EventHandler(this.Options_CH17_CheckedChanged);
            // 
            // Options_ClassicFolderSelectDialogCheckBox
            // 
            this.Options_ClassicFolderSelectDialogCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_ClassicFolderSelectDialogCheckBox.ForeColor = System.Drawing.Color.Black;
            this.Options_ClassicFolderSelectDialogCheckBox.Location = new System.Drawing.Point(9, 65);
            this.Options_ClassicFolderSelectDialogCheckBox.Name = "Options_ClassicFolderSelectDialogCheckBox";
            this.Options_ClassicFolderSelectDialogCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Options_ClassicFolderSelectDialogCheckBox.Size = new System.Drawing.Size(435, 17);
            this.Options_ClassicFolderSelectDialogCheckBox.TabIndex = 0;
            this.Options_ClassicFolderSelectDialogCheckBox.Text = "checkBox3";
            this.Options_ClassicFolderSelectDialogCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Options_ClassicFolderSelectDialogCheckBox.UseVisualStyleBackColor = true;
            // 
            // Watcher_List
            // 
            this.Watcher_List.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Watcher_List.ForeColor = System.Drawing.Color.Black;
            this.Watcher_List.FormattingEnabled = true;
            this.Watcher_List.Location = new System.Drawing.Point(153, 302);
            this.Watcher_List.Name = "Watcher_List";
            this.Watcher_List.Size = new System.Drawing.Size(304, 21);
            this.Watcher_List.TabIndex = 5;
            // 
            // Options_GR01
            // 
            this.Options_GR01.Controls.Add(this.Options_WatchedCheckbox);
            this.Options_GR01.Controls.Add(this.Options_OtherLabel);
            this.Options_GR01.Controls.Add(this.Options_StorageLabel);
            this.Options_GR01.Controls.Add(this.Options_SourceLabel);
            this.Options_GR01.Controls.Add(this.Options_StatusLabel);
            this.Options_GR01.Controls.Add(this.Options_MylistOther);
            this.Options_GR01.Controls.Add(this.Options_MylistStorage);
            this.Options_GR01.Controls.Add(this.Options_AutoAddToMyListCheckBox);
            this.Options_GR01.Controls.Add(this.Options_MylistSource);
            this.Options_GR01.Controls.Add(this.Options_MylistState);
            this.Options_GR01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_GR01.ForeColor = System.Drawing.Color.Black;
            this.Options_GR01.Location = new System.Drawing.Point(604, 13);
            this.Options_GR01.Margin = new System.Windows.Forms.Padding(10);
            this.Options_GR01.Name = "Options_GR01";
            this.Options_GR01.Size = new System.Drawing.Size(476, 181);
            this.Options_GR01.TabIndex = 0;
            this.Options_GR01.TabStop = false;
            this.Options_GR01.Text = "groupBox2";
            // 
            // Options_WatchedCheckbox
            // 
            this.Options_WatchedCheckbox.ForeColor = System.Drawing.Color.Black;
            this.Options_WatchedCheckbox.Location = new System.Drawing.Point(9, 124);
            this.Options_WatchedCheckbox.Name = "Options_WatchedCheckbox";
            this.Options_WatchedCheckbox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Options_WatchedCheckbox.Size = new System.Drawing.Size(435, 17);
            this.Options_WatchedCheckbox.TabIndex = 0;
            this.Options_WatchedCheckbox.Text = "checkBox1";
            this.Options_WatchedCheckbox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Options_WatchedCheckbox.UseVisualStyleBackColor = true;
            // 
            // Options_OtherLabel
            // 
            this.Options_OtherLabel.AutoSize = true;
            this.Options_OtherLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_OtherLabel.ForeColor = System.Drawing.Color.Black;
            this.Options_OtherLabel.Location = new System.Drawing.Point(6, 101);
            this.Options_OtherLabel.Name = "Options_OtherLabel";
            this.Options_OtherLabel.Size = new System.Drawing.Size(46, 13);
            this.Options_OtherLabel.TabIndex = 0;
            this.Options_OtherLabel.Text = "Nadpis";
            // 
            // Options_StorageLabel
            // 
            this.Options_StorageLabel.AutoSize = true;
            this.Options_StorageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_StorageLabel.ForeColor = System.Drawing.Color.Black;
            this.Options_StorageLabel.Location = new System.Drawing.Point(6, 75);
            this.Options_StorageLabel.Name = "Options_StorageLabel";
            this.Options_StorageLabel.Size = new System.Drawing.Size(46, 13);
            this.Options_StorageLabel.TabIndex = 0;
            this.Options_StorageLabel.Text = "Nadpis";
            // 
            // Options_SourceLabel
            // 
            this.Options_SourceLabel.AutoSize = true;
            this.Options_SourceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_SourceLabel.ForeColor = System.Drawing.Color.Black;
            this.Options_SourceLabel.Location = new System.Drawing.Point(6, 49);
            this.Options_SourceLabel.Name = "Options_SourceLabel";
            this.Options_SourceLabel.Size = new System.Drawing.Size(46, 13);
            this.Options_SourceLabel.TabIndex = 0;
            this.Options_SourceLabel.Text = "Nadpis";
            // 
            // Options_StatusLabel
            // 
            this.Options_StatusLabel.AutoSize = true;
            this.Options_StatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_StatusLabel.ForeColor = System.Drawing.Color.Black;
            this.Options_StatusLabel.Location = new System.Drawing.Point(6, 22);
            this.Options_StatusLabel.Name = "Options_StatusLabel";
            this.Options_StatusLabel.Size = new System.Drawing.Size(46, 13);
            this.Options_StatusLabel.TabIndex = 0;
            this.Options_StatusLabel.Text = "Nadpis";
            // 
            // Options_MylistOther
            // 
            this.Options_MylistOther.BackColor = System.Drawing.Color.White;
            this.Options_MylistOther.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_MylistOther.ForeColor = System.Drawing.Color.Black;
            this.Options_MylistOther.Location = new System.Drawing.Point(140, 98);
            this.Options_MylistOther.Name = "Options_MylistOther";
            this.Options_MylistOther.Size = new System.Drawing.Size(304, 20);
            this.Options_MylistOther.TabIndex = 0;
            // 
            // Options_MylistStorage
            // 
            this.Options_MylistStorage.BackColor = System.Drawing.Color.White;
            this.Options_MylistStorage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_MylistStorage.ForeColor = System.Drawing.Color.Black;
            this.Options_MylistStorage.Location = new System.Drawing.Point(140, 72);
            this.Options_MylistStorage.Name = "Options_MylistStorage";
            this.Options_MylistStorage.Size = new System.Drawing.Size(304, 20);
            this.Options_MylistStorage.TabIndex = 0;
            // 
            // Options_AutoAddToMyListCheckBox
            // 
            this.Options_AutoAddToMyListCheckBox.ForeColor = System.Drawing.Color.Black;
            this.Options_AutoAddToMyListCheckBox.Location = new System.Drawing.Point(9, 147);
            this.Options_AutoAddToMyListCheckBox.Name = "Options_AutoAddToMyListCheckBox";
            this.Options_AutoAddToMyListCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Options_AutoAddToMyListCheckBox.Size = new System.Drawing.Size(435, 17);
            this.Options_AutoAddToMyListCheckBox.TabIndex = 0;
            this.Options_AutoAddToMyListCheckBox.Text = "checkBox1";
            this.Options_AutoAddToMyListCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Options_AutoAddToMyListCheckBox.UseVisualStyleBackColor = true;
            // 
            // Options_MylistSource
            // 
            this.Options_MylistSource.BackColor = System.Drawing.Color.White;
            this.Options_MylistSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_MylistSource.ForeColor = System.Drawing.Color.Black;
            this.Options_MylistSource.Location = new System.Drawing.Point(140, 46);
            this.Options_MylistSource.Name = "Options_MylistSource";
            this.Options_MylistSource.Size = new System.Drawing.Size(304, 20);
            this.Options_MylistSource.TabIndex = 0;
            // 
            // Options_MylistState
            // 
            this.Options_MylistState.BackColor = System.Drawing.Color.White;
            this.Options_MylistState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Options_MylistState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_MylistState.ForeColor = System.Drawing.Color.Black;
            this.Options_MylistState.FormattingEnabled = true;
            this.Options_MylistState.Items.AddRange(new object[] {
            "Unknown",
            "HDD",
            "CD/DVD",
            "Other"});
            this.Options_MylistState.Location = new System.Drawing.Point(140, 19);
            this.Options_MylistState.Name = "Options_MylistState";
            this.Options_MylistState.Size = new System.Drawing.Size(304, 21);
            this.Options_MylistState.TabIndex = 0;
            // 
            // Options_NetworkLabel
            // 
            this.Options_NetworkLabel.AutoSize = true;
            this.Options_NetworkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_NetworkLabel.ForeColor = System.Drawing.Color.Black;
            this.Options_NetworkLabel.Location = new System.Drawing.Point(10, 17);
            this.Options_NetworkLabel.Name = "Options_NetworkLabel";
            this.Options_NetworkLabel.Size = new System.Drawing.Size(46, 13);
            this.Options_NetworkLabel.TabIndex = 0;
            this.Options_NetworkLabel.Text = "Nadpis";
            // 
            // Watcher_CH01
            // 
            this.Watcher_CH01.AutoSize = true;
            this.Watcher_CH01.ForeColor = System.Drawing.Color.Black;
            this.Watcher_CH01.Location = new System.Drawing.Point(517, 306);
            this.Watcher_CH01.Name = "Watcher_CH01";
            this.Watcher_CH01.Size = new System.Drawing.Size(80, 17);
            this.Watcher_CH01.TabIndex = 2;
            this.Watcher_CH01.Text = "checkBox1";
            this.Watcher_CH01.UseVisualStyleBackColor = true;
            // 
            // Options_ServerLabel
            // 
            this.Options_ServerLabel.AutoSize = true;
            this.Options_ServerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_ServerLabel.ForeColor = System.Drawing.Color.Black;
            this.Options_ServerLabel.Location = new System.Drawing.Point(10, 70);
            this.Options_ServerLabel.Name = "Options_ServerLabel";
            this.Options_ServerLabel.Size = new System.Drawing.Size(46, 13);
            this.Options_ServerLabel.TabIndex = 0;
            this.Options_ServerLabel.Text = "Nadpis";
            // 
            // Options_Network
            // 
            this.Options_Network.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Options_Network.ForeColor = System.Drawing.Color.Black;
            this.Options_Network.FormattingEnabled = true;
            this.Options_Network.Location = new System.Drawing.Point(153, 14);
            this.Options_Network.Name = "Options_Network";
            this.Options_Network.Size = new System.Drawing.Size(304, 21);
            this.Options_Network.TabIndex = 0;
            // 
            // Options_Delay
            // 
            this.Options_Delay.BackColor = System.Drawing.Color.White;
            this.Options_Delay.ForeColor = System.Drawing.Color.Black;
            this.Options_Delay.Location = new System.Drawing.Point(153, 197);
            this.Options_Delay.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.Options_Delay.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.Options_Delay.Name = "Options_Delay";
            this.Options_Delay.Size = new System.Drawing.Size(304, 20);
            this.Options_Delay.TabIndex = 0;
            this.Options_Delay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Options_Delay.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // Options_Password
            // 
            this.Options_Password.BackColor = System.Drawing.Color.White;
            this.Options_Password.ForeColor = System.Drawing.Color.Black;
            this.Options_Password.Location = new System.Drawing.Point(153, 145);
            this.Options_Password.Name = "Options_Password";
            this.Options_Password.PasswordChar = '*';
            this.Options_Password.Size = new System.Drawing.Size(304, 20);
            this.Options_Password.TabIndex = 0;
            this.Options_Password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Options_Reset
            // 
            this.Options_Reset.BackColor = System.Drawing.Color.White;
            this.Options_Reset.ForeColor = System.Drawing.Color.Black;
            this.Options_Reset.Location = new System.Drawing.Point(153, 223);
            this.Options_Reset.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.Options_Reset.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Options_Reset.Name = "Options_Reset";
            this.Options_Reset.Size = new System.Drawing.Size(304, 20);
            this.Options_Reset.TabIndex = 0;
            this.Options_Reset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Options_Reset.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // Options_ServerPort
            // 
            this.Options_ServerPort.BackColor = System.Drawing.Color.White;
            this.Options_ServerPort.ForeColor = System.Drawing.Color.Black;
            this.Options_ServerPort.Location = new System.Drawing.Point(153, 93);
            this.Options_ServerPort.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.Options_ServerPort.Minimum = new decimal(new int[] {
            1025,
            0,
            0,
            0});
            this.Options_ServerPort.Name = "Options_ServerPort";
            this.Options_ServerPort.Size = new System.Drawing.Size(304, 20);
            this.Options_ServerPort.TabIndex = 0;
            this.Options_ServerPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Options_ServerPort.Value = new decimal(new int[] {
            9000,
            0,
            0,
            0});
            // 
            // Options_PortLabel
            // 
            this.Options_PortLabel.AutoSize = true;
            this.Options_PortLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_PortLabel.ForeColor = System.Drawing.Color.Black;
            this.Options_PortLabel.Location = new System.Drawing.Point(10, 96);
            this.Options_PortLabel.Name = "Options_PortLabel";
            this.Options_PortLabel.Size = new System.Drawing.Size(46, 13);
            this.Options_PortLabel.TabIndex = 0;
            this.Options_PortLabel.Text = "Nadpis";
            // 
            // Options_Backup
            // 
            this.Options_Backup.BackColor = System.Drawing.Color.White;
            this.Options_Backup.ForeColor = System.Drawing.Color.Black;
            this.Options_Backup.Location = new System.Drawing.Point(153, 249);
            this.Options_Backup.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.Options_Backup.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Options_Backup.Name = "Options_Backup";
            this.Options_Backup.Size = new System.Drawing.Size(304, 20);
            this.Options_Backup.TabIndex = 0;
            this.Options_Backup.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Options_Backup.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // Options_LocalPort
            // 
            this.Options_LocalPort.BackColor = System.Drawing.Color.White;
            this.Options_LocalPort.ForeColor = System.Drawing.Color.Black;
            this.Options_LocalPort.Location = new System.Drawing.Point(153, 41);
            this.Options_LocalPort.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.Options_LocalPort.Minimum = new decimal(new int[] {
            1025,
            0,
            0,
            0});
            this.Options_LocalPort.Name = "Options_LocalPort";
            this.Options_LocalPort.Size = new System.Drawing.Size(304, 20);
            this.Options_LocalPort.TabIndex = 0;
            this.Options_LocalPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Options_LocalPort.Value = new decimal(new int[] {
            45678,
            0,
            0,
            0});
            // 
            // Options_User
            // 
            this.Options_User.BackColor = System.Drawing.Color.White;
            this.Options_User.ForeColor = System.Drawing.Color.Black;
            this.Options_User.Location = new System.Drawing.Point(153, 119);
            this.Options_User.Name = "Options_User";
            this.Options_User.ReadOnly = true;
            this.Options_User.Size = new System.Drawing.Size(304, 20);
            this.Options_User.TabIndex = 0;
            this.Options_User.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Options_UserNameLabel
            // 
            this.Options_UserNameLabel.AutoSize = true;
            this.Options_UserNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_UserNameLabel.ForeColor = System.Drawing.Color.Black;
            this.Options_UserNameLabel.Location = new System.Drawing.Point(10, 122);
            this.Options_UserNameLabel.Name = "Options_UserNameLabel";
            this.Options_UserNameLabel.Size = new System.Drawing.Size(46, 13);
            this.Options_UserNameLabel.TabIndex = 0;
            this.Options_UserNameLabel.Text = "Nadpis";
            // 
            // Options_Hash_WatcherLabel
            // 
            this.Options_Hash_WatcherLabel.AutoSize = true;
            this.Options_Hash_WatcherLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_Hash_WatcherLabel.ForeColor = System.Drawing.Color.Black;
            this.Options_Hash_WatcherLabel.Location = new System.Drawing.Point(10, 305);
            this.Options_Hash_WatcherLabel.Name = "Options_Hash_WatcherLabel";
            this.Options_Hash_WatcherLabel.Size = new System.Drawing.Size(46, 13);
            this.Options_Hash_WatcherLabel.TabIndex = 0;
            this.Options_Hash_WatcherLabel.Text = "Nadpis";
            // 
            // Options_LocalPortLabel
            // 
            this.Options_LocalPortLabel.AutoSize = true;
            this.Options_LocalPortLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_LocalPortLabel.ForeColor = System.Drawing.Color.Black;
            this.Options_LocalPortLabel.Location = new System.Drawing.Point(10, 43);
            this.Options_LocalPortLabel.Name = "Options_LocalPortLabel";
            this.Options_LocalPortLabel.Size = new System.Drawing.Size(46, 13);
            this.Options_LocalPortLabel.TabIndex = 0;
            this.Options_LocalPortLabel.Text = "Nadpis";
            // 
            // Options_PasswordLabel
            // 
            this.Options_PasswordLabel.AutoSize = true;
            this.Options_PasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_PasswordLabel.ForeColor = System.Drawing.Color.Black;
            this.Options_PasswordLabel.Location = new System.Drawing.Point(10, 148);
            this.Options_PasswordLabel.Name = "Options_PasswordLabel";
            this.Options_PasswordLabel.Size = new System.Drawing.Size(46, 13);
            this.Options_PasswordLabel.TabIndex = 0;
            this.Options_PasswordLabel.Text = "Nadpis";
            // 
            // Options_FileTypesLabel
            // 
            this.Options_FileTypesLabel.AutoSize = true;
            this.Options_FileTypesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_FileTypesLabel.ForeColor = System.Drawing.Color.Black;
            this.Options_FileTypesLabel.Location = new System.Drawing.Point(10, 279);
            this.Options_FileTypesLabel.Name = "Options_FileTypesLabel";
            this.Options_FileTypesLabel.Size = new System.Drawing.Size(46, 13);
            this.Options_FileTypesLabel.TabIndex = 0;
            this.Options_FileTypesLabel.Text = "Nadpis";
            // 
            // Options_TimeoutLabel
            // 
            this.Options_TimeoutLabel.AutoSize = true;
            this.Options_TimeoutLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_TimeoutLabel.ForeColor = System.Drawing.Color.Black;
            this.Options_TimeoutLabel.Location = new System.Drawing.Point(10, 173);
            this.Options_TimeoutLabel.Name = "Options_TimeoutLabel";
            this.Options_TimeoutLabel.Size = new System.Drawing.Size(46, 13);
            this.Options_TimeoutLabel.TabIndex = 0;
            this.Options_TimeoutLabel.Text = "Nadpis";
            // 
            // Options_DbBackupCountLabel
            // 
            this.Options_DbBackupCountLabel.AutoSize = true;
            this.Options_DbBackupCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_DbBackupCountLabel.ForeColor = System.Drawing.Color.Black;
            this.Options_DbBackupCountLabel.Location = new System.Drawing.Point(10, 251);
            this.Options_DbBackupCountLabel.Name = "Options_DbBackupCountLabel";
            this.Options_DbBackupCountLabel.Size = new System.Drawing.Size(46, 13);
            this.Options_DbBackupCountLabel.TabIndex = 0;
            this.Options_DbBackupCountLabel.Text = "Nadpis";
            // 
            // Options_Language
            // 
            this.Options_Language.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Options_Language.ForeColor = System.Drawing.Color.Black;
            this.Options_Language.FormattingEnabled = true;
            this.Options_Language.Items.AddRange(new object[] {
            "en-US",
            "cs-CZ"});
            this.Options_Language.Location = new System.Drawing.Point(153, 329);
            this.Options_Language.Name = "Options_Language";
            this.Options_Language.Size = new System.Drawing.Size(304, 21);
            this.Options_Language.TabIndex = 0;
            this.Options_Language.SelectedIndexChanged += new System.EventHandler(this.Options_Language_SelectedIndexChanged);
            // 
            // Options_TimeOut
            // 
            this.Options_TimeOut.BackColor = System.Drawing.Color.White;
            this.Options_TimeOut.ForeColor = System.Drawing.Color.Black;
            this.Options_TimeOut.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.Options_TimeOut.Location = new System.Drawing.Point(153, 171);
            this.Options_TimeOut.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.Options_TimeOut.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.Options_TimeOut.Name = "Options_TimeOut";
            this.Options_TimeOut.Size = new System.Drawing.Size(304, 20);
            this.Options_TimeOut.TabIndex = 0;
            this.Options_TimeOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Options_TimeOut.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // Options_DelayLabel
            // 
            this.Options_DelayLabel.AutoSize = true;
            this.Options_DelayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_DelayLabel.ForeColor = System.Drawing.Color.Black;
            this.Options_DelayLabel.Location = new System.Drawing.Point(10, 199);
            this.Options_DelayLabel.Name = "Options_DelayLabel";
            this.Options_DelayLabel.Size = new System.Drawing.Size(46, 13);
            this.Options_DelayLabel.TabIndex = 0;
            this.Options_DelayLabel.Text = "Nadpis";
            // 
            // Options_ResetCountLabel
            // 
            this.Options_ResetCountLabel.AutoSize = true;
            this.Options_ResetCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_ResetCountLabel.ForeColor = System.Drawing.Color.Black;
            this.Options_ResetCountLabel.Location = new System.Drawing.Point(10, 225);
            this.Options_ResetCountLabel.Name = "Options_ResetCountLabel";
            this.Options_ResetCountLabel.Size = new System.Drawing.Size(46, 13);
            this.Options_ResetCountLabel.TabIndex = 0;
            this.Options_ResetCountLabel.Text = "Nadpis";
            // 
            // Options_ServerName
            // 
            this.Options_ServerName.BackColor = System.Drawing.Color.White;
            this.Options_ServerName.ForeColor = System.Drawing.Color.Black;
            this.Options_ServerName.Location = new System.Drawing.Point(153, 67);
            this.Options_ServerName.Name = "Options_ServerName";
            this.Options_ServerName.Size = new System.Drawing.Size(304, 20);
            this.Options_ServerName.TabIndex = 0;
            this.Options_ServerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Options_ExtensionList
            // 
            this.Options_ExtensionList.ForeColor = System.Drawing.Color.Black;
            this.Options_ExtensionList.FormattingEnabled = true;
            this.Options_ExtensionList.Items.AddRange(new object[] {
            "en-US",
            "cs-CZ"});
            this.Options_ExtensionList.Location = new System.Drawing.Point(153, 275);
            this.Options_ExtensionList.Name = "Options_ExtensionList";
            this.Options_ExtensionList.Size = new System.Drawing.Size(304, 21);
            this.Options_ExtensionList.TabIndex = 0;
            this.Options_ExtensionList.SelectedIndexChanged += new System.EventHandler(this.Options_Language_SelectedIndexChanged);
            // 
            // MainTab_RulesPage
            // 
            this.MainTab_RulesPage.BackColor = System.Drawing.Color.White;
            this.MainTab_RulesPage.Controls.Add(this.Rules_DeleteSourceIfEmptyCheckBox);
            this.MainTab_RulesPage.Controls.Add(this.Rules_TagsButton);
            this.MainTab_RulesPage.Controls.Add(this.Rules_ReplaceExistingCheckBox);
            this.MainTab_RulesPage.Controls.Add(this.Rules_DontCopyToAnotherDiskCheckBox);
            this.MainTab_RulesPage.Controls.Add(this.Rules_AutomaticRenamingCheckBox);
            this.MainTab_RulesPage.Controls.Add(this.Rules_RulesForCharacterReplacingGroupBox);
            this.MainTab_RulesPage.Controls.Add(this.Rules_ExportInfoGroupBox);
            this.MainTab_RulesPage.Controls.Add(this.Rules_RulesForGeneratingDirectoriesGroupBox);
            this.MainTab_RulesPage.Controls.Add(this.Rules_RulesForFileRenamingGroupBox);
            this.MainTab_RulesPage.Location = new System.Drawing.Point(4, 22);
            this.MainTab_RulesPage.Name = "MainTab_RulesPage";
            this.MainTab_RulesPage.Padding = new System.Windows.Forms.Padding(3);
            this.MainTab_RulesPage.Size = new System.Drawing.Size(1119, 680);
            this.MainTab_RulesPage.TabIndex = 0;
            this.MainTab_RulesPage.Text = "2";
            this.MainTab_RulesPage.UseVisualStyleBackColor = true;
            // 
            // Rules_DeleteSourceIfEmptyCheckBox
            // 
            this.Rules_DeleteSourceIfEmptyCheckBox.AutoSize = true;
            this.Rules_DeleteSourceIfEmptyCheckBox.Location = new System.Drawing.Point(756, 15);
            this.Rules_DeleteSourceIfEmptyCheckBox.Name = "Rules_DeleteSourceIfEmptyCheckBox";
            this.Rules_DeleteSourceIfEmptyCheckBox.Size = new System.Drawing.Size(80, 17);
            this.Rules_DeleteSourceIfEmptyCheckBox.TabIndex = 1;
            this.Rules_DeleteSourceIfEmptyCheckBox.Text = "checkBox1";
            this.Rules_DeleteSourceIfEmptyCheckBox.UseVisualStyleBackColor = true;
            // 
            // Rules_TagsButton
            // 
            this.Rules_TagsButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Rules_TagsButton.ForeColor = System.Drawing.Color.Black;
            this.Rules_TagsButton.Location = new System.Drawing.Point(1006, 11);
            this.Rules_TagsButton.Name = "Rules_TagsButton";
            this.Rules_TagsButton.Size = new System.Drawing.Size(75, 23);
            this.Rules_TagsButton.TabIndex = 0;
            this.Rules_TagsButton.Text = "button1";
            this.Rules_TagsButton.UseVisualStyleBackColor = true;
            this.Rules_TagsButton.Click += new System.EventHandler(this.Rules_Tags_Click);
            // 
            // Rules_ReplaceExistingCheckBox
            // 
            this.Rules_ReplaceExistingCheckBox.AutoSize = true;
            this.Rules_ReplaceExistingCheckBox.ForeColor = System.Drawing.Color.Black;
            this.Rules_ReplaceExistingCheckBox.Location = new System.Drawing.Point(506, 15);
            this.Rules_ReplaceExistingCheckBox.Name = "Rules_ReplaceExistingCheckBox";
            this.Rules_ReplaceExistingCheckBox.Size = new System.Drawing.Size(80, 17);
            this.Rules_ReplaceExistingCheckBox.TabIndex = 0;
            this.Rules_ReplaceExistingCheckBox.Text = "checkBox3";
            this.Rules_ReplaceExistingCheckBox.UseVisualStyleBackColor = true;
            // 
            // Rules_DontCopyToAnotherDiskCheckBox
            // 
            this.Rules_DontCopyToAnotherDiskCheckBox.AutoSize = true;
            this.Rules_DontCopyToAnotherDiskCheckBox.ForeColor = System.Drawing.Color.Black;
            this.Rules_DontCopyToAnotherDiskCheckBox.Location = new System.Drawing.Point(256, 15);
            this.Rules_DontCopyToAnotherDiskCheckBox.Name = "Rules_DontCopyToAnotherDiskCheckBox";
            this.Rules_DontCopyToAnotherDiskCheckBox.Size = new System.Drawing.Size(80, 17);
            this.Rules_DontCopyToAnotherDiskCheckBox.TabIndex = 0;
            this.Rules_DontCopyToAnotherDiskCheckBox.Text = "checkBox2";
            this.Rules_DontCopyToAnotherDiskCheckBox.UseVisualStyleBackColor = true;
            // 
            // Rules_AutomaticRenamingCheckBox
            // 
            this.Rules_AutomaticRenamingCheckBox.AutoSize = true;
            this.Rules_AutomaticRenamingCheckBox.ForeColor = System.Drawing.Color.Black;
            this.Rules_AutomaticRenamingCheckBox.Location = new System.Drawing.Point(6, 15);
            this.Rules_AutomaticRenamingCheckBox.Name = "Rules_AutomaticRenamingCheckBox";
            this.Rules_AutomaticRenamingCheckBox.Size = new System.Drawing.Size(80, 17);
            this.Rules_AutomaticRenamingCheckBox.TabIndex = 0;
            this.Rules_AutomaticRenamingCheckBox.Text = "checkBox1";
            this.Rules_AutomaticRenamingCheckBox.UseVisualStyleBackColor = true;
            // 
            // Rules_RulesForCharacterReplacingGroupBox
            // 
            this.Rules_RulesForCharacterReplacingGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Rules_RulesForCharacterReplacingGroupBox.Controls.Add(this.Rules_Replace);
            this.Rules_RulesForCharacterReplacingGroupBox.Location = new System.Drawing.Point(6, 409);
            this.Rules_RulesForCharacterReplacingGroupBox.Name = "Rules_RulesForCharacterReplacingGroupBox";
            this.Rules_RulesForCharacterReplacingGroupBox.Size = new System.Drawing.Size(1098, 183);
            this.Rules_RulesForCharacterReplacingGroupBox.TabIndex = 0;
            this.Rules_RulesForCharacterReplacingGroupBox.TabStop = false;
            this.Rules_RulesForCharacterReplacingGroupBox.Text = "groupBox3";
            // 
            // Rules_Replace
            // 
            this.Rules_Replace.AllowUserToResizeColumns = false;
            this.Rules_Replace.AllowUserToResizeRows = false;
            this.Rules_Replace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Rules_Replace.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Rules_Replace.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Rules_Replace.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Rules_Replace.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Rules_Replace_Mn01,
            this.Rules_Replace_Mn02});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Rules_Replace.DefaultCellStyle = dataGridViewCellStyle2;
            this.Rules_Replace.GridColor = System.Drawing.Color.LightGray;
            this.Rules_Replace.Location = new System.Drawing.Point(6, 19);
            this.Rules_Replace.Name = "Rules_Replace";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Rules_Replace.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Rules_Replace.RowHeadersVisible = false;
            this.Rules_Replace.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Rules_Replace.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.Rules_Replace.ShowCellErrors = false;
            this.Rules_Replace.ShowCellToolTips = false;
            this.Rules_Replace.ShowEditingIcon = false;
            this.Rules_Replace.ShowRowErrors = false;
            this.Rules_Replace.Size = new System.Drawing.Size(1086, 158);
            this.Rules_Replace.TabIndex = 0;
            this.Rules_Replace.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Rules_Replace_KeyUp);
            this.Rules_Replace.MouseEnter += new System.EventHandler(this.Rules_Replace_MouseEnter);
            // 
            // Rules_Replace_Mn01
            // 
            this.Rules_Replace_Mn01.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Rules_Replace_Mn01.FillWeight = 50F;
            this.Rules_Replace_Mn01.HeaderText = "";
            this.Rules_Replace_Mn01.Name = "Rules_Replace_Mn01";
            // 
            // Rules_Replace_Mn02
            // 
            this.Rules_Replace_Mn02.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Rules_Replace_Mn02.FillWeight = 50F;
            this.Rules_Replace_Mn02.HeaderText = "";
            this.Rules_Replace_Mn02.Name = "Rules_Replace_Mn02";
            // 
            // Rules_ExportInfoGroupBox
            // 
            this.Rules_ExportInfoGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Rules_ExportInfoGroupBox.Controls.Add(this.Rules_InfoDell);
            this.Rules_ExportInfoGroupBox.Controls.Add(this.Rules_InfoRenameDoNothingRadioButton);
            this.Rules_ExportInfoGroupBox.Controls.Add(this.Rules_InfoExportRadioButton);
            this.Rules_ExportInfoGroupBox.Controls.Add(this.Rules_InfoAdd);
            this.Rules_ExportInfoGroupBox.Controls.Add(this.Rules_InfoC);
            this.Rules_ExportInfoGroupBox.Controls.Add(this.Rules_Info);
            this.Rules_ExportInfoGroupBox.ForeColor = System.Drawing.Color.Black;
            this.Rules_ExportInfoGroupBox.Location = new System.Drawing.Point(789, 49);
            this.Rules_ExportInfoGroupBox.Name = "Rules_ExportInfoGroupBox";
            this.Rules_ExportInfoGroupBox.Size = new System.Drawing.Size(291, 354);
            this.Rules_ExportInfoGroupBox.TabIndex = 0;
            this.Rules_ExportInfoGroupBox.TabStop = false;
            this.Rules_ExportInfoGroupBox.Text = "groupBox2";
            // 
            // Rules_InfoRenameDoNothingRadioButton
            // 
            this.Rules_InfoRenameDoNothingRadioButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Rules_InfoRenameDoNothingRadioButton.AutoSize = true;
            this.Rules_InfoRenameDoNothingRadioButton.Checked = true;
            this.Rules_InfoRenameDoNothingRadioButton.ForeColor = System.Drawing.Color.Black;
            this.Rules_InfoRenameDoNothingRadioButton.Location = new System.Drawing.Point(180, 19);
            this.Rules_InfoRenameDoNothingRadioButton.Name = "Rules_InfoRenameDoNothingRadioButton";
            this.Rules_InfoRenameDoNothingRadioButton.Size = new System.Drawing.Size(85, 17);
            this.Rules_InfoRenameDoNothingRadioButton.TabIndex = 0;
            this.Rules_InfoRenameDoNothingRadioButton.TabStop = true;
            this.Rules_InfoRenameDoNothingRadioButton.Text = "radioButton1";
            this.Rules_InfoRenameDoNothingRadioButton.UseVisualStyleBackColor = true;
            // 
            // Rules_InfoExportRadioButton
            // 
            this.Rules_InfoExportRadioButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Rules_InfoExportRadioButton.AutoSize = true;
            this.Rules_InfoExportRadioButton.ForeColor = System.Drawing.Color.Black;
            this.Rules_InfoExportRadioButton.Location = new System.Drawing.Point(89, 19);
            this.Rules_InfoExportRadioButton.Name = "Rules_InfoExportRadioButton";
            this.Rules_InfoExportRadioButton.Size = new System.Drawing.Size(85, 17);
            this.Rules_InfoExportRadioButton.TabIndex = 0;
            this.Rules_InfoExportRadioButton.Text = "radioButton1";
            this.Rules_InfoExportRadioButton.UseVisualStyleBackColor = true;
            // 
            // Rules_InfoC
            // 
            this.Rules_InfoC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Rules_InfoC.BackColor = System.Drawing.Color.White;
            this.Rules_InfoC.ForeColor = System.Drawing.Color.Black;
            this.Rules_InfoC.FormattingEnabled = true;
            this.Rules_InfoC.Location = new System.Drawing.Point(6, 327);
            this.Rules_InfoC.Name = "Rules_InfoC";
            this.Rules_InfoC.Size = new System.Drawing.Size(221, 21);
            this.Rules_InfoC.TabIndex = 0;
            this.Rules_InfoC.SelectedIndexChanged += new System.EventHandler(this.Rules_InfoC_SelectedIndexChanged);
            // 
            // Rules_Info
            // 
            this.Rules_Info.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Rules_Info.BackColor = System.Drawing.Color.White;
            this.Rules_Info.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Rules_Info.ForeColor = System.Drawing.Color.Black;
            this.Rules_Info.Location = new System.Drawing.Point(6, 43);
            this.Rules_Info.Multiline = true;
            this.Rules_Info.Name = "Rules_Info";
            this.Rules_Info.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Rules_Info.Size = new System.Drawing.Size(279, 276);
            this.Rules_Info.TabIndex = 0;
            // 
            // Rules_RulesForGeneratingDirectoriesGroupBox
            // 
            this.Rules_RulesForGeneratingDirectoriesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Rules_RulesForGeneratingDirectoriesGroupBox.Controls.Add(this.Rules_FilesRulesMoveDel);
            this.Rules_RulesForGeneratingDirectoriesGroupBox.Controls.Add(this.Rules_FilesRulesMove_RB03);
            this.Rules_RulesForGeneratingDirectoriesGroupBox.Controls.Add(this.Rules_FilesRulesMove_RB01);
            this.Rules_RulesForGeneratingDirectoriesGroupBox.Controls.Add(this.Rules_FilesRulesMove_RB02);
            this.Rules_RulesForGeneratingDirectoriesGroupBox.Controls.Add(this.Rules_FilesRulesMoveAdd);
            this.Rules_RulesForGeneratingDirectoriesGroupBox.Controls.Add(this.Rules_FilesRulesMoveC);
            this.Rules_RulesForGeneratingDirectoriesGroupBox.Controls.Add(this.Rules_FilesRulesMove);
            this.Rules_RulesForGeneratingDirectoriesGroupBox.ForeColor = System.Drawing.Color.Black;
            this.Rules_RulesForGeneratingDirectoriesGroupBox.Location = new System.Drawing.Point(477, 49);
            this.Rules_RulesForGeneratingDirectoriesGroupBox.Name = "Rules_RulesForGeneratingDirectoriesGroupBox";
            this.Rules_RulesForGeneratingDirectoriesGroupBox.Size = new System.Drawing.Size(291, 354);
            this.Rules_RulesForGeneratingDirectoriesGroupBox.TabIndex = 0;
            this.Rules_RulesForGeneratingDirectoriesGroupBox.TabStop = false;
            this.Rules_RulesForGeneratingDirectoriesGroupBox.Text = "groupBox2";
            // 
            // Rules_FilesRulesMove_RB03
            // 
            this.Rules_FilesRulesMove_RB03.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Rules_FilesRulesMove_RB03.AutoSize = true;
            this.Rules_FilesRulesMove_RB03.Checked = true;
            this.Rules_FilesRulesMove_RB03.ForeColor = System.Drawing.Color.Black;
            this.Rules_FilesRulesMove_RB03.Location = new System.Drawing.Point(180, 19);
            this.Rules_FilesRulesMove_RB03.Name = "Rules_FilesRulesMove_RB03";
            this.Rules_FilesRulesMove_RB03.Size = new System.Drawing.Size(85, 17);
            this.Rules_FilesRulesMove_RB03.TabIndex = 0;
            this.Rules_FilesRulesMove_RB03.TabStop = true;
            this.Rules_FilesRulesMove_RB03.Text = "radioButton1";
            this.Rules_FilesRulesMove_RB03.UseVisualStyleBackColor = true;
            // 
            // Rules_FilesRulesMove_RB01
            // 
            this.Rules_FilesRulesMove_RB01.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Rules_FilesRulesMove_RB01.AutoSize = true;
            this.Rules_FilesRulesMove_RB01.ForeColor = System.Drawing.Color.Black;
            this.Rules_FilesRulesMove_RB01.Location = new System.Drawing.Point(-2, 19);
            this.Rules_FilesRulesMove_RB01.Name = "Rules_FilesRulesMove_RB01";
            this.Rules_FilesRulesMove_RB01.Size = new System.Drawing.Size(85, 17);
            this.Rules_FilesRulesMove_RB01.TabIndex = 0;
            this.Rules_FilesRulesMove_RB01.Text = "radioButton1";
            this.Rules_FilesRulesMove_RB01.UseVisualStyleBackColor = true;
            // 
            // Rules_FilesRulesMove_RB02
            // 
            this.Rules_FilesRulesMove_RB02.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Rules_FilesRulesMove_RB02.AutoSize = true;
            this.Rules_FilesRulesMove_RB02.ForeColor = System.Drawing.Color.Black;
            this.Rules_FilesRulesMove_RB02.Location = new System.Drawing.Point(89, 19);
            this.Rules_FilesRulesMove_RB02.Name = "Rules_FilesRulesMove_RB02";
            this.Rules_FilesRulesMove_RB02.Size = new System.Drawing.Size(85, 17);
            this.Rules_FilesRulesMove_RB02.TabIndex = 0;
            this.Rules_FilesRulesMove_RB02.Text = "radioButton1";
            this.Rules_FilesRulesMove_RB02.UseVisualStyleBackColor = true;
            // 
            // Rules_FilesRulesMoveC
            // 
            this.Rules_FilesRulesMoveC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Rules_FilesRulesMoveC.BackColor = System.Drawing.Color.White;
            this.Rules_FilesRulesMoveC.ForeColor = System.Drawing.Color.Black;
            this.Rules_FilesRulesMoveC.FormattingEnabled = true;
            this.Rules_FilesRulesMoveC.Location = new System.Drawing.Point(6, 327);
            this.Rules_FilesRulesMoveC.Name = "Rules_FilesRulesMoveC";
            this.Rules_FilesRulesMoveC.Size = new System.Drawing.Size(221, 21);
            this.Rules_FilesRulesMoveC.TabIndex = 0;
            this.Rules_FilesRulesMoveC.SelectedIndexChanged += new System.EventHandler(this.Rules_FilesRulesMoveC_SelectedIndexChanged);
            // 
            // Rules_FilesRulesMove
            // 
            this.Rules_FilesRulesMove.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Rules_FilesRulesMove.BackColor = System.Drawing.Color.White;
            this.Rules_FilesRulesMove.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Rules_FilesRulesMove.ForeColor = System.Drawing.Color.Black;
            this.Rules_FilesRulesMove.Location = new System.Drawing.Point(6, 43);
            this.Rules_FilesRulesMove.Multiline = true;
            this.Rules_FilesRulesMove.Name = "Rules_FilesRulesMove";
            this.Rules_FilesRulesMove.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Rules_FilesRulesMove.Size = new System.Drawing.Size(279, 276);
            this.Rules_FilesRulesMove.TabIndex = 0;
            // 
            // Rules_RulesForFileRenamingGroupBox
            // 
            this.Rules_RulesForFileRenamingGroupBox.BackColor = System.Drawing.Color.White;
            this.Rules_RulesForFileRenamingGroupBox.Controls.Add(this.Rules_Position);
            this.Rules_RulesForFileRenamingGroupBox.Controls.Add(this.Rules_RulesNumberPositionLabel);
            this.Rules_RulesForFileRenamingGroupBox.Controls.Add(this.Rules_FilesRulesRename_DoNothingRadioButton);
            this.Rules_RulesForFileRenamingGroupBox.Controls.Add(this.Rules_FilesRulesRename_RenameRadioButton);
            this.Rules_RulesForFileRenamingGroupBox.Controls.Add(this.Rules_FilesRulesRenameDel);
            this.Rules_RulesForFileRenamingGroupBox.Controls.Add(this.Rules_FilesRulesRenameAdd);
            this.Rules_RulesForFileRenamingGroupBox.Controls.Add(this.Rules_FilesRulesRenameC);
            this.Rules_RulesForFileRenamingGroupBox.Controls.Add(this.Rules_FilesRulesRename);
            this.Rules_RulesForFileRenamingGroupBox.ForeColor = System.Drawing.Color.Black;
            this.Rules_RulesForFileRenamingGroupBox.Location = new System.Drawing.Point(6, 49);
            this.Rules_RulesForFileRenamingGroupBox.Name = "Rules_RulesForFileRenamingGroupBox";
            this.Rules_RulesForFileRenamingGroupBox.Size = new System.Drawing.Size(459, 354);
            this.Rules_RulesForFileRenamingGroupBox.TabIndex = 0;
            this.Rules_RulesForFileRenamingGroupBox.TabStop = false;
            this.Rules_RulesForFileRenamingGroupBox.Text = "groupBox1";
            // 
            // Rules_Position
            // 
            this.Rules_Position.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Rules_Position.ForeColor = System.Drawing.Color.Black;
            this.Rules_Position.FormattingEnabled = true;
            this.Rules_Position.Items.AddRange(new object[] {
            "Manual",
            "Auto",
            "Auto - Spec",
            "02",
            "003",
            "0004",
            "00005",
            "000006"});
            this.Rules_Position.Location = new System.Drawing.Point(104, 18);
            this.Rules_Position.Name = "Rules_Position";
            this.Rules_Position.Size = new System.Drawing.Size(121, 21);
            this.Rules_Position.TabIndex = 0;
            // 
            // Rules_RulesNumberPositionLabel
            // 
            this.Rules_RulesNumberPositionLabel.AutoSize = true;
            this.Rules_RulesNumberPositionLabel.ForeColor = System.Drawing.Color.Black;
            this.Rules_RulesNumberPositionLabel.Location = new System.Drawing.Point(6, 21);
            this.Rules_RulesNumberPositionLabel.Name = "Rules_RulesNumberPositionLabel";
            this.Rules_RulesNumberPositionLabel.Size = new System.Drawing.Size(35, 13);
            this.Rules_RulesNumberPositionLabel.TabIndex = 0;
            this.Rules_RulesNumberPositionLabel.Text = "label1";
            // 
            // Rules_FilesRulesRename_DoNothingRadioButton
            // 
            this.Rules_FilesRulesRename_DoNothingRadioButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Rules_FilesRulesRename_DoNothingRadioButton.AutoSize = true;
            this.Rules_FilesRulesRename_DoNothingRadioButton.ForeColor = System.Drawing.Color.Black;
            this.Rules_FilesRulesRename_DoNothingRadioButton.Location = new System.Drawing.Point(358, 20);
            this.Rules_FilesRulesRename_DoNothingRadioButton.Name = "Rules_FilesRulesRename_DoNothingRadioButton";
            this.Rules_FilesRulesRename_DoNothingRadioButton.Size = new System.Drawing.Size(85, 17);
            this.Rules_FilesRulesRename_DoNothingRadioButton.TabIndex = 0;
            this.Rules_FilesRulesRename_DoNothingRadioButton.TabStop = true;
            this.Rules_FilesRulesRename_DoNothingRadioButton.Text = "radioButton1";
            this.Rules_FilesRulesRename_DoNothingRadioButton.UseVisualStyleBackColor = true;
            // 
            // Rules_FilesRulesRename_RenameRadioButton
            // 
            this.Rules_FilesRulesRename_RenameRadioButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Rules_FilesRulesRename_RenameRadioButton.AutoSize = true;
            this.Rules_FilesRulesRename_RenameRadioButton.ForeColor = System.Drawing.Color.Black;
            this.Rules_FilesRulesRename_RenameRadioButton.Location = new System.Drawing.Point(267, 20);
            this.Rules_FilesRulesRename_RenameRadioButton.Name = "Rules_FilesRulesRename_RenameRadioButton";
            this.Rules_FilesRulesRename_RenameRadioButton.Size = new System.Drawing.Size(85, 17);
            this.Rules_FilesRulesRename_RenameRadioButton.TabIndex = 0;
            this.Rules_FilesRulesRename_RenameRadioButton.TabStop = true;
            this.Rules_FilesRulesRename_RenameRadioButton.Text = "radioButton1";
            this.Rules_FilesRulesRename_RenameRadioButton.UseVisualStyleBackColor = true;
            // 
            // Rules_FilesRulesRenameC
            // 
            this.Rules_FilesRulesRenameC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Rules_FilesRulesRenameC.BackColor = System.Drawing.Color.White;
            this.Rules_FilesRulesRenameC.ForeColor = System.Drawing.Color.Black;
            this.Rules_FilesRulesRenameC.FormattingEnabled = true;
            this.Rules_FilesRulesRenameC.Location = new System.Drawing.Point(6, 327);
            this.Rules_FilesRulesRenameC.Name = "Rules_FilesRulesRenameC";
            this.Rules_FilesRulesRenameC.Size = new System.Drawing.Size(389, 21);
            this.Rules_FilesRulesRenameC.TabIndex = 0;
            this.Rules_FilesRulesRenameC.SelectedIndexChanged += new System.EventHandler(this.Rules_FilesRulesRenameC_SelectedIndexChanged);
            // 
            // Rules_FilesRulesRename
            // 
            this.Rules_FilesRulesRename.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Rules_FilesRulesRename.BackColor = System.Drawing.Color.White;
            this.Rules_FilesRulesRename.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Rules_FilesRulesRename.ForeColor = System.Drawing.Color.Black;
            this.Rules_FilesRulesRename.Location = new System.Drawing.Point(6, 43);
            this.Rules_FilesRulesRename.Multiline = true;
            this.Rules_FilesRulesRename.Name = "Rules_FilesRulesRename";
            this.Rules_FilesRulesRename.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Rules_FilesRulesRename.Size = new System.Drawing.Size(447, 276);
            this.Rules_FilesRulesRename.TabIndex = 0;
            // 
            // MainTab_HashPage
            // 
            this.MainTab_HashPage.BackColor = System.Drawing.Color.White;
            this.MainTab_HashPage.Controls.Add(this.Hash_GR01);
            this.MainTab_HashPage.Location = new System.Drawing.Point(4, 22);
            this.MainTab_HashPage.Name = "MainTab_HashPage";
            this.MainTab_HashPage.Size = new System.Drawing.Size(1119, 680);
            this.MainTab_HashPage.TabIndex = 0;
            this.MainTab_HashPage.Text = "6";
            this.MainTab_HashPage.UseVisualStyleBackColor = true;
            // 
            // Hash_GR01
            // 
            this.Hash_GR01.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Hash_GR01.Controls.Add(this.Hash_ProgressBar_Total_Percent);
            this.Hash_GR01.Controls.Add(this.Hash_ProgressBar_Percent);
            this.Hash_GR01.Controls.Add(this.Hash);
            this.Hash_GR01.Controls.Add(this.Hash_ProgressBar_Total);
            this.Hash_GR01.Controls.Add(this.Hash_Nazvy_Souboru);
            this.Hash_GR01.Controls.Add(this.Hash_LB03);
            this.Hash_GR01.Controls.Add(this.Hash_ProgressBar);
            this.Hash_GR01.Controls.Add(this.Hash_LB02);
            this.Hash_GR01.Controls.Add(this.Hash_Cesta);
            this.Hash_GR01.Controls.Add(this.Hash_Waiting);
            this.Hash_GR01.Controls.Add(this.Hash_Stop_Total);
            this.Hash_GR01.Controls.Add(this.Hash_CH03);
            this.Hash_GR01.Controls.Add(this.Hash_Files);
            this.Hash_GR01.Controls.Add(this.Hash_CH02);
            this.Hash_GR01.Controls.Add(this.Hash_Delete);
            this.Hash_GR01.Controls.Add(this.Hash_CH01);
            this.Hash_GR01.Controls.Add(this.Hash_DeleteAll);
            this.Hash_GR01.Location = new System.Drawing.Point(6, 6);
            this.Hash_GR01.Name = "Hash_GR01";
            this.Hash_GR01.Size = new System.Drawing.Size(1110, 671);
            this.Hash_GR01.TabIndex = 0;
            this.Hash_GR01.TabStop = false;
            this.Hash_GR01.Text = "groupBox1";
            // 
            // Hash_ProgressBar_Total_Percent
            // 
            this.Hash_ProgressBar_Total_Percent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Hash_ProgressBar_Total_Percent.Location = new System.Drawing.Point(1003, 642);
            this.Hash_ProgressBar_Total_Percent.Name = "Hash_ProgressBar_Total_Percent";
            this.Hash_ProgressBar_Total_Percent.Size = new System.Drawing.Size(100, 23);
            this.Hash_ProgressBar_Total_Percent.TabIndex = 0;
            this.Hash_ProgressBar_Total_Percent.Text = "0%";
            this.Hash_ProgressBar_Total_Percent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Hash_ProgressBar_Percent
            // 
            this.Hash_ProgressBar_Percent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Hash_ProgressBar_Percent.Location = new System.Drawing.Point(1003, 613);
            this.Hash_ProgressBar_Percent.Name = "Hash_ProgressBar_Percent";
            this.Hash_ProgressBar_Percent.Size = new System.Drawing.Size(100, 23);
            this.Hash_ProgressBar_Percent.TabIndex = 0;
            this.Hash_ProgressBar_Percent.Text = "0%";
            this.Hash_ProgressBar_Percent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Hash_ProgressBar_Total
            // 
            this.Hash_ProgressBar_Total.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Hash_ProgressBar_Total.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(219)))), ((int)(((byte)(58)))));
            this.Hash_ProgressBar_Total.Location = new System.Drawing.Point(6, 642);
            this.Hash_ProgressBar_Total.Name = "Hash_ProgressBar_Total";
            this.Hash_ProgressBar_Total.Size = new System.Drawing.Size(991, 23);
            this.Hash_ProgressBar_Total.Step = 1;
            this.Hash_ProgressBar_Total.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.Hash_ProgressBar_Total.TabIndex = 0;
            // 
            // Hash_Nazvy_Souboru
            // 
            this.Hash_Nazvy_Souboru.AllowDrop = true;
            this.Hash_Nazvy_Souboru.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Hash_Nazvy_Souboru.Font = new System.Drawing.Font("Courier New", 10F);
            this.Hash_Nazvy_Souboru.ForeColor = System.Drawing.Color.Black;
            this.Hash_Nazvy_Souboru.FormattingEnabled = true;
            this.Hash_Nazvy_Souboru.ItemHeight = 16;
            this.Hash_Nazvy_Souboru.Location = new System.Drawing.Point(5, 61);
            this.Hash_Nazvy_Souboru.Name = "Hash_Nazvy_Souboru";
            this.Hash_Nazvy_Souboru.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.Hash_Nazvy_Souboru.Size = new System.Drawing.Size(1098, 532);
            this.Hash_Nazvy_Souboru.TabIndex = 0;
            this.Hash_Nazvy_Souboru.DragDrop += new System.Windows.Forms.DragEventHandler(this.Hash_Nazvy_Souboru_DragDrop);
            this.Hash_Nazvy_Souboru.DragEnter += new System.Windows.Forms.DragEventHandler(this.Hash_Nazvy_Souboru_DragEnter);
            this.Hash_Nazvy_Souboru.MouseEnter += new System.EventHandler(this.Hash_Nazvy_Souboru_MouseEnter);
            // 
            // Hash_LB03
            // 
            this.Hash_LB03.AutoSize = true;
            this.Hash_LB03.ForeColor = System.Drawing.Color.Black;
            this.Hash_LB03.Location = new System.Drawing.Point(281, 31);
            this.Hash_LB03.Name = "Hash_LB03";
            this.Hash_LB03.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Hash_LB03.Size = new System.Drawing.Size(20, 13);
            this.Hash_LB03.TabIndex = 0;
            this.Hash_LB03.Text = "ms";
            // 
            // Hash_ProgressBar
            // 
            this.Hash_ProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Hash_ProgressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(219)))), ((int)(((byte)(58)))));
            this.Hash_ProgressBar.Location = new System.Drawing.Point(6, 613);
            this.Hash_ProgressBar.Name = "Hash_ProgressBar";
            this.Hash_ProgressBar.Size = new System.Drawing.Size(991, 23);
            this.Hash_ProgressBar.Step = 1;
            this.Hash_ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.Hash_ProgressBar.TabIndex = 0;
            // 
            // Hash_LB02
            // 
            this.Hash_LB02.AutoSize = true;
            this.Hash_LB02.ForeColor = System.Drawing.Color.Black;
            this.Hash_LB02.Location = new System.Drawing.Point(157, 31);
            this.Hash_LB02.Name = "Hash_LB02";
            this.Hash_LB02.Size = new System.Drawing.Size(35, 13);
            this.Hash_LB02.TabIndex = 0;
            this.Hash_LB02.Text = "label1";
            // 
            // Hash_Waiting
            // 
            this.Hash_Waiting.ForeColor = System.Drawing.Color.Black;
            this.Hash_Waiting.Location = new System.Drawing.Point(226, 29);
            this.Hash_Waiting.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Hash_Waiting.Name = "Hash_Waiting";
            this.Hash_Waiting.Size = new System.Drawing.Size(49, 20);
            this.Hash_Waiting.TabIndex = 0;
            this.Hash_Waiting.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Hash_Waiting.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Hash_CH03
            // 
            this.Hash_CH03.AutoSize = true;
            this.Hash_CH03.ForeColor = System.Drawing.Color.Black;
            this.Hash_CH03.Location = new System.Drawing.Point(455, 32);
            this.Hash_CH03.Name = "Hash_CH03";
            this.Hash_CH03.Size = new System.Drawing.Size(65, 17);
            this.Hash_CH03.TabIndex = 0;
            this.Hash_CH03.Text = "Window";
            this.Hash_CH03.UseVisualStyleBackColor = true;
            // 
            // Hash_CH02
            // 
            this.Hash_CH02.AutoSize = true;
            this.Hash_CH02.ForeColor = System.Drawing.Color.Black;
            this.Hash_CH02.Location = new System.Drawing.Point(405, 32);
            this.Hash_CH02.Name = "Hash_CH02";
            this.Hash_CH02.Size = new System.Drawing.Size(44, 17);
            this.Hash_CH02.TabIndex = 0;
            this.Hash_CH02.Text = "Log";
            this.Hash_CH02.UseVisualStyleBackColor = true;
            // 
            // Hash_CH01
            // 
            this.Hash_CH01.AutoSize = true;
            this.Hash_CH01.ForeColor = System.Drawing.Color.Black;
            this.Hash_CH01.Location = new System.Drawing.Point(323, 32);
            this.Hash_CH01.Name = "Hash_CH01";
            this.Hash_CH01.Size = new System.Drawing.Size(76, 17);
            this.Hash_CH01.TabIndex = 0;
            this.Hash_CH01.Text = "AvDump 2";
            this.Hash_CH01.UseVisualStyleBackColor = true;
            // 
            // MainTab_AnimePage
            // 
            this.MainTab_AnimePage.BackColor = System.Drawing.Color.White;
            this.MainTab_AnimePage.Controls.Add(this.MainTabData);
            this.MainTab_AnimePage.Location = new System.Drawing.Point(4, 22);
            this.MainTab_AnimePage.Name = "MainTab_AnimePage";
            this.MainTab_AnimePage.Size = new System.Drawing.Size(1119, 680);
            this.MainTab_AnimePage.TabIndex = 0;
            this.MainTab_AnimePage.Text = "3";
            this.MainTab_AnimePage.UseVisualStyleBackColor = true;
            // 
            // MainTabData
            // 
            this.MainTabData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTabData.Controls.Add(this.MainTabData_MyListTabPage);
            this.MainTabData.Controls.Add(this.MainTabData_FilesTabPage);
            this.MainTabData.Controls.Add(this.MainTabData_AnimeTabPage);
            this.MainTabData.Controls.Add(this.MainTabData_Anime2TabPage);
            this.MainTabData.Controls.Add(this.MainTabData_GenresTabPage);
            this.MainTabData.Controls.Add(this.MainTabData_GroupsTabPage);
            this.MainTabData.Controls.Add(this.MainTabData_SearchTabPage);
            this.MainTabData.Controls.Add(this.MainTabData_OthersTabPage);
            this.MainTabData.Controls.Add(this.MainTabData_GraphsTabPage);
            this.MainTabData.Controls.Add(this.MainTabData_ExportTabPage);
            this.MainTabData.Location = new System.Drawing.Point(3, 3);
            this.MainTabData.Name = "MainTabData";
            this.MainTabData.SelectedIndex = 0;
            this.MainTabData.Size = new System.Drawing.Size(1113, 674);
            this.MainTabData.TabIndex = 0;
            this.MainTabData.SelectedIndexChanged += new System.EventHandler(this.MainTabData_SelectedIndexChanged);
            this.MainTabData.MouseEnter += new System.EventHandler(this.MainTabData_MouseEnter);
            // 
            // MainTabData_MyListTabPage
            // 
            this.MainTabData_MyListTabPage.BackColor = System.Drawing.Color.White;
            this.MainTabData_MyListTabPage.Controls.Add(this.Options_GR04);
            this.MainTabData_MyListTabPage.Location = new System.Drawing.Point(4, 22);
            this.MainTabData_MyListTabPage.Name = "MainTabData_MyListTabPage";
            this.MainTabData_MyListTabPage.Size = new System.Drawing.Size(1105, 648);
            this.MainTabData_MyListTabPage.TabIndex = 0;
            this.MainTabData_MyListTabPage.Text = "0";
            this.MainTabData_MyListTabPage.UseVisualStyleBackColor = true;
            // 
            // Options_GR04
            // 
            this.Options_GR04.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Options_GR04.BackColor = System.Drawing.Color.White;
            this.Options_GR04.Controls.Add(this.Options_MyListRefreshMin);
            this.Options_GR04.Controls.Add(this.Options_MyListRefresh);
            this.Options_GR04.Controls.Add(this.MyListAnime);
            this.Options_GR04.Location = new System.Drawing.Point(-4, -13);
            this.Options_GR04.MinimumSize = new System.Drawing.Size(471, 265);
            this.Options_GR04.Name = "Options_GR04";
            this.Options_GR04.Size = new System.Drawing.Size(1113, 674);
            this.Options_GR04.TabIndex = 0;
            this.Options_GR04.TabStop = false;
            this.Options_GR04.Text = "groupBox3";
            // 
            // MyListAnime
            // 
            this.MyListAnime.AllowUserToAddRows = false;
            this.MyListAnime.AllowUserToDeleteRows = false;
            this.MyListAnime.AllowUserToResizeRows = false;
            this.MyListAnime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MyListAnime.BackgroundColor = System.Drawing.Color.White;
            this.MyListAnime.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.MyListAnime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MyListAnime.ColumnHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.MyListAnime.DefaultCellStyle = dataGridViewCellStyle5;
            this.MyListAnime.GridColor = System.Drawing.Color.White;
            this.MyListAnime.Location = new System.Drawing.Point(7, 19);
            this.MyListAnime.Name = "MyListAnime";
            this.MyListAnime.ReadOnly = true;
            this.MyListAnime.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.MyListAnime.RowHeadersVisible = false;
            this.MyListAnime.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.MyListAnime.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.MyListAnime.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MyListAnime.Size = new System.Drawing.Size(1099, 597);
            this.MyListAnime.TabIndex = 1;
            // 
            // MainTabData_FilesTabPage
            // 
            this.MainTabData_FilesTabPage.BackColor = System.Drawing.Color.White;
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFilesTree_CH04);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFilesTree_CH03);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFilesTree_CH02);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFilesTree_CH01);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_LB06);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_LB05);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_LB04);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_LB03);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_LB02);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_LB01);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_Filtr04);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_Filtr03);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_Filtr02);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_Filtr01);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFilesTree);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_RB05);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_RB04);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_Year);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_Month);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_Day);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_RB03);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_RB02);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_RB01);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_Page);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_Rows);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_Bt21);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_Bt22);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_Bt20);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_Bt19);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_Bt00);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_Bt01);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_Bt18);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_Bt17);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_Bt16);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_Bt15);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_Bt14);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_Bt13);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_Bt12);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_Bt11);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_Bt10);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_Bt09);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_Bt08);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_Bt07);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_Bt06);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_Bt05);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_Bt04);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_Bt03);
            this.MainTabData_FilesTabPage.Controls.Add(this.DataFiles_Bt02);
            this.MainTabData_FilesTabPage.Location = new System.Drawing.Point(4, 22);
            this.MainTabData_FilesTabPage.Name = "MainTabData_FilesTabPage";
            this.MainTabData_FilesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.MainTabData_FilesTabPage.Size = new System.Drawing.Size(1105, 648);
            this.MainTabData_FilesTabPage.TabIndex = 0;
            this.MainTabData_FilesTabPage.Text = "1";
            this.MainTabData_FilesTabPage.UseVisualStyleBackColor = true;
            // 
            // DataFilesTree_CH04
            // 
            this.DataFilesTree_CH04.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DataFilesTree_CH04.AutoSize = true;
            this.DataFilesTree_CH04.ForeColor = System.Drawing.Color.Black;
            this.DataFilesTree_CH04.Location = new System.Drawing.Point(68, 624);
            this.DataFilesTree_CH04.Name = "DataFilesTree_CH04";
            this.DataFilesTree_CH04.Size = new System.Drawing.Size(15, 14);
            this.DataFilesTree_CH04.TabIndex = 0;
            this.DataFilesTree_CH04.UseVisualStyleBackColor = true;
            // 
            // DataFilesTree_CH03
            // 
            this.DataFilesTree_CH03.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DataFilesTree_CH03.AutoSize = true;
            this.DataFilesTree_CH03.ForeColor = System.Drawing.Color.Black;
            this.DataFilesTree_CH03.Location = new System.Drawing.Point(1010, 623);
            this.DataFilesTree_CH03.Name = "DataFilesTree_CH03";
            this.DataFilesTree_CH03.Size = new System.Drawing.Size(80, 17);
            this.DataFilesTree_CH03.TabIndex = 0;
            this.DataFilesTree_CH03.Text = "checkBox2";
            this.DataFilesTree_CH03.UseVisualStyleBackColor = true;
            // 
            // DataFilesTree_CH02
            // 
            this.DataFilesTree_CH02.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DataFilesTree_CH02.AutoSize = true;
            this.DataFilesTree_CH02.ForeColor = System.Drawing.Color.Black;
            this.DataFilesTree_CH02.Location = new System.Drawing.Point(893, 623);
            this.DataFilesTree_CH02.Name = "DataFilesTree_CH02";
            this.DataFilesTree_CH02.Size = new System.Drawing.Size(80, 17);
            this.DataFilesTree_CH02.TabIndex = 0;
            this.DataFilesTree_CH02.Text = "checkBox2";
            this.DataFilesTree_CH02.UseVisualStyleBackColor = true;
            this.DataFilesTree_CH02.Visible = false;
            this.DataFilesTree_CH02.CheckedChanged += new System.EventHandler(this.DataFilesTree_CH02_CheckedChanged);
            // 
            // DataFilesTree_CH01
            // 
            this.DataFilesTree_CH01.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DataFilesTree_CH01.AutoSize = true;
            this.DataFilesTree_CH01.ForeColor = System.Drawing.Color.Black;
            this.DataFilesTree_CH01.Location = new System.Drawing.Point(778, 623);
            this.DataFilesTree_CH01.Name = "DataFilesTree_CH01";
            this.DataFilesTree_CH01.Size = new System.Drawing.Size(80, 17);
            this.DataFilesTree_CH01.TabIndex = 0;
            this.DataFilesTree_CH01.Text = "checkBox1";
            this.DataFilesTree_CH01.UseVisualStyleBackColor = true;
            this.DataFilesTree_CH01.Visible = false;
            this.DataFilesTree_CH01.CheckedChanged += new System.EventHandler(this.DataFilesTree_CH01_CheckedChanged);
            // 
            // DataFiles_LB06
            // 
            this.DataFiles_LB06.AutoSize = true;
            this.DataFiles_LB06.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DataFiles_LB06.ForeColor = System.Drawing.Color.Black;
            this.DataFiles_LB06.Location = new System.Drawing.Point(681, 8);
            this.DataFiles_LB06.Name = "DataFiles_LB06";
            this.DataFiles_LB06.Size = new System.Drawing.Size(13, 13);
            this.DataFiles_LB06.TabIndex = 0;
            this.DataFiles_LB06.Text = "0";
            // 
            // DataFiles_LB05
            // 
            this.DataFiles_LB05.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DataFiles_LB05.AutoSize = true;
            this.DataFiles_LB05.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DataFiles_LB05.ForeColor = System.Drawing.Color.Black;
            this.DataFiles_LB05.Location = new System.Drawing.Point(1049, 596);
            this.DataFiles_LB05.Name = "DataFiles_LB05";
            this.DataFiles_LB05.Size = new System.Drawing.Size(41, 13);
            this.DataFiles_LB05.TabIndex = 0;
            this.DataFiles_LB05.Text = "label1";
            this.DataFiles_LB05.Visible = false;
            // 
            // DataFiles_LB04
            // 
            this.DataFiles_LB04.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DataFiles_LB04.AutoSize = true;
            this.DataFiles_LB04.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DataFiles_LB04.ForeColor = System.Drawing.Color.Black;
            this.DataFiles_LB04.Location = new System.Drawing.Point(789, 596);
            this.DataFiles_LB04.Name = "DataFiles_LB04";
            this.DataFiles_LB04.Size = new System.Drawing.Size(41, 13);
            this.DataFiles_LB04.TabIndex = 0;
            this.DataFiles_LB04.Text = "label1";
            // 
            // DataFiles_LB03
            // 
            this.DataFiles_LB03.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DataFiles_LB03.AutoSize = true;
            this.DataFiles_LB03.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DataFiles_LB03.ForeColor = System.Drawing.Color.Black;
            this.DataFiles_LB03.Location = new System.Drawing.Point(528, 596);
            this.DataFiles_LB03.Name = "DataFiles_LB03";
            this.DataFiles_LB03.Size = new System.Drawing.Size(41, 13);
            this.DataFiles_LB03.TabIndex = 0;
            this.DataFiles_LB03.Text = "label1";
            // 
            // DataFiles_LB02
            // 
            this.DataFiles_LB02.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DataFiles_LB02.AutoSize = true;
            this.DataFiles_LB02.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DataFiles_LB02.ForeColor = System.Drawing.Color.Black;
            this.DataFiles_LB02.Location = new System.Drawing.Point(267, 596);
            this.DataFiles_LB02.Name = "DataFiles_LB02";
            this.DataFiles_LB02.Size = new System.Drawing.Size(41, 13);
            this.DataFiles_LB02.TabIndex = 0;
            this.DataFiles_LB02.Text = "label1";
            // 
            // DataFiles_LB01
            // 
            this.DataFiles_LB01.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DataFiles_LB01.AutoSize = true;
            this.DataFiles_LB01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DataFiles_LB01.ForeColor = System.Drawing.Color.Black;
            this.DataFiles_LB01.Location = new System.Drawing.Point(6, 596);
            this.DataFiles_LB01.Name = "DataFiles_LB01";
            this.DataFiles_LB01.Size = new System.Drawing.Size(41, 13);
            this.DataFiles_LB01.TabIndex = 0;
            this.DataFiles_LB01.Text = "label1";
            // 
            // DataFiles_Filtr04
            // 
            this.DataFiles_Filtr04.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DataFiles_Filtr04.ForeColor = System.Drawing.Color.Black;
            this.DataFiles_Filtr04.Location = new System.Drawing.Point(876, 593);
            this.DataFiles_Filtr04.Name = "DataFiles_Filtr04";
            this.DataFiles_Filtr04.Size = new System.Drawing.Size(168, 20);
            this.DataFiles_Filtr04.TabIndex = 0;
            // 
            // DataFiles_Filtr03
            // 
            this.DataFiles_Filtr03.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DataFiles_Filtr03.ForeColor = System.Drawing.Color.Black;
            this.DataFiles_Filtr03.Location = new System.Drawing.Point(615, 593);
            this.DataFiles_Filtr03.Name = "DataFiles_Filtr03";
            this.DataFiles_Filtr03.Size = new System.Drawing.Size(168, 20);
            this.DataFiles_Filtr03.TabIndex = 0;
            // 
            // DataFiles_Filtr02
            // 
            this.DataFiles_Filtr02.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DataFiles_Filtr02.ForeColor = System.Drawing.Color.Black;
            this.DataFiles_Filtr02.Location = new System.Drawing.Point(354, 593);
            this.DataFiles_Filtr02.Name = "DataFiles_Filtr02";
            this.DataFiles_Filtr02.Size = new System.Drawing.Size(168, 20);
            this.DataFiles_Filtr02.TabIndex = 0;
            // 
            // DataFiles_Filtr01
            // 
            this.DataFiles_Filtr01.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DataFiles_Filtr01.ForeColor = System.Drawing.Color.Black;
            this.DataFiles_Filtr01.Location = new System.Drawing.Point(93, 593);
            this.DataFiles_Filtr01.Name = "DataFiles_Filtr01";
            this.DataFiles_Filtr01.Size = new System.Drawing.Size(168, 20);
            this.DataFiles_Filtr01.TabIndex = 0;
            // 
            // DataFilesTree
            // 
            this.DataFilesTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataFilesTree.BackColor = System.Drawing.Color.White;
            this.DataFilesTree.ContextMenuStrip = this.DataFilesTree_Menu;
            this.DataFilesTree.Enabled = false;
            this.DataFilesTree.ForeColor = System.Drawing.Color.Black;
            this.DataFilesTree.ImageIndex = 0;
            this.DataFilesTree.ImageList = this.DataFilesTreeImages;
            this.DataFilesTree.Location = new System.Drawing.Point(631, 6);
            this.DataFilesTree.Name = "DataFilesTree";
            this.DataFilesTree.SelectedImageIndex = 0;
            this.DataFilesTree.Size = new System.Drawing.Size(53, 105);
            this.DataFilesTree.TabIndex = 0;
            this.DataFilesTree.Visible = false;
            this.DataFilesTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.DataFilesTree_AfterSelect);
            this.DataFilesTree.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DataFilesTree_MouseDoubleClick);
            // 
            // DataFilesTree_Menu
            // 
            this.DataFilesTree_Menu.BackColor = System.Drawing.Color.White;
            this.DataFilesTree_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DataFilesTree_Mn01,
            this.DataFilesTree_Mn02,
            this.DataFilesTree_Mn03,
            this.DataFilesTree_Mn07,
            this.DataFilesTree_Mn06,
            this.DataFilesTree_Mn04,
            this.DataFilesTree_Mn05,
            this.DataFilesTree_Mn08});
            this.DataFilesTree_Menu.Name = "DataFilesTree_Menu";
            this.DataFilesTree_Menu.Size = new System.Drawing.Size(81, 180);
            // 
            // DataFilesTree_Mn01
            // 
            this.DataFilesTree_Mn01.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DataFilesTree_Mn01_Mn01,
            this.DataFilesTree_Mn01_Mn02});
            this.DataFilesTree_Mn01.Name = "DataFilesTree_Mn01";
            this.DataFilesTree_Mn01.Size = new System.Drawing.Size(80, 22);
            this.DataFilesTree_Mn01.Text = "1";
            // 
            // DataFilesTree_Mn01_Mn01
            // 
            this.DataFilesTree_Mn01_Mn01.Name = "DataFilesTree_Mn01_Mn01";
            this.DataFilesTree_Mn01_Mn01.Size = new System.Drawing.Size(80, 22);
            this.DataFilesTree_Mn01_Mn01.Text = "1";
            this.DataFilesTree_Mn01_Mn01.Click += new System.EventHandler(this.DataFilesTree_Mn01_Mn01_Click);
            // 
            // DataFilesTree_Mn01_Mn02
            // 
            this.DataFilesTree_Mn01_Mn02.Name = "DataFilesTree_Mn01_Mn02";
            this.DataFilesTree_Mn01_Mn02.Size = new System.Drawing.Size(80, 22);
            this.DataFilesTree_Mn01_Mn02.Text = "2";
            this.DataFilesTree_Mn01_Mn02.Click += new System.EventHandler(this.DataFilesTree_Mn01_Mn02_Click);
            // 
            // DataFilesTree_Mn02
            // 
            this.DataFilesTree_Mn02.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DataFilesTree_Mn02_Mn01,
            this.DataFilesTree_Mn02_Mn02,
            this.DataFilesTree_Mn02_Mn03});
            this.DataFilesTree_Mn02.Name = "DataFilesTree_Mn02";
            this.DataFilesTree_Mn02.Size = new System.Drawing.Size(80, 22);
            this.DataFilesTree_Mn02.Text = "2";
            // 
            // DataFilesTree_Mn02_Mn01
            // 
            this.DataFilesTree_Mn02_Mn01.Name = "DataFilesTree_Mn02_Mn01";
            this.DataFilesTree_Mn02_Mn01.Size = new System.Drawing.Size(80, 22);
            this.DataFilesTree_Mn02_Mn01.Text = "1";
            this.DataFilesTree_Mn02_Mn01.Click += new System.EventHandler(this.DataFilesTree_Mn02_Mn01_Click);
            // 
            // DataFilesTree_Mn02_Mn02
            // 
            this.DataFilesTree_Mn02_Mn02.Name = "DataFilesTree_Mn02_Mn02";
            this.DataFilesTree_Mn02_Mn02.Size = new System.Drawing.Size(80, 22);
            this.DataFilesTree_Mn02_Mn02.Text = "2";
            this.DataFilesTree_Mn02_Mn02.Click += new System.EventHandler(this.DataFilesTree_Mn02_Mn02_Click);
            // 
            // DataFilesTree_Mn02_Mn03
            // 
            this.DataFilesTree_Mn02_Mn03.Name = "DataFilesTree_Mn02_Mn03";
            this.DataFilesTree_Mn02_Mn03.Size = new System.Drawing.Size(80, 22);
            this.DataFilesTree_Mn02_Mn03.Text = "3";
            this.DataFilesTree_Mn02_Mn03.Click += new System.EventHandler(this.DataFilesTree_Mn02_Mn03_Click);
            // 
            // DataFilesTree_Mn03
            // 
            this.DataFilesTree_Mn03.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DataFilesTree_Mn03_Mn01});
            this.DataFilesTree_Mn03.Name = "DataFilesTree_Mn03";
            this.DataFilesTree_Mn03.Size = new System.Drawing.Size(80, 22);
            this.DataFilesTree_Mn03.Text = "3";
            // 
            // DataFilesTree_Mn03_Mn01
            // 
            this.DataFilesTree_Mn03_Mn01.Name = "DataFilesTree_Mn03_Mn01";
            this.DataFilesTree_Mn03_Mn01.Size = new System.Drawing.Size(80, 22);
            this.DataFilesTree_Mn03_Mn01.Text = "1";
            this.DataFilesTree_Mn03_Mn01.Click += new System.EventHandler(this.DataFilesTree_Mn03_Mn01_Click);
            // 
            // DataFilesTree_Mn07
            // 
            this.DataFilesTree_Mn07.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DataFilesTree_Mn07_Mn01,
            this.DataFilesTree_Mn07_Mn02,
            this.DataFilesTree_Mn07_Mn03,
            this.DataFilesTree_Mn07_Mn04,
            this.DataFilesTree_Mn07_Mn05});
            this.DataFilesTree_Mn07.Name = "DataFilesTree_Mn07";
            this.DataFilesTree_Mn07.Size = new System.Drawing.Size(80, 22);
            this.DataFilesTree_Mn07.Text = "7";
            // 
            // DataFilesTree_Mn07_Mn01
            // 
            this.DataFilesTree_Mn07_Mn01.Name = "DataFilesTree_Mn07_Mn01";
            this.DataFilesTree_Mn07_Mn01.Size = new System.Drawing.Size(80, 22);
            this.DataFilesTree_Mn07_Mn01.Text = "1";
            this.DataFilesTree_Mn07_Mn01.Click += new System.EventHandler(this.DataFilesTree_Mn07_Mn01_Click);
            // 
            // DataFilesTree_Mn07_Mn02
            // 
            this.DataFilesTree_Mn07_Mn02.Name = "DataFilesTree_Mn07_Mn02";
            this.DataFilesTree_Mn07_Mn02.Size = new System.Drawing.Size(80, 22);
            this.DataFilesTree_Mn07_Mn02.Text = "2";
            this.DataFilesTree_Mn07_Mn02.Click += new System.EventHandler(this.DataFilesTree_Mn07_Mn02_Click);
            // 
            // DataFilesTree_Mn07_Mn03
            // 
            this.DataFilesTree_Mn07_Mn03.Name = "DataFilesTree_Mn07_Mn03";
            this.DataFilesTree_Mn07_Mn03.Size = new System.Drawing.Size(80, 22);
            this.DataFilesTree_Mn07_Mn03.Text = "3";
            this.DataFilesTree_Mn07_Mn03.Click += new System.EventHandler(this.DataFilesTree_Mn07_Mn03_Click);
            // 
            // DataFilesTree_Mn07_Mn04
            // 
            this.DataFilesTree_Mn07_Mn04.Name = "DataFilesTree_Mn07_Mn04";
            this.DataFilesTree_Mn07_Mn04.Size = new System.Drawing.Size(80, 22);
            this.DataFilesTree_Mn07_Mn04.Text = "4";
            this.DataFilesTree_Mn07_Mn04.Click += new System.EventHandler(this.DataFilesTree_Mn07_Mn04_Click);
            // 
            // DataFilesTree_Mn07_Mn05
            // 
            this.DataFilesTree_Mn07_Mn05.Name = "DataFilesTree_Mn07_Mn05";
            this.DataFilesTree_Mn07_Mn05.Size = new System.Drawing.Size(80, 22);
            this.DataFilesTree_Mn07_Mn05.Text = "5";
            this.DataFilesTree_Mn07_Mn05.Click += new System.EventHandler(this.DataFilesTree_Mn07_Mn05_Click);
            // 
            // DataFilesTree_Mn06
            // 
            this.DataFilesTree_Mn06.Name = "DataFilesTree_Mn06";
            this.DataFilesTree_Mn06.Size = new System.Drawing.Size(80, 22);
            this.DataFilesTree_Mn06.Text = "6";
            this.DataFilesTree_Mn06.DropDownOpening += new System.EventHandler(this.DataFilesTree_Mn06_DropDownOpening);
            this.DataFilesTree_Mn06.Click += new System.EventHandler(this.DataFilesTree_Mn06_Click);
            // 
            // DataFilesTree_Mn04
            // 
            this.DataFilesTree_Mn04.Name = "DataFilesTree_Mn04";
            this.DataFilesTree_Mn04.Size = new System.Drawing.Size(80, 22);
            this.DataFilesTree_Mn04.Text = "4";
            this.DataFilesTree_Mn04.Click += new System.EventHandler(this.DataFilesTree_Mn04_Click);
            // 
            // DataFilesTree_Mn05
            // 
            this.DataFilesTree_Mn05.Name = "DataFilesTree_Mn05";
            this.DataFilesTree_Mn05.Size = new System.Drawing.Size(80, 22);
            this.DataFilesTree_Mn05.Text = "5";
            this.DataFilesTree_Mn05.Click += new System.EventHandler(this.DataFilesTree_Mn05_Click);
            // 
            // DataFilesTree_Mn08
            // 
            this.DataFilesTree_Mn08.Name = "DataFilesTree_Mn08";
            this.DataFilesTree_Mn08.Size = new System.Drawing.Size(80, 22);
            this.DataFilesTree_Mn08.Text = "8";
            this.DataFilesTree_Mn08.Click += new System.EventHandler(this.DataFilesTree_Mn08_Click);
            // 
            // DataFilesTreeImages
            // 
            this.DataFilesTreeImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("DataFilesTreeImages.ImageStream")));
            this.DataFilesTreeImages.TransparentColor = System.Drawing.Color.Transparent;
            this.DataFilesTreeImages.Images.SetKeyName(0, "i_disk.ico");
            this.DataFilesTreeImages.Images.SetKeyName(1, "i_folder.ico");
            this.DataFilesTreeImages.Images.SetKeyName(2, "i_video.ico");
            this.DataFilesTreeImages.Images.SetKeyName(3, "239.ico");
            this.DataFilesTreeImages.Images.SetKeyName(4, "101.ico");
            this.DataFilesTreeImages.Images.SetKeyName(5, "102.ico");
            this.DataFilesTreeImages.Images.SetKeyName(6, "103.ico");
            this.DataFilesTreeImages.Images.SetKeyName(7, "104.ico");
            this.DataFilesTreeImages.Images.SetKeyName(8, "105.ico");
            this.DataFilesTreeImages.Images.SetKeyName(9, "106.ico");
            this.DataFilesTreeImages.Images.SetKeyName(10, "107.ico");
            this.DataFilesTreeImages.Images.SetKeyName(11, "108.ico");
            this.DataFilesTreeImages.Images.SetKeyName(12, "109.ico");
            this.DataFilesTreeImages.Images.SetKeyName(13, "110.ico");
            this.DataFilesTreeImages.Images.SetKeyName(14, "111.ico");
            this.DataFilesTreeImages.Images.SetKeyName(15, "112.ico");
            this.DataFilesTreeImages.Images.SetKeyName(16, "113.ico");
            this.DataFilesTreeImages.Images.SetKeyName(17, "114.ico");
            this.DataFilesTreeImages.Images.SetKeyName(18, "115.ico");
            this.DataFilesTreeImages.Images.SetKeyName(19, "116.ico");
            this.DataFilesTreeImages.Images.SetKeyName(20, "117.ico");
            this.DataFilesTreeImages.Images.SetKeyName(21, "118.ico");
            this.DataFilesTreeImages.Images.SetKeyName(22, "119.ico");
            this.DataFilesTreeImages.Images.SetKeyName(23, "120.ico");
            this.DataFilesTreeImages.Images.SetKeyName(24, "121.ico");
            this.DataFilesTreeImages.Images.SetKeyName(25, "122.ico");
            this.DataFilesTreeImages.Images.SetKeyName(26, "123.ico");
            this.DataFilesTreeImages.Images.SetKeyName(27, "124.ico");
            this.DataFilesTreeImages.Images.SetKeyName(28, "125.ico");
            this.DataFilesTreeImages.Images.SetKeyName(29, "126.ico");
            this.DataFilesTreeImages.Images.SetKeyName(30, "127.ico");
            this.DataFilesTreeImages.Images.SetKeyName(31, "128.ico");
            this.DataFilesTreeImages.Images.SetKeyName(32, "129.ico");
            this.DataFilesTreeImages.Images.SetKeyName(33, "130.ico");
            this.DataFilesTreeImages.Images.SetKeyName(34, "131.ico");
            this.DataFilesTreeImages.Images.SetKeyName(35, "132.ico");
            this.DataFilesTreeImages.Images.SetKeyName(36, "133.ico");
            this.DataFilesTreeImages.Images.SetKeyName(37, "134.ico");
            this.DataFilesTreeImages.Images.SetKeyName(38, "135.ico");
            this.DataFilesTreeImages.Images.SetKeyName(39, "136.ico");
            this.DataFilesTreeImages.Images.SetKeyName(40, "137.ico");
            this.DataFilesTreeImages.Images.SetKeyName(41, "138.ico");
            this.DataFilesTreeImages.Images.SetKeyName(42, "139.ico");
            this.DataFilesTreeImages.Images.SetKeyName(43, "140.ico");
            this.DataFilesTreeImages.Images.SetKeyName(44, "141.ico");
            this.DataFilesTreeImages.Images.SetKeyName(45, "142.ico");
            this.DataFilesTreeImages.Images.SetKeyName(46, "143.ico");
            this.DataFilesTreeImages.Images.SetKeyName(47, "144.ico");
            this.DataFilesTreeImages.Images.SetKeyName(48, "145.ico");
            this.DataFilesTreeImages.Images.SetKeyName(49, "146.ico");
            this.DataFilesTreeImages.Images.SetKeyName(50, "147.ico");
            this.DataFilesTreeImages.Images.SetKeyName(51, "148.ico");
            this.DataFilesTreeImages.Images.SetKeyName(52, "149.ico");
            this.DataFilesTreeImages.Images.SetKeyName(53, "150.ico");
            this.DataFilesTreeImages.Images.SetKeyName(54, "151.ico");
            this.DataFilesTreeImages.Images.SetKeyName(55, "152.ico");
            this.DataFilesTreeImages.Images.SetKeyName(56, "153.ico");
            this.DataFilesTreeImages.Images.SetKeyName(57, "154.ico");
            this.DataFilesTreeImages.Images.SetKeyName(58, "155.ico");
            this.DataFilesTreeImages.Images.SetKeyName(59, "156.ico");
            this.DataFilesTreeImages.Images.SetKeyName(60, "157.ico");
            this.DataFilesTreeImages.Images.SetKeyName(61, "158.ico");
            this.DataFilesTreeImages.Images.SetKeyName(62, "159.ico");
            this.DataFilesTreeImages.Images.SetKeyName(63, "160.ico");
            this.DataFilesTreeImages.Images.SetKeyName(64, "161.ico");
            this.DataFilesTreeImages.Images.SetKeyName(65, "162.ico");
            this.DataFilesTreeImages.Images.SetKeyName(66, "163.ico");
            this.DataFilesTreeImages.Images.SetKeyName(67, "164.ico");
            this.DataFilesTreeImages.Images.SetKeyName(68, "165.ico");
            this.DataFilesTreeImages.Images.SetKeyName(69, "166.ico");
            this.DataFilesTreeImages.Images.SetKeyName(70, "167.ico");
            this.DataFilesTreeImages.Images.SetKeyName(71, "168.ico");
            this.DataFilesTreeImages.Images.SetKeyName(72, "169.ico");
            this.DataFilesTreeImages.Images.SetKeyName(73, "170.ico");
            this.DataFilesTreeImages.Images.SetKeyName(74, "171.ico");
            this.DataFilesTreeImages.Images.SetKeyName(75, "172.ico");
            this.DataFilesTreeImages.Images.SetKeyName(76, "173.ico");
            this.DataFilesTreeImages.Images.SetKeyName(77, "174.ico");
            this.DataFilesTreeImages.Images.SetKeyName(78, "175.ico");
            this.DataFilesTreeImages.Images.SetKeyName(79, "176.ico");
            this.DataFilesTreeImages.Images.SetKeyName(80, "177.ico");
            this.DataFilesTreeImages.Images.SetKeyName(81, "178.ico");
            this.DataFilesTreeImages.Images.SetKeyName(82, "179.ico");
            this.DataFilesTreeImages.Images.SetKeyName(83, "180.ico");
            this.DataFilesTreeImages.Images.SetKeyName(84, "181.ico");
            this.DataFilesTreeImages.Images.SetKeyName(85, "182.ico");
            this.DataFilesTreeImages.Images.SetKeyName(86, "183.ico");
            this.DataFilesTreeImages.Images.SetKeyName(87, "184.ico");
            this.DataFilesTreeImages.Images.SetKeyName(88, "185.ico");
            this.DataFilesTreeImages.Images.SetKeyName(89, "186.ico");
            this.DataFilesTreeImages.Images.SetKeyName(90, "187.ico");
            this.DataFilesTreeImages.Images.SetKeyName(91, "188.ico");
            this.DataFilesTreeImages.Images.SetKeyName(92, "189.ico");
            this.DataFilesTreeImages.Images.SetKeyName(93, "190.ico");
            this.DataFilesTreeImages.Images.SetKeyName(94, "191.ico");
            this.DataFilesTreeImages.Images.SetKeyName(95, "192.ico");
            this.DataFilesTreeImages.Images.SetKeyName(96, "193.ico");
            this.DataFilesTreeImages.Images.SetKeyName(97, "194.ico");
            this.DataFilesTreeImages.Images.SetKeyName(98, "195.ico");
            this.DataFilesTreeImages.Images.SetKeyName(99, "196.ico");
            this.DataFilesTreeImages.Images.SetKeyName(100, "197.ico");
            this.DataFilesTreeImages.Images.SetKeyName(101, "198.ico");
            this.DataFilesTreeImages.Images.SetKeyName(102, "199.ico");
            this.DataFilesTreeImages.Images.SetKeyName(103, "200.ico");
            this.DataFilesTreeImages.Images.SetKeyName(104, "201.ico");
            this.DataFilesTreeImages.Images.SetKeyName(105, "202.ico");
            this.DataFilesTreeImages.Images.SetKeyName(106, "203.ico");
            this.DataFilesTreeImages.Images.SetKeyName(107, "204.ico");
            this.DataFilesTreeImages.Images.SetKeyName(108, "205.ico");
            this.DataFilesTreeImages.Images.SetKeyName(109, "206.ico");
            this.DataFilesTreeImages.Images.SetKeyName(110, "207.ico");
            this.DataFilesTreeImages.Images.SetKeyName(111, "208.ico");
            this.DataFilesTreeImages.Images.SetKeyName(112, "209.ico");
            this.DataFilesTreeImages.Images.SetKeyName(113, "210.ico");
            this.DataFilesTreeImages.Images.SetKeyName(114, "211.ico");
            this.DataFilesTreeImages.Images.SetKeyName(115, "212.ico");
            this.DataFilesTreeImages.Images.SetKeyName(116, "213.ico");
            this.DataFilesTreeImages.Images.SetKeyName(117, "214.ico");
            this.DataFilesTreeImages.Images.SetKeyName(118, "215.ico");
            this.DataFilesTreeImages.Images.SetKeyName(119, "216.ico");
            this.DataFilesTreeImages.Images.SetKeyName(120, "217.ico");
            this.DataFilesTreeImages.Images.SetKeyName(121, "218.ico");
            this.DataFilesTreeImages.Images.SetKeyName(122, "219.ico");
            this.DataFilesTreeImages.Images.SetKeyName(123, "220.ico");
            this.DataFilesTreeImages.Images.SetKeyName(124, "221.ico");
            this.DataFilesTreeImages.Images.SetKeyName(125, "222.ico");
            this.DataFilesTreeImages.Images.SetKeyName(126, "223.ico");
            this.DataFilesTreeImages.Images.SetKeyName(127, "224.ico");
            this.DataFilesTreeImages.Images.SetKeyName(128, "225.ico");
            this.DataFilesTreeImages.Images.SetKeyName(129, "226.ico");
            this.DataFilesTreeImages.Images.SetKeyName(130, "227.ico");
            this.DataFilesTreeImages.Images.SetKeyName(131, "228.ico");
            this.DataFilesTreeImages.Images.SetKeyName(132, "229.ico");
            this.DataFilesTreeImages.Images.SetKeyName(133, "230.ico");
            this.DataFilesTreeImages.Images.SetKeyName(134, "231.ico");
            this.DataFilesTreeImages.Images.SetKeyName(135, "232.ico");
            this.DataFilesTreeImages.Images.SetKeyName(136, "233.ico");
            this.DataFilesTreeImages.Images.SetKeyName(137, "234.ico");
            this.DataFilesTreeImages.Images.SetKeyName(138, "235.ico");
            this.DataFilesTreeImages.Images.SetKeyName(139, "236.ico");
            this.DataFilesTreeImages.Images.SetKeyName(140, "237.ico");
            this.DataFilesTreeImages.Images.SetKeyName(141, "238.ico");
            // 
            // DataFiles_RB05
            // 
            this.DataFiles_RB05.AutoSize = true;
            this.DataFiles_RB05.ForeColor = System.Drawing.Color.Black;
            this.DataFiles_RB05.Location = new System.Drawing.Point(548, 6);
            this.DataFiles_RB05.Name = "DataFiles_RB05";
            this.DataFiles_RB05.Size = new System.Drawing.Size(85, 17);
            this.DataFiles_RB05.TabIndex = 0;
            this.DataFiles_RB05.Text = "radioButton1";
            this.DataFiles_RB05.UseVisualStyleBackColor = true;
            this.DataFiles_RB05.CheckedChanged += new System.EventHandler(this.DataFiles_RB01_CheckedChanged);
            // 
            // DataFiles_RB04
            // 
            this.DataFiles_RB04.AutoSize = true;
            this.DataFiles_RB04.Checked = true;
            this.DataFiles_RB04.ForeColor = System.Drawing.Color.Black;
            this.DataFiles_RB04.Location = new System.Drawing.Point(457, 6);
            this.DataFiles_RB04.Name = "DataFiles_RB04";
            this.DataFiles_RB04.Size = new System.Drawing.Size(85, 17);
            this.DataFiles_RB04.TabIndex = 0;
            this.DataFiles_RB04.TabStop = true;
            this.DataFiles_RB04.Text = "radioButton1";
            this.DataFiles_RB04.UseVisualStyleBackColor = true;
            this.DataFiles_RB04.CheckedChanged += new System.EventHandler(this.DataFiles_RB01_CheckedChanged);
            // 
            // DataFiles_Year
            // 
            this.DataFiles_Year.ForeColor = System.Drawing.Color.Black;
            this.DataFiles_Year.Location = new System.Drawing.Point(371, 6);
            this.DataFiles_Year.Maximum = new decimal(new int[] {
            2999,
            0,
            0,
            0});
            this.DataFiles_Year.Minimum = new decimal(new int[] {
            2009,
            0,
            0,
            0});
            this.DataFiles_Year.Name = "DataFiles_Year";
            this.DataFiles_Year.Size = new System.Drawing.Size(80, 20);
            this.DataFiles_Year.TabIndex = 0;
            this.DataFiles_Year.Value = new decimal(new int[] {
            2009,
            0,
            0,
            0});
            this.DataFiles_Year.ValueChanged += new System.EventHandler(this.DataFiles_Day_ValueChanged);
            // 
            // DataFiles_Month
            // 
            this.DataFiles_Month.ForeColor = System.Drawing.Color.Black;
            this.DataFiles_Month.Location = new System.Drawing.Point(325, 6);
            this.DataFiles_Month.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.DataFiles_Month.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DataFiles_Month.Name = "DataFiles_Month";
            this.DataFiles_Month.Size = new System.Drawing.Size(40, 20);
            this.DataFiles_Month.TabIndex = 0;
            this.DataFiles_Month.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DataFiles_Month.ValueChanged += new System.EventHandler(this.DataFiles_Day_ValueChanged);
            // 
            // DataFiles_Day
            // 
            this.DataFiles_Day.ForeColor = System.Drawing.Color.Black;
            this.DataFiles_Day.Location = new System.Drawing.Point(279, 6);
            this.DataFiles_Day.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.DataFiles_Day.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DataFiles_Day.Name = "DataFiles_Day";
            this.DataFiles_Day.Size = new System.Drawing.Size(40, 20);
            this.DataFiles_Day.TabIndex = 0;
            this.DataFiles_Day.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DataFiles_Day.ValueChanged += new System.EventHandler(this.DataFiles_Day_ValueChanged);
            // 
            // DataFiles_RB03
            // 
            this.DataFiles_RB03.AutoSize = true;
            this.DataFiles_RB03.ForeColor = System.Drawing.Color.Black;
            this.DataFiles_RB03.Location = new System.Drawing.Point(188, 6);
            this.DataFiles_RB03.Name = "DataFiles_RB03";
            this.DataFiles_RB03.Size = new System.Drawing.Size(85, 17);
            this.DataFiles_RB03.TabIndex = 0;
            this.DataFiles_RB03.Text = "radioButton3";
            this.DataFiles_RB03.UseVisualStyleBackColor = true;
            this.DataFiles_RB03.CheckedChanged += new System.EventHandler(this.DataFiles_RB01_CheckedChanged);
            // 
            // DataFiles_RB02
            // 
            this.DataFiles_RB02.AutoSize = true;
            this.DataFiles_RB02.ForeColor = System.Drawing.Color.Black;
            this.DataFiles_RB02.Location = new System.Drawing.Point(97, 6);
            this.DataFiles_RB02.Name = "DataFiles_RB02";
            this.DataFiles_RB02.Size = new System.Drawing.Size(85, 17);
            this.DataFiles_RB02.TabIndex = 0;
            this.DataFiles_RB02.Text = "radioButton2";
            this.DataFiles_RB02.UseVisualStyleBackColor = true;
            this.DataFiles_RB02.CheckedChanged += new System.EventHandler(this.DataFiles_RB01_CheckedChanged);
            // 
            // DataFiles_RB01
            // 
            this.DataFiles_RB01.AutoSize = true;
            this.DataFiles_RB01.ForeColor = System.Drawing.Color.Black;
            this.DataFiles_RB01.Location = new System.Drawing.Point(6, 6);
            this.DataFiles_RB01.Name = "DataFiles_RB01";
            this.DataFiles_RB01.Size = new System.Drawing.Size(85, 17);
            this.DataFiles_RB01.TabIndex = 0;
            this.DataFiles_RB01.Text = "radioButton1";
            this.DataFiles_RB01.UseVisualStyleBackColor = true;
            this.DataFiles_RB01.CheckedChanged += new System.EventHandler(this.DataFiles_RB01_CheckedChanged);
            // 
            // DataFiles_Page
            // 
            this.DataFiles_Page.BackColor = System.Drawing.Color.White;
            this.DataFiles_Page.ForeColor = System.Drawing.Color.Black;
            this.DataFiles_Page.Location = new System.Drawing.Point(910, 6);
            this.DataFiles_Page.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.DataFiles_Page.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DataFiles_Page.Name = "DataFiles_Page";
            this.DataFiles_Page.Size = new System.Drawing.Size(72, 20);
            this.DataFiles_Page.TabIndex = 0;
            this.DataFiles_Page.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DataFiles_Page.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.DataFiles_Page.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DataFiles_Page.ValueChanged += new System.EventHandler(this.DataFiles_Page_ValueChanged);
            // 
            // DataFiles_Rows
            // 
            this.DataFiles_Rows.BackColor = System.Drawing.Color.White;
            this.DataFiles_Rows.ForeColor = System.Drawing.Color.Black;
            this.DataFiles_Rows.Location = new System.Drawing.Point(1018, 6);
            this.DataFiles_Rows.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.DataFiles_Rows.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.DataFiles_Rows.Name = "DataFiles_Rows";
            this.DataFiles_Rows.Size = new System.Drawing.Size(72, 20);
            this.DataFiles_Rows.TabIndex = 0;
            this.DataFiles_Rows.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DataFiles_Rows.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.DataFiles_Rows.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.DataFiles_Rows.ValueChanged += new System.EventHandler(this.DataFiles_Page_ValueChanged);
            // 
            // DataFiles
            // 
            this.DataFiles.AllowUserToAddRows = false;
            this.DataFiles.AllowUserToDeleteRows = false;
            this.DataFiles.AllowUserToResizeRows = false;
            this.DataFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataFiles.BackgroundColor = System.Drawing.Color.White;
            this.DataFiles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DataFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataFiles_Mn00,
            this.DataFiles_Mn01,
            this.DataFiles_Mn02,
            this.DataFiles_Mn03,
            this.DataFiles_Mn04,
            this.DataFiles_Mn05,
            this.DataFiles_Mn06,
            this.DataFiles_Mn07,
            this.DataFiles_Mn08,
            this.DataFiles_Mn09,
            this.DataFiles_Mn10,
            this.DataFiles_Mn11,
            this.DataFiles_Mn12,
            this.DataFiles_Mn13,
            this.DataFiles_Mn14,
            this.DataFiles_Mn15,
            this.DataFiles_Mn16,
            this.DataFiles_Mn17});
            this.DataFiles.ContextMenuStrip = this.DataFiles_Menu;
            this.DataFiles.GridColor = System.Drawing.Color.White;
            this.DataFiles.Location = new System.Drawing.Point(6, 32);
            this.DataFiles.Name = "DataFiles";
            this.DataFiles.ReadOnly = true;
            this.DataFiles.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataFiles.RowHeadersVisible = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.DataFiles.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.DataFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataFiles.Size = new System.Drawing.Size(1093, 555);
            this.DataFiles.TabIndex = 0;
            this.DataFiles.SelectionChanged += new System.EventHandler(this.DataFiles_SelectionChanged);
            this.DataFiles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DataFiles_MouseDoubleClick);
            this.DataFiles.MouseEnter += new System.EventHandler(this.DataFiles_MouseEnter);
            // 
            // DataFiles_Mn00
            // 
            this.DataFiles_Mn00.HeaderText = "";
            this.DataFiles_Mn00.Name = "DataFiles_Mn00";
            this.DataFiles_Mn00.ReadOnly = true;
            this.DataFiles_Mn00.Visible = false;
            // 
            // DataFiles_Mn01
            // 
            this.DataFiles_Mn01.HeaderText = "aID";
            this.DataFiles_Mn01.Name = "DataFiles_Mn01";
            this.DataFiles_Mn01.ReadOnly = true;
            this.DataFiles_Mn01.Width = 30;
            // 
            // DataFiles_Mn02
            // 
            this.DataFiles_Mn02.HeaderText = "eID";
            this.DataFiles_Mn02.Name = "DataFiles_Mn02";
            this.DataFiles_Mn02.ReadOnly = true;
            this.DataFiles_Mn02.Width = 30;
            // 
            // DataFiles_Mn03
            // 
            this.DataFiles_Mn03.HeaderText = "fID";
            this.DataFiles_Mn03.Name = "DataFiles_Mn03";
            this.DataFiles_Mn03.ReadOnly = true;
            this.DataFiles_Mn03.Width = 30;
            // 
            // DataFiles_Mn04
            // 
            this.DataFiles_Mn04.HeaderText = "lID";
            this.DataFiles_Mn04.Name = "DataFiles_Mn04";
            this.DataFiles_Mn04.ReadOnly = true;
            this.DataFiles_Mn04.Width = 30;
            // 
            // DataFiles_Mn05
            // 
            this.DataFiles_Mn05.HeaderText = "";
            this.DataFiles_Mn05.Name = "DataFiles_Mn05";
            this.DataFiles_Mn05.ReadOnly = true;
            this.DataFiles_Mn05.Width = 200;
            // 
            // DataFiles_Mn06
            // 
            this.DataFiles_Mn06.HeaderText = "";
            this.DataFiles_Mn06.Name = "DataFiles_Mn06";
            this.DataFiles_Mn06.ReadOnly = true;
            this.DataFiles_Mn06.Width = 250;
            // 
            // DataFiles_Mn07
            // 
            this.DataFiles_Mn07.HeaderText = "";
            this.DataFiles_Mn07.Name = "DataFiles_Mn07";
            this.DataFiles_Mn07.ReadOnly = true;
            // 
            // DataFiles_Mn08
            // 
            this.DataFiles_Mn08.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DataFiles_Mn08.HeaderText = "";
            this.DataFiles_Mn08.MinimumWidth = 250;
            this.DataFiles_Mn08.Name = "DataFiles_Mn08";
            this.DataFiles_Mn08.ReadOnly = true;
            // 
            // DataFiles_Mn09
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DataFiles_Mn09.DefaultCellStyle = dataGridViewCellStyle7;
            this.DataFiles_Mn09.HeaderText = "";
            this.DataFiles_Mn09.Name = "DataFiles_Mn09";
            this.DataFiles_Mn09.ReadOnly = true;
            // 
            // DataFiles_Mn10
            // 
            this.DataFiles_Mn10.HeaderText = "";
            this.DataFiles_Mn10.Name = "DataFiles_Mn10";
            this.DataFiles_Mn10.ReadOnly = true;
            this.DataFiles_Mn10.Width = 50;
            // 
            // DataFiles_Mn11
            // 
            this.DataFiles_Mn11.HeaderText = "";
            this.DataFiles_Mn11.Name = "DataFiles_Mn11";
            this.DataFiles_Mn11.ReadOnly = true;
            this.DataFiles_Mn11.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DataFiles_Mn11.Width = 23;
            // 
            // DataFiles_Mn12
            // 
            this.DataFiles_Mn12.HeaderText = "";
            this.DataFiles_Mn12.Name = "DataFiles_Mn12";
            this.DataFiles_Mn12.ReadOnly = true;
            this.DataFiles_Mn12.Width = 23;
            // 
            // DataFiles_Mn13
            // 
            this.DataFiles_Mn13.HeaderText = "";
            this.DataFiles_Mn13.Name = "DataFiles_Mn13";
            this.DataFiles_Mn13.ReadOnly = true;
            this.DataFiles_Mn13.Width = 23;
            // 
            // DataFiles_Mn14
            // 
            this.DataFiles_Mn14.HeaderText = "";
            this.DataFiles_Mn14.Name = "DataFiles_Mn14";
            this.DataFiles_Mn14.ReadOnly = true;
            this.DataFiles_Mn14.Width = 23;
            // 
            // DataFiles_Mn15
            // 
            this.DataFiles_Mn15.HeaderText = "";
            this.DataFiles_Mn15.Name = "DataFiles_Mn15";
            this.DataFiles_Mn15.ReadOnly = true;
            this.DataFiles_Mn15.Width = 23;
            // 
            // DataFiles_Mn16
            // 
            this.DataFiles_Mn16.HeaderText = "";
            this.DataFiles_Mn16.Name = "DataFiles_Mn16";
            this.DataFiles_Mn16.ReadOnly = true;
            this.DataFiles_Mn16.Width = 300;
            // 
            // DataFiles_Mn17
            // 
            this.DataFiles_Mn17.HeaderText = "";
            this.DataFiles_Mn17.Name = "DataFiles_Mn17";
            this.DataFiles_Mn17.ReadOnly = true;
            // 
            // DataFiles_Menu
            // 
            this.DataFiles_Menu.BackColor = System.Drawing.Color.White;
            this.DataFiles_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DataFiles_Menu_Mn01,
            this.DataFiles_Menu_Mn02,
            this.DataFiles_Menu_Mn05,
            this.DataFiles_Menu_Mn06,
            this.DataFiles_Menu_Mn03,
            this.DataFiles_Menu_Mn04,
            this.DataFiles_Menu_Mn07});
            this.DataFiles_Menu.Name = "Data";
            this.DataFiles_Menu.Size = new System.Drawing.Size(81, 158);
            this.DataFiles_Menu.Opening += new System.ComponentModel.CancelEventHandler(this.DataFiles_Menu_Opening);
            // 
            // DataFiles_Menu_Mn01
            // 
            this.DataFiles_Menu_Mn01.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DataFiles_Menu_Mn01_Mn01,
            this.DataFiles_Menu_Mn01_Mn02,
            this.DataFiles_Menu_Mn01_Mn03});
            this.DataFiles_Menu_Mn01.Name = "DataFiles_Menu_Mn01";
            this.DataFiles_Menu_Mn01.Size = new System.Drawing.Size(80, 22);
            this.DataFiles_Menu_Mn01.Text = "1";
            // 
            // DataFiles_Menu_Mn01_Mn01
            // 
            this.DataFiles_Menu_Mn01_Mn01.Name = "DataFiles_Menu_Mn01_Mn01";
            this.DataFiles_Menu_Mn01_Mn01.Size = new System.Drawing.Size(80, 22);
            this.DataFiles_Menu_Mn01_Mn01.Text = "1";
            this.DataFiles_Menu_Mn01_Mn01.Click += new System.EventHandler(this.DataFiles_Menu_Mn01_Mn01_Click);
            // 
            // DataFiles_Menu_Mn01_Mn02
            // 
            this.DataFiles_Menu_Mn01_Mn02.Name = "DataFiles_Menu_Mn01_Mn02";
            this.DataFiles_Menu_Mn01_Mn02.Size = new System.Drawing.Size(80, 22);
            this.DataFiles_Menu_Mn01_Mn02.Text = "2";
            this.DataFiles_Menu_Mn01_Mn02.Click += new System.EventHandler(this.DataFiles_Menu_Mn01_Mn02_Click);
            // 
            // DataFiles_Menu_Mn01_Mn03
            // 
            this.DataFiles_Menu_Mn01_Mn03.Name = "DataFiles_Menu_Mn01_Mn03";
            this.DataFiles_Menu_Mn01_Mn03.Size = new System.Drawing.Size(80, 22);
            this.DataFiles_Menu_Mn01_Mn03.Text = "3";
            this.DataFiles_Menu_Mn01_Mn03.Click += new System.EventHandler(this.DataFiles_Menu_Mn01_Mn03_Click);
            // 
            // DataFiles_Menu_Mn02
            // 
            this.DataFiles_Menu_Mn02.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DataFiles_Menu_Mn02_Mn01});
            this.DataFiles_Menu_Mn02.Name = "DataFiles_Menu_Mn02";
            this.DataFiles_Menu_Mn02.Size = new System.Drawing.Size(80, 22);
            this.DataFiles_Menu_Mn02.Text = "2";
            // 
            // DataFiles_Menu_Mn02_Mn01
            // 
            this.DataFiles_Menu_Mn02_Mn01.Name = "DataFiles_Menu_Mn02_Mn01";
            this.DataFiles_Menu_Mn02_Mn01.Size = new System.Drawing.Size(80, 22);
            this.DataFiles_Menu_Mn02_Mn01.Text = "1";
            this.DataFiles_Menu_Mn02_Mn01.Click += new System.EventHandler(this.DataFiles_Menu_Mn02_Mn01_Click);
            // 
            // DataFiles_Menu_Mn05
            // 
            this.DataFiles_Menu_Mn05.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DataFiles_Menu_Mn05_Mn01,
            this.DataFiles_Menu_Mn05_Mn02,
            this.DataFiles_Menu_Mn05_Mn03,
            this.DataFiles_Menu_Mn05_Mn04,
            this.DataFiles_Menu_Mn05_Mn05});
            this.DataFiles_Menu_Mn05.Name = "DataFiles_Menu_Mn05";
            this.DataFiles_Menu_Mn05.Size = new System.Drawing.Size(80, 22);
            this.DataFiles_Menu_Mn05.Text = "5";
            // 
            // DataFiles_Menu_Mn05_Mn01
            // 
            this.DataFiles_Menu_Mn05_Mn01.Name = "DataFiles_Menu_Mn05_Mn01";
            this.DataFiles_Menu_Mn05_Mn01.Size = new System.Drawing.Size(80, 22);
            this.DataFiles_Menu_Mn05_Mn01.Text = "1";
            this.DataFiles_Menu_Mn05_Mn01.Click += new System.EventHandler(this.DataFiles_Menu_Mn05_Mn01_Click);
            // 
            // DataFiles_Menu_Mn05_Mn02
            // 
            this.DataFiles_Menu_Mn05_Mn02.Name = "DataFiles_Menu_Mn05_Mn02";
            this.DataFiles_Menu_Mn05_Mn02.Size = new System.Drawing.Size(80, 22);
            this.DataFiles_Menu_Mn05_Mn02.Text = "3";
            this.DataFiles_Menu_Mn05_Mn02.Click += new System.EventHandler(this.DataFiles_Menu_Mn05_Mn02_Click);
            // 
            // DataFiles_Menu_Mn05_Mn03
            // 
            this.DataFiles_Menu_Mn05_Mn03.Name = "DataFiles_Menu_Mn05_Mn03";
            this.DataFiles_Menu_Mn05_Mn03.Size = new System.Drawing.Size(80, 22);
            this.DataFiles_Menu_Mn05_Mn03.Text = "4";
            this.DataFiles_Menu_Mn05_Mn03.Click += new System.EventHandler(this.DataFiles_Menu_Mn05_Mn03_Click);
            // 
            // DataFiles_Menu_Mn05_Mn04
            // 
            this.DataFiles_Menu_Mn05_Mn04.Name = "DataFiles_Menu_Mn05_Mn04";
            this.DataFiles_Menu_Mn05_Mn04.Size = new System.Drawing.Size(80, 22);
            this.DataFiles_Menu_Mn05_Mn04.Text = "5";
            this.DataFiles_Menu_Mn05_Mn04.Click += new System.EventHandler(this.DataFiles_Menu_Mn05_Mn04_Click);
            // 
            // DataFiles_Menu_Mn05_Mn05
            // 
            this.DataFiles_Menu_Mn05_Mn05.Name = "DataFiles_Menu_Mn05_Mn05";
            this.DataFiles_Menu_Mn05_Mn05.Size = new System.Drawing.Size(80, 22);
            this.DataFiles_Menu_Mn05_Mn05.Text = "2";
            this.DataFiles_Menu_Mn05_Mn05.Click += new System.EventHandler(this.DataFiles_Menu_Mn05_Mn05_Click);
            // 
            // DataFiles_Menu_Mn06
            // 
            this.DataFiles_Menu_Mn06.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DataFiles_Menu_Mn06_Mn01,
            this.DataFiles_Menu_Mn06_Mn02,
            this.DataFiles_Menu_Mn06_Mn03,
            this.DataFiles_Menu_Mn06_Mn04});
            this.DataFiles_Menu_Mn06.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DataFiles_Menu_Mn06.Name = "DataFiles_Menu_Mn06";
            this.DataFiles_Menu_Mn06.Size = new System.Drawing.Size(80, 22);
            this.DataFiles_Menu_Mn06.Text = "6";
            this.DataFiles_Menu_Mn06.Click += new System.EventHandler(this.DataFiles_Menu_Mn06_Click);
            // 
            // DataFiles_Menu_Mn06_Mn01
            // 
            this.DataFiles_Menu_Mn06_Mn01.BackColor = System.Drawing.Color.Transparent;
            this.DataFiles_Menu_Mn06_Mn01.CheckOnClick = true;
            this.DataFiles_Menu_Mn06_Mn01.ForeColor = System.Drawing.Color.Black;
            this.DataFiles_Menu_Mn06_Mn01.Name = "DataFiles_Menu_Mn06_Mn01";
            this.DataFiles_Menu_Mn06_Mn01.Size = new System.Drawing.Size(80, 22);
            this.DataFiles_Menu_Mn06_Mn01.Text = "1";
            // 
            // DataFiles_Menu_Mn06_Mn02
            // 
            this.DataFiles_Menu_Mn06_Mn02.BackColor = System.Drawing.Color.Transparent;
            this.DataFiles_Menu_Mn06_Mn02.CheckOnClick = true;
            this.DataFiles_Menu_Mn06_Mn02.ForeColor = System.Drawing.Color.Black;
            this.DataFiles_Menu_Mn06_Mn02.Name = "DataFiles_Menu_Mn06_Mn02";
            this.DataFiles_Menu_Mn06_Mn02.Size = new System.Drawing.Size(80, 22);
            this.DataFiles_Menu_Mn06_Mn02.Text = "2";
            this.DataFiles_Menu_Mn06_Mn02.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // DataFiles_Menu_Mn06_Mn03
            // 
            this.DataFiles_Menu_Mn06_Mn03.BackColor = System.Drawing.Color.Transparent;
            this.DataFiles_Menu_Mn06_Mn03.CheckOnClick = true;
            this.DataFiles_Menu_Mn06_Mn03.ForeColor = System.Drawing.Color.Black;
            this.DataFiles_Menu_Mn06_Mn03.Name = "DataFiles_Menu_Mn06_Mn03";
            this.DataFiles_Menu_Mn06_Mn03.Size = new System.Drawing.Size(80, 22);
            this.DataFiles_Menu_Mn06_Mn03.Text = "3";
            // 
            // DataFiles_Menu_Mn06_Mn04
            // 
            this.DataFiles_Menu_Mn06_Mn04.BackColor = System.Drawing.Color.Transparent;
            this.DataFiles_Menu_Mn06_Mn04.CheckOnClick = true;
            this.DataFiles_Menu_Mn06_Mn04.ForeColor = System.Drawing.Color.Black;
            this.DataFiles_Menu_Mn06_Mn04.Name = "DataFiles_Menu_Mn06_Mn04";
            this.DataFiles_Menu_Mn06_Mn04.Size = new System.Drawing.Size(80, 22);
            this.DataFiles_Menu_Mn06_Mn04.Text = "4";
            // 
            // DataFiles_Menu_Mn03
            // 
            this.DataFiles_Menu_Mn03.Name = "DataFiles_Menu_Mn03";
            this.DataFiles_Menu_Mn03.Size = new System.Drawing.Size(80, 22);
            this.DataFiles_Menu_Mn03.Text = "3";
            this.DataFiles_Menu_Mn03.DropDownOpening += new System.EventHandler(this.DataFiles_Menu_Mn03_DropDownOpening);
            this.DataFiles_Menu_Mn03.Click += new System.EventHandler(this.DataFiles_Menu_Mn03_Click);
            // 
            // DataFiles_Menu_Mn04
            // 
            this.DataFiles_Menu_Mn04.Name = "DataFiles_Menu_Mn04";
            this.DataFiles_Menu_Mn04.Size = new System.Drawing.Size(80, 22);
            this.DataFiles_Menu_Mn04.Text = "4";
            this.DataFiles_Menu_Mn04.Click += new System.EventHandler(this.DataFiles_Menu_Mn04_Click);
            // 
            // DataFiles_Menu_Mn07
            // 
            this.DataFiles_Menu_Mn07.Name = "DataFiles_Menu_Mn07";
            this.DataFiles_Menu_Mn07.Size = new System.Drawing.Size(80, 22);
            this.DataFiles_Menu_Mn07.Text = "7";
            this.DataFiles_Menu_Mn07.Click += new System.EventHandler(this.DataFiles_Menu_Mn07_Click);
            // 
            // MainTabData_AnimeTabPage
            // 
            this.MainTabData_AnimeTabPage.BackColor = System.Drawing.Color.White;
            this.MainTabData_AnimeTabPage.Controls.Add(this.DataAnime_Page);
            this.MainTabData_AnimeTabPage.Controls.Add(this.DataAnime_Rows);
            this.MainTabData_AnimeTabPage.Controls.Add(this.DataAnime);
            this.MainTabData_AnimeTabPage.Location = new System.Drawing.Point(4, 22);
            this.MainTabData_AnimeTabPage.Name = "MainTabData_AnimeTabPage";
            this.MainTabData_AnimeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.MainTabData_AnimeTabPage.Size = new System.Drawing.Size(1105, 648);
            this.MainTabData_AnimeTabPage.TabIndex = 0;
            this.MainTabData_AnimeTabPage.Text = "2";
            this.MainTabData_AnimeTabPage.UseVisualStyleBackColor = true;
            // 
            // DataAnime_Page
            // 
            this.DataAnime_Page.BackColor = System.Drawing.Color.White;
            this.DataAnime_Page.ForeColor = System.Drawing.Color.Black;
            this.DataAnime_Page.Location = new System.Drawing.Point(910, 6);
            this.DataAnime_Page.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.DataAnime_Page.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DataAnime_Page.Name = "DataAnime_Page";
            this.DataAnime_Page.Size = new System.Drawing.Size(72, 20);
            this.DataAnime_Page.TabIndex = 0;
            this.DataAnime_Page.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DataAnime_Page.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.DataAnime_Page.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DataAnime_Page.ValueChanged += new System.EventHandler(this.DataAnime_Page_ValueChanged);
            // 
            // DataAnime_Rows
            // 
            this.DataAnime_Rows.BackColor = System.Drawing.Color.White;
            this.DataAnime_Rows.ForeColor = System.Drawing.Color.Black;
            this.DataAnime_Rows.Location = new System.Drawing.Point(1018, 6);
            this.DataAnime_Rows.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.DataAnime_Rows.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.DataAnime_Rows.Name = "DataAnime_Rows";
            this.DataAnime_Rows.Size = new System.Drawing.Size(72, 20);
            this.DataAnime_Rows.TabIndex = 0;
            this.DataAnime_Rows.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DataAnime_Rows.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.DataAnime_Rows.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.DataAnime_Rows.ValueChanged += new System.EventHandler(this.DataAnime_Page_ValueChanged);
            // 
            // DataAnime
            // 
            this.DataAnime.AllowUserToAddRows = false;
            this.DataAnime.AllowUserToDeleteRows = false;
            this.DataAnime.AllowUserToResizeRows = false;
            this.DataAnime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataAnime.BackgroundColor = System.Drawing.Color.White;
            this.DataAnime.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DataAnime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataAnime.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataAnime_Mn00,
            this.DataAnime_Mn01,
            this.DataAnime_Mn02,
            this.DataAnime_Mn03,
            this.DataAnime_Mn04,
            this.DataAnime_Mn05,
            this.DataAnime_Mn06,
            this.DataAnime_Mn08,
            this.DataAnime_Mn09,
            this.DataAnime_Mn10,
            this.DataAnime_Mn11,
            this.DataAnime_Mn12,
            this.DataAnime_Mn13,
            this.DataAnime_Mn14,
            this.DataAnime_Mn15,
            this.DataAnime_Mn16});
            this.DataAnime.ContextMenuStrip = this.DataAnime_Menu;
            this.DataAnime.GridColor = System.Drawing.Color.White;
            this.DataAnime.Location = new System.Drawing.Point(6, 32);
            this.DataAnime.Name = "DataAnime";
            this.DataAnime.ReadOnly = true;
            this.DataAnime.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataAnime.RowHeadersVisible = false;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Black;
            this.DataAnime.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.DataAnime.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataAnime.Size = new System.Drawing.Size(1093, 610);
            this.DataAnime.TabIndex = 0;
            this.DataAnime.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DataAnime_MouseClick);
            this.DataAnime.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DataAnime_MouseDoubleClick);
            this.DataAnime.MouseEnter += new System.EventHandler(this.DataAnime_MouseEnter);
            // 
            // DataAnime_Mn00
            // 
            this.DataAnime_Mn00.HeaderText = "";
            this.DataAnime_Mn00.Name = "DataAnime_Mn00";
            this.DataAnime_Mn00.ReadOnly = true;
            this.DataAnime_Mn00.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DataAnime_Mn00.Visible = false;
            // 
            // DataAnime_Mn01
            // 
            this.DataAnime_Mn01.HeaderText = "";
            this.DataAnime_Mn01.Name = "DataAnime_Mn01";
            this.DataAnime_Mn01.ReadOnly = true;
            this.DataAnime_Mn01.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DataAnime_Mn01.Width = 15;
            // 
            // DataAnime_Mn02
            // 
            this.DataAnime_Mn02.HeaderText = "";
            this.DataAnime_Mn02.Name = "DataAnime_Mn02";
            this.DataAnime_Mn02.ReadOnly = true;
            this.DataAnime_Mn02.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DataAnime_Mn02.Width = 15;
            // 
            // DataAnime_Mn03
            // 
            this.DataAnime_Mn03.HeaderText = "";
            this.DataAnime_Mn03.Name = "DataAnime_Mn03";
            this.DataAnime_Mn03.ReadOnly = true;
            this.DataAnime_Mn03.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DataAnime_Mn03.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DataAnime_Mn03.Visible = false;
            // 
            // DataAnime_Mn04
            // 
            this.DataAnime_Mn04.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DataAnime_Mn04.HeaderText = "";
            this.DataAnime_Mn04.MinimumWidth = 500;
            this.DataAnime_Mn04.Name = "DataAnime_Mn04";
            this.DataAnime_Mn04.ReadOnly = true;
            this.DataAnime_Mn04.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DataAnime_Mn05
            // 
            this.DataAnime_Mn05.HeaderText = "";
            this.DataAnime_Mn05.Name = "DataAnime_Mn05";
            this.DataAnime_Mn05.ReadOnly = true;
            this.DataAnime_Mn05.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DataAnime_Mn06
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DataAnime_Mn06.DefaultCellStyle = dataGridViewCellStyle9;
            this.DataAnime_Mn06.HeaderText = "";
            this.DataAnime_Mn06.Name = "DataAnime_Mn06";
            this.DataAnime_Mn06.ReadOnly = true;
            this.DataAnime_Mn06.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DataAnime_Mn08
            // 
            this.DataAnime_Mn08.HeaderText = "";
            this.DataAnime_Mn08.Name = "DataAnime_Mn08";
            this.DataAnime_Mn08.ReadOnly = true;
            this.DataAnime_Mn08.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DataAnime_Mn09
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DataAnime_Mn09.DefaultCellStyle = dataGridViewCellStyle10;
            this.DataAnime_Mn09.HeaderText = "";
            this.DataAnime_Mn09.Name = "DataAnime_Mn09";
            this.DataAnime_Mn09.ReadOnly = true;
            this.DataAnime_Mn09.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DataAnime_Mn10
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DataAnime_Mn10.DefaultCellStyle = dataGridViewCellStyle11;
            this.DataAnime_Mn10.HeaderText = "";
            this.DataAnime_Mn10.Name = "DataAnime_Mn10";
            this.DataAnime_Mn10.ReadOnly = true;
            this.DataAnime_Mn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DataAnime_Mn11
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DataAnime_Mn11.DefaultCellStyle = dataGridViewCellStyle12;
            this.DataAnime_Mn11.HeaderText = "";
            this.DataAnime_Mn11.Name = "DataAnime_Mn11";
            this.DataAnime_Mn11.ReadOnly = true;
            this.DataAnime_Mn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DataAnime_Mn12
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DataAnime_Mn12.DefaultCellStyle = dataGridViewCellStyle13;
            this.DataAnime_Mn12.HeaderText = "";
            this.DataAnime_Mn12.Name = "DataAnime_Mn12";
            this.DataAnime_Mn12.ReadOnly = true;
            this.DataAnime_Mn12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DataAnime_Mn13
            // 
            this.DataAnime_Mn13.HeaderText = "";
            this.DataAnime_Mn13.Name = "DataAnime_Mn13";
            this.DataAnime_Mn13.ReadOnly = true;
            this.DataAnime_Mn13.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DataAnime_Mn13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DataAnime_Mn14
            // 
            this.DataAnime_Mn14.HeaderText = "";
            this.DataAnime_Mn14.Name = "DataAnime_Mn14";
            this.DataAnime_Mn14.ReadOnly = true;
            this.DataAnime_Mn14.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DataAnime_Mn14.Width = 23;
            // 
            // DataAnime_Mn15
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DataAnime_Mn15.DefaultCellStyle = dataGridViewCellStyle14;
            this.DataAnime_Mn15.HeaderText = "";
            this.DataAnime_Mn15.Name = "DataAnime_Mn15";
            this.DataAnime_Mn15.ReadOnly = true;
            this.DataAnime_Mn15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DataAnime_Mn16
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DataAnime_Mn16.DefaultCellStyle = dataGridViewCellStyle15;
            this.DataAnime_Mn16.HeaderText = "";
            this.DataAnime_Mn16.Name = "DataAnime_Mn16";
            this.DataAnime_Mn16.ReadOnly = true;
            this.DataAnime_Mn16.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DataAnime_Menu
            // 
            this.DataAnime_Menu.BackColor = System.Drawing.Color.White;
            this.DataAnime_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DataAnime_Menu_Expand,
            this.DataAnime_Menu_MyList,
            this.DataAnime_Menu_Database,
            this.DataAnime_Menu_Mn04});
            this.DataAnime_Menu.Name = "DataFiles_Menu";
            this.DataAnime_Menu.Size = new System.Drawing.Size(81, 92);
            // 
            // DataAnime_Menu_Expand
            // 
            this.DataAnime_Menu_Expand.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DataAnime_Menu_Expand_Anime,
            this.DataAnime_Menu_Expand_Episodes,
            this.DataAnime_Menu_Expand_All,
            this.DataAnime_Menu_Expand_CollapseEpisodes,
            this.DataAnime_Menu_Expand_CollapseAllEpisodes,
            this.DataAnime_Menu_Expand_CollapseAll});
            this.DataAnime_Menu_Expand.Name = "DataAnime_Menu_Expand";
            this.DataAnime_Menu_Expand.Size = new System.Drawing.Size(80, 22);
            this.DataAnime_Menu_Expand.Text = "1";
            // 
            // DataAnime_Menu_Expand_Anime
            // 
            this.DataAnime_Menu_Expand_Anime.Name = "DataAnime_Menu_Expand_Anime";
            this.DataAnime_Menu_Expand_Anime.Size = new System.Drawing.Size(80, 22);
            this.DataAnime_Menu_Expand_Anime.Text = "1";
            this.DataAnime_Menu_Expand_Anime.Click += new System.EventHandler(this.DataAnime_Menu_Mn01_Mn01_Click);
            // 
            // DataAnime_Menu_Expand_Episodes
            // 
            this.DataAnime_Menu_Expand_Episodes.Name = "DataAnime_Menu_Expand_Episodes";
            this.DataAnime_Menu_Expand_Episodes.Size = new System.Drawing.Size(80, 22);
            this.DataAnime_Menu_Expand_Episodes.Text = "2";
            this.DataAnime_Menu_Expand_Episodes.Click += new System.EventHandler(this.DataAnime_Menu_Mn01_Mn02_Click);
            // 
            // DataAnime_Menu_Expand_All
            // 
            this.DataAnime_Menu_Expand_All.Name = "DataAnime_Menu_Expand_All";
            this.DataAnime_Menu_Expand_All.Size = new System.Drawing.Size(80, 22);
            this.DataAnime_Menu_Expand_All.Text = "3";
            this.DataAnime_Menu_Expand_All.Click += new System.EventHandler(this.DataAnime_Menu_Mn01_Mn03_Click);
            // 
            // DataAnime_Menu_Expand_CollapseEpisodes
            // 
            this.DataAnime_Menu_Expand_CollapseEpisodes.Name = "DataAnime_Menu_Expand_CollapseEpisodes";
            this.DataAnime_Menu_Expand_CollapseEpisodes.Size = new System.Drawing.Size(80, 22);
            this.DataAnime_Menu_Expand_CollapseEpisodes.Text = "4";
            this.DataAnime_Menu_Expand_CollapseEpisodes.Click += new System.EventHandler(this.DataAnime_Menu_Mn01_Mn04_Click);
            // 
            // DataAnime_Menu_Expand_CollapseAllEpisodes
            // 
            this.DataAnime_Menu_Expand_CollapseAllEpisodes.Name = "DataAnime_Menu_Expand_CollapseAllEpisodes";
            this.DataAnime_Menu_Expand_CollapseAllEpisodes.Size = new System.Drawing.Size(80, 22);
            this.DataAnime_Menu_Expand_CollapseAllEpisodes.Text = "5";
            this.DataAnime_Menu_Expand_CollapseAllEpisodes.Click += new System.EventHandler(this.DataAnime_Menu_Mn01_Mn05_Click);
            // 
            // DataAnime_Menu_Expand_CollapseAll
            // 
            this.DataAnime_Menu_Expand_CollapseAll.Name = "DataAnime_Menu_Expand_CollapseAll";
            this.DataAnime_Menu_Expand_CollapseAll.Size = new System.Drawing.Size(80, 22);
            this.DataAnime_Menu_Expand_CollapseAll.Text = "6";
            this.DataAnime_Menu_Expand_CollapseAll.Click += new System.EventHandler(this.DataAnime_Menu_Mn01_Mn06_Click);
            // 
            // DataAnime_Menu_MyList
            // 
            this.DataAnime_Menu_MyList.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DataAnime_Menu_MyList_AddModify,
            this.DataAnime_Menu_MyList_Delete,
            this.DataAnime_Menu_MyList_Watched});
            this.DataAnime_Menu_MyList.Name = "DataAnime_Menu_MyList";
            this.DataAnime_Menu_MyList.Size = new System.Drawing.Size(80, 22);
            this.DataAnime_Menu_MyList.Text = "2";
            // 
            // DataAnime_Menu_MyList_AddModify
            // 
            this.DataAnime_Menu_MyList_AddModify.Name = "DataAnime_Menu_MyList_AddModify";
            this.DataAnime_Menu_MyList_AddModify.Size = new System.Drawing.Size(80, 22);
            this.DataAnime_Menu_MyList_AddModify.Text = "1";
            this.DataAnime_Menu_MyList_AddModify.Click += new System.EventHandler(this.DataAnime_Menu_Mn02_Mn01_Click);
            // 
            // DataAnime_Menu_MyList_Delete
            // 
            this.DataAnime_Menu_MyList_Delete.Name = "DataAnime_Menu_MyList_Delete";
            this.DataAnime_Menu_MyList_Delete.Size = new System.Drawing.Size(80, 22);
            this.DataAnime_Menu_MyList_Delete.Text = "2";
            this.DataAnime_Menu_MyList_Delete.Click += new System.EventHandler(this.DataAnime_Menu_Mn02_Mn02_Click);
            // 
            // DataAnime_Menu_MyList_Watched
            // 
            this.DataAnime_Menu_MyList_Watched.Name = "DataAnime_Menu_MyList_Watched";
            this.DataAnime_Menu_MyList_Watched.Size = new System.Drawing.Size(80, 22);
            this.DataAnime_Menu_MyList_Watched.Text = "3";
            this.DataAnime_Menu_MyList_Watched.Click += new System.EventHandler(this.DataAnime_Menu_Mn02_Mn03_Click);
            // 
            // DataAnime_Menu_Database
            // 
            this.DataAnime_Menu_Database.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DataAnime_Menu_Database_Delete});
            this.DataAnime_Menu_Database.Name = "DataAnime_Menu_Database";
            this.DataAnime_Menu_Database.Size = new System.Drawing.Size(80, 22);
            this.DataAnime_Menu_Database.Text = "3";
            // 
            // DataAnime_Menu_Database_Delete
            // 
            this.DataAnime_Menu_Database_Delete.Name = "DataAnime_Menu_Database_Delete";
            this.DataAnime_Menu_Database_Delete.Size = new System.Drawing.Size(80, 22);
            this.DataAnime_Menu_Database_Delete.Text = "1";
            this.DataAnime_Menu_Database_Delete.Click += new System.EventHandler(this.DataAnime_Menu_Mn03_Mn01_Click);
            // 
            // DataAnime_Menu_Mn04
            // 
            this.DataAnime_Menu_Mn04.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DataAnime_Menu_Mn04_Mn01,
            this.DataAnime_Menu_Mn04_Mn02,
            this.DataAnime_Menu_Mn04_Mn03,
            this.DataAnime_Menu_Mn04_Mn04,
            this.DataAnime_Menu_Mn04_Mn05});
            this.DataAnime_Menu_Mn04.Name = "DataAnime_Menu_Mn04";
            this.DataAnime_Menu_Mn04.Size = new System.Drawing.Size(80, 22);
            this.DataAnime_Menu_Mn04.Text = "4";
            // 
            // DataAnime_Menu_Mn04_Mn01
            // 
            this.DataAnime_Menu_Mn04_Mn01.Name = "DataAnime_Menu_Mn04_Mn01";
            this.DataAnime_Menu_Mn04_Mn01.Size = new System.Drawing.Size(80, 22);
            this.DataAnime_Menu_Mn04_Mn01.Text = "1";
            this.DataAnime_Menu_Mn04_Mn01.Click += new System.EventHandler(this.DataAnime_Menu_Mn04_Mn01_Click);
            // 
            // DataAnime_Menu_Mn04_Mn02
            // 
            this.DataAnime_Menu_Mn04_Mn02.Name = "DataAnime_Menu_Mn04_Mn02";
            this.DataAnime_Menu_Mn04_Mn02.Size = new System.Drawing.Size(80, 22);
            this.DataAnime_Menu_Mn04_Mn02.Text = "2";
            this.DataAnime_Menu_Mn04_Mn02.Click += new System.EventHandler(this.DataAnime_Menu_Mn04_Mn02_Click);
            // 
            // DataAnime_Menu_Mn04_Mn03
            // 
            this.DataAnime_Menu_Mn04_Mn03.Name = "DataAnime_Menu_Mn04_Mn03";
            this.DataAnime_Menu_Mn04_Mn03.Size = new System.Drawing.Size(80, 22);
            this.DataAnime_Menu_Mn04_Mn03.Text = "3";
            this.DataAnime_Menu_Mn04_Mn03.Click += new System.EventHandler(this.DataAnime_Menu_Mn04_Mn03_Click);
            // 
            // DataAnime_Menu_Mn04_Mn04
            // 
            this.DataAnime_Menu_Mn04_Mn04.Name = "DataAnime_Menu_Mn04_Mn04";
            this.DataAnime_Menu_Mn04_Mn04.Size = new System.Drawing.Size(80, 22);
            this.DataAnime_Menu_Mn04_Mn04.Text = "4";
            this.DataAnime_Menu_Mn04_Mn04.Click += new System.EventHandler(this.DataAnime_Menu_Mn04_Mn04_Click);
            // 
            // DataAnime_Menu_Mn04_Mn05
            // 
            this.DataAnime_Menu_Mn04_Mn05.Name = "DataAnime_Menu_Mn04_Mn05";
            this.DataAnime_Menu_Mn04_Mn05.Size = new System.Drawing.Size(80, 22);
            this.DataAnime_Menu_Mn04_Mn05.Text = "5";
            this.DataAnime_Menu_Mn04_Mn05.Click += new System.EventHandler(this.DataAnime_Menu_Mn04_Mn05_Click);
            // 
            // MainTabData_Anime2TabPage
            // 
            this.MainTabData_Anime2TabPage.BackColor = System.Drawing.Color.White;
            this.MainTabData_Anime2TabPage.Controls.Add(this.Anime_Rel);
            this.MainTabData_Anime2TabPage.Controls.Add(this.Anime_RelDel);
            this.MainTabData_Anime2TabPage.Controls.Add(this.AnimeTree_CH02);
            this.MainTabData_Anime2TabPage.Controls.Add(this.AnimeTree_CH01);
            this.MainTabData_Anime2TabPage.Controls.Add(this.Anime_GR01);
            this.MainTabData_Anime2TabPage.Controls.Add(this.AnimeTree);
            this.MainTabData_Anime2TabPage.Controls.Add(this.Anime_Lang03);
            this.MainTabData_Anime2TabPage.Controls.Add(this.Anime_Lang02);
            this.MainTabData_Anime2TabPage.Controls.Add(this.Anime_Lang01);
            this.MainTabData_Anime2TabPage.Location = new System.Drawing.Point(4, 22);
            this.MainTabData_Anime2TabPage.Name = "MainTabData_Anime2TabPage";
            this.MainTabData_Anime2TabPage.Size = new System.Drawing.Size(1105, 648);
            this.MainTabData_Anime2TabPage.TabIndex = 0;
            this.MainTabData_Anime2TabPage.Text = "3";
            this.MainTabData_Anime2TabPage.UseVisualStyleBackColor = true;
            // 
            // Anime_RelDel
            // 
            this.Anime_RelDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Anime_RelDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Anime_RelDel.Location = new System.Drawing.Point(190, 96);
            this.Anime_RelDel.Name = "Anime_RelDel";
            this.Anime_RelDel.Size = new System.Drawing.Size(15, 15);
            this.Anime_RelDel.TabIndex = 0;
            this.Anime_RelDel.UseVisualStyleBackColor = true;
            this.Anime_RelDel.Visible = false;
            this.Anime_RelDel.Click += new System.EventHandler(this.Anime_RelDel_Click);
            // 
            // AnimeTree_CH02
            // 
            this.AnimeTree_CH02.AutoSize = true;
            this.AnimeTree_CH02.ForeColor = System.Drawing.Color.Black;
            this.AnimeTree_CH02.Location = new System.Drawing.Point(140, 20);
            this.AnimeTree_CH02.Name = "AnimeTree_CH02";
            this.AnimeTree_CH02.Size = new System.Drawing.Size(44, 17);
            this.AnimeTree_CH02.TabIndex = 0;
            this.AnimeTree_CH02.Text = "18+";
            this.AnimeTree_CH02.UseVisualStyleBackColor = true;
            // 
            // AnimeTree_CH01
            // 
            this.AnimeTree_CH01.AutoSize = true;
            this.AnimeTree_CH01.ForeColor = System.Drawing.Color.Black;
            this.AnimeTree_CH01.Location = new System.Drawing.Point(90, 20);
            this.AnimeTree_CH01.Name = "AnimeTree_CH01";
            this.AnimeTree_CH01.Size = new System.Drawing.Size(44, 17);
            this.AnimeTree_CH01.TabIndex = 0;
            this.AnimeTree_CH01.Text = "18+";
            this.AnimeTree_CH01.ThreeState = true;
            this.AnimeTree_CH01.UseVisualStyleBackColor = true;
            // 
            // Anime_GR01
            // 
            this.Anime_GR01.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Anime_GR01.Controls.Add(this.Anime_DateOK);
            this.Anime_GR01.Controls.Add(this.Anime_CB01);
            this.Anime_GR01.Controls.Add(this.Anime_CB02);
            this.Anime_GR01.Controls.Add(this.Anime_Seen);
            this.Anime_GR01.Controls.Add(this.Anime_RatImg);
            this.Anime_GR01.Controls.Add(this.Anime_Rat);
            this.Anime_GR01.Controls.Add(this.Anime_BT01);
            this.Anime_GR01.Controls.Add(this.Anime_LB11);
            this.Anime_GR01.Controls.Add(this.Anime_RelationTree);
            this.Anime_GR01.Controls.Add(this.Anime_LB08);
            this.Anime_GR01.Controls.Add(this.Anime_Img);
            this.Anime_GR01.Controls.Add(this.Anime_OP07);
            this.Anime_GR01.Controls.Add(this.Anime_OP06);
            this.Anime_GR01.Controls.Add(this.Anime_OP04);
            this.Anime_GR01.Controls.Add(this.Anime_OP03);
            this.Anime_GR01.Controls.Add(this.Anime_OP02);
            this.Anime_GR01.Controls.Add(this.Anime_OP01);
            this.Anime_GR01.Controls.Add(this.Anime_LB04);
            this.Anime_GR01.Controls.Add(this.Anime_LB07);
            this.Anime_GR01.Controls.Add(this.Anime_LB05);
            this.Anime_GR01.Controls.Add(this.Anime_LB10);
            this.Anime_GR01.Controls.Add(this.Anime_LB09);
            this.Anime_GR01.Controls.Add(this.Anime_LB06);
            this.Anime_GR01.Controls.Add(this.Anime_LB03);
            this.Anime_GR01.Controls.Add(this.AnimeData);
            this.Anime_GR01.Controls.Add(this.Anime_LB02);
            this.Anime_GR01.Controls.Add(this.Anime_LB01);
            this.Anime_GR01.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Anime_GR01.ForeColor = System.Drawing.Color.Black;
            this.Anime_GR01.Location = new System.Drawing.Point(257, 3);
            this.Anime_GR01.Name = "Anime_GR01";
            this.Anime_GR01.Size = new System.Drawing.Size(845, 642);
            this.Anime_GR01.TabIndex = 0;
            this.Anime_GR01.TabStop = false;
            this.Anime_GR01.Text = "groupBox1";
            this.Anime_GR01.Visible = false;
            // 
            // Anime_CB01
            // 
            this.Anime_CB01.BackColor = System.Drawing.Color.White;
            this.Anime_CB01.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Anime_CB01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Anime_CB01.ForeColor = System.Drawing.Color.Black;
            this.Anime_CB01.FormattingEnabled = true;
            this.Anime_CB01.Location = new System.Drawing.Point(364, 195);
            this.Anime_CB01.Name = "Anime_CB01";
            this.Anime_CB01.Size = new System.Drawing.Size(150, 21);
            this.Anime_CB01.Sorted = true;
            this.Anime_CB01.TabIndex = 1;
            this.Anime_CB01.SelectedIndexChanged += new System.EventHandler(this.Anime_CB01_SelectedIndexChanged);
            // 
            // Anime_CB02
            // 
            this.Anime_CB02.BackColor = System.Drawing.Color.White;
            this.Anime_CB02.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Anime_CB02.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Anime_CB02.ForeColor = System.Drawing.Color.Black;
            this.Anime_CB02.FormattingEnabled = true;
            this.Anime_CB02.Location = new System.Drawing.Point(364, 291);
            this.Anime_CB02.Name = "Anime_CB02";
            this.Anime_CB02.Size = new System.Drawing.Size(150, 21);
            this.Anime_CB02.Sorted = true;
            this.Anime_CB02.TabIndex = 1;
            this.Anime_CB02.SelectedIndexChanged += new System.EventHandler(this.Anime_CB02_SelectedIndexChanged);
            // 
            // Anime_Seen
            // 
            this.Anime_Seen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Anime_Seen.BackColor = System.Drawing.Color.White;
            this.Anime_Seen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Anime_Seen.ForeColor = System.Drawing.Color.Black;
            this.Anime_Seen.Location = new System.Drawing.Point(488, 265);
            this.Anime_Seen.Mask = "00/00/0000";
            this.Anime_Seen.Name = "Anime_Seen";
            this.Anime_Seen.ReadOnly = true;
            this.Anime_Seen.Size = new System.Drawing.Size(75, 20);
            this.Anime_Seen.TabIndex = 0;
            this.Anime_Seen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Anime_Seen.ValidatingType = typeof(System.DateTime);
            this.Anime_Seen.Click += new System.EventHandler(this.Anime_Seen_Click);
            this.Anime_Seen.TextChanged += new System.EventHandler(this.Anime_Seen_TextChanged);
            // 
            // Anime_Rat
            // 
            this.Anime_Rat.BackColor = System.Drawing.Color.White;
            this.Anime_Rat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Anime_Rat.ForeColor = System.Drawing.Color.Black;
            this.Anime_Rat.Location = new System.Drawing.Point(240, 265);
            this.Anime_Rat.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.Anime_Rat.Name = "Anime_Rat";
            this.Anime_Rat.Size = new System.Drawing.Size(62, 20);
            this.Anime_Rat.TabIndex = 0;
            this.Anime_Rat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Anime_Rat.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.Anime_Rat.ValueChanged += new System.EventHandler(this.Anime_Rat_ValueChanged);
            // 
            // Anime_LB11
            // 
            this.Anime_LB11.AutoSize = true;
            this.Anime_LB11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Anime_LB11.Location = new System.Drawing.Point(237, 294);
            this.Anime_LB11.Name = "Anime_LB11";
            this.Anime_LB11.Size = new System.Drawing.Size(41, 13);
            this.Anime_LB11.TabIndex = 0;
            this.Anime_LB11.Text = "label1";
            // 
            // Anime_RelationTree
            // 
            this.Anime_RelationTree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Anime_RelationTree.BackColor = System.Drawing.Color.White;
            this.Anime_RelationTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Anime_RelationTree.ForeColor = System.Drawing.Color.Black;
            this.Anime_RelationTree.Location = new System.Drawing.Point(569, 42);
            this.Anime_RelationTree.Name = "Anime_RelationTree";
            this.Anime_RelationTree.ShowLines = false;
            this.Anime_RelationTree.Size = new System.Drawing.Size(270, 270);
            this.Anime_RelationTree.TabIndex = 0;
            this.Anime_RelationTree.DoubleClick += new System.EventHandler(this.Anime_RelationTree_DoubleClick);
            this.Anime_RelationTree.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Anime_RelationTree_MouseClick);
            // 
            // Anime_LB08
            // 
            this.Anime_LB08.AutoSize = true;
            this.Anime_LB08.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Anime_LB08.ForeColor = System.Drawing.Color.Black;
            this.Anime_LB08.Location = new System.Drawing.Point(237, 179);
            this.Anime_LB08.Margin = new System.Windows.Forms.Padding(3);
            this.Anime_LB08.Name = "Anime_LB08";
            this.Anime_LB08.Size = new System.Drawing.Size(65, 13);
            this.Anime_LB08.TabIndex = 0;
            this.Anime_LB08.TabStop = true;
            this.Anime_LB08.Text = "linkLabel1";
            this.Anime_LB08.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Anime_LB08_LinkClicked);
            // 
            // Anime_OP07
            // 
            this.Anime_OP07.AutoSize = true;
            this.Anime_OP07.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Anime_OP07.ForeColor = System.Drawing.Color.Black;
            this.Anime_OP07.Location = new System.Drawing.Point(361, 160);
            this.Anime_OP07.Name = "Anime_OP07";
            this.Anime_OP07.Size = new System.Drawing.Size(35, 13);
            this.Anime_OP07.TabIndex = 0;
            this.Anime_OP07.Text = "label1";
            // 
            // Anime_OP06
            // 
            this.Anime_OP06.AutoSize = true;
            this.Anime_OP06.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Anime_OP06.ForeColor = System.Drawing.Color.Black;
            this.Anime_OP06.Location = new System.Drawing.Point(361, 141);
            this.Anime_OP06.Name = "Anime_OP06";
            this.Anime_OP06.Size = new System.Drawing.Size(35, 13);
            this.Anime_OP06.TabIndex = 0;
            this.Anime_OP06.Text = "label1";
            // 
            // Anime_OP04
            // 
            this.Anime_OP04.AutoSize = true;
            this.Anime_OP04.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Anime_OP04.ForeColor = System.Drawing.Color.Black;
            this.Anime_OP04.Location = new System.Drawing.Point(361, 122);
            this.Anime_OP04.Name = "Anime_OP04";
            this.Anime_OP04.Size = new System.Drawing.Size(35, 13);
            this.Anime_OP04.TabIndex = 0;
            this.Anime_OP04.Text = "label1";
            // 
            // Anime_OP03
            // 
            this.Anime_OP03.AutoSize = true;
            this.Anime_OP03.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Anime_OP03.ForeColor = System.Drawing.Color.Black;
            this.Anime_OP03.Location = new System.Drawing.Point(361, 103);
            this.Anime_OP03.Name = "Anime_OP03";
            this.Anime_OP03.Size = new System.Drawing.Size(35, 13);
            this.Anime_OP03.TabIndex = 0;
            this.Anime_OP03.Text = "label1";
            // 
            // Anime_OP02
            // 
            this.Anime_OP02.AutoSize = true;
            this.Anime_OP02.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Anime_OP02.ForeColor = System.Drawing.Color.Black;
            this.Anime_OP02.Location = new System.Drawing.Point(361, 84);
            this.Anime_OP02.Name = "Anime_OP02";
            this.Anime_OP02.Size = new System.Drawing.Size(35, 13);
            this.Anime_OP02.TabIndex = 0;
            this.Anime_OP02.Text = "label1";
            // 
            // Anime_OP01
            // 
            this.Anime_OP01.AutoSize = true;
            this.Anime_OP01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Anime_OP01.ForeColor = System.Drawing.Color.Black;
            this.Anime_OP01.Location = new System.Drawing.Point(361, 65);
            this.Anime_OP01.Name = "Anime_OP01";
            this.Anime_OP01.Size = new System.Drawing.Size(35, 13);
            this.Anime_OP01.TabIndex = 0;
            this.Anime_OP01.Text = "label1";
            // 
            // Anime_LB04
            // 
            this.Anime_LB04.AutoSize = true;
            this.Anime_LB04.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Anime_LB04.ForeColor = System.Drawing.Color.Black;
            this.Anime_LB04.Location = new System.Drawing.Point(237, 84);
            this.Anime_LB04.Margin = new System.Windows.Forms.Padding(3);
            this.Anime_LB04.Name = "Anime_LB04";
            this.Anime_LB04.Size = new System.Drawing.Size(46, 13);
            this.Anime_LB04.TabIndex = 0;
            this.Anime_LB04.Text = "Nadpis";
            // 
            // Anime_LB07
            // 
            this.Anime_LB07.AutoSize = true;
            this.Anime_LB07.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Anime_LB07.ForeColor = System.Drawing.Color.Black;
            this.Anime_LB07.Location = new System.Drawing.Point(237, 198);
            this.Anime_LB07.Margin = new System.Windows.Forms.Padding(3);
            this.Anime_LB07.Name = "Anime_LB07";
            this.Anime_LB07.Size = new System.Drawing.Size(46, 13);
            this.Anime_LB07.TabIndex = 0;
            this.Anime_LB07.Text = "Nadpis";
            // 
            // Anime_LB05
            // 
            this.Anime_LB05.AutoSize = true;
            this.Anime_LB05.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Anime_LB05.ForeColor = System.Drawing.Color.Black;
            this.Anime_LB05.Location = new System.Drawing.Point(237, 103);
            this.Anime_LB05.Margin = new System.Windows.Forms.Padding(3);
            this.Anime_LB05.Name = "Anime_LB05";
            this.Anime_LB05.Size = new System.Drawing.Size(46, 13);
            this.Anime_LB05.TabIndex = 0;
            this.Anime_LB05.Text = "Nadpis";
            // 
            // Anime_LB10
            // 
            this.Anime_LB10.AutoSize = true;
            this.Anime_LB10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Anime_LB10.ForeColor = System.Drawing.Color.Black;
            this.Anime_LB10.Location = new System.Drawing.Point(237, 160);
            this.Anime_LB10.Margin = new System.Windows.Forms.Padding(3);
            this.Anime_LB10.Name = "Anime_LB10";
            this.Anime_LB10.Size = new System.Drawing.Size(46, 13);
            this.Anime_LB10.TabIndex = 0;
            this.Anime_LB10.Text = "Nadpis";
            // 
            // Anime_LB09
            // 
            this.Anime_LB09.AutoSize = true;
            this.Anime_LB09.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Anime_LB09.ForeColor = System.Drawing.Color.Black;
            this.Anime_LB09.Location = new System.Drawing.Point(237, 141);
            this.Anime_LB09.Margin = new System.Windows.Forms.Padding(3);
            this.Anime_LB09.Name = "Anime_LB09";
            this.Anime_LB09.Size = new System.Drawing.Size(46, 13);
            this.Anime_LB09.TabIndex = 0;
            this.Anime_LB09.Text = "Nadpis";
            // 
            // Anime_LB06
            // 
            this.Anime_LB06.AutoSize = true;
            this.Anime_LB06.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Anime_LB06.ForeColor = System.Drawing.Color.Black;
            this.Anime_LB06.Location = new System.Drawing.Point(237, 122);
            this.Anime_LB06.Margin = new System.Windows.Forms.Padding(3);
            this.Anime_LB06.Name = "Anime_LB06";
            this.Anime_LB06.Size = new System.Drawing.Size(46, 13);
            this.Anime_LB06.TabIndex = 0;
            this.Anime_LB06.Text = "Nadpis";
            // 
            // Anime_LB03
            // 
            this.Anime_LB03.AutoSize = true;
            this.Anime_LB03.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Anime_LB03.ForeColor = System.Drawing.Color.Black;
            this.Anime_LB03.Location = new System.Drawing.Point(237, 65);
            this.Anime_LB03.Margin = new System.Windows.Forms.Padding(3);
            this.Anime_LB03.Name = "Anime_LB03";
            this.Anime_LB03.Size = new System.Drawing.Size(46, 13);
            this.Anime_LB03.TabIndex = 0;
            this.Anime_LB03.Text = "Nadpis";
            // 
            // AnimeData
            // 
            this.AnimeData.AllowUserToAddRows = false;
            this.AnimeData.AllowUserToDeleteRows = false;
            this.AnimeData.AllowUserToResizeRows = false;
            this.AnimeData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AnimeData.BackgroundColor = System.Drawing.Color.White;
            this.AnimeData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.AnimeData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AnimeData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AnimeData_Mn01,
            this.AnimeData_Mn02,
            this.AnimeData_Mn03,
            this.AnimeData_Mn04,
            this.AnimeData_Mn05,
            this.AnimeData_Mn06,
            this.AnimeData_Mn07,
            this.AnimeData_Mn08,
            this.AnimeData_Mn09,
            this.AnimeData_Mn10,
            this.AnimeData_Mn11,
            this.AnimeData_Mn12,
            this.AnimeData_Mn13});
            this.AnimeData.GridColor = System.Drawing.Color.White;
            this.AnimeData.Location = new System.Drawing.Point(6, 327);
            this.AnimeData.Name = "AnimeData";
            this.AnimeData.ReadOnly = true;
            this.AnimeData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.AnimeData.RowHeadersVisible = false;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.Black;
            this.AnimeData.RowsDefaultCellStyle = dataGridViewCellStyle21;
            this.AnimeData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AnimeData.ShowCellErrors = false;
            this.AnimeData.Size = new System.Drawing.Size(833, 309);
            this.AnimeData.TabIndex = 0;
            this.AnimeData.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AnimeData_MouseClick);
            this.AnimeData.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AnimeData_MouseDoubleClick);
            this.AnimeData.MouseEnter += new System.EventHandler(this.AnimeData_MouseEnter);
            // 
            // AnimeData_Mn01
            // 
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.AnimeData_Mn01.DefaultCellStyle = dataGridViewCellStyle17;
            this.AnimeData_Mn01.HeaderText = "";
            this.AnimeData_Mn01.Name = "AnimeData_Mn01";
            this.AnimeData_Mn01.ReadOnly = true;
            this.AnimeData_Mn01.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.AnimeData_Mn01.Visible = false;
            // 
            // AnimeData_Mn02
            // 
            this.AnimeData_Mn02.HeaderText = "";
            this.AnimeData_Mn02.Name = "AnimeData_Mn02";
            this.AnimeData_Mn02.ReadOnly = true;
            this.AnimeData_Mn02.Width = 20;
            // 
            // AnimeData_Mn03
            // 
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.AnimeData_Mn03.DefaultCellStyle = dataGridViewCellStyle18;
            this.AnimeData_Mn03.HeaderText = "";
            this.AnimeData_Mn03.Name = "AnimeData_Mn03";
            this.AnimeData_Mn03.ReadOnly = true;
            this.AnimeData_Mn03.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.AnimeData_Mn03.Width = 50;
            // 
            // AnimeData_Mn04
            // 
            this.AnimeData_Mn04.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.AnimeData_Mn04.DefaultCellStyle = dataGridViewCellStyle19;
            this.AnimeData_Mn04.HeaderText = "";
            this.AnimeData_Mn04.Name = "AnimeData_Mn04";
            this.AnimeData_Mn04.ReadOnly = true;
            this.AnimeData_Mn04.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // AnimeData_Mn05
            // 
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.AnimeData_Mn05.DefaultCellStyle = dataGridViewCellStyle20;
            this.AnimeData_Mn05.HeaderText = "";
            this.AnimeData_Mn05.Name = "AnimeData_Mn05";
            this.AnimeData_Mn05.ReadOnly = true;
            this.AnimeData_Mn05.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // AnimeData_Mn06
            // 
            this.AnimeData_Mn06.HeaderText = "";
            this.AnimeData_Mn06.Name = "AnimeData_Mn06";
            this.AnimeData_Mn06.ReadOnly = true;
            this.AnimeData_Mn06.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.AnimeData_Mn06.Visible = false;
            // 
            // AnimeData_Mn07
            // 
            this.AnimeData_Mn07.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.AnimeData_Mn07.HeaderText = "";
            this.AnimeData_Mn07.Name = "AnimeData_Mn07";
            this.AnimeData_Mn07.ReadOnly = true;
            this.AnimeData_Mn07.Width = 5;
            // 
            // AnimeData_Mn08
            // 
            this.AnimeData_Mn08.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.AnimeData_Mn08.HeaderText = "";
            this.AnimeData_Mn08.Name = "AnimeData_Mn08";
            this.AnimeData_Mn08.ReadOnly = true;
            this.AnimeData_Mn08.Width = 5;
            // 
            // AnimeData_Mn09
            // 
            this.AnimeData_Mn09.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.AnimeData_Mn09.HeaderText = "";
            this.AnimeData_Mn09.Name = "AnimeData_Mn09";
            this.AnimeData_Mn09.ReadOnly = true;
            this.AnimeData_Mn09.Width = 5;
            // 
            // AnimeData_Mn10
            // 
            this.AnimeData_Mn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.AnimeData_Mn10.HeaderText = "";
            this.AnimeData_Mn10.Name = "AnimeData_Mn10";
            this.AnimeData_Mn10.ReadOnly = true;
            this.AnimeData_Mn10.Width = 5;
            // 
            // AnimeData_Mn11
            // 
            this.AnimeData_Mn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.AnimeData_Mn11.HeaderText = "";
            this.AnimeData_Mn11.Name = "AnimeData_Mn11";
            this.AnimeData_Mn11.ReadOnly = true;
            this.AnimeData_Mn11.Width = 5;
            // 
            // AnimeData_Mn12
            // 
            this.AnimeData_Mn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.AnimeData_Mn12.HeaderText = "";
            this.AnimeData_Mn12.Name = "AnimeData_Mn12";
            this.AnimeData_Mn12.ReadOnly = true;
            this.AnimeData_Mn12.Width = 5;
            // 
            // AnimeData_Mn13
            // 
            this.AnimeData_Mn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.AnimeData_Mn13.HeaderText = "";
            this.AnimeData_Mn13.Name = "AnimeData_Mn13";
            this.AnimeData_Mn13.ReadOnly = true;
            this.AnimeData_Mn13.Width = 5;
            // 
            // Anime_LB02
            // 
            this.Anime_LB02.AutoSize = true;
            this.Anime_LB02.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Anime_LB02.ForeColor = System.Drawing.Color.Black;
            this.Anime_LB02.LinkArea = new System.Windows.Forms.LinkArea(0, 1000);
            this.Anime_LB02.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.Anime_LB02.LinkColor = System.Drawing.Color.Black;
            this.Anime_LB02.Location = new System.Drawing.Point(295, 42);
            this.Anime_LB02.Name = "Anime_LB02";
            this.Anime_LB02.Size = new System.Drawing.Size(51, 20);
            this.Anime_LB02.TabIndex = 0;
            this.Anime_LB02.TabStop = true;
            this.Anime_LB02.Text = "Nadpis";
            this.Anime_LB02.UseCompatibleTextRendering = true;
            this.Anime_LB02.Visible = false;
            this.Anime_LB02.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Anime_LB02_LinkClicked);
            // 
            // Anime_LB01
            // 
            this.Anime_LB01.AutoSize = true;
            this.Anime_LB01.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Anime_LB01.ForeColor = System.Drawing.Color.Black;
            this.Anime_LB01.LinkArea = new System.Windows.Forms.LinkArea(0, 1000);
            this.Anime_LB01.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.Anime_LB01.LinkColor = System.Drawing.Color.Black;
            this.Anime_LB01.Location = new System.Drawing.Point(240, 42);
            this.Anime_LB01.Name = "Anime_LB01";
            this.Anime_LB01.Size = new System.Drawing.Size(49, 20);
            this.Anime_LB01.TabIndex = 0;
            this.Anime_LB01.TabStop = true;
            this.Anime_LB01.Text = "Nadpis";
            this.Anime_LB01.UseCompatibleTextRendering = true;
            this.Anime_LB01.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Anime_LB01_LinkClicked);
            // 
            // AnimeTree
            // 
            this.AnimeTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.AnimeTree.BackColor = System.Drawing.Color.White;
            this.AnimeTree.ContextMenuStrip = this.AnimeTree_Menu;
            this.AnimeTree.ForeColor = System.Drawing.Color.Black;
            this.AnimeTree.Location = new System.Drawing.Point(3, 45);
            this.AnimeTree.Name = "AnimeTree";
            this.AnimeTree.ShowRootLines = false;
            this.AnimeTree.Size = new System.Drawing.Size(248, 600);
            this.AnimeTree.TabIndex = 0;
            this.AnimeTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.AnimeTree_AfterSelect);
            this.AnimeTree.MouseEnter += new System.EventHandler(this.AnimeTree_MouseEnter);
            // 
            // AnimeTree_Menu
            // 
            this.AnimeTree_Menu.BackColor = System.Drawing.Color.White;
            this.AnimeTree_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AnimeTree_Menu_Mn01,
            this.AnimeTree_Menu_Mn02});
            this.AnimeTree_Menu.Name = "AnimeTree_Menu";
            this.AnimeTree_Menu.Size = new System.Drawing.Size(81, 48);
            // 
            // AnimeTree_Menu_Mn01
            // 
            this.AnimeTree_Menu_Mn01.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AnimeTree_Menu_Mn01_Mn01,
            this.AnimeTree_Menu_Mn01_Mn02,
            this.AnimeTree_Menu_Mn01_Mn03,
            this.AnimeTree_Menu_Mn01_Mn04,
            this.AnimeTree_Menu_Mn01_Mn05});
            this.AnimeTree_Menu_Mn01.Name = "AnimeTree_Menu_Mn01";
            this.AnimeTree_Menu_Mn01.Size = new System.Drawing.Size(80, 22);
            this.AnimeTree_Menu_Mn01.Text = "1";
            // 
            // AnimeTree_Menu_Mn01_Mn01
            // 
            this.AnimeTree_Menu_Mn01_Mn01.Name = "AnimeTree_Menu_Mn01_Mn01";
            this.AnimeTree_Menu_Mn01_Mn01.Size = new System.Drawing.Size(80, 22);
            this.AnimeTree_Menu_Mn01_Mn01.Text = "1";
            this.AnimeTree_Menu_Mn01_Mn01.Click += new System.EventHandler(this.AnimeTree_Menu_Mn01_Mn01_Click);
            // 
            // AnimeTree_Menu_Mn01_Mn02
            // 
            this.AnimeTree_Menu_Mn01_Mn02.Name = "AnimeTree_Menu_Mn01_Mn02";
            this.AnimeTree_Menu_Mn01_Mn02.Size = new System.Drawing.Size(80, 22);
            this.AnimeTree_Menu_Mn01_Mn02.Text = "2";
            this.AnimeTree_Menu_Mn01_Mn02.Click += new System.EventHandler(this.AnimeTree_Menu_Mn01_Mn02_Click);
            // 
            // AnimeTree_Menu_Mn01_Mn03
            // 
            this.AnimeTree_Menu_Mn01_Mn03.Name = "AnimeTree_Menu_Mn01_Mn03";
            this.AnimeTree_Menu_Mn01_Mn03.Size = new System.Drawing.Size(80, 22);
            this.AnimeTree_Menu_Mn01_Mn03.Text = "3";
            this.AnimeTree_Menu_Mn01_Mn03.Click += new System.EventHandler(this.AnimeTree_Menu_Mn01_Mn03_Click);
            // 
            // AnimeTree_Menu_Mn01_Mn04
            // 
            this.AnimeTree_Menu_Mn01_Mn04.Name = "AnimeTree_Menu_Mn01_Mn04";
            this.AnimeTree_Menu_Mn01_Mn04.Size = new System.Drawing.Size(80, 22);
            this.AnimeTree_Menu_Mn01_Mn04.Text = "4";
            this.AnimeTree_Menu_Mn01_Mn04.Click += new System.EventHandler(this.AnimeTree_Menu_Mn01_Mn04_Click);
            // 
            // AnimeTree_Menu_Mn01_Mn05
            // 
            this.AnimeTree_Menu_Mn01_Mn05.Name = "AnimeTree_Menu_Mn01_Mn05";
            this.AnimeTree_Menu_Mn01_Mn05.Size = new System.Drawing.Size(80, 22);
            this.AnimeTree_Menu_Mn01_Mn05.Text = "5";
            this.AnimeTree_Menu_Mn01_Mn05.Click += new System.EventHandler(this.AnimeTree_Menu_Mn01_Mn05_Click);
            // 
            // AnimeTree_Menu_Mn02
            // 
            this.AnimeTree_Menu_Mn02.Name = "AnimeTree_Menu_Mn02";
            this.AnimeTree_Menu_Mn02.Size = new System.Drawing.Size(80, 22);
            this.AnimeTree_Menu_Mn02.Text = "2";
            this.AnimeTree_Menu_Mn02.Click += new System.EventHandler(this.AnimeTree_Menu_Mn02_Click);
            // 
            // MainTabData_GenresTabPage
            // 
            this.MainTabData_GenresTabPage.BackColor = System.Drawing.Color.White;
            this.MainTabData_GenresTabPage.Controls.Add(this.DataGenres_Page);
            this.MainTabData_GenresTabPage.Controls.Add(this.DataGenres_Rows);
            this.MainTabData_GenresTabPage.Controls.Add(this.DataGenres);
            this.MainTabData_GenresTabPage.Location = new System.Drawing.Point(4, 22);
            this.MainTabData_GenresTabPage.Name = "MainTabData_GenresTabPage";
            this.MainTabData_GenresTabPage.Size = new System.Drawing.Size(1105, 648);
            this.MainTabData_GenresTabPage.TabIndex = 0;
            this.MainTabData_GenresTabPage.Text = "4";
            this.MainTabData_GenresTabPage.UseVisualStyleBackColor = true;
            // 
            // DataGenres_Page
            // 
            this.DataGenres_Page.BackColor = System.Drawing.Color.White;
            this.DataGenres_Page.ForeColor = System.Drawing.Color.Black;
            this.DataGenres_Page.Location = new System.Drawing.Point(910, 6);
            this.DataGenres_Page.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.DataGenres_Page.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DataGenres_Page.Name = "DataGenres_Page";
            this.DataGenres_Page.Size = new System.Drawing.Size(72, 20);
            this.DataGenres_Page.TabIndex = 0;
            this.DataGenres_Page.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DataGenres_Page.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.DataGenres_Page.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DataGenres_Page.ValueChanged += new System.EventHandler(this.DataGenres_Page_ValueChanged);
            // 
            // DataGenres_Rows
            // 
            this.DataGenres_Rows.BackColor = System.Drawing.Color.White;
            this.DataGenres_Rows.ForeColor = System.Drawing.Color.Black;
            this.DataGenres_Rows.Location = new System.Drawing.Point(1018, 6);
            this.DataGenres_Rows.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.DataGenres_Rows.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.DataGenres_Rows.Name = "DataGenres_Rows";
            this.DataGenres_Rows.Size = new System.Drawing.Size(72, 20);
            this.DataGenres_Rows.TabIndex = 0;
            this.DataGenres_Rows.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DataGenres_Rows.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.DataGenres_Rows.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.DataGenres_Rows.ValueChanged += new System.EventHandler(this.DataGenres_Page_ValueChanged);
            // 
            // DataGenres
            // 
            this.DataGenres.AllowUserToAddRows = false;
            this.DataGenres.AllowUserToDeleteRows = false;
            this.DataGenres.AllowUserToResizeRows = false;
            this.DataGenres.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGenres.BackgroundColor = System.Drawing.Color.White;
            this.DataGenres.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DataGenres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGenres.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataGenres_Mn01,
            this.DataGenres_Mn02,
            this.DataGenres_Mn03,
            this.DataGenres_Mn04,
            this.DataGenres_Mn05,
            this.DataGenres_Mn06,
            this.DataGenres_Mn07});
            this.DataGenres.GridColor = System.Drawing.Color.White;
            this.DataGenres.Location = new System.Drawing.Point(6, 32);
            this.DataGenres.Name = "DataGenres";
            this.DataGenres.ReadOnly = true;
            this.DataGenres.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataGenres.RowHeadersVisible = false;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.Color.Black;
            this.DataGenres.RowsDefaultCellStyle = dataGridViewCellStyle22;
            this.DataGenres.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGenres.Size = new System.Drawing.Size(1093, 610);
            this.DataGenres.TabIndex = 0;
            this.DataGenres.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DataGenres_MouseClick);
            this.DataGenres.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DataGenres_MouseDoubleClick);
            this.DataGenres.MouseEnter += new System.EventHandler(this.DataGenres_MouseEnter);
            // 
            // DataGenres_Mn01
            // 
            this.DataGenres_Mn01.HeaderText = "";
            this.DataGenres_Mn01.Name = "DataGenres_Mn01";
            this.DataGenres_Mn01.ReadOnly = true;
            this.DataGenres_Mn01.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DataGenres_Mn01.Visible = false;
            // 
            // DataGenres_Mn02
            // 
            this.DataGenres_Mn02.HeaderText = "";
            this.DataGenres_Mn02.Name = "DataGenres_Mn02";
            this.DataGenres_Mn02.ReadOnly = true;
            this.DataGenres_Mn02.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGenres_Mn02.Width = 15;
            // 
            // DataGenres_Mn03
            // 
            this.DataGenres_Mn03.HeaderText = "";
            this.DataGenres_Mn03.Name = "DataGenres_Mn03";
            this.DataGenres_Mn03.ReadOnly = true;
            this.DataGenres_Mn03.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGenres_Mn03.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DataGenres_Mn03.Visible = false;
            // 
            // DataGenres_Mn04
            // 
            this.DataGenres_Mn04.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DataGenres_Mn04.HeaderText = "";
            this.DataGenres_Mn04.Name = "DataGenres_Mn04";
            this.DataGenres_Mn04.ReadOnly = true;
            this.DataGenres_Mn04.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DataGenres_Mn05
            // 
            this.DataGenres_Mn05.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DataGenres_Mn05.HeaderText = "";
            this.DataGenres_Mn05.Name = "DataGenres_Mn05";
            this.DataGenres_Mn05.ReadOnly = true;
            this.DataGenres_Mn05.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DataGenres_Mn06
            // 
            this.DataGenres_Mn06.HeaderText = "";
            this.DataGenres_Mn06.Name = "DataGenres_Mn06";
            this.DataGenres_Mn06.ReadOnly = true;
            this.DataGenres_Mn06.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DataGenres_Mn07
            // 
            this.DataGenres_Mn07.HeaderText = "";
            this.DataGenres_Mn07.Name = "DataGenres_Mn07";
            this.DataGenres_Mn07.ReadOnly = true;
            this.DataGenres_Mn07.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MainTabData_GroupsTabPage
            // 
            this.MainTabData_GroupsTabPage.BackColor = System.Drawing.Color.White;
            this.MainTabData_GroupsTabPage.Controls.Add(this.DataGroups_Page);
            this.MainTabData_GroupsTabPage.Controls.Add(this.DataGroups_Rows);
            this.MainTabData_GroupsTabPage.Controls.Add(this.DataGroups);
            this.MainTabData_GroupsTabPage.Location = new System.Drawing.Point(4, 22);
            this.MainTabData_GroupsTabPage.Name = "MainTabData_GroupsTabPage";
            this.MainTabData_GroupsTabPage.Size = new System.Drawing.Size(1105, 648);
            this.MainTabData_GroupsTabPage.TabIndex = 0;
            this.MainTabData_GroupsTabPage.Text = "5";
            this.MainTabData_GroupsTabPage.UseVisualStyleBackColor = true;
            // 
            // DataGroups_Page
            // 
            this.DataGroups_Page.BackColor = System.Drawing.Color.White;
            this.DataGroups_Page.ForeColor = System.Drawing.Color.Black;
            this.DataGroups_Page.Location = new System.Drawing.Point(910, 6);
            this.DataGroups_Page.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.DataGroups_Page.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DataGroups_Page.Name = "DataGroups_Page";
            this.DataGroups_Page.Size = new System.Drawing.Size(72, 20);
            this.DataGroups_Page.TabIndex = 0;
            this.DataGroups_Page.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DataGroups_Page.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.DataGroups_Page.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DataGroups_Page.ValueChanged += new System.EventHandler(this.DataGroups_Page_ValueChanged);
            // 
            // DataGroups_Rows
            // 
            this.DataGroups_Rows.BackColor = System.Drawing.Color.White;
            this.DataGroups_Rows.ForeColor = System.Drawing.Color.Black;
            this.DataGroups_Rows.Location = new System.Drawing.Point(1018, 6);
            this.DataGroups_Rows.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.DataGroups_Rows.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.DataGroups_Rows.Name = "DataGroups_Rows";
            this.DataGroups_Rows.Size = new System.Drawing.Size(72, 20);
            this.DataGroups_Rows.TabIndex = 0;
            this.DataGroups_Rows.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DataGroups_Rows.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.DataGroups_Rows.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.DataGroups_Rows.ValueChanged += new System.EventHandler(this.DataGroups_Page_ValueChanged);
            // 
            // DataGroups
            // 
            this.DataGroups.AllowUserToAddRows = false;
            this.DataGroups.AllowUserToDeleteRows = false;
            this.DataGroups.AllowUserToResizeRows = false;
            this.DataGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGroups.BackgroundColor = System.Drawing.Color.White;
            this.DataGroups.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DataGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGroups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataGroups_Mn01,
            this.DataGroups_Mn02,
            this.DataGroups_Mn03,
            this.DataGroups_Mn04,
            this.DataGroups_Mn05,
            this.DataGroups_Mn06,
            this.DataGroups_Mn07});
            this.DataGroups.GridColor = System.Drawing.Color.White;
            this.DataGroups.Location = new System.Drawing.Point(6, 32);
            this.DataGroups.Name = "DataGroups";
            this.DataGroups.ReadOnly = true;
            this.DataGroups.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataGroups.RowHeadersVisible = false;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.Color.Black;
            this.DataGroups.RowsDefaultCellStyle = dataGridViewCellStyle23;
            this.DataGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGroups.Size = new System.Drawing.Size(1093, 610);
            this.DataGroups.TabIndex = 0;
            this.DataGroups.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DataGroups_MouseClick);
            this.DataGroups.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DataGroups_MouseDoubleClick);
            // 
            // DataGroups_Mn01
            // 
            this.DataGroups_Mn01.HeaderText = "";
            this.DataGroups_Mn01.Name = "DataGroups_Mn01";
            this.DataGroups_Mn01.ReadOnly = true;
            this.DataGroups_Mn01.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DataGroups_Mn01.Visible = false;
            // 
            // DataGroups_Mn02
            // 
            this.DataGroups_Mn02.HeaderText = "";
            this.DataGroups_Mn02.Name = "DataGroups_Mn02";
            this.DataGroups_Mn02.ReadOnly = true;
            this.DataGroups_Mn02.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGroups_Mn02.Width = 15;
            // 
            // DataGroups_Mn03
            // 
            this.DataGroups_Mn03.HeaderText = "";
            this.DataGroups_Mn03.Name = "DataGroups_Mn03";
            this.DataGroups_Mn03.ReadOnly = true;
            this.DataGroups_Mn03.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DataGroups_Mn03.Visible = false;
            // 
            // DataGroups_Mn04
            // 
            this.DataGroups_Mn04.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DataGroups_Mn04.HeaderText = "";
            this.DataGroups_Mn04.Name = "DataGroups_Mn04";
            this.DataGroups_Mn04.ReadOnly = true;
            this.DataGroups_Mn04.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DataGroups_Mn05
            // 
            this.DataGroups_Mn05.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DataGroups_Mn05.HeaderText = "";
            this.DataGroups_Mn05.Name = "DataGroups_Mn05";
            this.DataGroups_Mn05.ReadOnly = true;
            this.DataGroups_Mn05.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DataGroups_Mn06
            // 
            this.DataGroups_Mn06.HeaderText = "";
            this.DataGroups_Mn06.Name = "DataGroups_Mn06";
            this.DataGroups_Mn06.ReadOnly = true;
            this.DataGroups_Mn06.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DataGroups_Mn07
            // 
            this.DataGroups_Mn07.HeaderText = "";
            this.DataGroups_Mn07.Name = "DataGroups_Mn07";
            this.DataGroups_Mn07.ReadOnly = true;
            this.DataGroups_Mn07.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MainTabData_SearchTabPage
            // 
            this.MainTabData_SearchTabPage.BackColor = System.Drawing.Color.White;
            this.MainTabData_SearchTabPage.Controls.Add(this.DataSearch_CH02);
            this.MainTabData_SearchTabPage.Controls.Add(this.DataSearch_CH01);
            this.MainTabData_SearchTabPage.Controls.Add(this.DataSearch_NM05);
            this.MainTabData_SearchTabPage.Controls.Add(this.DataSearch_NM04);
            this.MainTabData_SearchTabPage.Controls.Add(this.DataSearch_NM03);
            this.MainTabData_SearchTabPage.Controls.Add(this.DataSearch_NM02);
            this.MainTabData_SearchTabPage.Controls.Add(this.DataSearch_NM01);
            this.MainTabData_SearchTabPage.Controls.Add(this.DataSearch_CB01);
            this.MainTabData_SearchTabPage.Controls.Add(this.DataSearch_CB02);
            this.MainTabData_SearchTabPage.Controls.Add(this.DataSearch_TX05);
            this.MainTabData_SearchTabPage.Controls.Add(this.DataSearch_TX04);
            this.MainTabData_SearchTabPage.Controls.Add(this.DataSearch_TX08);
            this.MainTabData_SearchTabPage.Controls.Add(this.DataSearch_TX03);
            this.MainTabData_SearchTabPage.Controls.Add(this.DataSearch_TX07);
            this.MainTabData_SearchTabPage.Controls.Add(this.DataSearch_TX02);
            this.MainTabData_SearchTabPage.Controls.Add(this.DataSearch_TX06);
            this.MainTabData_SearchTabPage.Controls.Add(this.DataSearch_TX01);
            this.MainTabData_SearchTabPage.Controls.Add(this.DataSearch_LB15);
            this.MainTabData_SearchTabPage.Controls.Add(this.DataSearch_LB10);
            this.MainTabData_SearchTabPage.Controls.Add(this.DataSearch_LB05);
            this.MainTabData_SearchTabPage.Controls.Add(this.DataSearch_LB14);
            this.MainTabData_SearchTabPage.Controls.Add(this.DataSearch_LB09);
            this.MainTabData_SearchTabPage.Controls.Add(this.DataSearch_LB04);
            this.MainTabData_SearchTabPage.Controls.Add(this.DataSearch_LB13);
            this.MainTabData_SearchTabPage.Controls.Add(this.DataSearch_LB08);
            this.MainTabData_SearchTabPage.Controls.Add(this.DataSearch_LB03);
            this.MainTabData_SearchTabPage.Controls.Add(this.DataSearch_LB12);
            this.MainTabData_SearchTabPage.Controls.Add(this.DataSearch_LB07);
            this.MainTabData_SearchTabPage.Controls.Add(this.DataSearch_LB02);
            this.MainTabData_SearchTabPage.Controls.Add(this.DataSearch_LB11);
            this.MainTabData_SearchTabPage.Controls.Add(this.DataSearch_LB06);
            this.MainTabData_SearchTabPage.Controls.Add(this.DataSearch_LB01);
            this.MainTabData_SearchTabPage.Controls.Add(this.DataSearch_LB16);
            this.MainTabData_SearchTabPage.Controls.Add(this.DataSearch_Genres);
            this.MainTabData_SearchTabPage.Controls.Add(this.DataSearch_Clear);
            this.MainTabData_SearchTabPage.Controls.Add(this.DataSearch_Select);
            this.MainTabData_SearchTabPage.Controls.Add(this.DataSearch);
            this.MainTabData_SearchTabPage.ForeColor = System.Drawing.Color.Black;
            this.MainTabData_SearchTabPage.Location = new System.Drawing.Point(4, 22);
            this.MainTabData_SearchTabPage.Name = "MainTabData_SearchTabPage";
            this.MainTabData_SearchTabPage.Size = new System.Drawing.Size(1105, 648);
            this.MainTabData_SearchTabPage.TabIndex = 0;
            this.MainTabData_SearchTabPage.Text = "7";
            this.MainTabData_SearchTabPage.UseVisualStyleBackColor = true;
            // 
            // DataSearch_CH02
            // 
            this.DataSearch_CH02.AutoSize = true;
            this.DataSearch_CH02.ForeColor = System.Drawing.Color.Black;
            this.DataSearch_CH02.Location = new System.Drawing.Point(726, 5);
            this.DataSearch_CH02.Name = "DataSearch_CH02";
            this.DataSearch_CH02.Size = new System.Drawing.Size(80, 17);
            this.DataSearch_CH02.TabIndex = 0;
            this.DataSearch_CH02.Text = "checkBox2";
            this.DataSearch_CH02.UseVisualStyleBackColor = true;
            this.DataSearch_CH02.CheckedChanged += new System.EventHandler(this.DataSearch_CH02_CheckedChanged);
            // 
            // DataSearch_CH01
            // 
            this.DataSearch_CH01.AutoSize = true;
            this.DataSearch_CH01.ForeColor = System.Drawing.Color.Black;
            this.DataSearch_CH01.Location = new System.Drawing.Point(705, 6);
            this.DataSearch_CH01.Name = "DataSearch_CH01";
            this.DataSearch_CH01.Size = new System.Drawing.Size(15, 14);
            this.DataSearch_CH01.TabIndex = 0;
            this.DataSearch_CH01.UseVisualStyleBackColor = true;
            this.DataSearch_CH01.CheckedChanged += new System.EventHandler(this.DataSearch_CH01_CheckedChanged);
            // 
            // DataSearch_NM05
            // 
            this.DataSearch_NM05.ForeColor = System.Drawing.Color.Black;
            this.DataSearch_NM05.Location = new System.Drawing.Point(100, 108);
            this.DataSearch_NM05.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.DataSearch_NM05.Name = "DataSearch_NM05";
            this.DataSearch_NM05.Size = new System.Drawing.Size(100, 20);
            this.DataSearch_NM05.TabIndex = 0;
            this.DataSearch_NM05.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.DataSearch_NM05.ThousandsSeparator = true;
            // 
            // DataSearch_NM04
            // 
            this.DataSearch_NM04.ForeColor = System.Drawing.Color.Black;
            this.DataSearch_NM04.Location = new System.Drawing.Point(100, 82);
            this.DataSearch_NM04.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.DataSearch_NM04.Name = "DataSearch_NM04";
            this.DataSearch_NM04.Size = new System.Drawing.Size(100, 20);
            this.DataSearch_NM04.TabIndex = 0;
            this.DataSearch_NM04.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.DataSearch_NM04.ThousandsSeparator = true;
            // 
            // DataSearch_NM03
            // 
            this.DataSearch_NM03.ForeColor = System.Drawing.Color.Black;
            this.DataSearch_NM03.Location = new System.Drawing.Point(100, 56);
            this.DataSearch_NM03.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.DataSearch_NM03.Name = "DataSearch_NM03";
            this.DataSearch_NM03.Size = new System.Drawing.Size(100, 20);
            this.DataSearch_NM03.TabIndex = 0;
            this.DataSearch_NM03.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.DataSearch_NM03.ThousandsSeparator = true;
            // 
            // DataSearch_NM02
            // 
            this.DataSearch_NM02.ForeColor = System.Drawing.Color.Black;
            this.DataSearch_NM02.Location = new System.Drawing.Point(100, 30);
            this.DataSearch_NM02.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.DataSearch_NM02.Name = "DataSearch_NM02";
            this.DataSearch_NM02.Size = new System.Drawing.Size(100, 20);
            this.DataSearch_NM02.TabIndex = 0;
            this.DataSearch_NM02.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.DataSearch_NM02.ThousandsSeparator = true;
            // 
            // DataSearch_NM01
            // 
            this.DataSearch_NM01.ForeColor = System.Drawing.Color.Black;
            this.DataSearch_NM01.Location = new System.Drawing.Point(100, 4);
            this.DataSearch_NM01.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.DataSearch_NM01.Name = "DataSearch_NM01";
            this.DataSearch_NM01.Size = new System.Drawing.Size(100, 20);
            this.DataSearch_NM01.TabIndex = 0;
            this.DataSearch_NM01.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // DataSearch_CB01
            // 
            this.DataSearch_CB01.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DataSearch_CB01.ForeColor = System.Drawing.Color.Black;
            this.DataSearch_CB01.FormattingEnabled = true;
            this.DataSearch_CB01.Items.AddRange(new object[] {
            "",
            "TV Series",
            "Movie",
            "OVA",
            "TV Special",
            "Web",
            "Music Video",
            "Other"});
            this.DataSearch_CB01.Location = new System.Drawing.Point(506, 3);
            this.DataSearch_CB01.Name = "DataSearch_CB01";
            this.DataSearch_CB01.Size = new System.Drawing.Size(100, 21);
            this.DataSearch_CB01.TabIndex = 0;
            // 
            // DataSearch_CB02
            // 
            this.DataSearch_CB02.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DataSearch_CB02.ForeColor = System.Drawing.Color.Black;
            this.DataSearch_CB02.FormattingEnabled = true;
            this.DataSearch_CB02.Items.AddRange(new object[] {
            "",
            "Blu-ray",
            "HDTV",
            "HKDVD",
            "DTV",
            "TV",
            "www",
            "VCD",
            "LD",
            "VHS",
            "camcorder",
            "unknown"});
            this.DataSearch_CB02.Location = new System.Drawing.Point(506, 28);
            this.DataSearch_CB02.Name = "DataSearch_CB02";
            this.DataSearch_CB02.Size = new System.Drawing.Size(100, 21);
            this.DataSearch_CB02.TabIndex = 0;
            // 
            // DataSearch_TX05
            // 
            this.DataSearch_TX05.ForeColor = System.Drawing.Color.Black;
            this.DataSearch_TX05.Location = new System.Drawing.Point(303, 107);
            this.DataSearch_TX05.Name = "DataSearch_TX05";
            this.DataSearch_TX05.Size = new System.Drawing.Size(100, 20);
            this.DataSearch_TX05.TabIndex = 0;
            // 
            // DataSearch_TX04
            // 
            this.DataSearch_TX04.ForeColor = System.Drawing.Color.Black;
            this.DataSearch_TX04.Location = new System.Drawing.Point(303, 81);
            this.DataSearch_TX04.Name = "DataSearch_TX04";
            this.DataSearch_TX04.Size = new System.Drawing.Size(100, 20);
            this.DataSearch_TX04.TabIndex = 0;
            // 
            // DataSearch_TX08
            // 
            this.DataSearch_TX08.ForeColor = System.Drawing.Color.Black;
            this.DataSearch_TX08.Location = new System.Drawing.Point(506, 107);
            this.DataSearch_TX08.Name = "DataSearch_TX08";
            this.DataSearch_TX08.Size = new System.Drawing.Size(100, 20);
            this.DataSearch_TX08.TabIndex = 0;
            // 
            // DataSearch_TX03
            // 
            this.DataSearch_TX03.ForeColor = System.Drawing.Color.Black;
            this.DataSearch_TX03.Location = new System.Drawing.Point(303, 55);
            this.DataSearch_TX03.Name = "DataSearch_TX03";
            this.DataSearch_TX03.Size = new System.Drawing.Size(100, 20);
            this.DataSearch_TX03.TabIndex = 0;
            // 
            // DataSearch_TX07
            // 
            this.DataSearch_TX07.ForeColor = System.Drawing.Color.Black;
            this.DataSearch_TX07.Location = new System.Drawing.Point(506, 81);
            this.DataSearch_TX07.Name = "DataSearch_TX07";
            this.DataSearch_TX07.Size = new System.Drawing.Size(100, 20);
            this.DataSearch_TX07.TabIndex = 0;
            // 
            // DataSearch_TX02
            // 
            this.DataSearch_TX02.ForeColor = System.Drawing.Color.Black;
            this.DataSearch_TX02.Location = new System.Drawing.Point(303, 29);
            this.DataSearch_TX02.Name = "DataSearch_TX02";
            this.DataSearch_TX02.Size = new System.Drawing.Size(100, 20);
            this.DataSearch_TX02.TabIndex = 0;
            // 
            // DataSearch_TX06
            // 
            this.DataSearch_TX06.ForeColor = System.Drawing.Color.Black;
            this.DataSearch_TX06.Location = new System.Drawing.Point(506, 55);
            this.DataSearch_TX06.Name = "DataSearch_TX06";
            this.DataSearch_TX06.Size = new System.Drawing.Size(100, 20);
            this.DataSearch_TX06.TabIndex = 0;
            // 
            // DataSearch_TX01
            // 
            this.DataSearch_TX01.ForeColor = System.Drawing.Color.Black;
            this.DataSearch_TX01.Location = new System.Drawing.Point(303, 3);
            this.DataSearch_TX01.Name = "DataSearch_TX01";
            this.DataSearch_TX01.Size = new System.Drawing.Size(100, 20);
            this.DataSearch_TX01.TabIndex = 0;
            // 
            // DataSearch_LB15
            // 
            this.DataSearch_LB15.AutoSize = true;
            this.DataSearch_LB15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DataSearch_LB15.ForeColor = System.Drawing.Color.Black;
            this.DataSearch_LB15.Location = new System.Drawing.Point(409, 110);
            this.DataSearch_LB15.Margin = new System.Windows.Forms.Padding(3);
            this.DataSearch_LB15.Name = "DataSearch_LB15";
            this.DataSearch_LB15.Size = new System.Drawing.Size(41, 13);
            this.DataSearch_LB15.TabIndex = 0;
            this.DataSearch_LB15.Text = "label1";
            // 
            // DataSearch_LB10
            // 
            this.DataSearch_LB10.AutoSize = true;
            this.DataSearch_LB10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DataSearch_LB10.ForeColor = System.Drawing.Color.Black;
            this.DataSearch_LB10.Location = new System.Drawing.Point(206, 110);
            this.DataSearch_LB10.Margin = new System.Windows.Forms.Padding(3);
            this.DataSearch_LB10.Name = "DataSearch_LB10";
            this.DataSearch_LB10.Size = new System.Drawing.Size(41, 13);
            this.DataSearch_LB10.TabIndex = 0;
            this.DataSearch_LB10.Text = "label1";
            // 
            // DataSearch_LB05
            // 
            this.DataSearch_LB05.AutoSize = true;
            this.DataSearch_LB05.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DataSearch_LB05.ForeColor = System.Drawing.Color.Black;
            this.DataSearch_LB05.Location = new System.Drawing.Point(3, 110);
            this.DataSearch_LB05.Margin = new System.Windows.Forms.Padding(3);
            this.DataSearch_LB05.Name = "DataSearch_LB05";
            this.DataSearch_LB05.Size = new System.Drawing.Size(41, 13);
            this.DataSearch_LB05.TabIndex = 0;
            this.DataSearch_LB05.Text = "label1";
            // 
            // DataSearch_LB14
            // 
            this.DataSearch_LB14.AutoSize = true;
            this.DataSearch_LB14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DataSearch_LB14.ForeColor = System.Drawing.Color.Black;
            this.DataSearch_LB14.Location = new System.Drawing.Point(409, 84);
            this.DataSearch_LB14.Margin = new System.Windows.Forms.Padding(3);
            this.DataSearch_LB14.Name = "DataSearch_LB14";
            this.DataSearch_LB14.Size = new System.Drawing.Size(41, 13);
            this.DataSearch_LB14.TabIndex = 0;
            this.DataSearch_LB14.Text = "label1";
            // 
            // DataSearch_LB09
            // 
            this.DataSearch_LB09.AutoSize = true;
            this.DataSearch_LB09.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DataSearch_LB09.ForeColor = System.Drawing.Color.Black;
            this.DataSearch_LB09.Location = new System.Drawing.Point(206, 84);
            this.DataSearch_LB09.Margin = new System.Windows.Forms.Padding(3);
            this.DataSearch_LB09.Name = "DataSearch_LB09";
            this.DataSearch_LB09.Size = new System.Drawing.Size(41, 13);
            this.DataSearch_LB09.TabIndex = 0;
            this.DataSearch_LB09.Text = "label1";
            // 
            // DataSearch_LB04
            // 
            this.DataSearch_LB04.AutoSize = true;
            this.DataSearch_LB04.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DataSearch_LB04.ForeColor = System.Drawing.Color.Black;
            this.DataSearch_LB04.Location = new System.Drawing.Point(3, 84);
            this.DataSearch_LB04.Margin = new System.Windows.Forms.Padding(3);
            this.DataSearch_LB04.Name = "DataSearch_LB04";
            this.DataSearch_LB04.Size = new System.Drawing.Size(41, 13);
            this.DataSearch_LB04.TabIndex = 0;
            this.DataSearch_LB04.Text = "label1";
            // 
            // DataSearch_LB13
            // 
            this.DataSearch_LB13.AutoSize = true;
            this.DataSearch_LB13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DataSearch_LB13.ForeColor = System.Drawing.Color.Black;
            this.DataSearch_LB13.Location = new System.Drawing.Point(409, 58);
            this.DataSearch_LB13.Margin = new System.Windows.Forms.Padding(3);
            this.DataSearch_LB13.Name = "DataSearch_LB13";
            this.DataSearch_LB13.Size = new System.Drawing.Size(41, 13);
            this.DataSearch_LB13.TabIndex = 0;
            this.DataSearch_LB13.Text = "label1";
            // 
            // DataSearch_LB08
            // 
            this.DataSearch_LB08.AutoSize = true;
            this.DataSearch_LB08.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DataSearch_LB08.ForeColor = System.Drawing.Color.Black;
            this.DataSearch_LB08.Location = new System.Drawing.Point(206, 58);
            this.DataSearch_LB08.Margin = new System.Windows.Forms.Padding(3);
            this.DataSearch_LB08.Name = "DataSearch_LB08";
            this.DataSearch_LB08.Size = new System.Drawing.Size(41, 13);
            this.DataSearch_LB08.TabIndex = 0;
            this.DataSearch_LB08.Text = "label1";
            // 
            // DataSearch_LB03
            // 
            this.DataSearch_LB03.AutoSize = true;
            this.DataSearch_LB03.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DataSearch_LB03.ForeColor = System.Drawing.Color.Black;
            this.DataSearch_LB03.Location = new System.Drawing.Point(3, 58);
            this.DataSearch_LB03.Margin = new System.Windows.Forms.Padding(3);
            this.DataSearch_LB03.Name = "DataSearch_LB03";
            this.DataSearch_LB03.Size = new System.Drawing.Size(41, 13);
            this.DataSearch_LB03.TabIndex = 0;
            this.DataSearch_LB03.Text = "label1";
            // 
            // DataSearch_LB12
            // 
            this.DataSearch_LB12.AutoSize = true;
            this.DataSearch_LB12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DataSearch_LB12.ForeColor = System.Drawing.Color.Black;
            this.DataSearch_LB12.Location = new System.Drawing.Point(409, 32);
            this.DataSearch_LB12.Margin = new System.Windows.Forms.Padding(3);
            this.DataSearch_LB12.Name = "DataSearch_LB12";
            this.DataSearch_LB12.Size = new System.Drawing.Size(41, 13);
            this.DataSearch_LB12.TabIndex = 0;
            this.DataSearch_LB12.Text = "label1";
            // 
            // DataSearch_LB07
            // 
            this.DataSearch_LB07.AutoSize = true;
            this.DataSearch_LB07.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DataSearch_LB07.ForeColor = System.Drawing.Color.Black;
            this.DataSearch_LB07.Location = new System.Drawing.Point(206, 32);
            this.DataSearch_LB07.Margin = new System.Windows.Forms.Padding(3);
            this.DataSearch_LB07.Name = "DataSearch_LB07";
            this.DataSearch_LB07.Size = new System.Drawing.Size(41, 13);
            this.DataSearch_LB07.TabIndex = 0;
            this.DataSearch_LB07.Text = "label1";
            // 
            // DataSearch_LB02
            // 
            this.DataSearch_LB02.AutoSize = true;
            this.DataSearch_LB02.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DataSearch_LB02.ForeColor = System.Drawing.Color.Black;
            this.DataSearch_LB02.Location = new System.Drawing.Point(3, 32);
            this.DataSearch_LB02.Margin = new System.Windows.Forms.Padding(3);
            this.DataSearch_LB02.Name = "DataSearch_LB02";
            this.DataSearch_LB02.Size = new System.Drawing.Size(41, 13);
            this.DataSearch_LB02.TabIndex = 0;
            this.DataSearch_LB02.Text = "label1";
            // 
            // DataSearch_LB11
            // 
            this.DataSearch_LB11.AutoSize = true;
            this.DataSearch_LB11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DataSearch_LB11.ForeColor = System.Drawing.Color.Black;
            this.DataSearch_LB11.Location = new System.Drawing.Point(409, 6);
            this.DataSearch_LB11.Margin = new System.Windows.Forms.Padding(3);
            this.DataSearch_LB11.Name = "DataSearch_LB11";
            this.DataSearch_LB11.Size = new System.Drawing.Size(41, 13);
            this.DataSearch_LB11.TabIndex = 0;
            this.DataSearch_LB11.Text = "label1";
            // 
            // DataSearch_LB06
            // 
            this.DataSearch_LB06.AutoSize = true;
            this.DataSearch_LB06.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DataSearch_LB06.ForeColor = System.Drawing.Color.Black;
            this.DataSearch_LB06.Location = new System.Drawing.Point(206, 6);
            this.DataSearch_LB06.Margin = new System.Windows.Forms.Padding(3);
            this.DataSearch_LB06.Name = "DataSearch_LB06";
            this.DataSearch_LB06.Size = new System.Drawing.Size(41, 13);
            this.DataSearch_LB06.TabIndex = 0;
            this.DataSearch_LB06.Text = "label1";
            // 
            // DataSearch_LB01
            // 
            this.DataSearch_LB01.AutoSize = true;
            this.DataSearch_LB01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DataSearch_LB01.ForeColor = System.Drawing.Color.Black;
            this.DataSearch_LB01.Location = new System.Drawing.Point(3, 6);
            this.DataSearch_LB01.Margin = new System.Windows.Forms.Padding(3);
            this.DataSearch_LB01.Name = "DataSearch_LB01";
            this.DataSearch_LB01.Size = new System.Drawing.Size(41, 13);
            this.DataSearch_LB01.TabIndex = 0;
            this.DataSearch_LB01.Text = "label1";
            // 
            // DataSearch_LB16
            // 
            this.DataSearch_LB16.AutoSize = true;
            this.DataSearch_LB16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DataSearch_LB16.ForeColor = System.Drawing.Color.Black;
            this.DataSearch_LB16.Location = new System.Drawing.Point(612, 6);
            this.DataSearch_LB16.Margin = new System.Windows.Forms.Padding(3);
            this.DataSearch_LB16.Name = "DataSearch_LB16";
            this.DataSearch_LB16.Size = new System.Drawing.Size(41, 13);
            this.DataSearch_LB16.TabIndex = 0;
            this.DataSearch_LB16.Text = "label1";
            // 
            // DataSearch_Genres
            // 
            this.DataSearch_Genres.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataSearch_Genres.CheckOnClick = true;
            this.DataSearch_Genres.ForeColor = System.Drawing.Color.Black;
            this.DataSearch_Genres.FormattingEnabled = true;
            this.DataSearch_Genres.Location = new System.Drawing.Point(615, 34);
            this.DataSearch_Genres.MultiColumn = true;
            this.DataSearch_Genres.Name = "DataSearch_Genres";
            this.DataSearch_Genres.Size = new System.Drawing.Size(382, 94);
            this.DataSearch_Genres.Sorted = true;
            this.DataSearch_Genres.TabIndex = 0;
            this.DataSearch_Genres.MouseEnter += new System.EventHandler(this.DataSearch_Genres_MouseEnter);
            // 
            // DataSearch_Clear
            // 
            this.DataSearch_Clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DataSearch_Clear.ForeColor = System.Drawing.Color.Black;
            this.DataSearch_Clear.Location = new System.Drawing.Point(1024, 74);
            this.DataSearch_Clear.Name = "DataSearch_Clear";
            this.DataSearch_Clear.Size = new System.Drawing.Size(75, 23);
            this.DataSearch_Clear.TabIndex = 0;
            this.DataSearch_Clear.Text = "button1";
            this.DataSearch_Clear.UseVisualStyleBackColor = true;
            this.DataSearch_Clear.Click += new System.EventHandler(this.DataSearch_Clear_Click);
            // 
            // DataSearch_Select
            // 
            this.DataSearch_Select.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DataSearch_Select.ForeColor = System.Drawing.Color.Black;
            this.DataSearch_Select.Location = new System.Drawing.Point(1024, 105);
            this.DataSearch_Select.Name = "DataSearch_Select";
            this.DataSearch_Select.Size = new System.Drawing.Size(75, 23);
            this.DataSearch_Select.TabIndex = 0;
            this.DataSearch_Select.Text = "button1";
            this.DataSearch_Select.UseVisualStyleBackColor = true;
            this.DataSearch_Select.Click += new System.EventHandler(this.DataSearch_Select_Click);
            // 
            // DataSearch
            // 
            this.DataSearch.AllowUserToAddRows = false;
            this.DataSearch.AllowUserToDeleteRows = false;
            this.DataSearch.AllowUserToResizeRows = false;
            this.DataSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataSearch.BackgroundColor = System.Drawing.Color.White;
            this.DataSearch.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DataSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataSearch_Mn01,
            this.DataSearch_Mn02,
            this.DataSearch_Mn03,
            this.DataSearch_Mn04,
            this.DataSearch_Mn05});
            this.DataSearch.GridColor = System.Drawing.Color.White;
            this.DataSearch.Location = new System.Drawing.Point(6, 141);
            this.DataSearch.Name = "DataSearch";
            this.DataSearch.ReadOnly = true;
            this.DataSearch.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataSearch.RowHeadersVisible = false;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.Black;
            this.DataSearch.RowsDefaultCellStyle = dataGridViewCellStyle24;
            this.DataSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataSearch.Size = new System.Drawing.Size(1093, 504);
            this.DataSearch.TabIndex = 0;
            this.DataSearch.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DataSearch_MouseDoubleClick);
            this.DataSearch.MouseEnter += new System.EventHandler(this.DataSearch_MouseEnter);
            // 
            // DataSearch_Mn01
            // 
            this.DataSearch_Mn01.HeaderText = "";
            this.DataSearch_Mn01.MinimumWidth = 100;
            this.DataSearch_Mn01.Name = "DataSearch_Mn01";
            this.DataSearch_Mn01.ReadOnly = true;
            this.DataSearch_Mn01.Visible = false;
            // 
            // DataSearch_Mn02
            // 
            this.DataSearch_Mn02.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DataSearch_Mn02.FillWeight = 50F;
            this.DataSearch_Mn02.HeaderText = "";
            this.DataSearch_Mn02.MinimumWidth = 100;
            this.DataSearch_Mn02.Name = "DataSearch_Mn02";
            this.DataSearch_Mn02.ReadOnly = true;
            // 
            // DataSearch_Mn03
            // 
            this.DataSearch_Mn03.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DataSearch_Mn03.FillWeight = 50F;
            this.DataSearch_Mn03.HeaderText = "";
            this.DataSearch_Mn03.MinimumWidth = 100;
            this.DataSearch_Mn03.Name = "DataSearch_Mn03";
            this.DataSearch_Mn03.ReadOnly = true;
            // 
            // DataSearch_Mn04
            // 
            this.DataSearch_Mn04.HeaderText = "";
            this.DataSearch_Mn04.Name = "DataSearch_Mn04";
            this.DataSearch_Mn04.ReadOnly = true;
            // 
            // DataSearch_Mn05
            // 
            this.DataSearch_Mn05.HeaderText = "";
            this.DataSearch_Mn05.Name = "DataSearch_Mn05";
            this.DataSearch_Mn05.ReadOnly = true;
            // 
            // MainTabData_OthersTabPage
            // 
            this.MainTabData_OthersTabPage.BackColor = System.Drawing.Color.White;
            this.MainTabData_OthersTabPage.Controls.Add(this.AnimeSeen);
            this.MainTabData_OthersTabPage.Controls.Add(this.AnimeRating);
            this.MainTabData_OthersTabPage.Controls.Add(this.AnimeTags);
            this.MainTabData_OthersTabPage.Location = new System.Drawing.Point(4, 22);
            this.MainTabData_OthersTabPage.Name = "MainTabData_OthersTabPage";
            this.MainTabData_OthersTabPage.Size = new System.Drawing.Size(1105, 648);
            this.MainTabData_OthersTabPage.TabIndex = 0;
            this.MainTabData_OthersTabPage.Text = "8";
            // 
            // AnimeSeen
            // 
            this.AnimeSeen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AnimeSeen.BackColor = System.Drawing.Color.White;
            this.AnimeSeen.ForeColor = System.Drawing.Color.Black;
            this.AnimeSeen.ImageIndex = 1;
            this.AnimeSeen.ImageList = this.DataFilesTreeImages;
            this.AnimeSeen.Location = new System.Drawing.Point(802, 44);
            this.AnimeSeen.Name = "AnimeSeen";
            this.AnimeSeen.SelectedImageIndex = 0;
            this.AnimeSeen.Size = new System.Drawing.Size(284, 560);
            this.AnimeSeen.TabIndex = 0;
            this.AnimeSeen.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AnimeSeen_MouseDoubleClick);
            // 
            // AnimeRating
            // 
            this.AnimeRating.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AnimeRating.BackColor = System.Drawing.Color.White;
            this.AnimeRating.ForeColor = System.Drawing.Color.Black;
            this.AnimeRating.ImageIndex = 1;
            this.AnimeRating.ImageList = this.DataFilesTreeImages;
            this.AnimeRating.Location = new System.Drawing.Point(369, 44);
            this.AnimeRating.Name = "AnimeRating";
            this.AnimeRating.SelectedImageIndex = 0;
            this.AnimeRating.Size = new System.Drawing.Size(284, 560);
            this.AnimeRating.TabIndex = 0;
            this.AnimeRating.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AnimeRating_MouseDoubleClick);
            // 
            // AnimeTags
            // 
            this.AnimeTags.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AnimeTags.BackColor = System.Drawing.Color.White;
            this.AnimeTags.ForeColor = System.Drawing.Color.Black;
            this.AnimeTags.ImageIndex = 1;
            this.AnimeTags.ImageList = this.DataFilesTreeImages;
            this.AnimeTags.Location = new System.Drawing.Point(7, 44);
            this.AnimeTags.Name = "AnimeTags";
            this.AnimeTags.SelectedImageIndex = 0;
            this.AnimeTags.Size = new System.Drawing.Size(284, 560);
            this.AnimeTags.TabIndex = 0;
            this.AnimeTags.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AnimeTags_MouseDoubleClick);
            // 
            // MainTabData_GraphsTabPage
            // 
            this.MainTabData_GraphsTabPage.BackColor = System.Drawing.Color.White;
            this.MainTabData_GraphsTabPage.Controls.Add(this.panel1);
            this.MainTabData_GraphsTabPage.Controls.Add(this.Zgc_Graph);
            this.MainTabData_GraphsTabPage.Location = new System.Drawing.Point(4, 22);
            this.MainTabData_GraphsTabPage.Name = "MainTabData_GraphsTabPage";
            this.MainTabData_GraphsTabPage.Size = new System.Drawing.Size(1105, 648);
            this.MainTabData_GraphsTabPage.TabIndex = 0;
            this.MainTabData_GraphsTabPage.Text = "9";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Zgc_GraphB06);
            this.panel1.Controls.Add(this.Zgc_GraphB05);
            this.panel1.Controls.Add(this.Zgc_GraphB04);
            this.panel1.Controls.Add(this.Zgc_GraphB03);
            this.panel1.Controls.Add(this.Zgc_GraphB02);
            this.panel1.Controls.Add(this.Zgc_GraphB01);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 603);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1105, 45);
            this.panel1.TabIndex = 0;
            // 
            // Zgc_Graph
            // 
            this.Zgc_Graph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Zgc_Graph.AutoSize = true;
            this.Zgc_Graph.EditButtons = System.Windows.Forms.MouseButtons.None;
            this.Zgc_Graph.EditModifierKeys = System.Windows.Forms.Keys.None;
            this.Zgc_Graph.IsEnableHPan = false;
            this.Zgc_Graph.IsEnableHZoom = false;
            this.Zgc_Graph.IsEnableVPan = false;
            this.Zgc_Graph.IsEnableVZoom = false;
            this.Zgc_Graph.IsEnableWheelZoom = false;
            this.Zgc_Graph.IsPrintFillPage = false;
            this.Zgc_Graph.IsPrintKeepAspectRatio = false;
            this.Zgc_Graph.IsPrintScaleAll = false;
            this.Zgc_Graph.IsShowContextMenu = false;
            this.Zgc_Graph.IsShowCopyMessage = false;
            this.Zgc_Graph.LinkButtons = System.Windows.Forms.MouseButtons.None;
            this.Zgc_Graph.LinkModifierKeys = System.Windows.Forms.Keys.None;
            this.Zgc_Graph.Location = new System.Drawing.Point(3, 3);
            this.Zgc_Graph.Name = "Zgc_Graph";
            this.Zgc_Graph.PanButtons = System.Windows.Forms.MouseButtons.None;
            this.Zgc_Graph.PanButtons2 = System.Windows.Forms.MouseButtons.None;
            this.Zgc_Graph.PanModifierKeys = System.Windows.Forms.Keys.None;
            this.Zgc_Graph.ScrollGrace = 0D;
            this.Zgc_Graph.ScrollMaxX = 0D;
            this.Zgc_Graph.ScrollMaxY = 0D;
            this.Zgc_Graph.ScrollMaxY2 = 0D;
            this.Zgc_Graph.ScrollMinX = 0D;
            this.Zgc_Graph.ScrollMinY = 0D;
            this.Zgc_Graph.ScrollMinY2 = 0D;
            this.Zgc_Graph.SelectButtons = System.Windows.Forms.MouseButtons.None;
            this.Zgc_Graph.SelectModifierKeys = System.Windows.Forms.Keys.None;
            this.Zgc_Graph.Size = new System.Drawing.Size(1099, 594);
            this.Zgc_Graph.TabIndex = 0;
            this.Zgc_Graph.ZoomButtons = System.Windows.Forms.MouseButtons.None;
            // 
            // MainTabData_ExportTabPage
            // 
            this.MainTabData_ExportTabPage.BackColor = System.Drawing.Color.White;
            this.MainTabData_ExportTabPage.Controls.Add(this.Anime_ExportLB01);
            this.MainTabData_ExportTabPage.Controls.Add(this.Anime_ExportBT02);
            this.MainTabData_ExportTabPage.Controls.Add(this.Anime_ExportBT01);
            this.MainTabData_ExportTabPage.Controls.Add(this.Anime_ExportCH18);
            this.MainTabData_ExportTabPage.Controls.Add(this.Anime_ExportCH17);
            this.MainTabData_ExportTabPage.Controls.Add(this.Anime_ExportCH16);
            this.MainTabData_ExportTabPage.Controls.Add(this.Anime_ExportCH15);
            this.MainTabData_ExportTabPage.Controls.Add(this.Anime_ExportCH14);
            this.MainTabData_ExportTabPage.Controls.Add(this.Anime_ExportCH13);
            this.MainTabData_ExportTabPage.Controls.Add(this.Anime_ExportCH12);
            this.MainTabData_ExportTabPage.Controls.Add(this.Anime_ExportCH11);
            this.MainTabData_ExportTabPage.Controls.Add(this.Anime_ExportCH10);
            this.MainTabData_ExportTabPage.Controls.Add(this.Anime_ExportCH09);
            this.MainTabData_ExportTabPage.Controls.Add(this.Anime_ExportCH08);
            this.MainTabData_ExportTabPage.Controls.Add(this.Anime_ExportCH07);
            this.MainTabData_ExportTabPage.Controls.Add(this.Anime_ExportCH06);
            this.MainTabData_ExportTabPage.Controls.Add(this.Anime_ExportCH05);
            this.MainTabData_ExportTabPage.Controls.Add(this.Anime_ExportCH04);
            this.MainTabData_ExportTabPage.Controls.Add(this.Anime_ExportCH03);
            this.MainTabData_ExportTabPage.Controls.Add(this.Anime_ExportCH02);
            this.MainTabData_ExportTabPage.Controls.Add(this.Anime_ExportCH01);
            this.MainTabData_ExportTabPage.Location = new System.Drawing.Point(4, 22);
            this.MainTabData_ExportTabPage.Name = "MainTabData_ExportTabPage";
            this.MainTabData_ExportTabPage.Size = new System.Drawing.Size(1105, 648);
            this.MainTabData_ExportTabPage.TabIndex = 0;
            this.MainTabData_ExportTabPage.Text = "10";
            // 
            // Anime_ExportLB01
            // 
            this.Anime_ExportLB01.AutoSize = true;
            this.Anime_ExportLB01.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Anime_ExportLB01.Location = new System.Drawing.Point(32, 208);
            this.Anime_ExportLB01.Name = "Anime_ExportLB01";
            this.Anime_ExportLB01.Size = new System.Drawing.Size(51, 16);
            this.Anime_ExportLB01.TabIndex = 0;
            this.Anime_ExportLB01.Text = "label2";
            // 
            // Anime_ExportBT02
            // 
            this.Anime_ExportBT02.Location = new System.Drawing.Point(635, 268);
            this.Anime_ExportBT02.Name = "Anime_ExportBT02";
            this.Anime_ExportBT02.Size = new System.Drawing.Size(80, 23);
            this.Anime_ExportBT02.TabIndex = 0;
            this.Anime_ExportBT02.Text = "button2";
            this.Anime_ExportBT02.UseVisualStyleBackColor = true;
            this.Anime_ExportBT02.Click += new System.EventHandler(this.Anime_ExportBT02_Click);
            // 
            // Anime_ExportBT01
            // 
            this.Anime_ExportBT01.Location = new System.Drawing.Point(435, 268);
            this.Anime_ExportBT01.Name = "Anime_ExportBT01";
            this.Anime_ExportBT01.Size = new System.Drawing.Size(87, 23);
            this.Anime_ExportBT01.TabIndex = 0;
            this.Anime_ExportBT01.Text = "button1";
            this.Anime_ExportBT01.UseVisualStyleBackColor = true;
            this.Anime_ExportBT01.Click += new System.EventHandler(this.Anime_ExportBT01_Click);
            // 
            // Anime_ExportCH18
            // 
            this.Anime_ExportCH18.AutoSize = true;
            this.Anime_ExportCH18.Location = new System.Drawing.Point(235, 127);
            this.Anime_ExportCH18.Name = "Anime_ExportCH18";
            this.Anime_ExportCH18.Size = new System.Drawing.Size(80, 17);
            this.Anime_ExportCH18.TabIndex = 0;
            this.Anime_ExportCH18.Text = "checkBox1";
            this.Anime_ExportCH18.UseVisualStyleBackColor = true;
            // 
            // Anime_ExportCH17
            // 
            this.Anime_ExportCH17.AutoSize = true;
            this.Anime_ExportCH17.Location = new System.Drawing.Point(35, 127);
            this.Anime_ExportCH17.Name = "Anime_ExportCH17";
            this.Anime_ExportCH17.Size = new System.Drawing.Size(80, 17);
            this.Anime_ExportCH17.TabIndex = 0;
            this.Anime_ExportCH17.Text = "checkBox1";
            this.Anime_ExportCH17.UseVisualStyleBackColor = true;
            // 
            // Anime_ExportCH16
            // 
            this.Anime_ExportCH16.AutoSize = true;
            this.Anime_ExportCH16.Location = new System.Drawing.Point(635, 102);
            this.Anime_ExportCH16.Name = "Anime_ExportCH16";
            this.Anime_ExportCH16.Size = new System.Drawing.Size(80, 17);
            this.Anime_ExportCH16.TabIndex = 0;
            this.Anime_ExportCH16.Text = "checkBox1";
            this.Anime_ExportCH16.UseVisualStyleBackColor = true;
            // 
            // Anime_ExportCH15
            // 
            this.Anime_ExportCH15.AutoSize = true;
            this.Anime_ExportCH15.Location = new System.Drawing.Point(435, 102);
            this.Anime_ExportCH15.Name = "Anime_ExportCH15";
            this.Anime_ExportCH15.Size = new System.Drawing.Size(80, 17);
            this.Anime_ExportCH15.TabIndex = 0;
            this.Anime_ExportCH15.Text = "checkBox1";
            this.Anime_ExportCH15.UseVisualStyleBackColor = true;
            // 
            // Anime_ExportCH14
            // 
            this.Anime_ExportCH14.AutoSize = true;
            this.Anime_ExportCH14.Location = new System.Drawing.Point(235, 104);
            this.Anime_ExportCH14.Name = "Anime_ExportCH14";
            this.Anime_ExportCH14.Size = new System.Drawing.Size(80, 17);
            this.Anime_ExportCH14.TabIndex = 0;
            this.Anime_ExportCH14.Text = "checkBox1";
            this.Anime_ExportCH14.UseVisualStyleBackColor = true;
            // 
            // Anime_ExportCH13
            // 
            this.Anime_ExportCH13.AutoSize = true;
            this.Anime_ExportCH13.Location = new System.Drawing.Point(35, 104);
            this.Anime_ExportCH13.Name = "Anime_ExportCH13";
            this.Anime_ExportCH13.Size = new System.Drawing.Size(80, 17);
            this.Anime_ExportCH13.TabIndex = 0;
            this.Anime_ExportCH13.Text = "checkBox1";
            this.Anime_ExportCH13.UseVisualStyleBackColor = true;
            // 
            // Anime_ExportCH12
            // 
            this.Anime_ExportCH12.AutoSize = true;
            this.Anime_ExportCH12.Location = new System.Drawing.Point(635, 79);
            this.Anime_ExportCH12.Name = "Anime_ExportCH12";
            this.Anime_ExportCH12.Size = new System.Drawing.Size(80, 17);
            this.Anime_ExportCH12.TabIndex = 0;
            this.Anime_ExportCH12.Text = "checkBox1";
            this.Anime_ExportCH12.UseVisualStyleBackColor = true;
            // 
            // Anime_ExportCH11
            // 
            this.Anime_ExportCH11.AutoSize = true;
            this.Anime_ExportCH11.Location = new System.Drawing.Point(435, 79);
            this.Anime_ExportCH11.Name = "Anime_ExportCH11";
            this.Anime_ExportCH11.Size = new System.Drawing.Size(80, 17);
            this.Anime_ExportCH11.TabIndex = 0;
            this.Anime_ExportCH11.Text = "checkBox1";
            this.Anime_ExportCH11.UseVisualStyleBackColor = true;
            // 
            // Anime_ExportCH10
            // 
            this.Anime_ExportCH10.AutoSize = true;
            this.Anime_ExportCH10.Location = new System.Drawing.Point(235, 81);
            this.Anime_ExportCH10.Name = "Anime_ExportCH10";
            this.Anime_ExportCH10.Size = new System.Drawing.Size(80, 17);
            this.Anime_ExportCH10.TabIndex = 0;
            this.Anime_ExportCH10.Text = "checkBox1";
            this.Anime_ExportCH10.UseVisualStyleBackColor = true;
            // 
            // Anime_ExportCH09
            // 
            this.Anime_ExportCH09.AutoSize = true;
            this.Anime_ExportCH09.Location = new System.Drawing.Point(35, 81);
            this.Anime_ExportCH09.Name = "Anime_ExportCH09";
            this.Anime_ExportCH09.Size = new System.Drawing.Size(80, 17);
            this.Anime_ExportCH09.TabIndex = 0;
            this.Anime_ExportCH09.Text = "checkBox1";
            this.Anime_ExportCH09.UseVisualStyleBackColor = true;
            // 
            // Anime_ExportCH08
            // 
            this.Anime_ExportCH08.AutoSize = true;
            this.Anime_ExportCH08.Location = new System.Drawing.Point(635, 56);
            this.Anime_ExportCH08.Name = "Anime_ExportCH08";
            this.Anime_ExportCH08.Size = new System.Drawing.Size(80, 17);
            this.Anime_ExportCH08.TabIndex = 0;
            this.Anime_ExportCH08.Text = "checkBox1";
            this.Anime_ExportCH08.UseVisualStyleBackColor = true;
            // 
            // Anime_ExportCH07
            // 
            this.Anime_ExportCH07.AutoSize = true;
            this.Anime_ExportCH07.Location = new System.Drawing.Point(435, 56);
            this.Anime_ExportCH07.Name = "Anime_ExportCH07";
            this.Anime_ExportCH07.Size = new System.Drawing.Size(80, 17);
            this.Anime_ExportCH07.TabIndex = 0;
            this.Anime_ExportCH07.Text = "checkBox1";
            this.Anime_ExportCH07.UseVisualStyleBackColor = true;
            // 
            // Anime_ExportCH06
            // 
            this.Anime_ExportCH06.AutoSize = true;
            this.Anime_ExportCH06.Location = new System.Drawing.Point(235, 58);
            this.Anime_ExportCH06.Name = "Anime_ExportCH06";
            this.Anime_ExportCH06.Size = new System.Drawing.Size(80, 17);
            this.Anime_ExportCH06.TabIndex = 0;
            this.Anime_ExportCH06.Text = "checkBox1";
            this.Anime_ExportCH06.UseVisualStyleBackColor = true;
            // 
            // Anime_ExportCH05
            // 
            this.Anime_ExportCH05.AutoSize = true;
            this.Anime_ExportCH05.Location = new System.Drawing.Point(35, 58);
            this.Anime_ExportCH05.Name = "Anime_ExportCH05";
            this.Anime_ExportCH05.Size = new System.Drawing.Size(80, 17);
            this.Anime_ExportCH05.TabIndex = 0;
            this.Anime_ExportCH05.Text = "checkBox1";
            this.Anime_ExportCH05.UseVisualStyleBackColor = true;
            // 
            // Anime_ExportCH04
            // 
            this.Anime_ExportCH04.AutoSize = true;
            this.Anime_ExportCH04.Location = new System.Drawing.Point(635, 35);
            this.Anime_ExportCH04.Name = "Anime_ExportCH04";
            this.Anime_ExportCH04.Size = new System.Drawing.Size(80, 17);
            this.Anime_ExportCH04.TabIndex = 0;
            this.Anime_ExportCH04.Text = "checkBox1";
            this.Anime_ExportCH04.UseVisualStyleBackColor = true;
            // 
            // Anime_ExportCH03
            // 
            this.Anime_ExportCH03.AutoSize = true;
            this.Anime_ExportCH03.Location = new System.Drawing.Point(435, 33);
            this.Anime_ExportCH03.Name = "Anime_ExportCH03";
            this.Anime_ExportCH03.Size = new System.Drawing.Size(80, 17);
            this.Anime_ExportCH03.TabIndex = 0;
            this.Anime_ExportCH03.Text = "checkBox1";
            this.Anime_ExportCH03.UseVisualStyleBackColor = true;
            // 
            // Anime_ExportCH02
            // 
            this.Anime_ExportCH02.AutoSize = true;
            this.Anime_ExportCH02.Location = new System.Drawing.Point(235, 35);
            this.Anime_ExportCH02.Name = "Anime_ExportCH02";
            this.Anime_ExportCH02.Size = new System.Drawing.Size(80, 17);
            this.Anime_ExportCH02.TabIndex = 0;
            this.Anime_ExportCH02.Text = "checkBox1";
            this.Anime_ExportCH02.UseVisualStyleBackColor = true;
            // 
            // Anime_ExportCH01
            // 
            this.Anime_ExportCH01.AutoSize = true;
            this.Anime_ExportCH01.Checked = true;
            this.Anime_ExportCH01.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Anime_ExportCH01.Enabled = false;
            this.Anime_ExportCH01.Location = new System.Drawing.Point(35, 35);
            this.Anime_ExportCH01.Name = "Anime_ExportCH01";
            this.Anime_ExportCH01.Size = new System.Drawing.Size(80, 17);
            this.Anime_ExportCH01.TabIndex = 0;
            this.Anime_ExportCH01.Text = "checkBox1";
            this.Anime_ExportCH01.UseVisualStyleBackColor = true;
            // 
            // MainTab_MangaPage
            // 
            this.MainTab_MangaPage.BackColor = System.Drawing.Color.White;
            this.MainTab_MangaPage.Controls.Add(this.MainTabManga);
            this.MainTab_MangaPage.Location = new System.Drawing.Point(4, 22);
            this.MainTab_MangaPage.Name = "MainTab_MangaPage";
            this.MainTab_MangaPage.Size = new System.Drawing.Size(1119, 680);
            this.MainTab_MangaPage.TabIndex = 0;
            this.MainTab_MangaPage.Text = "7";
            this.MainTab_MangaPage.UseVisualStyleBackColor = true;
            // 
            // MainTabManga
            // 
            this.MainTabManga.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTabManga.Controls.Add(this.MainTabManga_Mn01);
            this.MainTabManga.Controls.Add(this.MainTabManga_Mn02);
            this.MainTabManga.Controls.Add(this.MainTabManga_Mn03);
            this.MainTabManga.Location = new System.Drawing.Point(3, 3);
            this.MainTabManga.Name = "MainTabManga";
            this.MainTabManga.SelectedIndex = 0;
            this.MainTabManga.Size = new System.Drawing.Size(1104, 674);
            this.MainTabManga.TabIndex = 0;
            this.MainTabManga.SelectedIndexChanged += new System.EventHandler(this.MainTabManga_SelectedIndexChanged);
            // 
            // MainTabManga_Mn01
            // 
            this.MainTabManga_Mn01.BackColor = System.Drawing.Color.White;
            this.MainTabManga_Mn01.Controls.Add(this.Options_MyListRefreshManga);
            this.MainTabManga_Mn01.Controls.Add(this.Manga_Gr04);
            this.MainTabManga_Mn01.Controls.Add(this.MangaTree_CH01);
            this.MainTabManga_Mn01.Controls.Add(this.Manga_Gr01);
            this.MainTabManga_Mn01.Controls.Add(this.Manga_Tree);
            this.MainTabManga_Mn01.Controls.Add(this.Manga_Lang03);
            this.MainTabManga_Mn01.Controls.Add(this.Manga_Lang02);
            this.MainTabManga_Mn01.Controls.Add(this.Manga_Lang01);
            this.MainTabManga_Mn01.Location = new System.Drawing.Point(4, 22);
            this.MainTabManga_Mn01.Name = "MainTabManga_Mn01";
            this.MainTabManga_Mn01.Padding = new System.Windows.Forms.Padding(3);
            this.MainTabManga_Mn01.Size = new System.Drawing.Size(1096, 648);
            this.MainTabManga_Mn01.TabIndex = 0;
            this.MainTabManga_Mn01.Text = "1";
            this.MainTabManga_Mn01.UseVisualStyleBackColor = true;
            // 
            // Manga_Gr04
            // 
            this.Manga_Gr04.Controls.Add(this.Options_MangaLabel);
            this.Manga_Gr04.Controls.Add(this.Options_LB65);
            this.Manga_Gr04.Controls.Add(this.Options_VolumesLabel);
            this.Manga_Gr04.Controls.Add(this.Options_LB54);
            this.Manga_Gr04.Controls.Add(this.Options_ReadLabel);
            this.Manga_Gr04.Controls.Add(this.Options_LB56);
            this.Manga_Gr04.Controls.Add(this.Options_ChaptersLabel);
            this.Manga_Gr04.Controls.Add(this.Options_LB64);
            this.Manga_Gr04.Controls.Add(this.Options_TotalPagesLabel);
            this.Manga_Gr04.Controls.Add(this.Options_LB62);
            this.Manga_Gr04.Controls.Add(this.Options_AdultLabel);
            this.Manga_Gr04.Controls.Add(this.Options_LB58);
            this.Manga_Gr04.Controls.Add(this.Options_ReadLabel2);
            this.Manga_Gr04.Controls.Add(this.Options_LB60);
            this.Manga_Gr04.Controls.Add(this.Options_FileSizeLabel);
            this.Manga_Gr04.Controls.Add(this.Options_LB52);
            this.Manga_Gr04.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.Manga_Gr04.Location = new System.Drawing.Point(3, 6);
            this.Manga_Gr04.Name = "Manga_Gr04";
            this.Manga_Gr04.Size = new System.Drawing.Size(248, 189);
            this.Manga_Gr04.TabIndex = 0;
            this.Manga_Gr04.TabStop = false;
            this.Manga_Gr04.Text = "groupBox1";
            // 
            // Options_MangaLabel
            // 
            this.Options_MangaLabel.AutoSize = true;
            this.Options_MangaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_MangaLabel.ForeColor = System.Drawing.Color.Black;
            this.Options_MangaLabel.Location = new System.Drawing.Point(10, 25);
            this.Options_MangaLabel.Margin = new System.Windows.Forms.Padding(3);
            this.Options_MangaLabel.Name = "Options_MangaLabel";
            this.Options_MangaLabel.Size = new System.Drawing.Size(46, 13);
            this.Options_MangaLabel.TabIndex = 0;
            this.Options_MangaLabel.Text = "Nadpis";
            // 
            // Options_LB65
            // 
            this.Options_LB65.AutoSize = true;
            this.Options_LB65.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_LB65.ForeColor = System.Drawing.Color.Black;
            this.Options_LB65.Location = new System.Drawing.Point(136, 158);
            this.Options_LB65.Margin = new System.Windows.Forms.Padding(3);
            this.Options_LB65.Name = "Options_LB65";
            this.Options_LB65.Size = new System.Drawing.Size(34, 13);
            this.Options_LB65.TabIndex = 0;
            this.Options_LB65.Text = "Value";
            this.Options_LB65.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Options_VolumesLabel
            // 
            this.Options_VolumesLabel.AutoSize = true;
            this.Options_VolumesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_VolumesLabel.ForeColor = System.Drawing.Color.Black;
            this.Options_VolumesLabel.Location = new System.Drawing.Point(10, 44);
            this.Options_VolumesLabel.Margin = new System.Windows.Forms.Padding(3);
            this.Options_VolumesLabel.Name = "Options_VolumesLabel";
            this.Options_VolumesLabel.Size = new System.Drawing.Size(46, 13);
            this.Options_VolumesLabel.TabIndex = 0;
            this.Options_VolumesLabel.Text = "Nadpis";
            // 
            // Options_LB54
            // 
            this.Options_LB54.AutoSize = true;
            this.Options_LB54.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_LB54.ForeColor = System.Drawing.Color.Black;
            this.Options_LB54.Location = new System.Drawing.Point(136, 44);
            this.Options_LB54.Margin = new System.Windows.Forms.Padding(3);
            this.Options_LB54.Name = "Options_LB54";
            this.Options_LB54.Size = new System.Drawing.Size(34, 13);
            this.Options_LB54.TabIndex = 0;
            this.Options_LB54.Text = "Value";
            this.Options_LB54.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Options_ReadLabel
            // 
            this.Options_ReadLabel.AutoSize = true;
            this.Options_ReadLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_ReadLabel.ForeColor = System.Drawing.Color.Black;
            this.Options_ReadLabel.Location = new System.Drawing.Point(10, 101);
            this.Options_ReadLabel.Margin = new System.Windows.Forms.Padding(3);
            this.Options_ReadLabel.Name = "Options_ReadLabel";
            this.Options_ReadLabel.Size = new System.Drawing.Size(46, 13);
            this.Options_ReadLabel.TabIndex = 0;
            this.Options_ReadLabel.Text = "Nadpis";
            // 
            // Options_LB56
            // 
            this.Options_LB56.AutoSize = true;
            this.Options_LB56.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_LB56.ForeColor = System.Drawing.Color.Black;
            this.Options_LB56.Location = new System.Drawing.Point(136, 63);
            this.Options_LB56.Margin = new System.Windows.Forms.Padding(3);
            this.Options_LB56.Name = "Options_LB56";
            this.Options_LB56.Size = new System.Drawing.Size(34, 13);
            this.Options_LB56.TabIndex = 0;
            this.Options_LB56.Text = "Value";
            this.Options_LB56.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Options_ChaptersLabel
            // 
            this.Options_ChaptersLabel.AutoSize = true;
            this.Options_ChaptersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_ChaptersLabel.ForeColor = System.Drawing.Color.Black;
            this.Options_ChaptersLabel.Location = new System.Drawing.Point(10, 63);
            this.Options_ChaptersLabel.Margin = new System.Windows.Forms.Padding(3);
            this.Options_ChaptersLabel.Name = "Options_ChaptersLabel";
            this.Options_ChaptersLabel.Size = new System.Drawing.Size(46, 13);
            this.Options_ChaptersLabel.TabIndex = 0;
            this.Options_ChaptersLabel.Text = "Nadpis";
            // 
            // Options_LB64
            // 
            this.Options_LB64.AutoSize = true;
            this.Options_LB64.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_LB64.ForeColor = System.Drawing.Color.Black;
            this.Options_LB64.Location = new System.Drawing.Point(136, 139);
            this.Options_LB64.Margin = new System.Windows.Forms.Padding(3);
            this.Options_LB64.Name = "Options_LB64";
            this.Options_LB64.Size = new System.Drawing.Size(34, 13);
            this.Options_LB64.TabIndex = 0;
            this.Options_LB64.Text = "Value";
            this.Options_LB64.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Options_TotalPagesLabel
            // 
            this.Options_TotalPagesLabel.AutoSize = true;
            this.Options_TotalPagesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_TotalPagesLabel.ForeColor = System.Drawing.Color.Black;
            this.Options_TotalPagesLabel.Location = new System.Drawing.Point(10, 120);
            this.Options_TotalPagesLabel.Margin = new System.Windows.Forms.Padding(3);
            this.Options_TotalPagesLabel.Name = "Options_TotalPagesLabel";
            this.Options_TotalPagesLabel.Size = new System.Drawing.Size(46, 13);
            this.Options_TotalPagesLabel.TabIndex = 0;
            this.Options_TotalPagesLabel.Text = "Nadpis";
            // 
            // Options_LB62
            // 
            this.Options_LB62.AutoSize = true;
            this.Options_LB62.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_LB62.ForeColor = System.Drawing.Color.Black;
            this.Options_LB62.Location = new System.Drawing.Point(136, 120);
            this.Options_LB62.Margin = new System.Windows.Forms.Padding(3);
            this.Options_LB62.Name = "Options_LB62";
            this.Options_LB62.Size = new System.Drawing.Size(34, 13);
            this.Options_LB62.TabIndex = 0;
            this.Options_LB62.Text = "Value";
            this.Options_LB62.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Options_AdultLabel
            // 
            this.Options_AdultLabel.AutoSize = true;
            this.Options_AdultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_AdultLabel.ForeColor = System.Drawing.Color.Black;
            this.Options_AdultLabel.Location = new System.Drawing.Point(10, 139);
            this.Options_AdultLabel.Margin = new System.Windows.Forms.Padding(3);
            this.Options_AdultLabel.Name = "Options_AdultLabel";
            this.Options_AdultLabel.Size = new System.Drawing.Size(46, 13);
            this.Options_AdultLabel.TabIndex = 0;
            this.Options_AdultLabel.Text = "Nadpis";
            // 
            // Options_LB58
            // 
            this.Options_LB58.AutoSize = true;
            this.Options_LB58.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_LB58.ForeColor = System.Drawing.Color.Black;
            this.Options_LB58.Location = new System.Drawing.Point(136, 81);
            this.Options_LB58.Margin = new System.Windows.Forms.Padding(3);
            this.Options_LB58.Name = "Options_LB58";
            this.Options_LB58.Size = new System.Drawing.Size(34, 13);
            this.Options_LB58.TabIndex = 0;
            this.Options_LB58.Text = "Value";
            this.Options_LB58.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Options_ReadLabel2
            // 
            this.Options_ReadLabel2.AutoSize = true;
            this.Options_ReadLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_ReadLabel2.ForeColor = System.Drawing.Color.Black;
            this.Options_ReadLabel2.Location = new System.Drawing.Point(10, 158);
            this.Options_ReadLabel2.Margin = new System.Windows.Forms.Padding(3);
            this.Options_ReadLabel2.Name = "Options_ReadLabel2";
            this.Options_ReadLabel2.Size = new System.Drawing.Size(46, 13);
            this.Options_ReadLabel2.TabIndex = 0;
            this.Options_ReadLabel2.Text = "Nadpis";
            // 
            // Options_LB60
            // 
            this.Options_LB60.AutoSize = true;
            this.Options_LB60.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_LB60.ForeColor = System.Drawing.Color.Black;
            this.Options_LB60.Location = new System.Drawing.Point(136, 101);
            this.Options_LB60.Margin = new System.Windows.Forms.Padding(3);
            this.Options_LB60.Name = "Options_LB60";
            this.Options_LB60.Size = new System.Drawing.Size(34, 13);
            this.Options_LB60.TabIndex = 0;
            this.Options_LB60.Text = "Value";
            this.Options_LB60.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Options_FileSizeLabel
            // 
            this.Options_FileSizeLabel.AutoSize = true;
            this.Options_FileSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_FileSizeLabel.ForeColor = System.Drawing.Color.Black;
            this.Options_FileSizeLabel.Location = new System.Drawing.Point(10, 82);
            this.Options_FileSizeLabel.Margin = new System.Windows.Forms.Padding(3);
            this.Options_FileSizeLabel.Name = "Options_FileSizeLabel";
            this.Options_FileSizeLabel.Size = new System.Drawing.Size(46, 13);
            this.Options_FileSizeLabel.TabIndex = 0;
            this.Options_FileSizeLabel.Text = "Nadpis";
            // 
            // Options_LB52
            // 
            this.Options_LB52.AutoSize = true;
            this.Options_LB52.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Options_LB52.ForeColor = System.Drawing.Color.Black;
            this.Options_LB52.Location = new System.Drawing.Point(136, 25);
            this.Options_LB52.Margin = new System.Windows.Forms.Padding(3);
            this.Options_LB52.Name = "Options_LB52";
            this.Options_LB52.Size = new System.Drawing.Size(34, 13);
            this.Options_LB52.TabIndex = 0;
            this.Options_LB52.Text = "Value";
            this.Options_LB52.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MangaTree_CH01
            // 
            this.MangaTree_CH01.AutoSize = true;
            this.MangaTree_CH01.Location = new System.Drawing.Point(93, 205);
            this.MangaTree_CH01.Name = "MangaTree_CH01";
            this.MangaTree_CH01.Size = new System.Drawing.Size(80, 17);
            this.MangaTree_CH01.TabIndex = 0;
            this.MangaTree_CH01.Text = "checkBox1";
            this.MangaTree_CH01.UseVisualStyleBackColor = true;
            // 
            // Manga_Gr01
            // 
            this.Manga_Gr01.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Manga_Gr01.Controls.Add(this.Manga_CB01);
            this.Manga_Gr01.Controls.Add(this.Manga_RelationTree);
            this.Manga_Gr01.Controls.Add(this.Manga_Chapter);
            this.Manga_Gr01.Controls.Add(this.Manga_Edit);
            this.Manga_Gr01.Controls.Add(this.Manga_LB14);
            this.Manga_Gr01.Controls.Add(this.Manga_LB53);
            this.Manga_Gr01.Controls.Add(this.Manga_LB45);
            this.Manga_Gr01.Controls.Add(this.Manga_LB52);
            this.Manga_Gr01.Controls.Add(this.Manga_LB13);
            this.Manga_Gr01.Controls.Add(this.Manga_Picture);
            this.Manga_Gr01.Controls.Add(this.Manga_LB40);
            this.Manga_Gr01.Controls.Add(this.Manga_LB10);
            this.Manga_Gr01.Controls.Add(this.Manga_LB12);
            this.Manga_Gr01.Controls.Add(this.Manga_LB38);
            this.Manga_Gr01.Controls.Add(this.Manga_LB08);
            this.Manga_Gr01.Controls.Add(this.Manga_LB06);
            this.Manga_Gr01.Controls.Add(this.Manga_LB04);
            this.Manga_Gr01.Controls.Add(this.Manga_LB05);
            this.Manga_Gr01.Controls.Add(this.Manga_LB25);
            this.Manga_Gr01.Controls.Add(this.Manga_LB39);
            this.Manga_Gr01.Controls.Add(this.Manga_LB15);
            this.Manga_Gr01.Controls.Add(this.Manga_LB37);
            this.Manga_Gr01.Controls.Add(this.Manga_LB07);
            this.Manga_Gr01.Controls.Add(this.Manga_LB01);
            this.Manga_Gr01.Controls.Add(this.Manga_LB09);
            this.Manga_Gr01.Controls.Add(this.Manga_LB03);
            this.Manga_Gr01.Controls.Add(this.Manga_Data);
            this.Manga_Gr01.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Manga_Gr01.ForeColor = System.Drawing.Color.Black;
            this.Manga_Gr01.Location = new System.Drawing.Point(257, 3);
            this.Manga_Gr01.Name = "Manga_Gr01";
            this.Manga_Gr01.Size = new System.Drawing.Size(836, 642);
            this.Manga_Gr01.TabIndex = 0;
            this.Manga_Gr01.TabStop = false;
            this.Manga_Gr01.Text = "groupBox1";
            this.Manga_Gr01.Visible = false;
            // 
            // Manga_CB01
            // 
            this.Manga_CB01.BackColor = System.Drawing.Color.White;
            this.Manga_CB01.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Manga_CB01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Manga_CB01.ForeColor = System.Drawing.Color.Black;
            this.Manga_CB01.FormattingEnabled = true;
            this.Manga_CB01.Location = new System.Drawing.Point(364, 290);
            this.Manga_CB01.Name = "Manga_CB01";
            this.Manga_CB01.Size = new System.Drawing.Size(150, 21);
            this.Manga_CB01.Sorted = true;
            this.Manga_CB01.TabIndex = 2;
            this.Manga_CB01.SelectedIndexChanged += new System.EventHandler(this.Manga_CB01_SelectedIndexChanged);
            // 
            // Manga_RelationTree
            // 
            this.Manga_RelationTree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Manga_RelationTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Manga_RelationTree.Location = new System.Drawing.Point(560, 17);
            this.Manga_RelationTree.Name = "Manga_RelationTree";
            this.Manga_RelationTree.ShowLines = false;
            this.Manga_RelationTree.Size = new System.Drawing.Size(270, 255);
            this.Manga_RelationTree.TabIndex = 0;
            this.Manga_RelationTree.DoubleClick += new System.EventHandler(this.Manga_RelationTree_DoubleClick);
            // 
            // Manga_LB14
            // 
            this.Manga_LB14.AutoSize = true;
            this.Manga_LB14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Manga_LB14.ForeColor = System.Drawing.Color.Black;
            this.Manga_LB14.Location = new System.Drawing.Point(237, 198);
            this.Manga_LB14.Margin = new System.Windows.Forms.Padding(3);
            this.Manga_LB14.Name = "Manga_LB14";
            this.Manga_LB14.Size = new System.Drawing.Size(65, 13);
            this.Manga_LB14.TabIndex = 0;
            this.Manga_LB14.TabStop = true;
            this.Manga_LB14.Text = "linkLabel1";
            this.Manga_LB14.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Manga_LB14_LinkClicked);
            // 
            // Manga_LB53
            // 
            this.Manga_LB53.AutoSize = true;
            this.Manga_LB53.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Manga_LB53.ForeColor = System.Drawing.Color.Black;
            this.Manga_LB53.Location = new System.Drawing.Point(237, 274);
            this.Manga_LB53.Margin = new System.Windows.Forms.Padding(3);
            this.Manga_LB53.Name = "Manga_LB53";
            this.Manga_LB53.Size = new System.Drawing.Size(65, 13);
            this.Manga_LB53.TabIndex = 0;
            this.Manga_LB53.TabStop = true;
            this.Manga_LB53.Text = "linkLabel1";
            this.Manga_LB53.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Manga_LB53_LinkClicked);
            // 
            // Manga_LB45
            // 
            this.Manga_LB45.AutoSize = true;
            this.Manga_LB45.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Manga_LB45.ForeColor = System.Drawing.Color.Black;
            this.Manga_LB45.Location = new System.Drawing.Point(237, 236);
            this.Manga_LB45.Margin = new System.Windows.Forms.Padding(3);
            this.Manga_LB45.Name = "Manga_LB45";
            this.Manga_LB45.Size = new System.Drawing.Size(65, 13);
            this.Manga_LB45.TabIndex = 0;
            this.Manga_LB45.TabStop = true;
            this.Manga_LB45.Text = "linkLabel1";
            this.Manga_LB45.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Manga_LB45_LinkClicked);
            // 
            // Manga_LB52
            // 
            this.Manga_LB52.AutoSize = true;
            this.Manga_LB52.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Manga_LB52.ForeColor = System.Drawing.Color.Black;
            this.Manga_LB52.Location = new System.Drawing.Point(237, 255);
            this.Manga_LB52.Margin = new System.Windows.Forms.Padding(3);
            this.Manga_LB52.Name = "Manga_LB52";
            this.Manga_LB52.Size = new System.Drawing.Size(65, 13);
            this.Manga_LB52.TabIndex = 0;
            this.Manga_LB52.TabStop = true;
            this.Manga_LB52.Text = "linkLabel1";
            this.Manga_LB52.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Manga_LB52_LinkClicked);
            // 
            // Manga_LB13
            // 
            this.Manga_LB13.AutoSize = true;
            this.Manga_LB13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Manga_LB13.ForeColor = System.Drawing.Color.Black;
            this.Manga_LB13.Location = new System.Drawing.Point(237, 217);
            this.Manga_LB13.Margin = new System.Windows.Forms.Padding(3);
            this.Manga_LB13.Name = "Manga_LB13";
            this.Manga_LB13.Size = new System.Drawing.Size(65, 13);
            this.Manga_LB13.TabIndex = 0;
            this.Manga_LB13.TabStop = true;
            this.Manga_LB13.Text = "linkLabel1";
            this.Manga_LB13.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Manga_LB13_LinkClicked);
            // 
            // Manga_LB40
            // 
            this.Manga_LB40.AutoSize = true;
            this.Manga_LB40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Manga_LB40.ForeColor = System.Drawing.Color.Black;
            this.Manga_LB40.Location = new System.Drawing.Point(361, 160);
            this.Manga_LB40.Name = "Manga_LB40";
            this.Manga_LB40.Size = new System.Drawing.Size(35, 13);
            this.Manga_LB40.TabIndex = 0;
            this.Manga_LB40.Text = "label1";
            // 
            // Manga_LB10
            // 
            this.Manga_LB10.AutoSize = true;
            this.Manga_LB10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Manga_LB10.ForeColor = System.Drawing.Color.Black;
            this.Manga_LB10.Location = new System.Drawing.Point(361, 122);
            this.Manga_LB10.Name = "Manga_LB10";
            this.Manga_LB10.Size = new System.Drawing.Size(35, 13);
            this.Manga_LB10.TabIndex = 0;
            this.Manga_LB10.Text = "label1";
            // 
            // Manga_LB12
            // 
            this.Manga_LB12.AutoSize = true;
            this.Manga_LB12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Manga_LB12.ForeColor = System.Drawing.Color.Black;
            this.Manga_LB12.Location = new System.Drawing.Point(361, 46);
            this.Manga_LB12.Name = "Manga_LB12";
            this.Manga_LB12.Size = new System.Drawing.Size(35, 13);
            this.Manga_LB12.TabIndex = 0;
            this.Manga_LB12.Text = "label1";
            // 
            // Manga_LB38
            // 
            this.Manga_LB38.AutoSize = true;
            this.Manga_LB38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Manga_LB38.ForeColor = System.Drawing.Color.Black;
            this.Manga_LB38.Location = new System.Drawing.Point(361, 141);
            this.Manga_LB38.Name = "Manga_LB38";
            this.Manga_LB38.Size = new System.Drawing.Size(35, 13);
            this.Manga_LB38.TabIndex = 0;
            this.Manga_LB38.Text = "label1";
            // 
            // Manga_LB08
            // 
            this.Manga_LB08.AutoSize = true;
            this.Manga_LB08.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Manga_LB08.ForeColor = System.Drawing.Color.Black;
            this.Manga_LB08.Location = new System.Drawing.Point(361, 103);
            this.Manga_LB08.Name = "Manga_LB08";
            this.Manga_LB08.Size = new System.Drawing.Size(35, 13);
            this.Manga_LB08.TabIndex = 0;
            this.Manga_LB08.Text = "label1";
            // 
            // Manga_LB06
            // 
            this.Manga_LB06.AutoSize = true;
            this.Manga_LB06.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Manga_LB06.ForeColor = System.Drawing.Color.Black;
            this.Manga_LB06.Location = new System.Drawing.Point(361, 84);
            this.Manga_LB06.Name = "Manga_LB06";
            this.Manga_LB06.Size = new System.Drawing.Size(35, 13);
            this.Manga_LB06.TabIndex = 0;
            this.Manga_LB06.Text = "label1";
            // 
            // Manga_LB04
            // 
            this.Manga_LB04.AutoSize = true;
            this.Manga_LB04.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Manga_LB04.ForeColor = System.Drawing.Color.Black;
            this.Manga_LB04.Location = new System.Drawing.Point(361, 65);
            this.Manga_LB04.Name = "Manga_LB04";
            this.Manga_LB04.Size = new System.Drawing.Size(35, 13);
            this.Manga_LB04.TabIndex = 0;
            this.Manga_LB04.Text = "label1";
            // 
            // Manga_LB05
            // 
            this.Manga_LB05.AutoSize = true;
            this.Manga_LB05.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Manga_LB05.ForeColor = System.Drawing.Color.Black;
            this.Manga_LB05.Location = new System.Drawing.Point(237, 84);
            this.Manga_LB05.Margin = new System.Windows.Forms.Padding(3);
            this.Manga_LB05.Name = "Manga_LB05";
            this.Manga_LB05.Size = new System.Drawing.Size(46, 13);
            this.Manga_LB05.TabIndex = 0;
            this.Manga_LB05.Text = "Nadpis";
            // 
            // Manga_LB25
            // 
            this.Manga_LB25.AutoSize = true;
            this.Manga_LB25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Manga_LB25.ForeColor = System.Drawing.Color.Black;
            this.Manga_LB25.Location = new System.Drawing.Point(237, 293);
            this.Manga_LB25.Margin = new System.Windows.Forms.Padding(3);
            this.Manga_LB25.Name = "Manga_LB25";
            this.Manga_LB25.Size = new System.Drawing.Size(46, 13);
            this.Manga_LB25.TabIndex = 0;
            this.Manga_LB25.Text = "Nadpis";
            // 
            // Manga_LB39
            // 
            this.Manga_LB39.AutoSize = true;
            this.Manga_LB39.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Manga_LB39.ForeColor = System.Drawing.Color.Black;
            this.Manga_LB39.Location = new System.Drawing.Point(237, 160);
            this.Manga_LB39.Margin = new System.Windows.Forms.Padding(3);
            this.Manga_LB39.Name = "Manga_LB39";
            this.Manga_LB39.Size = new System.Drawing.Size(46, 13);
            this.Manga_LB39.TabIndex = 0;
            this.Manga_LB39.Text = "Nadpis";
            // 
            // Manga_LB15
            // 
            this.Manga_LB15.AutoSize = true;
            this.Manga_LB15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Manga_LB15.ForeColor = System.Drawing.Color.Black;
            this.Manga_LB15.Location = new System.Drawing.Point(237, 122);
            this.Manga_LB15.Margin = new System.Windows.Forms.Padding(3);
            this.Manga_LB15.Name = "Manga_LB15";
            this.Manga_LB15.Size = new System.Drawing.Size(46, 13);
            this.Manga_LB15.TabIndex = 0;
            this.Manga_LB15.Text = "Nadpis";
            // 
            // Manga_LB37
            // 
            this.Manga_LB37.AutoSize = true;
            this.Manga_LB37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Manga_LB37.ForeColor = System.Drawing.Color.Black;
            this.Manga_LB37.Location = new System.Drawing.Point(237, 141);
            this.Manga_LB37.Margin = new System.Windows.Forms.Padding(3);
            this.Manga_LB37.Name = "Manga_LB37";
            this.Manga_LB37.Size = new System.Drawing.Size(46, 13);
            this.Manga_LB37.TabIndex = 0;
            this.Manga_LB37.Text = "Nadpis";
            // 
            // Manga_LB07
            // 
            this.Manga_LB07.AutoSize = true;
            this.Manga_LB07.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Manga_LB07.ForeColor = System.Drawing.Color.Black;
            this.Manga_LB07.Location = new System.Drawing.Point(237, 103);
            this.Manga_LB07.Margin = new System.Windows.Forms.Padding(3);
            this.Manga_LB07.Name = "Manga_LB07";
            this.Manga_LB07.Size = new System.Drawing.Size(46, 13);
            this.Manga_LB07.TabIndex = 0;
            this.Manga_LB07.Text = "Nadpis";
            // 
            // Manga_LB01
            // 
            this.Manga_LB01.AutoSize = true;
            this.Manga_LB01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Manga_LB01.ForeColor = System.Drawing.Color.Black;
            this.Manga_LB01.Location = new System.Drawing.Point(237, 46);
            this.Manga_LB01.Margin = new System.Windows.Forms.Padding(3);
            this.Manga_LB01.Name = "Manga_LB01";
            this.Manga_LB01.Size = new System.Drawing.Size(46, 13);
            this.Manga_LB01.TabIndex = 0;
            this.Manga_LB01.Text = "Nadpis";
            // 
            // Manga_LB09
            // 
            this.Manga_LB09.AutoSize = true;
            this.Manga_LB09.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Manga_LB09.ForeColor = System.Drawing.Color.Black;
            this.Manga_LB09.Location = new System.Drawing.Point(237, 179);
            this.Manga_LB09.Margin = new System.Windows.Forms.Padding(3);
            this.Manga_LB09.Name = "Manga_LB09";
            this.Manga_LB09.Size = new System.Drawing.Size(46, 13);
            this.Manga_LB09.TabIndex = 0;
            this.Manga_LB09.Text = "Nadpis";
            // 
            // Manga_LB03
            // 
            this.Manga_LB03.AutoSize = true;
            this.Manga_LB03.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Manga_LB03.ForeColor = System.Drawing.Color.Black;
            this.Manga_LB03.Location = new System.Drawing.Point(237, 65);
            this.Manga_LB03.Margin = new System.Windows.Forms.Padding(3);
            this.Manga_LB03.Name = "Manga_LB03";
            this.Manga_LB03.Size = new System.Drawing.Size(46, 13);
            this.Manga_LB03.TabIndex = 0;
            this.Manga_LB03.Text = "Nadpis";
            // 
            // Manga_Data
            // 
            this.Manga_Data.AllowUserToAddRows = false;
            this.Manga_Data.AllowUserToDeleteRows = false;
            this.Manga_Data.AllowUserToResizeRows = false;
            this.Manga_Data.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Manga_Data.BackgroundColor = System.Drawing.Color.White;
            this.Manga_Data.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.Manga_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Manga_Data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Manga_Data_Mn01,
            this.Manga_Data_Mn02,
            this.Manga_Data_Mn03,
            this.Manga_Data_Mn10,
            this.Manga_Data_Mn04,
            this.Manga_Data_Mn05,
            this.Manga_Data_Mn08,
            this.Manga_Data_Mn09,
            this.Manga_Data_Mn06,
            this.Manga_Data_Mn07});
            this.Manga_Data.GridColor = System.Drawing.Color.White;
            this.Manga_Data.Location = new System.Drawing.Point(6, 327);
            this.Manga_Data.Name = "Manga_Data";
            this.Manga_Data.ReadOnly = true;
            this.Manga_Data.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Manga_Data.RowHeadersVisible = false;
            dataGridViewCellStyle28.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle28.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.Color.Black;
            this.Manga_Data.RowsDefaultCellStyle = dataGridViewCellStyle28;
            this.Manga_Data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Manga_Data.Size = new System.Drawing.Size(824, 309);
            this.Manga_Data.TabIndex = 0;
            this.Manga_Data.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Manga_Data_MouseClick);
            this.Manga_Data.MouseEnter += new System.EventHandler(this.Manga_Data_MouseEnter);
            // 
            // Manga_Data_Mn01
            // 
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Manga_Data_Mn01.DefaultCellStyle = dataGridViewCellStyle25;
            this.Manga_Data_Mn01.HeaderText = "";
            this.Manga_Data_Mn01.Name = "Manga_Data_Mn01";
            this.Manga_Data_Mn01.ReadOnly = true;
            this.Manga_Data_Mn01.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Manga_Data_Mn01.Visible = false;
            // 
            // Manga_Data_Mn02
            // 
            this.Manga_Data_Mn02.HeaderText = "";
            this.Manga_Data_Mn02.Name = "Manga_Data_Mn02";
            this.Manga_Data_Mn02.ReadOnly = true;
            this.Manga_Data_Mn02.Width = 20;
            // 
            // Manga_Data_Mn03
            // 
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Manga_Data_Mn03.DefaultCellStyle = dataGridViewCellStyle26;
            this.Manga_Data_Mn03.HeaderText = "";
            this.Manga_Data_Mn03.Name = "Manga_Data_Mn03";
            this.Manga_Data_Mn03.ReadOnly = true;
            this.Manga_Data_Mn03.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Manga_Data_Mn03.Width = 50;
            // 
            // Manga_Data_Mn10
            // 
            this.Manga_Data_Mn10.HeaderText = "";
            this.Manga_Data_Mn10.Name = "Manga_Data_Mn10";
            this.Manga_Data_Mn10.ReadOnly = true;
            this.Manga_Data_Mn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Manga_Data_Mn10.Width = 50;
            // 
            // Manga_Data_Mn04
            // 
            this.Manga_Data_Mn04.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Manga_Data_Mn04.DefaultCellStyle = dataGridViewCellStyle27;
            this.Manga_Data_Mn04.HeaderText = "";
            this.Manga_Data_Mn04.Name = "Manga_Data_Mn04";
            this.Manga_Data_Mn04.ReadOnly = true;
            this.Manga_Data_Mn04.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Manga_Data_Mn05
            // 
            this.Manga_Data_Mn05.HeaderText = "";
            this.Manga_Data_Mn05.Name = "Manga_Data_Mn05";
            this.Manga_Data_Mn05.ReadOnly = true;
            this.Manga_Data_Mn05.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Manga_Data_Mn08
            // 
            this.Manga_Data_Mn08.HeaderText = "";
            this.Manga_Data_Mn08.Name = "Manga_Data_Mn08";
            this.Manga_Data_Mn08.ReadOnly = true;
            this.Manga_Data_Mn08.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Manga_Data_Mn09
            // 
            this.Manga_Data_Mn09.HeaderText = "";
            this.Manga_Data_Mn09.Name = "Manga_Data_Mn09";
            this.Manga_Data_Mn09.ReadOnly = true;
            this.Manga_Data_Mn09.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Manga_Data_Mn06
            // 
            this.Manga_Data_Mn06.HeaderText = "";
            this.Manga_Data_Mn06.Name = "Manga_Data_Mn06";
            this.Manga_Data_Mn06.ReadOnly = true;
            this.Manga_Data_Mn06.Width = 30;
            // 
            // Manga_Data_Mn07
            // 
            this.Manga_Data_Mn07.HeaderText = "";
            this.Manga_Data_Mn07.Name = "Manga_Data_Mn07";
            this.Manga_Data_Mn07.ReadOnly = true;
            this.Manga_Data_Mn07.Width = 30;
            // 
            // Manga_Tree
            // 
            this.Manga_Tree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Manga_Tree.BackColor = System.Drawing.Color.White;
            this.Manga_Tree.ContextMenuStrip = this.Manga_Tree_Menu;
            this.Manga_Tree.ForeColor = System.Drawing.Color.Black;
            this.Manga_Tree.Location = new System.Drawing.Point(3, 230);
            this.Manga_Tree.Name = "Manga_Tree";
            this.Manga_Tree.ShowRootLines = false;
            this.Manga_Tree.Size = new System.Drawing.Size(248, 415);
            this.Manga_Tree.TabIndex = 0;
            this.Manga_Tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.Manga_Tree_AfterSelect);
            this.Manga_Tree.MouseEnter += new System.EventHandler(this.Manga_Tree_MouseEnter);
            // 
            // Manga_Tree_Menu
            // 
            this.Manga_Tree_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Manga_Tree_Menu_Mn01});
            this.Manga_Tree_Menu.Name = "Manga_Tree_Menu";
            this.Manga_Tree_Menu.Size = new System.Drawing.Size(81, 26);
            // 
            // Manga_Tree_Menu_Mn01
            // 
            this.Manga_Tree_Menu_Mn01.Name = "Manga_Tree_Menu_Mn01";
            this.Manga_Tree_Menu_Mn01.Size = new System.Drawing.Size(80, 22);
            this.Manga_Tree_Menu_Mn01.Text = "1";
            this.Manga_Tree_Menu_Mn01.Click += new System.EventHandler(this.Manga_Tree_Menu_Mn01_Click);
            // 
            // MainTabManga_Mn02
            // 
            this.MainTabManga_Mn02.BackColor = System.Drawing.Color.White;
            this.MainTabManga_Mn02.Controls.Add(this.Manga_Gr03);
            this.MainTabManga_Mn02.Controls.Add(this.Manga_Gr02);
            this.MainTabManga_Mn02.Location = new System.Drawing.Point(4, 22);
            this.MainTabManga_Mn02.Name = "MainTabManga_Mn02";
            this.MainTabManga_Mn02.Padding = new System.Windows.Forms.Padding(3);
            this.MainTabManga_Mn02.Size = new System.Drawing.Size(1096, 648);
            this.MainTabManga_Mn02.TabIndex = 0;
            this.MainTabManga_Mn02.Text = "2";
            this.MainTabManga_Mn02.UseVisualStyleBackColor = true;
            // 
            // Manga_Gr03
            // 
            this.Manga_Gr03.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Manga_Gr03.Controls.Add(this.Manga_EditCh);
            this.Manga_Gr03.Controls.Add(this.Manga_Tx20);
            this.Manga_Gr03.Controls.Add(this.Manga_ChaptersDT);
            this.Manga_Gr03.Controls.Add(this.Manga_Tx21);
            this.Manga_Gr03.Controls.Add(this.Manga_Tx19);
            this.Manga_Gr03.Controls.Add(this.Manga_Tx12);
            this.Manga_Gr03.Controls.Add(this.Manga_LB41);
            this.Manga_Gr03.Controls.Add(this.Manga_Obr_CHD);
            this.Manga_Gr03.Controls.Add(this.Manga_Insert_CHD);
            this.Manga_Gr03.Controls.Add(this.Manga_LB42);
            this.Manga_Gr03.Controls.Add(this.Manga_LB43);
            this.Manga_Gr03.Location = new System.Drawing.Point(885, 6);
            this.Manga_Gr03.Name = "Manga_Gr03";
            this.Manga_Gr03.Size = new System.Drawing.Size(205, 329);
            this.Manga_Gr03.TabIndex = 0;
            this.Manga_Gr03.TabStop = false;
            this.Manga_Gr03.Text = "groupBox2";
            this.Manga_Gr03.Visible = false;
            // 
            // Manga_Tx20
            // 
            this.Manga_Tx20.Location = new System.Drawing.Point(618, 19);
            this.Manga_Tx20.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Manga_Tx20.Name = "Manga_Tx20";
            this.Manga_Tx20.Size = new System.Drawing.Size(150, 20);
            this.Manga_Tx20.TabIndex = 0;
            // 
            // Manga_ChaptersDT
            // 
            this.Manga_ChaptersDT.AllowUserToAddRows = false;
            this.Manga_ChaptersDT.AllowUserToDeleteRows = false;
            this.Manga_ChaptersDT.AllowUserToResizeColumns = false;
            this.Manga_ChaptersDT.AllowUserToResizeRows = false;
            this.Manga_ChaptersDT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Manga_ChaptersDT.BackgroundColor = System.Drawing.Color.White;
            this.Manga_ChaptersDT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Manga_ChaptersDT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Manga_ChaptersCM01,
            this.Manga_ChaptersCM02,
            this.Manga_ChaptersCM03,
            this.Manga_ChaptersCM04,
            this.Manga_ChaptersCM05,
            this.Manga_ChaptersCM06});
            this.Manga_ChaptersDT.GridColor = System.Drawing.Color.White;
            this.Manga_ChaptersDT.Location = new System.Drawing.Point(9, 64);
            this.Manga_ChaptersDT.Name = "Manga_ChaptersDT";
            this.Manga_ChaptersDT.RowHeadersVisible = false;
            this.Manga_ChaptersDT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Manga_ChaptersDT.ShowCellErrors = false;
            this.Manga_ChaptersDT.ShowCellToolTips = false;
            this.Manga_ChaptersDT.ShowEditingIcon = false;
            this.Manga_ChaptersDT.ShowRowErrors = false;
            this.Manga_ChaptersDT.Size = new System.Drawing.Size(184, 259);
            this.Manga_ChaptersDT.TabIndex = 0;
            this.Manga_ChaptersDT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Manga_ChaptersDT_KeyDown);
            this.Manga_ChaptersDT.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Manga_ChaptersDT_MouseClick);
            // 
            // Manga_ChaptersCM01
            // 
            this.Manga_ChaptersCM01.FillWeight = 50F;
            this.Manga_ChaptersCM01.HeaderText = "";
            this.Manga_ChaptersCM01.MinimumWidth = 50;
            this.Manga_ChaptersCM01.Name = "Manga_ChaptersCM01";
            this.Manga_ChaptersCM01.Width = 50;
            // 
            // Manga_ChaptersCM02
            // 
            this.Manga_ChaptersCM02.FillWeight = 50F;
            this.Manga_ChaptersCM02.HeaderText = "";
            this.Manga_ChaptersCM02.MinimumWidth = 50;
            this.Manga_ChaptersCM02.Name = "Manga_ChaptersCM02";
            this.Manga_ChaptersCM02.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Manga_ChaptersCM02.Width = 50;
            // 
            // Manga_ChaptersCM03
            // 
            this.Manga_ChaptersCM03.FillWeight = 50F;
            this.Manga_ChaptersCM03.HeaderText = "";
            this.Manga_ChaptersCM03.MinimumWidth = 50;
            this.Manga_ChaptersCM03.Name = "Manga_ChaptersCM03";
            this.Manga_ChaptersCM03.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Manga_ChaptersCM03.Width = 50;
            // 
            // Manga_ChaptersCM04
            // 
            this.Manga_ChaptersCM04.FillWeight = 50F;
            this.Manga_ChaptersCM04.HeaderText = "";
            this.Manga_ChaptersCM04.MinimumWidth = 50;
            this.Manga_ChaptersCM04.Name = "Manga_ChaptersCM04";
            this.Manga_ChaptersCM04.Width = 50;
            // 
            // Manga_ChaptersCM05
            // 
            this.Manga_ChaptersCM05.FillWeight = 250F;
            this.Manga_ChaptersCM05.HeaderText = "";
            this.Manga_ChaptersCM05.MinimumWidth = 250;
            this.Manga_ChaptersCM05.Name = "Manga_ChaptersCM05";
            this.Manga_ChaptersCM05.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Manga_ChaptersCM05.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Manga_ChaptersCM05.Width = 250;
            // 
            // Manga_ChaptersCM06
            // 
            this.Manga_ChaptersCM06.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Manga_ChaptersCM06.HeaderText = "";
            this.Manga_ChaptersCM06.Name = "Manga_ChaptersCM06";
            this.Manga_ChaptersCM06.ReadOnly = true;
            this.Manga_ChaptersCM06.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Manga_Tx21
            // 
            this.Manga_Tx21.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Manga_Tx21.ForeColor = System.Drawing.Color.Black;
            this.Manga_Tx21.FormattingEnabled = true;
            this.Manga_Tx21.Items.AddRange(new object[] {
            "japanese",
            "english",
            "czech"});
            this.Manga_Tx21.Location = new System.Drawing.Point(374, 19);
            this.Manga_Tx21.Name = "Manga_Tx21";
            this.Manga_Tx21.Size = new System.Drawing.Size(150, 21);
            this.Manga_Tx21.TabIndex = 0;
            // 
            // Manga_Tx19
            // 
            this.Manga_Tx19.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Manga_Tx19.ForeColor = System.Drawing.Color.Black;
            this.Manga_Tx19.Location = new System.Drawing.Point(107, 19);
            this.Manga_Tx19.Name = "Manga_Tx19";
            this.Manga_Tx19.ReadOnly = true;
            this.Manga_Tx19.Size = new System.Drawing.Size(150, 20);
            this.Manga_Tx19.TabIndex = 0;
            // 
            // Manga_Tx12
            // 
            this.Manga_Tx12.BackColor = System.Drawing.Color.White;
            this.Manga_Tx12.ForeColor = System.Drawing.Color.Black;
            this.Manga_Tx12.Location = new System.Drawing.Point(997, 23);
            this.Manga_Tx12.Name = "Manga_Tx12";
            this.Manga_Tx12.Size = new System.Drawing.Size(75, 20);
            this.Manga_Tx12.TabIndex = 0;
            this.Manga_Tx12.Text = "0";
            this.Manga_Tx12.Visible = false;
            // 
            // Manga_LB41
            // 
            this.Manga_LB41.AutoSize = true;
            this.Manga_LB41.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Manga_LB41.ForeColor = System.Drawing.Color.Black;
            this.Manga_LB41.Location = new System.Drawing.Point(13, 22);
            this.Manga_LB41.Name = "Manga_LB41";
            this.Manga_LB41.Size = new System.Drawing.Size(48, 13);
            this.Manga_LB41.TabIndex = 0;
            this.Manga_LB41.Text = "label13";
            // 
            // Manga_LB42
            // 
            this.Manga_LB42.AutoSize = true;
            this.Manga_LB42.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Manga_LB42.ForeColor = System.Drawing.Color.Black;
            this.Manga_LB42.Location = new System.Drawing.Point(292, 22);
            this.Manga_LB42.Name = "Manga_LB42";
            this.Manga_LB42.Size = new System.Drawing.Size(48, 13);
            this.Manga_LB42.TabIndex = 0;
            this.Manga_LB42.Text = "label13";
            // 
            // Manga_LB43
            // 
            this.Manga_LB43.AutoSize = true;
            this.Manga_LB43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Manga_LB43.ForeColor = System.Drawing.Color.Black;
            this.Manga_LB43.Location = new System.Drawing.Point(530, 23);
            this.Manga_LB43.Name = "Manga_LB43";
            this.Manga_LB43.Size = new System.Drawing.Size(48, 13);
            this.Manga_LB43.TabIndex = 0;
            this.Manga_LB43.Text = "label13";
            // 
            // Manga_Gr02
            // 
            this.Manga_Gr02.Controls.Add(this.Manga_LB48);
            this.Manga_Gr02.Controls.Add(this.Manga_LB47);
            this.Manga_Gr02.Controls.Add(this.Manga_LB49);
            this.Manga_Gr02.Controls.Add(this.Manga_LB46);
            this.Manga_Gr02.Controls.Add(this.Manga_Tx07);
            this.Manga_Gr02.Controls.Add(this.Manga_Tx04);
            this.Manga_Gr02.Controls.Add(this.Manga_CH01);
            this.Manga_Gr02.Controls.Add(this.Manga_Manga);
            this.Manga_Gr02.Controls.Add(this.Manga_Anime);
            this.Manga_Gr02.Controls.Add(this.Manga_Genres);
            this.Manga_Gr02.Controls.Add(this.Manga_Delete);
            this.Manga_Gr02.Controls.Add(this.Manga_LB24);
            this.Manga_Gr02.Controls.Add(this.Manga_LB44);
            this.Manga_Gr02.Controls.Add(this.Manga_LB36);
            this.Manga_Gr02.Controls.Add(this.Manga_Update);
            this.Manga_Gr02.Controls.Add(this.Manga_LB22);
            this.Manga_Gr02.Controls.Add(this.Manga_LB23);
            this.Manga_Gr02.Controls.Add(this.Manga_Insert);
            this.Manga_Gr02.Controls.Add(this.Manga_LB35);
            this.Manga_Gr02.Controls.Add(this.Manga_LB51);
            this.Manga_Gr02.Controls.Add(this.Manga_LB21);
            this.Manga_Gr02.Controls.Add(this.Manga_Download_MAL);
            this.Manga_Gr02.Controls.Add(this.Manga_Download_MU);
            this.Manga_Gr02.Controls.Add(this.Manga_Download_MugiMugi);
            this.Manga_Gr02.Controls.Add(this.Manga_Download);
            this.Manga_Gr02.Controls.Add(this.Manga_Obr);
            this.Manga_Gr02.Controls.Add(this.Manga_LB50);
            this.Manga_Gr02.Controls.Add(this.Manga_LB20);
            this.Manga_Gr02.Controls.Add(this.Manga_LB19);
            this.Manga_Gr02.Controls.Add(this.Manga_LB18);
            this.Manga_Gr02.Controls.Add(this.Manga_LB17);
            this.Manga_Gr02.Controls.Add(this.Manga_LB16);
            this.Manga_Gr02.Controls.Add(this.Manga_Tx22);
            this.Manga_Gr02.Controls.Add(this.Manga_Tx18);
            this.Manga_Gr02.Controls.Add(this.Manga_Tx17);
            this.Manga_Gr02.Controls.Add(this.Manga_Tx24);
            this.Manga_Gr02.Controls.Add(this.Manga_Tx06);
            this.Manga_Gr02.Controls.Add(this.Manga_Tx23);
            this.Manga_Gr02.Controls.Add(this.Manga_Tx05);
            this.Manga_Gr02.Controls.Add(this.Manga_Tx03);
            this.Manga_Gr02.Controls.Add(this.Manga_Tx02);
            this.Manga_Gr02.Controls.Add(this.Manga_Tx08);
            this.Manga_Gr02.Controls.Add(this.Manga_Tx00);
            this.Manga_Gr02.Controls.Add(this.Manga_Tx01);
            this.Manga_Gr02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Manga_Gr02.ForeColor = System.Drawing.Color.Black;
            this.Manga_Gr02.Location = new System.Drawing.Point(3, 3);
            this.Manga_Gr02.Name = "Manga_Gr02";
            this.Manga_Gr02.Size = new System.Drawing.Size(1090, 642);
            this.Manga_Gr02.TabIndex = 0;
            this.Manga_Gr02.TabStop = false;
            this.Manga_Gr02.Text = "groupBox1";
            // 
            // Manga_LB48
            // 
            this.Manga_LB48.AutoSize = true;
            this.Manga_LB48.Location = new System.Drawing.Point(497, 178);
            this.Manga_LB48.Name = "Manga_LB48";
            this.Manga_LB48.Size = new System.Drawing.Size(175, 13);
            this.Manga_LB48.TabIndex = 1;
            this.Manga_LB48.Text = "http://myanimelist.net/manga/{ID}/";
            // 
            // Manga_LB47
            // 
            this.Manga_LB47.AutoSize = true;
            this.Manga_LB47.Location = new System.Drawing.Point(497, 126);
            this.Manga_LB47.Name = "Manga_LB47";
            this.Manga_LB47.Size = new System.Drawing.Size(251, 13);
            this.Manga_LB47.TabIndex = 1;
            this.Manga_LB47.Text = "http://www.mangaupdates.com/series.html?id={ID}";
            // 
            // Manga_LB49
            // 
            this.Manga_LB49.AutoSize = true;
            this.Manga_LB49.Location = new System.Drawing.Point(497, 204);
            this.Manga_LB49.Name = "Manga_LB49";
            this.Manga_LB49.Size = new System.Drawing.Size(202, 13);
            this.Manga_LB49.TabIndex = 1;
            this.Manga_LB49.Text = "http://doujinshi.mugimugi.org/book/{ID}/";
            // 
            // Manga_LB46
            // 
            this.Manga_LB46.AutoSize = true;
            this.Manga_LB46.Location = new System.Drawing.Point(497, 152);
            this.Manga_LB46.Name = "Manga_LB46";
            this.Manga_LB46.Size = new System.Drawing.Size(245, 13);
            this.Manga_LB46.TabIndex = 1;
            this.Manga_LB46.Text = "http://www.mangatraders.com/manga/series/{ID}";
            // 
            // Manga_Tx07
            // 
            this.Manga_Tx07.Location = new System.Drawing.Point(214, 226);
            this.Manga_Tx07.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.Manga_Tx07.Name = "Manga_Tx07";
            this.Manga_Tx07.Size = new System.Drawing.Size(248, 20);
            this.Manga_Tx07.TabIndex = 0;
            // 
            // Manga_Tx04
            // 
            this.Manga_Tx04.Location = new System.Drawing.Point(214, 97);
            this.Manga_Tx04.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.Manga_Tx04.Name = "Manga_Tx04";
            this.Manga_Tx04.Size = new System.Drawing.Size(248, 20);
            this.Manga_Tx04.TabIndex = 0;
            // 
            // Manga_CH01
            // 
            this.Manga_CH01.AutoSize = true;
            this.Manga_CH01.ForeColor = System.Drawing.Color.Black;
            this.Manga_CH01.Location = new System.Drawing.Point(468, 48);
            this.Manga_CH01.Name = "Manga_CH01";
            this.Manga_CH01.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Manga_CH01.Size = new System.Drawing.Size(15, 14);
            this.Manga_CH01.TabIndex = 0;
            this.Manga_CH01.UseVisualStyleBackColor = true;
            // 
            // Manga_Manga
            // 
            this.Manga_Manga.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Manga_Manga.BackColor = System.Drawing.Color.White;
            this.Manga_Manga.ColumnWidth = 200;
            this.Manga_Manga.ForeColor = System.Drawing.Color.Black;
            this.Manga_Manga.FormattingEnabled = true;
            this.Manga_Manga.Location = new System.Drawing.Point(316, 369);
            this.Manga_Manga.MultiColumn = true;
            this.Manga_Manga.Name = "Manga_Manga";
            this.Manga_Manga.Size = new System.Drawing.Size(331, 259);
            this.Manga_Manga.Sorted = true;
            this.Manga_Manga.TabIndex = 0;
            // 
            // Manga_Anime
            // 
            this.Manga_Anime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Manga_Anime.BackColor = System.Drawing.Color.White;
            this.Manga_Anime.ColumnWidth = 200;
            this.Manga_Anime.ForeColor = System.Drawing.Color.Black;
            this.Manga_Anime.FormattingEnabled = true;
            this.Manga_Anime.Location = new System.Drawing.Point(6, 369);
            this.Manga_Anime.MultiColumn = true;
            this.Manga_Anime.Name = "Manga_Anime";
            this.Manga_Anime.Size = new System.Drawing.Size(276, 259);
            this.Manga_Anime.Sorted = true;
            this.Manga_Anime.TabIndex = 0;
            // 
            // Manga_Genres
            // 
            this.Manga_Genres.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Manga_Genres.BackColor = System.Drawing.Color.White;
            this.Manga_Genres.ColumnWidth = 200;
            this.Manga_Genres.ForeColor = System.Drawing.Color.Black;
            this.Manga_Genres.FormattingEnabled = true;
            this.Manga_Genres.Location = new System.Drawing.Point(692, 369);
            this.Manga_Genres.MultiColumn = true;
            this.Manga_Genres.Name = "Manga_Genres";
            this.Manga_Genres.Size = new System.Drawing.Size(315, 259);
            this.Manga_Genres.Sorted = true;
            this.Manga_Genres.TabIndex = 0;
            // 
            // Manga_LB24
            // 
            this.Manga_LB24.AutoSize = true;
            this.Manga_LB24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Manga_LB24.ForeColor = System.Drawing.Color.Black;
            this.Manga_LB24.Location = new System.Drawing.Point(489, 48);
            this.Manga_LB24.Name = "Manga_LB24";
            this.Manga_LB24.Size = new System.Drawing.Size(48, 13);
            this.Manga_LB24.TabIndex = 0;
            this.Manga_LB24.Text = "label13";
            // 
            // Manga_LB44
            // 
            this.Manga_LB44.AutoSize = true;
            this.Manga_LB44.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Manga_LB44.ForeColor = System.Drawing.Color.Black;
            this.Manga_LB44.Location = new System.Drawing.Point(6, 307);
            this.Manga_LB44.Name = "Manga_LB44";
            this.Manga_LB44.Size = new System.Drawing.Size(48, 13);
            this.Manga_LB44.TabIndex = 0;
            this.Manga_LB44.Text = "label13";
            // 
            // Manga_LB36
            // 
            this.Manga_LB36.AutoSize = true;
            this.Manga_LB36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Manga_LB36.ForeColor = System.Drawing.Color.Black;
            this.Manga_LB36.Location = new System.Drawing.Point(6, 281);
            this.Manga_LB36.Name = "Manga_LB36";
            this.Manga_LB36.Size = new System.Drawing.Size(48, 13);
            this.Manga_LB36.TabIndex = 0;
            this.Manga_LB36.Text = "label13";
            // 
            // Manga_LB22
            // 
            this.Manga_LB22.AutoSize = true;
            this.Manga_LB22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Manga_LB22.ForeColor = System.Drawing.Color.Black;
            this.Manga_LB22.Location = new System.Drawing.Point(6, 229);
            this.Manga_LB22.Name = "Manga_LB22";
            this.Manga_LB22.Size = new System.Drawing.Size(48, 13);
            this.Manga_LB22.TabIndex = 0;
            this.Manga_LB22.Text = "label13";
            // 
            // Manga_LB23
            // 
            this.Manga_LB23.AutoSize = true;
            this.Manga_LB23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Manga_LB23.ForeColor = System.Drawing.Color.Black;
            this.Manga_LB23.Location = new System.Drawing.Point(6, 333);
            this.Manga_LB23.Name = "Manga_LB23";
            this.Manga_LB23.Size = new System.Drawing.Size(48, 13);
            this.Manga_LB23.TabIndex = 0;
            this.Manga_LB23.Text = "label13";
            // 
            // Manga_LB35
            // 
            this.Manga_LB35.AutoSize = true;
            this.Manga_LB35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Manga_LB35.ForeColor = System.Drawing.Color.Black;
            this.Manga_LB35.Location = new System.Drawing.Point(6, 255);
            this.Manga_LB35.Name = "Manga_LB35";
            this.Manga_LB35.Size = new System.Drawing.Size(48, 13);
            this.Manga_LB35.TabIndex = 0;
            this.Manga_LB35.Text = "label13";
            // 
            // Manga_LB51
            // 
            this.Manga_LB51.AutoSize = true;
            this.Manga_LB51.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Manga_LB51.ForeColor = System.Drawing.Color.Black;
            this.Manga_LB51.Location = new System.Drawing.Point(6, 204);
            this.Manga_LB51.Name = "Manga_LB51";
            this.Manga_LB51.Size = new System.Drawing.Size(48, 13);
            this.Manga_LB51.TabIndex = 0;
            this.Manga_LB51.Text = "label13";
            // 
            // Manga_LB21
            // 
            this.Manga_LB21.AutoSize = true;
            this.Manga_LB21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Manga_LB21.ForeColor = System.Drawing.Color.Black;
            this.Manga_LB21.Location = new System.Drawing.Point(6, 152);
            this.Manga_LB21.Name = "Manga_LB21";
            this.Manga_LB21.Size = new System.Drawing.Size(48, 13);
            this.Manga_LB21.TabIndex = 0;
            this.Manga_LB21.Text = "label13";
            // 
            // Manga_LB50
            // 
            this.Manga_LB50.AutoSize = true;
            this.Manga_LB50.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Manga_LB50.ForeColor = System.Drawing.Color.Black;
            this.Manga_LB50.Location = new System.Drawing.Point(6, 178);
            this.Manga_LB50.Name = "Manga_LB50";
            this.Manga_LB50.Size = new System.Drawing.Size(48, 13);
            this.Manga_LB50.TabIndex = 0;
            this.Manga_LB50.Text = "label13";
            // 
            // Manga_LB20
            // 
            this.Manga_LB20.AutoSize = true;
            this.Manga_LB20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Manga_LB20.ForeColor = System.Drawing.Color.Black;
            this.Manga_LB20.Location = new System.Drawing.Point(6, 126);
            this.Manga_LB20.Name = "Manga_LB20";
            this.Manga_LB20.Size = new System.Drawing.Size(48, 13);
            this.Manga_LB20.TabIndex = 0;
            this.Manga_LB20.Text = "label13";
            // 
            // Manga_LB19
            // 
            this.Manga_LB19.AutoSize = true;
            this.Manga_LB19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Manga_LB19.ForeColor = System.Drawing.Color.Black;
            this.Manga_LB19.Location = new System.Drawing.Point(6, 100);
            this.Manga_LB19.Name = "Manga_LB19";
            this.Manga_LB19.Size = new System.Drawing.Size(48, 13);
            this.Manga_LB19.TabIndex = 0;
            this.Manga_LB19.Text = "label13";
            // 
            // Manga_LB18
            // 
            this.Manga_LB18.AutoSize = true;
            this.Manga_LB18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Manga_LB18.ForeColor = System.Drawing.Color.Black;
            this.Manga_LB18.Location = new System.Drawing.Point(6, 74);
            this.Manga_LB18.Name = "Manga_LB18";
            this.Manga_LB18.Size = new System.Drawing.Size(48, 13);
            this.Manga_LB18.TabIndex = 0;
            this.Manga_LB18.Text = "label13";
            // 
            // Manga_LB17
            // 
            this.Manga_LB17.AutoSize = true;
            this.Manga_LB17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Manga_LB17.ForeColor = System.Drawing.Color.Black;
            this.Manga_LB17.Location = new System.Drawing.Point(6, 48);
            this.Manga_LB17.Name = "Manga_LB17";
            this.Manga_LB17.Size = new System.Drawing.Size(48, 13);
            this.Manga_LB17.TabIndex = 0;
            this.Manga_LB17.Text = "label13";
            // 
            // Manga_LB16
            // 
            this.Manga_LB16.AutoSize = true;
            this.Manga_LB16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Manga_LB16.ForeColor = System.Drawing.Color.Black;
            this.Manga_LB16.Location = new System.Drawing.Point(6, 22);
            this.Manga_LB16.Name = "Manga_LB16";
            this.Manga_LB16.Size = new System.Drawing.Size(48, 13);
            this.Manga_LB16.TabIndex = 0;
            this.Manga_LB16.Text = "label13";
            // 
            // Manga_Tx22
            // 
            this.Manga_Tx22.BackColor = System.Drawing.Color.White;
            this.Manga_Tx22.ForeColor = System.Drawing.Color.Black;
            this.Manga_Tx22.Location = new System.Drawing.Point(214, 304);
            this.Manga_Tx22.Name = "Manga_Tx22";
            this.Manga_Tx22.Size = new System.Drawing.Size(248, 20);
            this.Manga_Tx22.TabIndex = 0;
            // 
            // Manga_Tx18
            // 
            this.Manga_Tx18.BackColor = System.Drawing.Color.White;
            this.Manga_Tx18.ForeColor = System.Drawing.Color.Black;
            this.Manga_Tx18.Location = new System.Drawing.Point(214, 278);
            this.Manga_Tx18.Name = "Manga_Tx18";
            this.Manga_Tx18.Size = new System.Drawing.Size(248, 20);
            this.Manga_Tx18.TabIndex = 0;
            // 
            // Manga_Tx17
            // 
            this.Manga_Tx17.BackColor = System.Drawing.Color.White;
            this.Manga_Tx17.ForeColor = System.Drawing.Color.Black;
            this.Manga_Tx17.Location = new System.Drawing.Point(214, 252);
            this.Manga_Tx17.Name = "Manga_Tx17";
            this.Manga_Tx17.Size = new System.Drawing.Size(248, 20);
            this.Manga_Tx17.TabIndex = 0;
            // 
            // Manga_Tx24
            // 
            this.Manga_Tx24.BackColor = System.Drawing.Color.White;
            this.Manga_Tx24.ForeColor = System.Drawing.Color.Black;
            this.Manga_Tx24.Location = new System.Drawing.Point(214, 201);
            this.Manga_Tx24.Name = "Manga_Tx24";
            this.Manga_Tx24.Size = new System.Drawing.Size(248, 20);
            this.Manga_Tx24.TabIndex = 0;
            this.Manga_Tx24.TextChanged += new System.EventHandler(this.Manga_Tx24_TextChanged);
            this.Manga_Tx24.Enter += new System.EventHandler(this.Manga_Tx24_Enter);
            // 
            // Manga_Tx06
            // 
            this.Manga_Tx06.BackColor = System.Drawing.Color.White;
            this.Manga_Tx06.ForeColor = System.Drawing.Color.Black;
            this.Manga_Tx06.Location = new System.Drawing.Point(214, 149);
            this.Manga_Tx06.Name = "Manga_Tx06";
            this.Manga_Tx06.Size = new System.Drawing.Size(248, 20);
            this.Manga_Tx06.TabIndex = 0;
            this.Manga_Tx06.TextChanged += new System.EventHandler(this.Manga_Tx06_TextChanged);
            this.Manga_Tx06.Enter += new System.EventHandler(this.Manga_Tx06_Enter);
            // 
            // Manga_Tx23
            // 
            this.Manga_Tx23.BackColor = System.Drawing.Color.White;
            this.Manga_Tx23.ForeColor = System.Drawing.Color.Black;
            this.Manga_Tx23.Location = new System.Drawing.Point(214, 175);
            this.Manga_Tx23.Name = "Manga_Tx23";
            this.Manga_Tx23.Size = new System.Drawing.Size(248, 20);
            this.Manga_Tx23.TabIndex = 0;
            this.Manga_Tx23.TextChanged += new System.EventHandler(this.Manga_Tx23_TextChanged);
            this.Manga_Tx23.Enter += new System.EventHandler(this.Manga_Tx23_Enter);
            // 
            // Manga_Tx05
            // 
            this.Manga_Tx05.BackColor = System.Drawing.Color.White;
            this.Manga_Tx05.ForeColor = System.Drawing.Color.Black;
            this.Manga_Tx05.Location = new System.Drawing.Point(214, 123);
            this.Manga_Tx05.Name = "Manga_Tx05";
            this.Manga_Tx05.Size = new System.Drawing.Size(248, 20);
            this.Manga_Tx05.TabIndex = 0;
            this.Manga_Tx05.TextChanged += new System.EventHandler(this.Manga_Tx05_TextChanged);
            this.Manga_Tx05.Enter += new System.EventHandler(this.Manga_Tx05_Enter);
            // 
            // Manga_Tx03
            // 
            this.Manga_Tx03.BackColor = System.Drawing.Color.White;
            this.Manga_Tx03.ForeColor = System.Drawing.Color.Black;
            this.Manga_Tx03.Location = new System.Drawing.Point(214, 71);
            this.Manga_Tx03.Name = "Manga_Tx03";
            this.Manga_Tx03.Size = new System.Drawing.Size(248, 20);
            this.Manga_Tx03.TabIndex = 0;
            // 
            // Manga_Tx02
            // 
            this.Manga_Tx02.BackColor = System.Drawing.Color.White;
            this.Manga_Tx02.ForeColor = System.Drawing.Color.Black;
            this.Manga_Tx02.Location = new System.Drawing.Point(214, 45);
            this.Manga_Tx02.Name = "Manga_Tx02";
            this.Manga_Tx02.Size = new System.Drawing.Size(248, 20);
            this.Manga_Tx02.TabIndex = 0;
            // 
            // Manga_Tx08
            // 
            this.Manga_Tx08.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Manga_Tx08.ForeColor = System.Drawing.Color.Black;
            this.Manga_Tx08.Location = new System.Drawing.Point(214, 330);
            this.Manga_Tx08.Name = "Manga_Tx08";
            this.Manga_Tx08.ReadOnly = true;
            this.Manga_Tx08.Size = new System.Drawing.Size(248, 20);
            this.Manga_Tx08.TabIndex = 0;
            // 
            // Manga_Tx00
            // 
            this.Manga_Tx00.BackColor = System.Drawing.Color.White;
            this.Manga_Tx00.ForeColor = System.Drawing.Color.Black;
            this.Manga_Tx00.Location = new System.Drawing.Point(468, 19);
            this.Manga_Tx00.Name = "Manga_Tx00";
            this.Manga_Tx00.Size = new System.Drawing.Size(75, 20);
            this.Manga_Tx00.TabIndex = 0;
            this.Manga_Tx00.Text = "0";
            this.Manga_Tx00.Visible = false;
            // 
            // Manga_Tx01
            // 
            this.Manga_Tx01.BackColor = System.Drawing.Color.White;
            this.Manga_Tx01.ForeColor = System.Drawing.Color.Black;
            this.Manga_Tx01.Location = new System.Drawing.Point(214, 19);
            this.Manga_Tx01.Name = "Manga_Tx01";
            this.Manga_Tx01.Size = new System.Drawing.Size(248, 20);
            this.Manga_Tx01.TabIndex = 0;
            // 
            // MainTabManga_Mn03
            // 
            this.MainTabManga_Mn03.BackColor = System.Drawing.Color.White;
            this.MainTabManga_Mn03.Controls.Add(this.MangaSearch_NM04);
            this.MainTabManga_Mn03.Controls.Add(this.MangaSearch_NM03);
            this.MainTabManga_Mn03.Controls.Add(this.MangaSearch_NM02);
            this.MainTabManga_Mn03.Controls.Add(this.MangaSearch_NM01);
            this.MainTabManga_Mn03.Controls.Add(this.MangaSearch_TX05);
            this.MainTabManga_Mn03.Controls.Add(this.MangaSearch_TX04);
            this.MainTabManga_Mn03.Controls.Add(this.MangaSearch_TX03);
            this.MainTabManga_Mn03.Controls.Add(this.MangaSearch_TX02);
            this.MainTabManga_Mn03.Controls.Add(this.MangaSearch_TX01);
            this.MainTabManga_Mn03.Controls.Add(this.MangaSearch_LB10);
            this.MainTabManga_Mn03.Controls.Add(this.MangaSearch_LB05);
            this.MainTabManga_Mn03.Controls.Add(this.MangaSearch_LB04);
            this.MainTabManga_Mn03.Controls.Add(this.MangaSearch_LB09);
            this.MainTabManga_Mn03.Controls.Add(this.MangaSearch_LB03);
            this.MainTabManga_Mn03.Controls.Add(this.MangaSearch_LB08);
            this.MainTabManga_Mn03.Controls.Add(this.MangaSearch_LB02);
            this.MainTabManga_Mn03.Controls.Add(this.MangaSearch_LB07);
            this.MainTabManga_Mn03.Controls.Add(this.MangaSearch_LB01);
            this.MainTabManga_Mn03.Controls.Add(this.MangaSearch_LB06);
            this.MainTabManga_Mn03.Controls.Add(this.MangaSearch_Genres);
            this.MainTabManga_Mn03.Controls.Add(this.MangaSearch_New);
            this.MainTabManga_Mn03.Controls.Add(this.MangaSearch_Search);
            this.MainTabManga_Mn03.Controls.Add(this.MangaSearch);
            this.MainTabManga_Mn03.Location = new System.Drawing.Point(4, 22);
            this.MainTabManga_Mn03.Name = "MainTabManga_Mn03";
            this.MainTabManga_Mn03.Size = new System.Drawing.Size(1096, 648);
            this.MainTabManga_Mn03.TabIndex = 0;
            this.MainTabManga_Mn03.Text = "3";
            // 
            // MangaSearch_NM04
            // 
            this.MangaSearch_NM04.ForeColor = System.Drawing.Color.Black;
            this.MangaSearch_NM04.Location = new System.Drawing.Point(381, 82);
            this.MangaSearch_NM04.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.MangaSearch_NM04.Name = "MangaSearch_NM04";
            this.MangaSearch_NM04.Size = new System.Drawing.Size(100, 20);
            this.MangaSearch_NM04.TabIndex = 0;
            this.MangaSearch_NM04.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MangaSearch_NM04.ThousandsSeparator = true;
            // 
            // MangaSearch_NM03
            // 
            this.MangaSearch_NM03.ForeColor = System.Drawing.Color.Black;
            this.MangaSearch_NM03.Location = new System.Drawing.Point(381, 56);
            this.MangaSearch_NM03.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.MangaSearch_NM03.Name = "MangaSearch_NM03";
            this.MangaSearch_NM03.Size = new System.Drawing.Size(100, 20);
            this.MangaSearch_NM03.TabIndex = 0;
            this.MangaSearch_NM03.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MangaSearch_NM03.ThousandsSeparator = true;
            // 
            // MangaSearch_NM02
            // 
            this.MangaSearch_NM02.ForeColor = System.Drawing.Color.Black;
            this.MangaSearch_NM02.Location = new System.Drawing.Point(381, 30);
            this.MangaSearch_NM02.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.MangaSearch_NM02.Name = "MangaSearch_NM02";
            this.MangaSearch_NM02.Size = new System.Drawing.Size(100, 20);
            this.MangaSearch_NM02.TabIndex = 0;
            this.MangaSearch_NM02.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MangaSearch_NM02.ThousandsSeparator = true;
            // 
            // MangaSearch_NM01
            // 
            this.MangaSearch_NM01.ForeColor = System.Drawing.Color.Black;
            this.MangaSearch_NM01.Location = new System.Drawing.Point(381, 4);
            this.MangaSearch_NM01.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.MangaSearch_NM01.Name = "MangaSearch_NM01";
            this.MangaSearch_NM01.Size = new System.Drawing.Size(100, 20);
            this.MangaSearch_NM01.TabIndex = 0;
            this.MangaSearch_NM01.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // MangaSearch_TX05
            // 
            this.MangaSearch_TX05.ForeColor = System.Drawing.Color.Black;
            this.MangaSearch_TX05.Location = new System.Drawing.Point(102, 107);
            this.MangaSearch_TX05.Name = "MangaSearch_TX05";
            this.MangaSearch_TX05.Size = new System.Drawing.Size(100, 20);
            this.MangaSearch_TX05.TabIndex = 0;
            // 
            // MangaSearch_TX04
            // 
            this.MangaSearch_TX04.ForeColor = System.Drawing.Color.Black;
            this.MangaSearch_TX04.Location = new System.Drawing.Point(102, 81);
            this.MangaSearch_TX04.Name = "MangaSearch_TX04";
            this.MangaSearch_TX04.Size = new System.Drawing.Size(100, 20);
            this.MangaSearch_TX04.TabIndex = 0;
            // 
            // MangaSearch_TX03
            // 
            this.MangaSearch_TX03.ForeColor = System.Drawing.Color.Black;
            this.MangaSearch_TX03.Location = new System.Drawing.Point(102, 55);
            this.MangaSearch_TX03.Name = "MangaSearch_TX03";
            this.MangaSearch_TX03.Size = new System.Drawing.Size(100, 20);
            this.MangaSearch_TX03.TabIndex = 0;
            // 
            // MangaSearch_TX02
            // 
            this.MangaSearch_TX02.ForeColor = System.Drawing.Color.Black;
            this.MangaSearch_TX02.Location = new System.Drawing.Point(102, 29);
            this.MangaSearch_TX02.Name = "MangaSearch_TX02";
            this.MangaSearch_TX02.Size = new System.Drawing.Size(100, 20);
            this.MangaSearch_TX02.TabIndex = 0;
            // 
            // MangaSearch_TX01
            // 
            this.MangaSearch_TX01.ForeColor = System.Drawing.Color.Black;
            this.MangaSearch_TX01.Location = new System.Drawing.Point(102, 3);
            this.MangaSearch_TX01.Name = "MangaSearch_TX01";
            this.MangaSearch_TX01.Size = new System.Drawing.Size(100, 20);
            this.MangaSearch_TX01.TabIndex = 0;
            // 
            // MangaSearch_LB10
            // 
            this.MangaSearch_LB10.AutoSize = true;
            this.MangaSearch_LB10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MangaSearch_LB10.ForeColor = System.Drawing.Color.Black;
            this.MangaSearch_LB10.Location = new System.Drawing.Point(487, 10);
            this.MangaSearch_LB10.Margin = new System.Windows.Forms.Padding(3);
            this.MangaSearch_LB10.Name = "MangaSearch_LB10";
            this.MangaSearch_LB10.Size = new System.Drawing.Size(41, 13);
            this.MangaSearch_LB10.TabIndex = 0;
            this.MangaSearch_LB10.Text = "label1";
            // 
            // MangaSearch_LB05
            // 
            this.MangaSearch_LB05.AutoSize = true;
            this.MangaSearch_LB05.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MangaSearch_LB05.ForeColor = System.Drawing.Color.Black;
            this.MangaSearch_LB05.Location = new System.Drawing.Point(5, 110);
            this.MangaSearch_LB05.Margin = new System.Windows.Forms.Padding(3);
            this.MangaSearch_LB05.Name = "MangaSearch_LB05";
            this.MangaSearch_LB05.Size = new System.Drawing.Size(41, 13);
            this.MangaSearch_LB05.TabIndex = 0;
            this.MangaSearch_LB05.Text = "label1";
            // 
            // MangaSearch_LB04
            // 
            this.MangaSearch_LB04.AutoSize = true;
            this.MangaSearch_LB04.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MangaSearch_LB04.ForeColor = System.Drawing.Color.Black;
            this.MangaSearch_LB04.Location = new System.Drawing.Point(5, 84);
            this.MangaSearch_LB04.Margin = new System.Windows.Forms.Padding(3);
            this.MangaSearch_LB04.Name = "MangaSearch_LB04";
            this.MangaSearch_LB04.Size = new System.Drawing.Size(41, 13);
            this.MangaSearch_LB04.TabIndex = 0;
            this.MangaSearch_LB04.Text = "label1";
            // 
            // MangaSearch_LB09
            // 
            this.MangaSearch_LB09.AutoSize = true;
            this.MangaSearch_LB09.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MangaSearch_LB09.ForeColor = System.Drawing.Color.Black;
            this.MangaSearch_LB09.Location = new System.Drawing.Point(226, 84);
            this.MangaSearch_LB09.Margin = new System.Windows.Forms.Padding(3);
            this.MangaSearch_LB09.Name = "MangaSearch_LB09";
            this.MangaSearch_LB09.Size = new System.Drawing.Size(41, 13);
            this.MangaSearch_LB09.TabIndex = 0;
            this.MangaSearch_LB09.Text = "label1";
            // 
            // MangaSearch_LB03
            // 
            this.MangaSearch_LB03.AutoSize = true;
            this.MangaSearch_LB03.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MangaSearch_LB03.ForeColor = System.Drawing.Color.Black;
            this.MangaSearch_LB03.Location = new System.Drawing.Point(5, 58);
            this.MangaSearch_LB03.Margin = new System.Windows.Forms.Padding(3);
            this.MangaSearch_LB03.Name = "MangaSearch_LB03";
            this.MangaSearch_LB03.Size = new System.Drawing.Size(41, 13);
            this.MangaSearch_LB03.TabIndex = 0;
            this.MangaSearch_LB03.Text = "label1";
            // 
            // MangaSearch_LB08
            // 
            this.MangaSearch_LB08.AutoSize = true;
            this.MangaSearch_LB08.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MangaSearch_LB08.ForeColor = System.Drawing.Color.Black;
            this.MangaSearch_LB08.Location = new System.Drawing.Point(226, 58);
            this.MangaSearch_LB08.Margin = new System.Windows.Forms.Padding(3);
            this.MangaSearch_LB08.Name = "MangaSearch_LB08";
            this.MangaSearch_LB08.Size = new System.Drawing.Size(41, 13);
            this.MangaSearch_LB08.TabIndex = 0;
            this.MangaSearch_LB08.Text = "label1";
            // 
            // MangaSearch_LB02
            // 
            this.MangaSearch_LB02.AutoSize = true;
            this.MangaSearch_LB02.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MangaSearch_LB02.ForeColor = System.Drawing.Color.Black;
            this.MangaSearch_LB02.Location = new System.Drawing.Point(5, 32);
            this.MangaSearch_LB02.Margin = new System.Windows.Forms.Padding(3);
            this.MangaSearch_LB02.Name = "MangaSearch_LB02";
            this.MangaSearch_LB02.Size = new System.Drawing.Size(41, 13);
            this.MangaSearch_LB02.TabIndex = 0;
            this.MangaSearch_LB02.Text = "label1";
            // 
            // MangaSearch_LB07
            // 
            this.MangaSearch_LB07.AutoSize = true;
            this.MangaSearch_LB07.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MangaSearch_LB07.ForeColor = System.Drawing.Color.Black;
            this.MangaSearch_LB07.Location = new System.Drawing.Point(226, 32);
            this.MangaSearch_LB07.Margin = new System.Windows.Forms.Padding(3);
            this.MangaSearch_LB07.Name = "MangaSearch_LB07";
            this.MangaSearch_LB07.Size = new System.Drawing.Size(41, 13);
            this.MangaSearch_LB07.TabIndex = 0;
            this.MangaSearch_LB07.Text = "label1";
            // 
            // MangaSearch_LB01
            // 
            this.MangaSearch_LB01.AutoSize = true;
            this.MangaSearch_LB01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MangaSearch_LB01.ForeColor = System.Drawing.Color.Black;
            this.MangaSearch_LB01.Location = new System.Drawing.Point(5, 6);
            this.MangaSearch_LB01.Margin = new System.Windows.Forms.Padding(3);
            this.MangaSearch_LB01.Name = "MangaSearch_LB01";
            this.MangaSearch_LB01.Size = new System.Drawing.Size(41, 13);
            this.MangaSearch_LB01.TabIndex = 0;
            this.MangaSearch_LB01.Text = "label1";
            // 
            // MangaSearch_LB06
            // 
            this.MangaSearch_LB06.AutoSize = true;
            this.MangaSearch_LB06.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MangaSearch_LB06.ForeColor = System.Drawing.Color.Black;
            this.MangaSearch_LB06.Location = new System.Drawing.Point(226, 6);
            this.MangaSearch_LB06.Margin = new System.Windows.Forms.Padding(3);
            this.MangaSearch_LB06.Name = "MangaSearch_LB06";
            this.MangaSearch_LB06.Size = new System.Drawing.Size(41, 13);
            this.MangaSearch_LB06.TabIndex = 0;
            this.MangaSearch_LB06.Text = "label1";
            // 
            // MangaSearch_Genres
            // 
            this.MangaSearch_Genres.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MangaSearch_Genres.CheckOnClick = true;
            this.MangaSearch_Genres.ForeColor = System.Drawing.Color.Black;
            this.MangaSearch_Genres.FormattingEnabled = true;
            this.MangaSearch_Genres.Location = new System.Drawing.Point(490, 34);
            this.MangaSearch_Genres.MultiColumn = true;
            this.MangaSearch_Genres.Name = "MangaSearch_Genres";
            this.MangaSearch_Genres.Size = new System.Drawing.Size(500, 94);
            this.MangaSearch_Genres.Sorted = true;
            this.MangaSearch_Genres.TabIndex = 0;
            // 
            // MangaSearch_New
            // 
            this.MangaSearch_New.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MangaSearch_New.ForeColor = System.Drawing.Color.Black;
            this.MangaSearch_New.Location = new System.Drawing.Point(1017, 74);
            this.MangaSearch_New.Name = "MangaSearch_New";
            this.MangaSearch_New.Size = new System.Drawing.Size(75, 23);
            this.MangaSearch_New.TabIndex = 0;
            this.MangaSearch_New.Text = "button1";
            this.MangaSearch_New.UseVisualStyleBackColor = true;
            this.MangaSearch_New.Click += new System.EventHandler(this.MangaSearch_New_Click);
            // 
            // MangaSearch_Search
            // 
            this.MangaSearch_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MangaSearch_Search.ForeColor = System.Drawing.Color.Black;
            this.MangaSearch_Search.Location = new System.Drawing.Point(1017, 105);
            this.MangaSearch_Search.Name = "MangaSearch_Search";
            this.MangaSearch_Search.Size = new System.Drawing.Size(75, 23);
            this.MangaSearch_Search.TabIndex = 0;
            this.MangaSearch_Search.Text = "button1";
            this.MangaSearch_Search.UseVisualStyleBackColor = true;
            this.MangaSearch_Search.Click += new System.EventHandler(this.MangaSearch_Search_Click);
            // 
            // MangaSearch
            // 
            this.MangaSearch.AllowUserToAddRows = false;
            this.MangaSearch.AllowUserToDeleteRows = false;
            this.MangaSearch.AllowUserToResizeRows = false;
            this.MangaSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MangaSearch.BackgroundColor = System.Drawing.Color.White;
            this.MangaSearch.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.MangaSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MangaSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MangaSearch_Mn01,
            this.MangaSearch_Mn02,
            this.MangaSearch_Mn03,
            this.MangaSearch_Mn04});
            this.MangaSearch.GridColor = System.Drawing.Color.White;
            this.MangaSearch.Location = new System.Drawing.Point(8, 141);
            this.MangaSearch.Name = "MangaSearch";
            this.MangaSearch.ReadOnly = true;
            this.MangaSearch.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.MangaSearch.RowHeadersVisible = false;
            dataGridViewCellStyle29.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle29.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle29.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle29.SelectionForeColor = System.Drawing.Color.Black;
            this.MangaSearch.RowsDefaultCellStyle = dataGridViewCellStyle29;
            this.MangaSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MangaSearch.Size = new System.Drawing.Size(1084, 504);
            this.MangaSearch.TabIndex = 0;
            this.MangaSearch.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MangaSearch_MouseDoubleClick);
            this.MangaSearch.MouseEnter += new System.EventHandler(this.MangaSearch_MouseEnter);
            // 
            // MangaSearch_Mn01
            // 
            this.MangaSearch_Mn01.HeaderText = "";
            this.MangaSearch_Mn01.MinimumWidth = 100;
            this.MangaSearch_Mn01.Name = "MangaSearch_Mn01";
            this.MangaSearch_Mn01.ReadOnly = true;
            this.MangaSearch_Mn01.Visible = false;
            // 
            // MangaSearch_Mn02
            // 
            this.MangaSearch_Mn02.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MangaSearch_Mn02.FillWeight = 50F;
            this.MangaSearch_Mn02.HeaderText = "";
            this.MangaSearch_Mn02.MinimumWidth = 100;
            this.MangaSearch_Mn02.Name = "MangaSearch_Mn02";
            this.MangaSearch_Mn02.ReadOnly = true;
            // 
            // MangaSearch_Mn03
            // 
            this.MangaSearch_Mn03.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MangaSearch_Mn03.FillWeight = 50F;
            this.MangaSearch_Mn03.HeaderText = "";
            this.MangaSearch_Mn03.MinimumWidth = 100;
            this.MangaSearch_Mn03.Name = "MangaSearch_Mn03";
            this.MangaSearch_Mn03.ReadOnly = true;
            // 
            // MangaSearch_Mn04
            // 
            this.MangaSearch_Mn04.HeaderText = "";
            this.MangaSearch_Mn04.Name = "MangaSearch_Mn04";
            this.MangaSearch_Mn04.ReadOnly = true;
            // 
            // MainTab_LogPage
            // 
            this.MainTab_LogPage.BackColor = System.Drawing.Color.White;
            this.MainTab_LogPage.Controls.Add(this.MainTabLog);
            this.MainTab_LogPage.Location = new System.Drawing.Point(4, 22);
            this.MainTab_LogPage.Name = "MainTab_LogPage";
            this.MainTab_LogPage.Size = new System.Drawing.Size(1119, 680);
            this.MainTab_LogPage.TabIndex = 0;
            this.MainTab_LogPage.Text = "4";
            this.MainTab_LogPage.UseVisualStyleBackColor = true;
            // 
            // MainTabLog
            // 
            this.MainTabLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTabLog.Controls.Add(this.MainTabLog_AniDbTabPage);
            this.MainTabLog.Controls.Add(this.MainTabLog_SqlTabPage);
            this.MainTabLog.Controls.Add(this.MainTabLog_ErrorTabPage);
            this.MainTabLog.Controls.Add(this.MainTabLog_TasksTabPage);
            this.MainTabLog.Location = new System.Drawing.Point(3, 3);
            this.MainTabLog.Name = "MainTabLog";
            this.MainTabLog.SelectedIndex = 0;
            this.MainTabLog.Size = new System.Drawing.Size(1104, 674);
            this.MainTabLog.TabIndex = 0;
            // 
            // MainTabLog_AniDbTabPage
            // 
            this.MainTabLog_AniDbTabPage.BackColor = System.Drawing.Color.White;
            this.MainTabLog_AniDbTabPage.Controls.Add(this.Log);
            this.MainTabLog_AniDbTabPage.Location = new System.Drawing.Point(4, 22);
            this.MainTabLog_AniDbTabPage.Name = "MainTabLog_AniDbTabPage";
            this.MainTabLog_AniDbTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.MainTabLog_AniDbTabPage.Size = new System.Drawing.Size(1096, 648);
            this.MainTabLog_AniDbTabPage.TabIndex = 0;
            this.MainTabLog_AniDbTabPage.Text = "1";
            this.MainTabLog_AniDbTabPage.UseVisualStyleBackColor = true;
            // 
            // Log
            // 
            this.Log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Log.BackColor = System.Drawing.Color.White;
            this.Log.Font = new System.Drawing.Font("Courier New", 12F);
            this.Log.ForeColor = System.Drawing.Color.Black;
            this.Log.Location = new System.Drawing.Point(6, 6);
            this.Log.MaxLength = 40000;
            this.Log.Multiline = true;
            this.Log.Name = "Log";
            this.Log.ReadOnly = true;
            this.Log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Log.Size = new System.Drawing.Size(1087, 636);
            this.Log.TabIndex = 0;
            // 
            // MainTabLog_SqlTabPage
            // 
            this.MainTabLog_SqlTabPage.BackColor = System.Drawing.Color.White;
            this.MainTabLog_SqlTabPage.Controls.Add(this.LogSQL);
            this.MainTabLog_SqlTabPage.Location = new System.Drawing.Point(4, 22);
            this.MainTabLog_SqlTabPage.Name = "MainTabLog_SqlTabPage";
            this.MainTabLog_SqlTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.MainTabLog_SqlTabPage.Size = new System.Drawing.Size(1096, 648);
            this.MainTabLog_SqlTabPage.TabIndex = 0;
            this.MainTabLog_SqlTabPage.Text = "2";
            this.MainTabLog_SqlTabPage.UseVisualStyleBackColor = true;
            // 
            // LogSQL
            // 
            this.LogSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogSQL.BackColor = System.Drawing.Color.White;
            this.LogSQL.Font = new System.Drawing.Font("Courier New", 12F);
            this.LogSQL.ForeColor = System.Drawing.Color.Black;
            this.LogSQL.Location = new System.Drawing.Point(6, 6);
            this.LogSQL.MaxLength = 40000;
            this.LogSQL.Multiline = true;
            this.LogSQL.Name = "LogSQL";
            this.LogSQL.ReadOnly = true;
            this.LogSQL.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LogSQL.Size = new System.Drawing.Size(1087, 636);
            this.LogSQL.TabIndex = 0;
            // 
            // MainTabLog_ErrorTabPage
            // 
            this.MainTabLog_ErrorTabPage.BackColor = System.Drawing.Color.White;
            this.MainTabLog_ErrorTabPage.Controls.Add(this.LogError);
            this.MainTabLog_ErrorTabPage.Location = new System.Drawing.Point(4, 22);
            this.MainTabLog_ErrorTabPage.Name = "MainTabLog_ErrorTabPage";
            this.MainTabLog_ErrorTabPage.Size = new System.Drawing.Size(1096, 648);
            this.MainTabLog_ErrorTabPage.TabIndex = 0;
            this.MainTabLog_ErrorTabPage.Text = "4";
            this.MainTabLog_ErrorTabPage.UseVisualStyleBackColor = true;
            // 
            // LogError
            // 
            this.LogError.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogError.BackColor = System.Drawing.Color.White;
            this.LogError.Font = new System.Drawing.Font("Courier New", 12F);
            this.LogError.ForeColor = System.Drawing.Color.Black;
            this.LogError.Location = new System.Drawing.Point(6, 6);
            this.LogError.MaxLength = 40000;
            this.LogError.Multiline = true;
            this.LogError.Name = "LogError";
            this.LogError.ReadOnly = true;
            this.LogError.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LogError.Size = new System.Drawing.Size(1087, 636);
            this.LogError.TabIndex = 0;
            // 
            // MainTabLog_TasksTabPage
            // 
            this.MainTabLog_TasksTabPage.BackColor = System.Drawing.Color.White;
            this.MainTabLog_TasksTabPage.Controls.Add(this.Add_Text02);
            this.MainTabLog_TasksTabPage.Controls.Add(this.Add_Text01);
            this.MainTabLog_TasksTabPage.Controls.Add(this.Add_LB01);
            this.MainTabLog_TasksTabPage.Controls.Add(this.Add_Add);
            this.MainTabLog_TasksTabPage.Controls.Add(this.LogTasksDelAll);
            this.MainTabLog_TasksTabPage.Controls.Add(this.LogTasksDel);
            this.MainTabLog_TasksTabPage.Controls.Add(this.LogTasks);
            this.MainTabLog_TasksTabPage.Location = new System.Drawing.Point(4, 22);
            this.MainTabLog_TasksTabPage.Name = "MainTabLog_TasksTabPage";
            this.MainTabLog_TasksTabPage.Size = new System.Drawing.Size(1096, 648);
            this.MainTabLog_TasksTabPage.TabIndex = 0;
            this.MainTabLog_TasksTabPage.Text = "3";
            this.MainTabLog_TasksTabPage.UseVisualStyleBackColor = true;
            // 
            // Add_Text02
            // 
            this.Add_Text02.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Add_Text02.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Add_Text02.ForeColor = System.Drawing.Color.Black;
            this.Add_Text02.FormattingEnabled = true;
            this.Add_Text02.Items.AddRange(new object[] {
            "Anime",
            "File",
            "Episode"});
            this.Add_Text02.Location = new System.Drawing.Point(188, 621);
            this.Add_Text02.Name = "Add_Text02";
            this.Add_Text02.Size = new System.Drawing.Size(121, 21);
            this.Add_Text02.TabIndex = 0;
            // 
            // Add_Text01
            // 
            this.Add_Text01.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Add_Text01.ForeColor = System.Drawing.Color.Black;
            this.Add_Text01.Location = new System.Drawing.Point(61, 621);
            this.Add_Text01.Name = "Add_Text01";
            this.Add_Text01.Size = new System.Drawing.Size(121, 20);
            this.Add_Text01.TabIndex = 0;
            // 
            // Add_LB01
            // 
            this.Add_LB01.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Add_LB01.AutoSize = true;
            this.Add_LB01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Add_LB01.ForeColor = System.Drawing.Color.Black;
            this.Add_LB01.Location = new System.Drawing.Point(3, 624);
            this.Add_LB01.Margin = new System.Windows.Forms.Padding(3);
            this.Add_LB01.Name = "Add_LB01";
            this.Add_LB01.Size = new System.Drawing.Size(41, 13);
            this.Add_LB01.TabIndex = 0;
            this.Add_LB01.Text = "label1";
            // 
            // LogTasks
            // 
            this.LogTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogTasks.BackColor = System.Drawing.Color.White;
            this.LogTasks.Font = new System.Drawing.Font("Courier New", 12F);
            this.LogTasks.ForeColor = System.Drawing.Color.Black;
            this.LogTasks.FormattingEnabled = true;
            this.LogTasks.ItemHeight = 18;
            this.LogTasks.Location = new System.Drawing.Point(6, 3);
            this.LogTasks.Name = "LogTasks";
            this.LogTasks.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.LogTasks.Size = new System.Drawing.Size(1087, 598);
            this.LogTasks.TabIndex = 0;
            // 
            // MainTab_SqlPage
            // 
            this.MainTab_SqlPage.BackColor = System.Drawing.Color.White;
            this.MainTab_SqlPage.Controls.Add(this.DataSql_CheckGroupBox);
            this.MainTab_SqlPage.Controls.Add(this.DataSQL_Text);
            this.MainTab_SqlPage.Controls.Add(this.DataSQL_Columns);
            this.MainTab_SqlPage.Controls.Add(this.DataSQL_Tables);
            this.MainTab_SqlPage.Controls.Add(this.DataSQL);
            this.MainTab_SqlPage.Controls.Add(this.DataSQL_Select);
            this.MainTab_SqlPage.Location = new System.Drawing.Point(4, 22);
            this.MainTab_SqlPage.Name = "MainTab_SqlPage";
            this.MainTab_SqlPage.Size = new System.Drawing.Size(1119, 680);
            this.MainTab_SqlPage.TabIndex = 0;
            this.MainTab_SqlPage.Text = "5";
            this.MainTab_SqlPage.UseVisualStyleBackColor = true;
            // 
            // DataSql_CheckGroupBox
            // 
            this.DataSql_CheckGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DataSql_CheckGroupBox.Controls.Add(this.DataSql_FilesButton);
            this.DataSql_CheckGroupBox.Controls.Add(this.DataSql_MyListButton);
            this.DataSql_CheckGroupBox.Controls.Add(this.DataSql_EpisodesButton);
            this.DataSql_CheckGroupBox.Controls.Add(this.DataSql_AnimeButton);
            this.DataSql_CheckGroupBox.ForeColor = System.Drawing.Color.Black;
            this.DataSql_CheckGroupBox.Location = new System.Drawing.Point(900, 427);
            this.DataSql_CheckGroupBox.Name = "DataSql_CheckGroupBox";
            this.DataSql_CheckGroupBox.Size = new System.Drawing.Size(207, 250);
            this.DataSql_CheckGroupBox.TabIndex = 0;
            this.DataSql_CheckGroupBox.TabStop = false;
            this.DataSql_CheckGroupBox.Text = "groupBox1";
            // 
            // DataSql_FilesButton
            // 
            this.DataSql_FilesButton.ForeColor = System.Drawing.Color.Black;
            this.DataSql_FilesButton.Location = new System.Drawing.Point(126, 19);
            this.DataSql_FilesButton.Name = "DataSql_FilesButton";
            this.DataSql_FilesButton.Size = new System.Drawing.Size(75, 23);
            this.DataSql_FilesButton.TabIndex = 0;
            this.DataSql_FilesButton.Text = "button4";
            this.DataSql_FilesButton.UseVisualStyleBackColor = true;
            this.DataSql_FilesButton.Click += new System.EventHandler(this.DataSQL_BT03_Click);
            // 
            // DataSql_MyListButton
            // 
            this.DataSql_MyListButton.ForeColor = System.Drawing.Color.Black;
            this.DataSql_MyListButton.Location = new System.Drawing.Point(126, 48);
            this.DataSql_MyListButton.Name = "DataSql_MyListButton";
            this.DataSql_MyListButton.Size = new System.Drawing.Size(75, 23);
            this.DataSql_MyListButton.TabIndex = 0;
            this.DataSql_MyListButton.Text = "button3";
            this.DataSql_MyListButton.UseVisualStyleBackColor = true;
            this.DataSql_MyListButton.Click += new System.EventHandler(this.DataSQL_BT04_Click);
            // 
            // DataSql_EpisodesButton
            // 
            this.DataSql_EpisodesButton.ForeColor = System.Drawing.Color.Black;
            this.DataSql_EpisodesButton.Location = new System.Drawing.Point(6, 48);
            this.DataSql_EpisodesButton.Name = "DataSql_EpisodesButton";
            this.DataSql_EpisodesButton.Size = new System.Drawing.Size(75, 23);
            this.DataSql_EpisodesButton.TabIndex = 0;
            this.DataSql_EpisodesButton.Text = "button2";
            this.DataSql_EpisodesButton.UseVisualStyleBackColor = true;
            this.DataSql_EpisodesButton.Click += new System.EventHandler(this.DataSQL_BT02_Click);
            // 
            // DataSql_AnimeButton
            // 
            this.DataSql_AnimeButton.ForeColor = System.Drawing.Color.Black;
            this.DataSql_AnimeButton.Location = new System.Drawing.Point(6, 19);
            this.DataSql_AnimeButton.Name = "DataSql_AnimeButton";
            this.DataSql_AnimeButton.Size = new System.Drawing.Size(75, 23);
            this.DataSql_AnimeButton.TabIndex = 0;
            this.DataSql_AnimeButton.Text = "button1";
            this.DataSql_AnimeButton.UseVisualStyleBackColor = true;
            this.DataSql_AnimeButton.Click += new System.EventHandler(this.DataSQL_BT01_Click);
            // 
            // DataSQL_Text
            // 
            this.DataSQL_Text.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataSQL_Text.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.DataSQL_Text.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.DataSQL_Text.ForeColor = System.Drawing.Color.Black;
            this.DataSQL_Text.FormattingEnabled = true;
            this.DataSQL_Text.Location = new System.Drawing.Point(3, 3);
            this.DataSQL_Text.Name = "DataSQL_Text";
            this.DataSQL_Text.Size = new System.Drawing.Size(1069, 21);
            this.DataSQL_Text.TabIndex = 0;
            this.DataSQL_Text.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DataSQL_Text_KeyUp);
            // 
            // DataSQL_Columns
            // 
            this.DataSQL_Columns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataSQL_Columns.ForeColor = System.Drawing.Color.Black;
            this.DataSQL_Columns.FormattingEnabled = true;
            this.DataSQL_Columns.Location = new System.Drawing.Point(900, 261);
            this.DataSQL_Columns.Name = "DataSQL_Columns";
            this.DataSQL_Columns.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.DataSQL_Columns.Size = new System.Drawing.Size(207, 160);
            this.DataSQL_Columns.TabIndex = 0;
            this.DataSQL_Columns.SelectedIndexChanged += new System.EventHandler(this.DataSQL_Columns_SelectedIndexChanged);
            // 
            // DataSQL_Tables
            // 
            this.DataSQL_Tables.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DataSQL_Tables.ForeColor = System.Drawing.Color.Black;
            this.DataSQL_Tables.FormattingEnabled = true;
            this.DataSQL_Tables.Location = new System.Drawing.Point(899, 30);
            this.DataSQL_Tables.Name = "DataSQL_Tables";
            this.DataSQL_Tables.Size = new System.Drawing.Size(207, 225);
            this.DataSQL_Tables.TabIndex = 0;
            this.DataSQL_Tables.SelectedIndexChanged += new System.EventHandler(this.DataSQL_Tables_SelectedIndexChanged);
            // 
            // DataSQL
            // 
            this.DataSQL.AllowUserToAddRows = false;
            this.DataSQL.AllowUserToDeleteRows = false;
            this.DataSQL.AllowUserToResizeRows = false;
            this.DataSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataSQL.BackgroundColor = System.Drawing.Color.White;
            this.DataSQL.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DataSQL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataSQL.GridColor = System.Drawing.Color.White;
            this.DataSQL.Location = new System.Drawing.Point(3, 30);
            this.DataSQL.Name = "DataSQL";
            this.DataSQL.ReadOnly = true;
            this.DataSQL.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataSQL.RowHeadersVisible = false;
            dataGridViewCellStyle30.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle30.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle30.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle30.SelectionForeColor = System.Drawing.Color.Black;
            this.DataSQL.RowsDefaultCellStyle = dataGridViewCellStyle30;
            this.DataSQL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataSQL.Size = new System.Drawing.Size(891, 647);
            this.DataSQL.TabIndex = 0;
            // 
            // ComunicationW
            // 
            this.ComunicationW.WorkerReportsProgress = true;
            this.ComunicationW.WorkerSupportsCancellation = true;
            this.ComunicationW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ComunicationW_DoWork);
            this.ComunicationW.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ComunicationW_ProgressChanged);
            this.ComunicationW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ComunicationW_RunWorkerCompleted);
            // 
            // ComunicationRec
            // 
            this.ComunicationRec.Interval = 5000;
            this.ComunicationRec.Tick += new System.EventHandler(this.ComunicationRec_Tick);
            // 
            // Hash_W
            // 
            this.Hash_W.WorkerReportsProgress = true;
            this.Hash_W.WorkerSupportsCancellation = true;
            this.Hash_W.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Hash_W_DoWork);
            this.Hash_W.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Hash_W_ProgressChanged);
            this.Hash_W.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Hash_W_RunWorkerCompleted);
            // 
            // AnimeData_Menu
            // 
            this.AnimeData_Menu.BackColor = System.Drawing.Color.White;
            this.AnimeData_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AnimeData_Menu_Mn01,
            this.AnimeData_Menu_Mn02,
            this.AnimeData_Menu_Mn03,
            this.AnimeData_Menu_Mn05,
            this.AnimeData_Menu_Mn04,
            this.AnimeData_Menu_Mn06});
            this.AnimeData_Menu.Name = "AnimeData_Menu";
            this.AnimeData_Menu.Size = new System.Drawing.Size(81, 136);
            // 
            // AnimeData_Menu_Mn01
            // 
            this.AnimeData_Menu_Mn01.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AnimeData_Menu_Mn01_Mn01,
            this.AnimeData_Menu_Mn01_Mn02});
            this.AnimeData_Menu_Mn01.Name = "AnimeData_Menu_Mn01";
            this.AnimeData_Menu_Mn01.Size = new System.Drawing.Size(80, 22);
            this.AnimeData_Menu_Mn01.Text = "1";
            // 
            // AnimeData_Menu_Mn01_Mn01
            // 
            this.AnimeData_Menu_Mn01_Mn01.Name = "AnimeData_Menu_Mn01_Mn01";
            this.AnimeData_Menu_Mn01_Mn01.Size = new System.Drawing.Size(80, 22);
            this.AnimeData_Menu_Mn01_Mn01.Text = "1";
            this.AnimeData_Menu_Mn01_Mn01.Click += new System.EventHandler(this.AnimeData_Menu_Mn01_Mn01_Click);
            // 
            // AnimeData_Menu_Mn01_Mn02
            // 
            this.AnimeData_Menu_Mn01_Mn02.Name = "AnimeData_Menu_Mn01_Mn02";
            this.AnimeData_Menu_Mn01_Mn02.Size = new System.Drawing.Size(80, 22);
            this.AnimeData_Menu_Mn01_Mn02.Text = "2";
            this.AnimeData_Menu_Mn01_Mn02.Click += new System.EventHandler(this.AnimeData_Menu_Mn01_Mn02_Click);
            // 
            // AnimeData_Menu_Mn02
            // 
            this.AnimeData_Menu_Mn02.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AnimeData_Menu_Mn02_Mn01,
            this.AnimeData_Menu_Mn02_Mn02,
            this.AnimeData_Menu_Mn02_Mn03});
            this.AnimeData_Menu_Mn02.Name = "AnimeData_Menu_Mn02";
            this.AnimeData_Menu_Mn02.Size = new System.Drawing.Size(80, 22);
            this.AnimeData_Menu_Mn02.Text = "2";
            // 
            // AnimeData_Menu_Mn02_Mn01
            // 
            this.AnimeData_Menu_Mn02_Mn01.Name = "AnimeData_Menu_Mn02_Mn01";
            this.AnimeData_Menu_Mn02_Mn01.Size = new System.Drawing.Size(80, 22);
            this.AnimeData_Menu_Mn02_Mn01.Text = "1";
            this.AnimeData_Menu_Mn02_Mn01.Click += new System.EventHandler(this.AnimeData_Menu_Mn02_Mn01_Click);
            // 
            // AnimeData_Menu_Mn02_Mn02
            // 
            this.AnimeData_Menu_Mn02_Mn02.Name = "AnimeData_Menu_Mn02_Mn02";
            this.AnimeData_Menu_Mn02_Mn02.Size = new System.Drawing.Size(80, 22);
            this.AnimeData_Menu_Mn02_Mn02.Text = "2";
            this.AnimeData_Menu_Mn02_Mn02.Click += new System.EventHandler(this.AnimeData_Menu_Mn02_Mn02_Click);
            // 
            // AnimeData_Menu_Mn02_Mn03
            // 
            this.AnimeData_Menu_Mn02_Mn03.Name = "AnimeData_Menu_Mn02_Mn03";
            this.AnimeData_Menu_Mn02_Mn03.Size = new System.Drawing.Size(80, 22);
            this.AnimeData_Menu_Mn02_Mn03.Text = "3";
            this.AnimeData_Menu_Mn02_Mn03.Click += new System.EventHandler(this.AnimeData_Menu_Mn02_Mn03_Click);
            // 
            // AnimeData_Menu_Mn03
            // 
            this.AnimeData_Menu_Mn03.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AnimeData_Menu_Mn03_Mn01});
            this.AnimeData_Menu_Mn03.Name = "AnimeData_Menu_Mn03";
            this.AnimeData_Menu_Mn03.Size = new System.Drawing.Size(80, 22);
            this.AnimeData_Menu_Mn03.Text = "3";
            // 
            // AnimeData_Menu_Mn03_Mn01
            // 
            this.AnimeData_Menu_Mn03_Mn01.Name = "AnimeData_Menu_Mn03_Mn01";
            this.AnimeData_Menu_Mn03_Mn01.Size = new System.Drawing.Size(80, 22);
            this.AnimeData_Menu_Mn03_Mn01.Text = "1";
            this.AnimeData_Menu_Mn03_Mn01.Click += new System.EventHandler(this.AnimeData_Menu_Mn03_Mn01_Click);
            // 
            // AnimeData_Menu_Mn05
            // 
            this.AnimeData_Menu_Mn05.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AnimeData_Menu_Mn05_Mn01,
            this.AnimeData_Menu_Mn05_Mn02,
            this.AnimeData_Menu_Mn05_Mn03,
            this.AnimeData_Menu_Mn05_Mn04,
            this.AnimeData_Menu_Mn05_Mn05});
            this.AnimeData_Menu_Mn05.Name = "AnimeData_Menu_Mn05";
            this.AnimeData_Menu_Mn05.Size = new System.Drawing.Size(80, 22);
            this.AnimeData_Menu_Mn05.Text = "5";
            // 
            // AnimeData_Menu_Mn05_Mn01
            // 
            this.AnimeData_Menu_Mn05_Mn01.Name = "AnimeData_Menu_Mn05_Mn01";
            this.AnimeData_Menu_Mn05_Mn01.Size = new System.Drawing.Size(80, 22);
            this.AnimeData_Menu_Mn05_Mn01.Text = "1";
            this.AnimeData_Menu_Mn05_Mn01.Click += new System.EventHandler(this.AnimeData_Menu_Mn05_Mn01_Click);
            // 
            // AnimeData_Menu_Mn05_Mn02
            // 
            this.AnimeData_Menu_Mn05_Mn02.Name = "AnimeData_Menu_Mn05_Mn02";
            this.AnimeData_Menu_Mn05_Mn02.Size = new System.Drawing.Size(80, 22);
            this.AnimeData_Menu_Mn05_Mn02.Text = "2";
            this.AnimeData_Menu_Mn05_Mn02.Click += new System.EventHandler(this.AnimeData_Menu_Mn05_Mn02_Click);
            // 
            // AnimeData_Menu_Mn05_Mn03
            // 
            this.AnimeData_Menu_Mn05_Mn03.Name = "AnimeData_Menu_Mn05_Mn03";
            this.AnimeData_Menu_Mn05_Mn03.Size = new System.Drawing.Size(80, 22);
            this.AnimeData_Menu_Mn05_Mn03.Text = "3";
            this.AnimeData_Menu_Mn05_Mn03.Click += new System.EventHandler(this.AnimeData_Menu_Mn05_Mn03_Click);
            // 
            // AnimeData_Menu_Mn05_Mn04
            // 
            this.AnimeData_Menu_Mn05_Mn04.Name = "AnimeData_Menu_Mn05_Mn04";
            this.AnimeData_Menu_Mn05_Mn04.Size = new System.Drawing.Size(80, 22);
            this.AnimeData_Menu_Mn05_Mn04.Text = "4";
            this.AnimeData_Menu_Mn05_Mn04.Click += new System.EventHandler(this.AnimeData_Menu_Mn05_Mn04_Click);
            // 
            // AnimeData_Menu_Mn05_Mn05
            // 
            this.AnimeData_Menu_Mn05_Mn05.Name = "AnimeData_Menu_Mn05_Mn05";
            this.AnimeData_Menu_Mn05_Mn05.Size = new System.Drawing.Size(80, 22);
            this.AnimeData_Menu_Mn05_Mn05.Text = "5";
            this.AnimeData_Menu_Mn05_Mn05.Click += new System.EventHandler(this.AnimeData_Menu_Mn05_Mn05_Click);
            // 
            // AnimeData_Menu_Mn04
            // 
            this.AnimeData_Menu_Mn04.Name = "AnimeData_Menu_Mn04";
            this.AnimeData_Menu_Mn04.Size = new System.Drawing.Size(80, 22);
            this.AnimeData_Menu_Mn04.Text = "4";
            this.AnimeData_Menu_Mn04.Click += new System.EventHandler(this.AnimeData_Menu_Mn04_Click);
            // 
            // AnimeData_Menu_Mn06
            // 
            this.AnimeData_Menu_Mn06.Name = "AnimeData_Menu_Mn06";
            this.AnimeData_Menu_Mn06.Size = new System.Drawing.Size(80, 22);
            this.AnimeData_Menu_Mn06.Text = "6";
            this.AnimeData_Menu_Mn06.Click += new System.EventHandler(this.AnimeData_Menu_Mn06_Click);
            // 
            // FRename_W
            // 
            this.FRename_W.WorkerReportsProgress = true;
            this.FRename_W.WorkerSupportsCancellation = true;
            this.FRename_W.DoWork += new System.ComponentModel.DoWorkEventHandler(this.FRename_W_DoWork);
            this.FRename_W.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.FRename_W_ProgressChanged);
            this.FRename_W.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.FRename_W_RunWorkerCompleted);
            // 
            // Manga_Data_Menu
            // 
            this.Manga_Data_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Manga_Data_Menu_Mn02,
            this.Manga_Data_Menu_Mn03,
            this.Manga_Data_Menu_Mn04});
            this.Manga_Data_Menu.Name = "Manga_Data_Menu";
            this.Manga_Data_Menu.Size = new System.Drawing.Size(81, 70);
            // 
            // Manga_Data_Menu_Mn02
            // 
            this.Manga_Data_Menu_Mn02.Name = "Manga_Data_Menu_Mn02";
            this.Manga_Data_Menu_Mn02.Size = new System.Drawing.Size(80, 22);
            this.Manga_Data_Menu_Mn02.Text = "2";
            this.Manga_Data_Menu_Mn02.Click += new System.EventHandler(this.Manga_Data_Menu_Mn02_Click);
            // 
            // Manga_Data_Menu_Mn03
            // 
            this.Manga_Data_Menu_Mn03.Name = "Manga_Data_Menu_Mn03";
            this.Manga_Data_Menu_Mn03.Size = new System.Drawing.Size(80, 22);
            this.Manga_Data_Menu_Mn03.Text = "3";
            this.Manga_Data_Menu_Mn03.Click += new System.EventHandler(this.Manga_Data_Menu_Mn03_Click);
            // 
            // Manga_Data_Menu_Mn04
            // 
            this.Manga_Data_Menu_Mn04.Name = "Manga_Data_Menu_Mn04";
            this.Manga_Data_Menu_Mn04.Size = new System.Drawing.Size(80, 22);
            this.Manga_Data_Menu_Mn04.Text = "4";
            this.Manga_Data_Menu_Mn04.Click += new System.EventHandler(this.Manga_Data_Menu_Mn04_Click);
            // 
            // StatusBar_ConnectLabel
            // 
            this.StatusBar_ConnectLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.StatusBar_ConnectLabel.ForeColor = System.Drawing.Color.Black;
            this.StatusBar_ConnectLabel.Location = new System.Drawing.Point(896, 0);
            this.StatusBar_ConnectLabel.Name = "StatusBar_ConnectLabel";
            this.StatusBar_ConnectLabel.Size = new System.Drawing.Size(85, 23);
            this.StatusBar_ConnectLabel.TabIndex = 0;
            this.StatusBar_ConnectLabel.Text = "label1";
            this.StatusBar_ConnectLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.StatusBar_ProgressBar);
            this.panel2.Controls.Add(this.StatusBar_Mn06);
            this.panel2.Controls.Add(this.StatusBar_Mn05);
            this.panel2.Controls.Add(this.StatusBar_Mn04);
            this.panel2.Controls.Add(this.StatusBar_Mn03);
            this.panel2.Controls.Add(this.StatusBar_Mn02);
            this.panel2.Controls.Add(this.StatusBar_TasksRemainingLabel);
            this.panel2.Controls.Add(this.StatusBar_ConnectLabel);
            this.panel2.Controls.Add(this.StatusBar_Connect);
            this.panel2.Controls.Add(this.StatusBar_Hash);
            this.panel2.Controls.Add(this.StatusBar_Refresh);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 724);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1151, 23);
            this.panel2.TabIndex = 0;
            // 
            // StatusBar_ProgressBar
            // 
            this.StatusBar_ProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusBar_ProgressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(219)))), ((int)(((byte)(58)))));
            this.StatusBar_ProgressBar.Location = new System.Drawing.Point(661, 0);
            this.StatusBar_ProgressBar.Name = "StatusBar_ProgressBar";
            this.StatusBar_ProgressBar.Size = new System.Drawing.Size(46, 20);
            this.StatusBar_ProgressBar.TabIndex = 0;
            // 
            // StatusBar_Mn06
            // 
            this.StatusBar_Mn06.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.StatusBar_Mn06.Location = new System.Drawing.Point(710, 0);
            this.StatusBar_Mn06.Margin = new System.Windows.Forms.Padding(0);
            this.StatusBar_Mn06.Name = "StatusBar_Mn06";
            this.StatusBar_Mn06.Size = new System.Drawing.Size(68, 23);
            this.StatusBar_Mn06.TabIndex = 0;
            this.StatusBar_Mn06.Text = "100%/100%";
            this.StatusBar_Mn06.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StatusBar_Mn05
            // 
            this.StatusBar_Mn05.Location = new System.Drawing.Point(558, 0);
            this.StatusBar_Mn05.Margin = new System.Windows.Forms.Padding(0);
            this.StatusBar_Mn05.Name = "StatusBar_Mn05";
            this.StatusBar_Mn05.Size = new System.Drawing.Size(100, 23);
            this.StatusBar_Mn05.TabIndex = 0;
            this.StatusBar_Mn05.Text = "label1";
            this.StatusBar_Mn05.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StatusBar_Mn04
            // 
            this.StatusBar_Mn04.Location = new System.Drawing.Point(288, 0);
            this.StatusBar_Mn04.Margin = new System.Windows.Forms.Padding(0);
            this.StatusBar_Mn04.Name = "StatusBar_Mn04";
            this.StatusBar_Mn04.Size = new System.Drawing.Size(200, 23);
            this.StatusBar_Mn04.TabIndex = 0;
            this.StatusBar_Mn04.Text = "label1";
            this.StatusBar_Mn04.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatusBar_Mn03
            // 
            this.StatusBar_Mn03.Location = new System.Drawing.Point(218, 0);
            this.StatusBar_Mn03.Margin = new System.Windows.Forms.Padding(0);
            this.StatusBar_Mn03.Name = "StatusBar_Mn03";
            this.StatusBar_Mn03.Size = new System.Drawing.Size(70, 23);
            this.StatusBar_Mn03.TabIndex = 0;
            this.StatusBar_Mn03.Text = "label1";
            this.StatusBar_Mn03.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StatusBar_Mn02
            // 
            this.StatusBar_Mn02.Location = new System.Drawing.Point(168, 0);
            this.StatusBar_Mn02.Margin = new System.Windows.Forms.Padding(0);
            this.StatusBar_Mn02.Name = "StatusBar_Mn02";
            this.StatusBar_Mn02.Size = new System.Drawing.Size(50, 23);
            this.StatusBar_Mn02.TabIndex = 0;
            this.StatusBar_Mn02.Text = "label1";
            this.StatusBar_Mn02.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatusBar_TasksRemainingLabel
            // 
            this.StatusBar_TasksRemainingLabel.Location = new System.Drawing.Point(68, 0);
            this.StatusBar_TasksRemainingLabel.Margin = new System.Windows.Forms.Padding(0);
            this.StatusBar_TasksRemainingLabel.Name = "StatusBar_TasksRemainingLabel";
            this.StatusBar_TasksRemainingLabel.Size = new System.Drawing.Size(100, 23);
            this.StatusBar_TasksRemainingLabel.TabIndex = 0;
            this.StatusBar_TasksRemainingLabel.Text = "label1";
            this.StatusBar_TasksRemainingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Notify
            // 
            this.Notify.Icon = ((System.Drawing.Icon)(resources.GetObject("Notify.Icon")));
            this.Notify.Text = "AniSub";
            this.Notify.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Notify_MouseDoubleClick);
            // 
            // StatusBar_Connect
            // 
            this.StatusBar_Connect.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.StatusBar_Connect.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("StatusBar_Connect.BackgroundImage")));
            this.StatusBar_Connect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.StatusBar_Connect.Enabled = false;
            this.StatusBar_Connect.ForeColor = System.Drawing.Color.Black;
            this.StatusBar_Connect.Location = new System.Drawing.Point(867, 0);
            this.StatusBar_Connect.Name = "StatusBar_Connect";
            this.StatusBar_Connect.Size = new System.Drawing.Size(23, 23);
            this.StatusBar_Connect.TabIndex = 0;
            this.StatusBar_Connect.UseVisualStyleBackColor = true;
            this.StatusBar_Connect.Click += new System.EventHandler(this.Options_StartComunication_Click);
            // 
            // StatusBar_Hash
            // 
            this.StatusBar_Hash.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.StatusBar_Hash.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("StatusBar_Hash.BackgroundImage")));
            this.StatusBar_Hash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.StatusBar_Hash.Enabled = false;
            this.StatusBar_Hash.ForeColor = System.Drawing.Color.Black;
            this.StatusBar_Hash.Location = new System.Drawing.Point(823, 0);
            this.StatusBar_Hash.Name = "StatusBar_Hash";
            this.StatusBar_Hash.Size = new System.Drawing.Size(23, 23);
            this.StatusBar_Hash.TabIndex = 0;
            this.StatusBar_Hash.UseVisualStyleBackColor = true;
            this.StatusBar_Hash.Click += new System.EventHandler(this.Hash_Click);
            // 
            // StatusBar_Refresh
            // 
            this.StatusBar_Refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StatusBar_Refresh.BackgroundImage = global::AniDBClient.Properties.Resources.i_Refresh;
            this.StatusBar_Refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.StatusBar_Refresh.Location = new System.Drawing.Point(12, 0);
            this.StatusBar_Refresh.Name = "StatusBar_Refresh";
            this.StatusBar_Refresh.Size = new System.Drawing.Size(23, 23);
            this.StatusBar_Refresh.TabIndex = 0;
            this.StatusBar_Refresh.UseVisualStyleBackColor = true;
            this.StatusBar_Refresh.Click += new System.EventHandler(this.StatusBar_Refresh_Click);
            // 
            // Options_CH13BT
            // 
            this.Options_CH13BT.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Options_CH13BT.BackgroundImage")));
            this.Options_CH13BT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Options_CH13BT.ForeColor = System.Drawing.Color.Black;
            this.Options_CH13BT.Location = new System.Drawing.Point(369, 103);
            this.Options_CH13BT.Name = "Options_CH13BT";
            this.Options_CH13BT.Size = new System.Drawing.Size(23, 23);
            this.Options_CH13BT.TabIndex = 0;
            this.Options_CH13BT.UseVisualStyleBackColor = true;
            this.Options_CH13BT.Click += new System.EventHandler(this.Options_CH13BT_Click);
            // 
            // Options_CH11BT
            // 
            this.Options_CH11BT.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Options_CH11BT.BackgroundImage")));
            this.Options_CH11BT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Options_CH11BT.ForeColor = System.Drawing.Color.Black;
            this.Options_CH11BT.Location = new System.Drawing.Point(369, 258);
            this.Options_CH11BT.Name = "Options_CH11BT";
            this.Options_CH11BT.Size = new System.Drawing.Size(23, 23);
            this.Options_CH11BT.TabIndex = 0;
            this.Options_CH11BT.UseVisualStyleBackColor = true;
            this.Options_CH11BT.Click += new System.EventHandler(this.Options_CH11BT_Click);
            // 
            // Options_CH12BT
            // 
            this.Options_CH12BT.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Options_CH12BT.BackgroundImage")));
            this.Options_CH12BT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Options_CH12BT.ForeColor = System.Drawing.Color.Black;
            this.Options_CH12BT.Location = new System.Drawing.Point(369, 287);
            this.Options_CH12BT.Name = "Options_CH12BT";
            this.Options_CH12BT.Size = new System.Drawing.Size(23, 23);
            this.Options_CH12BT.TabIndex = 0;
            this.Options_CH12BT.UseVisualStyleBackColor = true;
            this.Options_CH12BT.Click += new System.EventHandler(this.Options_CH12BT_Click);
            // 
            // Options_CH10BT
            // 
            this.Options_CH10BT.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Options_CH10BT.BackgroundImage")));
            this.Options_CH10BT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Options_CH10BT.ForeColor = System.Drawing.Color.Black;
            this.Options_CH10BT.Location = new System.Drawing.Point(369, 229);
            this.Options_CH10BT.Name = "Options_CH10BT";
            this.Options_CH10BT.Size = new System.Drawing.Size(23, 23);
            this.Options_CH10BT.TabIndex = 0;
            this.Options_CH10BT.UseVisualStyleBackColor = true;
            this.Options_CH10BT.Click += new System.EventHandler(this.Options_CH10BT_Click);
            // 
            // Options_CH09BT
            // 
            this.Options_CH09BT.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Options_CH09BT.BackgroundImage")));
            this.Options_CH09BT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Options_CH09BT.ForeColor = System.Drawing.Color.Black;
            this.Options_CH09BT.Location = new System.Drawing.Point(369, 200);
            this.Options_CH09BT.Name = "Options_CH09BT";
            this.Options_CH09BT.Size = new System.Drawing.Size(23, 23);
            this.Options_CH09BT.TabIndex = 0;
            this.Options_CH09BT.UseVisualStyleBackColor = true;
            this.Options_CH09BT.Click += new System.EventHandler(this.Options_CH09BT_Click);
            // 
            // Options_CH07BT
            // 
            this.Options_CH07BT.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Options_CH07BT.BackgroundImage")));
            this.Options_CH07BT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Options_CH07BT.ForeColor = System.Drawing.Color.Black;
            this.Options_CH07BT.Location = new System.Drawing.Point(369, 142);
            this.Options_CH07BT.Name = "Options_CH07BT";
            this.Options_CH07BT.Size = new System.Drawing.Size(23, 23);
            this.Options_CH07BT.TabIndex = 0;
            this.Options_CH07BT.UseVisualStyleBackColor = true;
            this.Options_CH07BT.Click += new System.EventHandler(this.Options_CH07BT_Click);
            // 
            // Options_CH08BT
            // 
            this.Options_CH08BT.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Options_CH08BT.BackgroundImage")));
            this.Options_CH08BT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Options_CH08BT.ForeColor = System.Drawing.Color.Black;
            this.Options_CH08BT.Location = new System.Drawing.Point(369, 171);
            this.Options_CH08BT.Name = "Options_CH08BT";
            this.Options_CH08BT.Size = new System.Drawing.Size(23, 23);
            this.Options_CH08BT.TabIndex = 0;
            this.Options_CH08BT.UseVisualStyleBackColor = true;
            this.Options_CH08BT.Click += new System.EventHandler(this.Options_CH08BT_Click);
            // 
            // Options_CH06BT
            // 
            this.Options_CH06BT.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Options_CH06BT.BackgroundImage")));
            this.Options_CH06BT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Options_CH06BT.ForeColor = System.Drawing.Color.Black;
            this.Options_CH06BT.Location = new System.Drawing.Point(369, 113);
            this.Options_CH06BT.Name = "Options_CH06BT";
            this.Options_CH06BT.Size = new System.Drawing.Size(23, 23);
            this.Options_CH06BT.TabIndex = 0;
            this.Options_CH06BT.UseVisualStyleBackColor = true;
            this.Options_CH06BT.Click += new System.EventHandler(this.Options_CH06BT_Click);
            // 
            // Options_CH05BT
            // 
            this.Options_CH05BT.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Options_CH05BT.BackgroundImage")));
            this.Options_CH05BT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Options_CH05BT.ForeColor = System.Drawing.Color.Black;
            this.Options_CH05BT.Location = new System.Drawing.Point(369, 84);
            this.Options_CH05BT.Name = "Options_CH05BT";
            this.Options_CH05BT.Size = new System.Drawing.Size(23, 23);
            this.Options_CH05BT.TabIndex = 0;
            this.Options_CH05BT.UseVisualStyleBackColor = true;
            this.Options_CH05BT.Click += new System.EventHandler(this.Options_CH05BT_Click);
            // 
            // Options_CH04BT
            // 
            this.Options_CH04BT.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Options_CH04BT.BackgroundImage")));
            this.Options_CH04BT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Options_CH04BT.ForeColor = System.Drawing.Color.Black;
            this.Options_CH04BT.Location = new System.Drawing.Point(369, 55);
            this.Options_CH04BT.Name = "Options_CH04BT";
            this.Options_CH04BT.Size = new System.Drawing.Size(23, 23);
            this.Options_CH04BT.TabIndex = 0;
            this.Options_CH04BT.UseVisualStyleBackColor = true;
            this.Options_CH04BT.Click += new System.EventHandler(this.Options_CH04BT_Click);
            // 
            // Options_CH03BT
            // 
            this.Options_CH03BT.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Options_CH03BT.BackgroundImage")));
            this.Options_CH03BT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Options_CH03BT.ForeColor = System.Drawing.Color.Black;
            this.Options_CH03BT.Location = new System.Drawing.Point(369, 26);
            this.Options_CH03BT.Name = "Options_CH03BT";
            this.Options_CH03BT.Size = new System.Drawing.Size(23, 23);
            this.Options_CH03BT.TabIndex = 0;
            this.Options_CH03BT.UseVisualStyleBackColor = true;
            this.Options_CH03BT.Click += new System.EventHandler(this.Options_CH03BT_Click);
            // 
            // Watcher_Delete
            // 
            this.Watcher_Delete.BackgroundImage = global::AniDBClient.Properties.Resources.i_Delete;
            this.Watcher_Delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Watcher_Delete.ForeColor = System.Drawing.Color.Black;
            this.Watcher_Delete.Location = new System.Drawing.Point(490, 302);
            this.Watcher_Delete.Name = "Watcher_Delete";
            this.Watcher_Delete.Size = new System.Drawing.Size(21, 21);
            this.Watcher_Delete.TabIndex = 3;
            this.Watcher_Delete.UseVisualStyleBackColor = true;
            this.Watcher_Delete.Click += new System.EventHandler(this.Watcher_Delete_Click);
            // 
            // Watcher_Add
            // 
            this.Watcher_Add.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Watcher_Add.BackgroundImage")));
            this.Watcher_Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Watcher_Add.ForeColor = System.Drawing.Color.Black;
            this.Watcher_Add.Location = new System.Drawing.Point(463, 302);
            this.Watcher_Add.Name = "Watcher_Add";
            this.Watcher_Add.Size = new System.Drawing.Size(21, 21);
            this.Watcher_Add.TabIndex = 4;
            this.Watcher_Add.UseVisualStyleBackColor = true;
            this.Watcher_Add.Click += new System.EventHandler(this.Watcher_Add_Click);
            // 
            // Options_ExtensionRem
            // 
            this.Options_ExtensionRem.BackgroundImage = global::AniDBClient.Properties.Resources.i_Delete;
            this.Options_ExtensionRem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Options_ExtensionRem.Location = new System.Drawing.Point(490, 275);
            this.Options_ExtensionRem.Name = "Options_ExtensionRem";
            this.Options_ExtensionRem.Size = new System.Drawing.Size(21, 21);
            this.Options_ExtensionRem.TabIndex = 0;
            this.Options_ExtensionRem.UseVisualStyleBackColor = true;
            this.Options_ExtensionRem.Click += new System.EventHandler(this.Options_ExtensionRem_Click);
            // 
            // Options_AccountChange
            // 
            this.Options_AccountChange.BackgroundImage = global::AniDBClient.Properties.Resources.i_Log_Out;
            this.Options_AccountChange.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Options_AccountChange.ForeColor = System.Drawing.Color.Black;
            this.Options_AccountChange.Location = new System.Drawing.Point(463, 119);
            this.Options_AccountChange.Name = "Options_AccountChange";
            this.Options_AccountChange.Size = new System.Drawing.Size(21, 21);
            this.Options_AccountChange.TabIndex = 0;
            this.Options_AccountChange.UseVisualStyleBackColor = true;
            this.Options_AccountChange.Click += new System.EventHandler(this.Options_AccountChange_Click);
            // 
            // Options_ExtensionAdd
            // 
            this.Options_ExtensionAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Options_ExtensionAdd.BackgroundImage")));
            this.Options_ExtensionAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Options_ExtensionAdd.ForeColor = System.Drawing.Color.Black;
            this.Options_ExtensionAdd.Location = new System.Drawing.Point(463, 275);
            this.Options_ExtensionAdd.Name = "Options_ExtensionAdd";
            this.Options_ExtensionAdd.Size = new System.Drawing.Size(21, 21);
            this.Options_ExtensionAdd.TabIndex = 0;
            this.Options_ExtensionAdd.UseVisualStyleBackColor = true;
            this.Options_ExtensionAdd.Click += new System.EventHandler(this.Options_ExtensionAdd_Click);
            // 
            // Options_w8Hack
            // 
            this.Options_w8Hack.BackgroundImage = global::AniDBClient.Properties.Resources.i_w8;
            this.Options_w8Hack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Options_w8Hack.ForeColor = System.Drawing.Color.Black;
            this.Options_w8Hack.Location = new System.Drawing.Point(867, 306);
            this.Options_w8Hack.Name = "Options_w8Hack";
            this.Options_w8Hack.Size = new System.Drawing.Size(36, 36);
            this.Options_w8Hack.TabIndex = 0;
            this.Options_w8Hack.UseVisualStyleBackColor = true;
            this.Options_w8Hack.Click += new System.EventHandler(this.Options_w8Hack_Click);
            // 
            // Options_SetingsDefault
            // 
            this.Options_SetingsDefault.BackgroundImage = global::AniDBClient.Properties.Resources.i_StockIndexDown;
            this.Options_SetingsDefault.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Options_SetingsDefault.ForeColor = System.Drawing.Color.Black;
            this.Options_SetingsDefault.Location = new System.Drawing.Point(925, 306);
            this.Options_SetingsDefault.Name = "Options_SetingsDefault";
            this.Options_SetingsDefault.Size = new System.Drawing.Size(36, 36);
            this.Options_SetingsDefault.TabIndex = 0;
            this.Options_SetingsDefault.UseVisualStyleBackColor = true;
            this.Options_SetingsDefault.Click += new System.EventHandler(this.Options_SetingsDefault_Click);
            // 
            // Options_SetingsLoad
            // 
            this.Options_SetingsLoad.BackgroundImage = global::AniDBClient.Properties.Resources.i_StockIndexUp;
            this.Options_SetingsLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Options_SetingsLoad.ForeColor = System.Drawing.Color.Black;
            this.Options_SetingsLoad.Location = new System.Drawing.Point(983, 306);
            this.Options_SetingsLoad.Name = "Options_SetingsLoad";
            this.Options_SetingsLoad.Size = new System.Drawing.Size(36, 36);
            this.Options_SetingsLoad.TabIndex = 0;
            this.Options_SetingsLoad.UseVisualStyleBackColor = true;
            this.Options_SetingsLoad.Click += new System.EventHandler(this.Options_SetingsLoad_Click);
            // 
            // Options_SetingsSave
            // 
            this.Options_SetingsSave.BackgroundImage = global::AniDBClient.Properties.Resources.i_Save;
            this.Options_SetingsSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Options_SetingsSave.ForeColor = System.Drawing.Color.Black;
            this.Options_SetingsSave.Location = new System.Drawing.Point(1044, 306);
            this.Options_SetingsSave.Name = "Options_SetingsSave";
            this.Options_SetingsSave.Size = new System.Drawing.Size(36, 36);
            this.Options_SetingsSave.TabIndex = 0;
            this.Options_SetingsSave.UseVisualStyleBackColor = true;
            this.Options_SetingsSave.Click += new System.EventHandler(this.Options_SetingsSave_Click);
            // 
            // Options_StartComunication
            // 
            this.Options_StartComunication.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Options_StartComunication.BackgroundImage")));
            this.Options_StartComunication.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Options_StartComunication.ForeColor = System.Drawing.Color.Black;
            this.Options_StartComunication.Location = new System.Drawing.Point(463, 67);
            this.Options_StartComunication.Name = "Options_StartComunication";
            this.Options_StartComunication.Size = new System.Drawing.Size(21, 21);
            this.Options_StartComunication.TabIndex = 0;
            this.Options_StartComunication.UseVisualStyleBackColor = true;
            this.Options_StartComunication.Click += new System.EventHandler(this.Options_StartComunication_Click);
            // 
            // Rules_InfoDell
            // 
            this.Rules_InfoDell.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Rules_InfoDell.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Rules_InfoDell.BackgroundImage")));
            this.Rules_InfoDell.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Rules_InfoDell.Location = new System.Drawing.Point(262, 325);
            this.Rules_InfoDell.Name = "Rules_InfoDell";
            this.Rules_InfoDell.Size = new System.Drawing.Size(23, 23);
            this.Rules_InfoDell.TabIndex = 0;
            this.Rules_InfoDell.UseVisualStyleBackColor = true;
            this.Rules_InfoDell.Click += new System.EventHandler(this.Rules_InfoDell_Click);
            // 
            // Rules_InfoAdd
            // 
            this.Rules_InfoAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Rules_InfoAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Rules_InfoAdd.BackgroundImage")));
            this.Rules_InfoAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Rules_InfoAdd.ForeColor = System.Drawing.Color.Black;
            this.Rules_InfoAdd.Location = new System.Drawing.Point(233, 325);
            this.Rules_InfoAdd.Name = "Rules_InfoAdd";
            this.Rules_InfoAdd.Size = new System.Drawing.Size(23, 23);
            this.Rules_InfoAdd.TabIndex = 0;
            this.Rules_InfoAdd.UseVisualStyleBackColor = true;
            this.Rules_InfoAdd.Click += new System.EventHandler(this.Rules_InfoAdd_Click);
            // 
            // Rules_FilesRulesMoveDel
            // 
            this.Rules_FilesRulesMoveDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Rules_FilesRulesMoveDel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Rules_FilesRulesMoveDel.BackgroundImage")));
            this.Rules_FilesRulesMoveDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Rules_FilesRulesMoveDel.Location = new System.Drawing.Point(262, 325);
            this.Rules_FilesRulesMoveDel.Name = "Rules_FilesRulesMoveDel";
            this.Rules_FilesRulesMoveDel.Size = new System.Drawing.Size(23, 23);
            this.Rules_FilesRulesMoveDel.TabIndex = 0;
            this.Rules_FilesRulesMoveDel.UseVisualStyleBackColor = true;
            this.Rules_FilesRulesMoveDel.Click += new System.EventHandler(this.Rules_FilesRulesMoveDel_Click);
            // 
            // Rules_FilesRulesMoveAdd
            // 
            this.Rules_FilesRulesMoveAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Rules_FilesRulesMoveAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Rules_FilesRulesMoveAdd.BackgroundImage")));
            this.Rules_FilesRulesMoveAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Rules_FilesRulesMoveAdd.ForeColor = System.Drawing.Color.Black;
            this.Rules_FilesRulesMoveAdd.Location = new System.Drawing.Point(233, 325);
            this.Rules_FilesRulesMoveAdd.Name = "Rules_FilesRulesMoveAdd";
            this.Rules_FilesRulesMoveAdd.Size = new System.Drawing.Size(23, 23);
            this.Rules_FilesRulesMoveAdd.TabIndex = 0;
            this.Rules_FilesRulesMoveAdd.UseVisualStyleBackColor = true;
            this.Rules_FilesRulesMoveAdd.Click += new System.EventHandler(this.Rules_FilesRulesMoveAdd_Click);
            // 
            // Rules_FilesRulesRenameDel
            // 
            this.Rules_FilesRulesRenameDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Rules_FilesRulesRenameDel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Rules_FilesRulesRenameDel.BackgroundImage")));
            this.Rules_FilesRulesRenameDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Rules_FilesRulesRenameDel.ForeColor = System.Drawing.Color.Black;
            this.Rules_FilesRulesRenameDel.Location = new System.Drawing.Point(430, 325);
            this.Rules_FilesRulesRenameDel.Name = "Rules_FilesRulesRenameDel";
            this.Rules_FilesRulesRenameDel.Size = new System.Drawing.Size(23, 23);
            this.Rules_FilesRulesRenameDel.TabIndex = 0;
            this.Rules_FilesRulesRenameDel.UseVisualStyleBackColor = true;
            this.Rules_FilesRulesRenameDel.Click += new System.EventHandler(this.Rules_FilesRulesRenameDel_Click);
            // 
            // Rules_FilesRulesRenameAdd
            // 
            this.Rules_FilesRulesRenameAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Rules_FilesRulesRenameAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Rules_FilesRulesRenameAdd.BackgroundImage")));
            this.Rules_FilesRulesRenameAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Rules_FilesRulesRenameAdd.ForeColor = System.Drawing.Color.Black;
            this.Rules_FilesRulesRenameAdd.Location = new System.Drawing.Point(401, 325);
            this.Rules_FilesRulesRenameAdd.Name = "Rules_FilesRulesRenameAdd";
            this.Rules_FilesRulesRenameAdd.Size = new System.Drawing.Size(23, 23);
            this.Rules_FilesRulesRenameAdd.TabIndex = 0;
            this.Rules_FilesRulesRenameAdd.UseVisualStyleBackColor = true;
            this.Rules_FilesRulesRenameAdd.Click += new System.EventHandler(this.Rules_FilesRulesRenameAdd_Click);
            // 
            // Hash
            // 
            this.Hash.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Hash.BackgroundImage")));
            this.Hash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Hash.Enabled = false;
            this.Hash.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Hash.ForeColor = System.Drawing.Color.Black;
            this.Hash.Location = new System.Drawing.Point(588, 21);
            this.Hash.Name = "Hash";
            this.Hash.Size = new System.Drawing.Size(36, 36);
            this.Hash.TabIndex = 0;
            this.Hash.UseVisualStyleBackColor = true;
            this.Hash.Click += new System.EventHandler(this.Hash_Click);
            // 
            // Hash_Cesta
            // 
            this.Hash_Cesta.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Hash_Cesta.BackgroundImage")));
            this.Hash_Cesta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Hash_Cesta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Hash_Cesta.ForeColor = System.Drawing.Color.Black;
            this.Hash_Cesta.Location = new System.Drawing.Point(6, 19);
            this.Hash_Cesta.Name = "Hash_Cesta";
            this.Hash_Cesta.Size = new System.Drawing.Size(36, 36);
            this.Hash_Cesta.TabIndex = 0;
            this.Hash_Cesta.UseVisualStyleBackColor = true;
            this.Hash_Cesta.Click += new System.EventHandler(this.Hash_Cesta_Click);
            // 
            // Hash_Stop_Total
            // 
            this.Hash_Stop_Total.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Hash_Stop_Total.BackgroundImage")));
            this.Hash_Stop_Total.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Hash_Stop_Total.Enabled = false;
            this.Hash_Stop_Total.ForeColor = System.Drawing.Color.Black;
            this.Hash_Stop_Total.Location = new System.Drawing.Point(630, 21);
            this.Hash_Stop_Total.Name = "Hash_Stop_Total";
            this.Hash_Stop_Total.Size = new System.Drawing.Size(36, 36);
            this.Hash_Stop_Total.TabIndex = 0;
            this.Hash_Stop_Total.UseVisualStyleBackColor = true;
            this.Hash_Stop_Total.Click += new System.EventHandler(this.Hash_Stop_Total_Click);
            // 
            // Hash_Files
            // 
            this.Hash_Files.BackgroundImage = global::AniDBClient.Properties.Resources.i_Key;
            this.Hash_Files.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Hash_Files.Enabled = false;
            this.Hash_Files.ForeColor = System.Drawing.Color.Black;
            this.Hash_Files.Location = new System.Drawing.Point(546, 21);
            this.Hash_Files.Name = "Hash_Files";
            this.Hash_Files.Size = new System.Drawing.Size(36, 36);
            this.Hash_Files.TabIndex = 0;
            this.Hash_Files.UseVisualStyleBackColor = true;
            this.Hash_Files.Click += new System.EventHandler(this.Hash_Files_Click);
            // 
            // Hash_Delete
            // 
            this.Hash_Delete.BackgroundImage = global::AniDBClient.Properties.Resources.i_Delete;
            this.Hash_Delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Hash_Delete.Enabled = false;
            this.Hash_Delete.ForeColor = System.Drawing.Color.Black;
            this.Hash_Delete.Location = new System.Drawing.Point(48, 19);
            this.Hash_Delete.Name = "Hash_Delete";
            this.Hash_Delete.Size = new System.Drawing.Size(36, 36);
            this.Hash_Delete.TabIndex = 0;
            this.Hash_Delete.UseVisualStyleBackColor = true;
            this.Hash_Delete.Click += new System.EventHandler(this.Hash_Delete_Click);
            // 
            // Hash_DeleteAll
            // 
            this.Hash_DeleteAll.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Hash_DeleteAll.BackgroundImage")));
            this.Hash_DeleteAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Hash_DeleteAll.Enabled = false;
            this.Hash_DeleteAll.ForeColor = System.Drawing.Color.Black;
            this.Hash_DeleteAll.Location = new System.Drawing.Point(90, 19);
            this.Hash_DeleteAll.Name = "Hash_DeleteAll";
            this.Hash_DeleteAll.Size = new System.Drawing.Size(36, 36);
            this.Hash_DeleteAll.TabIndex = 0;
            this.Hash_DeleteAll.UseVisualStyleBackColor = true;
            this.Hash_DeleteAll.Click += new System.EventHandler(this.Hash_DeleteAll_Click);
            // 
            // Options_MyListRefreshMin
            // 
            this.Options_MyListRefreshMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Options_MyListRefreshMin.BackgroundImage = global::AniDBClient.Properties.Resources.i_Refresh;
            this.Options_MyListRefreshMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Options_MyListRefreshMin.Location = new System.Drawing.Point(48, 622);
            this.Options_MyListRefreshMin.Name = "Options_MyListRefreshMin";
            this.Options_MyListRefreshMin.Size = new System.Drawing.Size(36, 36);
            this.Options_MyListRefreshMin.TabIndex = 0;
            this.Options_MyListRefreshMin.UseVisualStyleBackColor = true;
            this.Options_MyListRefreshMin.Click += new System.EventHandler(this.Options_MyListRefreshMin_Click);
            // 
            // Options_MyListRefresh
            // 
            this.Options_MyListRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Options_MyListRefresh.BackgroundImage = global::AniDBClient.Properties.Resources.i_Refresh;
            this.Options_MyListRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Options_MyListRefresh.Location = new System.Drawing.Point(6, 622);
            this.Options_MyListRefresh.Name = "Options_MyListRefresh";
            this.Options_MyListRefresh.Size = new System.Drawing.Size(36, 36);
            this.Options_MyListRefresh.TabIndex = 0;
            this.Options_MyListRefresh.UseVisualStyleBackColor = true;
            this.Options_MyListRefresh.Click += new System.EventHandler(this.Options_MyListRefresh_Click);
            // 
            // DataFiles_Bt21
            // 
            this.DataFiles_Bt21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DataFiles_Bt21.BackgroundImage = global::AniDBClient.Properties.Resources.i_Information;
            this.DataFiles_Bt21.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DataFiles_Bt21.Location = new System.Drawing.Point(731, 619);
            this.DataFiles_Bt21.Name = "DataFiles_Bt21";
            this.DataFiles_Bt21.Size = new System.Drawing.Size(23, 23);
            this.DataFiles_Bt21.TabIndex = 0;
            this.DataFiles_Bt21.UseVisualStyleBackColor = true;
            this.DataFiles_Bt21.Click += new System.EventHandler(this.DataFiles_Bt21_Click);
            // 
            // DataFiles_Bt22
            // 
            this.DataFiles_Bt22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DataFiles_Bt22.BackgroundImage = global::AniDBClient.Properties.Resources.i_Help;
            this.DataFiles_Bt22.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DataFiles_Bt22.Location = new System.Drawing.Point(673, 619);
            this.DataFiles_Bt22.Name = "DataFiles_Bt22";
            this.DataFiles_Bt22.Size = new System.Drawing.Size(23, 23);
            this.DataFiles_Bt22.TabIndex = 0;
            this.DataFiles_Bt22.UseVisualStyleBackColor = true;
            this.DataFiles_Bt22.Click += new System.EventHandler(this.DataFiles_Bt22_Click);
            // 
            // DataFiles_Bt20
            // 
            this.DataFiles_Bt20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DataFiles_Bt20.BackgroundImage = global::AniDBClient.Properties.Resources.i_Help;
            this.DataFiles_Bt20.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DataFiles_Bt20.Location = new System.Drawing.Point(702, 619);
            this.DataFiles_Bt20.Name = "DataFiles_Bt20";
            this.DataFiles_Bt20.Size = new System.Drawing.Size(23, 23);
            this.DataFiles_Bt20.TabIndex = 0;
            this.DataFiles_Bt20.UseVisualStyleBackColor = true;
            this.DataFiles_Bt20.Click += new System.EventHandler(this.DataFiles_Bt20_Click);
            // 
            // DataFiles_Bt19
            // 
            this.DataFiles_Bt19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DataFiles_Bt19.BackgroundImage = global::AniDBClient.Properties.Resources.i_Globe;
            this.DataFiles_Bt19.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DataFiles_Bt19.Location = new System.Drawing.Point(615, 619);
            this.DataFiles_Bt19.Name = "DataFiles_Bt19";
            this.DataFiles_Bt19.Size = new System.Drawing.Size(23, 23);
            this.DataFiles_Bt19.TabIndex = 0;
            this.DataFiles_Bt19.UseVisualStyleBackColor = true;
            this.DataFiles_Bt19.Click += new System.EventHandler(this.DataFiles_Bt19_Click);
            // 
            // DataFiles_Bt00
            // 
            this.DataFiles_Bt00.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DataFiles_Bt00.BackgroundImage = global::AniDBClient.Properties.Resources.i_Refresh;
            this.DataFiles_Bt00.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DataFiles_Bt00.Location = new System.Drawing.Point(6, 619);
            this.DataFiles_Bt00.Name = "DataFiles_Bt00";
            this.DataFiles_Bt00.Size = new System.Drawing.Size(23, 23);
            this.DataFiles_Bt00.TabIndex = 0;
            this.DataFiles_Bt00.UseVisualStyleBackColor = true;
            this.DataFiles_Bt00.Click += new System.EventHandler(this.DataFiles_Bt01_Click);
            // 
            // DataFiles_Bt01
            // 
            this.DataFiles_Bt01.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DataFiles_Bt01.BackgroundImage = global::AniDBClient.Properties.Resources.i_Delete;
            this.DataFiles_Bt01.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DataFiles_Bt01.Location = new System.Drawing.Point(35, 619);
            this.DataFiles_Bt01.Name = "DataFiles_Bt01";
            this.DataFiles_Bt01.Size = new System.Drawing.Size(23, 23);
            this.DataFiles_Bt01.TabIndex = 0;
            this.DataFiles_Bt01.UseVisualStyleBackColor = true;
            this.DataFiles_Bt01.Click += new System.EventHandler(this.DataFiles_Bt01_Click);
            // 
            // DataFiles_Bt18
            // 
            this.DataFiles_Bt18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DataFiles_Bt18.BackgroundImage = global::AniDBClient.Properties.Resources.anidb_file_removemylist;
            this.DataFiles_Bt18.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DataFiles_Bt18.Location = new System.Drawing.Point(557, 619);
            this.DataFiles_Bt18.Name = "DataFiles_Bt18";
            this.DataFiles_Bt18.Size = new System.Drawing.Size(23, 23);
            this.DataFiles_Bt18.TabIndex = 0;
            this.DataFiles_Bt18.UseVisualStyleBackColor = true;
            this.DataFiles_Bt18.Click += new System.EventHandler(this.DataFiles_Bt01_Click);
            // 
            // DataFiles_Bt17
            // 
            this.DataFiles_Bt17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DataFiles_Bt17.BackgroundImage = global::AniDBClient.Properties.Resources.anidb_file_addmylist;
            this.DataFiles_Bt17.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DataFiles_Bt17.Location = new System.Drawing.Point(528, 619);
            this.DataFiles_Bt17.Name = "DataFiles_Bt17";
            this.DataFiles_Bt17.Size = new System.Drawing.Size(23, 23);
            this.DataFiles_Bt17.TabIndex = 0;
            this.DataFiles_Bt17.UseVisualStyleBackColor = true;
            this.DataFiles_Bt17.Click += new System.EventHandler(this.DataFiles_Bt01_Click);
            // 
            // DataFiles_Bt16
            // 
            this.DataFiles_Bt16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DataFiles_Bt16.BackgroundImage = global::AniDBClient.Properties.Resources.anidb_atype_other;
            this.DataFiles_Bt16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DataFiles_Bt16.Location = new System.Drawing.Point(499, 619);
            this.DataFiles_Bt16.Name = "DataFiles_Bt16";
            this.DataFiles_Bt16.Size = new System.Drawing.Size(23, 23);
            this.DataFiles_Bt16.TabIndex = 0;
            this.DataFiles_Bt16.UseVisualStyleBackColor = true;
            this.DataFiles_Bt16.Click += new System.EventHandler(this.DataFiles_Bt01_Click);
            // 
            // DataFiles_Bt15
            // 
            this.DataFiles_Bt15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DataFiles_Bt15.BackgroundImage = global::AniDBClient.Properties.Resources.anidb_atype_web;
            this.DataFiles_Bt15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DataFiles_Bt15.Location = new System.Drawing.Point(470, 619);
            this.DataFiles_Bt15.Name = "DataFiles_Bt15";
            this.DataFiles_Bt15.Size = new System.Drawing.Size(23, 23);
            this.DataFiles_Bt15.TabIndex = 0;
            this.DataFiles_Bt15.UseVisualStyleBackColor = true;
            this.DataFiles_Bt15.Click += new System.EventHandler(this.DataFiles_Bt01_Click);
            // 
            // DataFiles_Bt14
            // 
            this.DataFiles_Bt14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DataFiles_Bt14.BackgroundImage = global::AniDBClient.Properties.Resources.anidb_atype_tv_series;
            this.DataFiles_Bt14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DataFiles_Bt14.Location = new System.Drawing.Point(441, 619);
            this.DataFiles_Bt14.Name = "DataFiles_Bt14";
            this.DataFiles_Bt14.Size = new System.Drawing.Size(23, 23);
            this.DataFiles_Bt14.TabIndex = 0;
            this.DataFiles_Bt14.UseVisualStyleBackColor = true;
            this.DataFiles_Bt14.Click += new System.EventHandler(this.DataFiles_Bt01_Click);
            // 
            // DataFiles_Bt13
            // 
            this.DataFiles_Bt13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DataFiles_Bt13.BackgroundImage = global::AniDBClient.Properties.Resources.Anidb_filestate_ondvd;
            this.DataFiles_Bt13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DataFiles_Bt13.Location = new System.Drawing.Point(412, 619);
            this.DataFiles_Bt13.Name = "DataFiles_Bt13";
            this.DataFiles_Bt13.Size = new System.Drawing.Size(23, 23);
            this.DataFiles_Bt13.TabIndex = 0;
            this.DataFiles_Bt13.UseVisualStyleBackColor = true;
            this.DataFiles_Bt13.Click += new System.EventHandler(this.DataFiles_Bt01_Click);
            // 
            // DataFiles_Bt12
            // 
            this.DataFiles_Bt12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DataFiles_Bt12.BackgroundImage = global::AniDBClient.Properties.Resources.anidb_atype_tv_special;
            this.DataFiles_Bt12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DataFiles_Bt12.Location = new System.Drawing.Point(383, 619);
            this.DataFiles_Bt12.Name = "DataFiles_Bt12";
            this.DataFiles_Bt12.Size = new System.Drawing.Size(23, 23);
            this.DataFiles_Bt12.TabIndex = 0;
            this.DataFiles_Bt12.UseVisualStyleBackColor = true;
            this.DataFiles_Bt12.Click += new System.EventHandler(this.DataFiles_Bt01_Click);
            // 
            // DataFiles_Bt11
            // 
            this.DataFiles_Bt11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DataFiles_Bt11.BackgroundImage = global::AniDBClient.Properties.Resources.anidb_atype_ova;
            this.DataFiles_Bt11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DataFiles_Bt11.Location = new System.Drawing.Point(354, 619);
            this.DataFiles_Bt11.Name = "DataFiles_Bt11";
            this.DataFiles_Bt11.Size = new System.Drawing.Size(23, 23);
            this.DataFiles_Bt11.TabIndex = 0;
            this.DataFiles_Bt11.UseVisualStyleBackColor = true;
            this.DataFiles_Bt11.Click += new System.EventHandler(this.DataFiles_Bt01_Click);
            // 
            // DataFiles_Bt10
            // 
            this.DataFiles_Bt10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DataFiles_Bt10.BackColor = System.Drawing.Color.White;
            this.DataFiles_Bt10.BackgroundImage = global::AniDBClient.Properties.Resources.anidb_seen_yes;
            this.DataFiles_Bt10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DataFiles_Bt10.Location = new System.Drawing.Point(325, 619);
            this.DataFiles_Bt10.Name = "DataFiles_Bt10";
            this.DataFiles_Bt10.Size = new System.Drawing.Size(23, 23);
            this.DataFiles_Bt10.TabIndex = 0;
            this.DataFiles_Bt10.UseVisualStyleBackColor = false;
            this.DataFiles_Bt10.Click += new System.EventHandler(this.DataFiles_Bt01_Click);
            // 
            // DataFiles_Bt09
            // 
            this.DataFiles_Bt09.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DataFiles_Bt09.BackgroundImage = global::AniDBClient.Properties.Resources.anidb_seen_no;
            this.DataFiles_Bt09.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DataFiles_Bt09.Location = new System.Drawing.Point(296, 619);
            this.DataFiles_Bt09.Name = "DataFiles_Bt09";
            this.DataFiles_Bt09.Size = new System.Drawing.Size(23, 23);
            this.DataFiles_Bt09.TabIndex = 0;
            this.DataFiles_Bt09.UseVisualStyleBackColor = true;
            this.DataFiles_Bt09.Click += new System.EventHandler(this.DataFiles_Bt01_Click);
            // 
            // DataFiles_Bt08
            // 
            this.DataFiles_Bt08.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DataFiles_Bt08.BackgroundImage = global::AniDBClient.Properties.Resources.anidb_state_release;
            this.DataFiles_Bt08.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DataFiles_Bt08.Location = new System.Drawing.Point(267, 619);
            this.DataFiles_Bt08.Name = "DataFiles_Bt08";
            this.DataFiles_Bt08.Size = new System.Drawing.Size(23, 23);
            this.DataFiles_Bt08.TabIndex = 0;
            this.DataFiles_Bt08.UseVisualStyleBackColor = true;
            this.DataFiles_Bt08.Click += new System.EventHandler(this.DataFiles_Bt01_Click);
            // 
            // DataFiles_Bt07
            // 
            this.DataFiles_Bt07.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DataFiles_Bt07.BackgroundImage = global::AniDBClient.Properties.Resources.anidb_filestate_other;
            this.DataFiles_Bt07.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DataFiles_Bt07.Location = new System.Drawing.Point(238, 619);
            this.DataFiles_Bt07.Name = "DataFiles_Bt07";
            this.DataFiles_Bt07.Size = new System.Drawing.Size(23, 23);
            this.DataFiles_Bt07.TabIndex = 0;
            this.DataFiles_Bt07.UseVisualStyleBackColor = true;
            this.DataFiles_Bt07.Click += new System.EventHandler(this.DataFiles_Bt01_Click);
            // 
            // DataFiles_Bt06
            // 
            this.DataFiles_Bt06.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DataFiles_Bt06.BackgroundImage = global::AniDBClient.Properties.Resources.anidb_state_shared;
            this.DataFiles_Bt06.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DataFiles_Bt06.Location = new System.Drawing.Point(209, 619);
            this.DataFiles_Bt06.Name = "DataFiles_Bt06";
            this.DataFiles_Bt06.Size = new System.Drawing.Size(23, 23);
            this.DataFiles_Bt06.TabIndex = 0;
            this.DataFiles_Bt06.UseVisualStyleBackColor = true;
            this.DataFiles_Bt06.Click += new System.EventHandler(this.DataFiles_Bt01_Click);
            // 
            // DataFiles_Bt05
            // 
            this.DataFiles_Bt05.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DataFiles_Bt05.BackgroundImage = global::AniDBClient.Properties.Resources.anidb_state_unknown;
            this.DataFiles_Bt05.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DataFiles_Bt05.Location = new System.Drawing.Point(180, 619);
            this.DataFiles_Bt05.Name = "DataFiles_Bt05";
            this.DataFiles_Bt05.Size = new System.Drawing.Size(23, 23);
            this.DataFiles_Bt05.TabIndex = 0;
            this.DataFiles_Bt05.UseVisualStyleBackColor = true;
            this.DataFiles_Bt05.Click += new System.EventHandler(this.DataFiles_Bt01_Click);
            // 
            // DataFiles_Bt04
            // 
            this.DataFiles_Bt04.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DataFiles_Bt04.BackgroundImage = global::AniDBClient.Properties.Resources.anidb_state_deleted;
            this.DataFiles_Bt04.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DataFiles_Bt04.Location = new System.Drawing.Point(151, 619);
            this.DataFiles_Bt04.Name = "DataFiles_Bt04";
            this.DataFiles_Bt04.Size = new System.Drawing.Size(23, 23);
            this.DataFiles_Bt04.TabIndex = 0;
            this.DataFiles_Bt04.UseVisualStyleBackColor = true;
            this.DataFiles_Bt04.Click += new System.EventHandler(this.DataFiles_Bt01_Click);
            // 
            // DataFiles_Bt03
            // 
            this.DataFiles_Bt03.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DataFiles_Bt03.BackgroundImage = global::AniDBClient.Properties.Resources.anidb_state_oncd;
            this.DataFiles_Bt03.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DataFiles_Bt03.Location = new System.Drawing.Point(122, 619);
            this.DataFiles_Bt03.Name = "DataFiles_Bt03";
            this.DataFiles_Bt03.Size = new System.Drawing.Size(23, 23);
            this.DataFiles_Bt03.TabIndex = 0;
            this.DataFiles_Bt03.UseVisualStyleBackColor = true;
            this.DataFiles_Bt03.Click += new System.EventHandler(this.DataFiles_Bt01_Click);
            // 
            // DataFiles_Bt02
            // 
            this.DataFiles_Bt02.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DataFiles_Bt02.BackgroundImage = global::AniDBClient.Properties.Resources.anidb_state_onhdd;
            this.DataFiles_Bt02.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DataFiles_Bt02.Location = new System.Drawing.Point(93, 619);
            this.DataFiles_Bt02.Name = "DataFiles_Bt02";
            this.DataFiles_Bt02.Size = new System.Drawing.Size(23, 23);
            this.DataFiles_Bt02.TabIndex = 0;
            this.DataFiles_Bt02.UseVisualStyleBackColor = true;
            this.DataFiles_Bt02.Click += new System.EventHandler(this.DataFiles_Bt01_Click);
            // 
            // Anime_Rel
            // 
            this.Anime_Rel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Anime_Rel.Location = new System.Drawing.Point(211, 14);
            this.Anime_Rel.Name = "Anime_Rel";
            this.Anime_Rel.Size = new System.Drawing.Size(15, 15);
            this.Anime_Rel.TabIndex = 0;
            this.Anime_Rel.TabStop = false;
            this.Anime_Rel.Visible = false;
            // 
            // Anime_DateOK
            // 
            this.Anime_DateOK.Location = new System.Drawing.Point(479, 141);
            this.Anime_DateOK.Name = "Anime_DateOK";
            this.Anime_DateOK.Size = new System.Drawing.Size(13, 13);
            this.Anime_DateOK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Anime_DateOK.TabIndex = 2;
            this.Anime_DateOK.TabStop = false;
            // 
            // Anime_RatImg
            // 
            this.Anime_RatImg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Anime_RatImg.Location = new System.Drawing.Point(364, 265);
            this.Anime_RatImg.Name = "Anime_RatImg";
            this.Anime_RatImg.Size = new System.Drawing.Size(104, 20);
            this.Anime_RatImg.TabIndex = 0;
            this.Anime_RatImg.TabStop = false;
            // 
            // Anime_BT01
            // 
            this.Anime_BT01.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Anime_BT01.BackgroundImage")));
            this.Anime_BT01.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Anime_BT01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Anime_BT01.Location = new System.Drawing.Point(520, 289);
            this.Anime_BT01.Name = "Anime_BT01";
            this.Anime_BT01.Size = new System.Drawing.Size(23, 23);
            this.Anime_BT01.TabIndex = 0;
            this.Anime_BT01.UseVisualStyleBackColor = true;
            this.Anime_BT01.Click += new System.EventHandler(this.Anime_BT01_Click);
            // 
            // Anime_Img
            // 
            this.Anime_Img.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Anime_Img.Location = new System.Drawing.Point(6, 42);
            this.Anime_Img.Name = "Anime_Img";
            this.Anime_Img.Size = new System.Drawing.Size(225, 279);
            this.Anime_Img.TabIndex = 0;
            this.Anime_Img.TabStop = false;
            this.Anime_Img.DoubleClick += new System.EventHandler(this.Anime_Img_DoubleClick);
            // 
            // Anime_Lang03
            // 
            this.Anime_Lang03.Image = ((System.Drawing.Image)(resources.GetObject("Anime_Lang03.Image")));
            this.Anime_Lang03.Location = new System.Drawing.Point(61, 16);
            this.Anime_Lang03.Name = "Anime_Lang03";
            this.Anime_Lang03.Size = new System.Drawing.Size(23, 23);
            this.Anime_Lang03.TabIndex = 0;
            this.Anime_Lang03.UseVisualStyleBackColor = true;
            this.Anime_Lang03.Click += new System.EventHandler(this.Anime_Lang03_Click);
            // 
            // Anime_Lang02
            // 
            this.Anime_Lang02.Image = global::AniDBClient.Properties.Resources.anidb_audio_english;
            this.Anime_Lang02.Location = new System.Drawing.Point(32, 16);
            this.Anime_Lang02.Name = "Anime_Lang02";
            this.Anime_Lang02.Size = new System.Drawing.Size(23, 23);
            this.Anime_Lang02.TabIndex = 0;
            this.Anime_Lang02.UseVisualStyleBackColor = true;
            this.Anime_Lang02.Click += new System.EventHandler(this.Anime_Lang02_Click);
            // 
            // Anime_Lang01
            // 
            this.Anime_Lang01.Image = ((System.Drawing.Image)(resources.GetObject("Anime_Lang01.Image")));
            this.Anime_Lang01.Location = new System.Drawing.Point(3, 16);
            this.Anime_Lang01.Name = "Anime_Lang01";
            this.Anime_Lang01.Size = new System.Drawing.Size(23, 23);
            this.Anime_Lang01.TabIndex = 0;
            this.Anime_Lang01.UseVisualStyleBackColor = true;
            this.Anime_Lang01.Click += new System.EventHandler(this.Anime_Lang01_Click);
            // 
            // Zgc_GraphB06
            // 
            this.Zgc_GraphB06.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Zgc_GraphB06.BackgroundImage")));
            this.Zgc_GraphB06.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Zgc_GraphB06.Location = new System.Drawing.Point(223, 3);
            this.Zgc_GraphB06.Name = "Zgc_GraphB06";
            this.Zgc_GraphB06.Size = new System.Drawing.Size(38, 38);
            this.Zgc_GraphB06.TabIndex = 0;
            this.Zgc_GraphB06.UseVisualStyleBackColor = true;
            this.Zgc_GraphB06.Click += new System.EventHandler(this.Zgc_GraphB06_Click);
            // 
            // Zgc_GraphB05
            // 
            this.Zgc_GraphB05.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Zgc_GraphB05.BackgroundImage")));
            this.Zgc_GraphB05.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Zgc_GraphB05.Location = new System.Drawing.Point(179, 3);
            this.Zgc_GraphB05.Name = "Zgc_GraphB05";
            this.Zgc_GraphB05.Size = new System.Drawing.Size(38, 38);
            this.Zgc_GraphB05.TabIndex = 0;
            this.Zgc_GraphB05.UseVisualStyleBackColor = true;
            this.Zgc_GraphB05.Click += new System.EventHandler(this.Zgc_GraphB05_Click);
            // 
            // Zgc_GraphB04
            // 
            this.Zgc_GraphB04.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Zgc_GraphB04.BackgroundImage")));
            this.Zgc_GraphB04.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Zgc_GraphB04.Location = new System.Drawing.Point(135, 3);
            this.Zgc_GraphB04.Name = "Zgc_GraphB04";
            this.Zgc_GraphB04.Size = new System.Drawing.Size(38, 38);
            this.Zgc_GraphB04.TabIndex = 0;
            this.Zgc_GraphB04.UseVisualStyleBackColor = true;
            this.Zgc_GraphB04.Click += new System.EventHandler(this.Zgc_GraphB04_Click);
            // 
            // Zgc_GraphB03
            // 
            this.Zgc_GraphB03.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Zgc_GraphB03.BackgroundImage")));
            this.Zgc_GraphB03.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Zgc_GraphB03.Location = new System.Drawing.Point(91, 3);
            this.Zgc_GraphB03.Name = "Zgc_GraphB03";
            this.Zgc_GraphB03.Size = new System.Drawing.Size(38, 38);
            this.Zgc_GraphB03.TabIndex = 0;
            this.Zgc_GraphB03.UseVisualStyleBackColor = true;
            this.Zgc_GraphB03.Click += new System.EventHandler(this.Zgc_GraphB03_Click);
            // 
            // Zgc_GraphB02
            // 
            this.Zgc_GraphB02.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Zgc_GraphB02.BackgroundImage")));
            this.Zgc_GraphB02.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Zgc_GraphB02.Location = new System.Drawing.Point(47, 3);
            this.Zgc_GraphB02.Name = "Zgc_GraphB02";
            this.Zgc_GraphB02.Size = new System.Drawing.Size(38, 38);
            this.Zgc_GraphB02.TabIndex = 0;
            this.Zgc_GraphB02.UseVisualStyleBackColor = true;
            this.Zgc_GraphB02.Click += new System.EventHandler(this.Zgc_GraphB02_Click);
            // 
            // Zgc_GraphB01
            // 
            this.Zgc_GraphB01.BackgroundImage = global::AniDBClient.Properties.Resources.i_Picture;
            this.Zgc_GraphB01.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Zgc_GraphB01.Location = new System.Drawing.Point(3, 3);
            this.Zgc_GraphB01.Name = "Zgc_GraphB01";
            this.Zgc_GraphB01.Size = new System.Drawing.Size(38, 38);
            this.Zgc_GraphB01.TabIndex = 0;
            this.Zgc_GraphB01.UseVisualStyleBackColor = true;
            this.Zgc_GraphB01.Click += new System.EventHandler(this.Zgc_GraphB01_Click);
            // 
            // Options_MyListRefreshManga
            // 
            this.Options_MyListRefreshManga.BackgroundImage = global::AniDBClient.Properties.Resources.i_Refresh;
            this.Options_MyListRefreshManga.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Options_MyListRefreshManga.Location = new System.Drawing.Point(227, 201);
            this.Options_MyListRefreshManga.Name = "Options_MyListRefreshManga";
            this.Options_MyListRefreshManga.Size = new System.Drawing.Size(24, 24);
            this.Options_MyListRefreshManga.TabIndex = 0;
            this.Options_MyListRefreshManga.UseVisualStyleBackColor = true;
            this.Options_MyListRefreshManga.Click += new System.EventHandler(this.Options_MyListRefreshMin_Click);
            // 
            // Manga_Chapter
            // 
            this.Manga_Chapter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Manga_Chapter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Manga_Chapter.BackgroundImage")));
            this.Manga_Chapter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Manga_Chapter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Manga_Chapter.ForeColor = System.Drawing.Color.Black;
            this.Manga_Chapter.Location = new System.Drawing.Point(738, 285);
            this.Manga_Chapter.Margin = new System.Windows.Forms.Padding(10);
            this.Manga_Chapter.Name = "Manga_Chapter";
            this.Manga_Chapter.Size = new System.Drawing.Size(36, 36);
            this.Manga_Chapter.TabIndex = 0;
            this.Manga_Chapter.UseVisualStyleBackColor = true;
            this.Manga_Chapter.Click += new System.EventHandler(this.Manga_Chapter_Click);
            // 
            // Manga_Edit
            // 
            this.Manga_Edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Manga_Edit.BackgroundImage = global::AniDBClient.Properties.Resources.i_Edit;
            this.Manga_Edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Manga_Edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Manga_Edit.ForeColor = System.Drawing.Color.Black;
            this.Manga_Edit.Location = new System.Drawing.Point(794, 285);
            this.Manga_Edit.Margin = new System.Windows.Forms.Padding(10);
            this.Manga_Edit.Name = "Manga_Edit";
            this.Manga_Edit.Size = new System.Drawing.Size(36, 36);
            this.Manga_Edit.TabIndex = 0;
            this.Manga_Edit.UseVisualStyleBackColor = true;
            this.Manga_Edit.Click += new System.EventHandler(this.Manga_Edit_Click);
            // 
            // Manga_Picture
            // 
            this.Manga_Picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Manga_Picture.Location = new System.Drawing.Point(6, 42);
            this.Manga_Picture.Name = "Manga_Picture";
            this.Manga_Picture.Size = new System.Drawing.Size(225, 279);
            this.Manga_Picture.TabIndex = 0;
            this.Manga_Picture.TabStop = false;
            // 
            // Manga_Lang03
            // 
            this.Manga_Lang03.Image = global::AniDBClient.Properties.Resources.anidb_audio_english;
            this.Manga_Lang03.Location = new System.Drawing.Point(35, 201);
            this.Manga_Lang03.Name = "Manga_Lang03";
            this.Manga_Lang03.Size = new System.Drawing.Size(23, 23);
            this.Manga_Lang03.TabIndex = 0;
            this.Manga_Lang03.UseVisualStyleBackColor = true;
            this.Manga_Lang03.Click += new System.EventHandler(this.Manga_Lang03_Click);
            // 
            // Manga_Lang02
            // 
            this.Manga_Lang02.Image = ((System.Drawing.Image)(resources.GetObject("Manga_Lang02.Image")));
            this.Manga_Lang02.Location = new System.Drawing.Point(64, 201);
            this.Manga_Lang02.Name = "Manga_Lang02";
            this.Manga_Lang02.Size = new System.Drawing.Size(23, 23);
            this.Manga_Lang02.TabIndex = 0;
            this.Manga_Lang02.UseVisualStyleBackColor = true;
            this.Manga_Lang02.Click += new System.EventHandler(this.Manga_Lang02_Click);
            // 
            // Manga_Lang01
            // 
            this.Manga_Lang01.Image = ((System.Drawing.Image)(resources.GetObject("Manga_Lang01.Image")));
            this.Manga_Lang01.Location = new System.Drawing.Point(6, 201);
            this.Manga_Lang01.Name = "Manga_Lang01";
            this.Manga_Lang01.Size = new System.Drawing.Size(23, 23);
            this.Manga_Lang01.TabIndex = 0;
            this.Manga_Lang01.UseVisualStyleBackColor = true;
            this.Manga_Lang01.Click += new System.EventHandler(this.Manga_Lang01_Click);
            // 
            // Manga_EditCh
            // 
            this.Manga_EditCh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Manga_EditCh.BackgroundImage = global::AniDBClient.Properties.Resources.i_Edit;
            this.Manga_EditCh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Manga_EditCh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Manga_EditCh.ForeColor = System.Drawing.Color.Black;
            this.Manga_EditCh.Location = new System.Drawing.Point(170, 17);
            this.Manga_EditCh.Margin = new System.Windows.Forms.Padding(10);
            this.Manga_EditCh.Name = "Manga_EditCh";
            this.Manga_EditCh.Size = new System.Drawing.Size(23, 23);
            this.Manga_EditCh.TabIndex = 0;
            this.Manga_EditCh.UseVisualStyleBackColor = true;
            this.Manga_EditCh.Click += new System.EventHandler(this.Manga_Edit_Click);
            // 
            // Manga_Obr_CHD
            // 
            this.Manga_Obr_CHD.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Manga_Obr_CHD.BackgroundImage")));
            this.Manga_Obr_CHD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Manga_Obr_CHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Manga_Obr_CHD.ForeColor = System.Drawing.Color.Black;
            this.Manga_Obr_CHD.Location = new System.Drawing.Point(263, 17);
            this.Manga_Obr_CHD.Name = "Manga_Obr_CHD";
            this.Manga_Obr_CHD.Size = new System.Drawing.Size(23, 23);
            this.Manga_Obr_CHD.TabIndex = 0;
            this.Manga_Obr_CHD.UseVisualStyleBackColor = true;
            this.Manga_Obr_CHD.Click += new System.EventHandler(this.Manga_Obr_CHD_Click);
            // 
            // Manga_Insert_CHD
            // 
            this.Manga_Insert_CHD.BackgroundImage = global::AniDBClient.Properties.Resources.i_Check;
            this.Manga_Insert_CHD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Manga_Insert_CHD.ForeColor = System.Drawing.Color.Black;
            this.Manga_Insert_CHD.Location = new System.Drawing.Point(818, 18);
            this.Manga_Insert_CHD.Name = "Manga_Insert_CHD";
            this.Manga_Insert_CHD.Size = new System.Drawing.Size(23, 23);
            this.Manga_Insert_CHD.TabIndex = 0;
            this.Manga_Insert_CHD.UseVisualStyleBackColor = true;
            this.Manga_Insert_CHD.Click += new System.EventHandler(this.Manga_Insert_CHD_Click);
            // 
            // Manga_Delete
            // 
            this.Manga_Delete.BackgroundImage = global::AniDBClient.Properties.Resources.i_Delete;
            this.Manga_Delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Manga_Delete.ForeColor = System.Drawing.Color.Black;
            this.Manga_Delete.Location = new System.Drawing.Point(588, 289);
            this.Manga_Delete.Name = "Manga_Delete";
            this.Manga_Delete.Size = new System.Drawing.Size(36, 36);
            this.Manga_Delete.TabIndex = 0;
            this.Manga_Delete.UseVisualStyleBackColor = true;
            this.Manga_Delete.Visible = false;
            this.Manga_Delete.Click += new System.EventHandler(this.Manga_Delete_Click);
            // 
            // Manga_Update
            // 
            this.Manga_Update.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Manga_Update.BackgroundImage")));
            this.Manga_Update.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Manga_Update.ForeColor = System.Drawing.Color.Black;
            this.Manga_Update.Location = new System.Drawing.Point(680, 289);
            this.Manga_Update.Name = "Manga_Update";
            this.Manga_Update.Size = new System.Drawing.Size(36, 36);
            this.Manga_Update.TabIndex = 0;
            this.Manga_Update.UseVisualStyleBackColor = true;
            this.Manga_Update.Click += new System.EventHandler(this.Manga_Update_Click);
            // 
            // Manga_Insert
            // 
            this.Manga_Insert.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Manga_Insert.BackgroundImage")));
            this.Manga_Insert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Manga_Insert.ForeColor = System.Drawing.Color.Black;
            this.Manga_Insert.Location = new System.Drawing.Point(773, 289);
            this.Manga_Insert.Name = "Manga_Insert";
            this.Manga_Insert.Size = new System.Drawing.Size(36, 36);
            this.Manga_Insert.TabIndex = 0;
            this.Manga_Insert.UseVisualStyleBackColor = true;
            this.Manga_Insert.Click += new System.EventHandler(this.Manga_Insert_Click);
            // 
            // Manga_Download_MAL
            // 
            this.Manga_Download_MAL.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Manga_Download_MAL.BackgroundImage")));
            this.Manga_Download_MAL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Manga_Download_MAL.Enabled = false;
            this.Manga_Download_MAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Manga_Download_MAL.ForeColor = System.Drawing.Color.Black;
            this.Manga_Download_MAL.Location = new System.Drawing.Point(468, 173);
            this.Manga_Download_MAL.Name = "Manga_Download_MAL";
            this.Manga_Download_MAL.Size = new System.Drawing.Size(23, 23);
            this.Manga_Download_MAL.TabIndex = 0;
            this.Manga_Download_MAL.UseVisualStyleBackColor = true;
            this.Manga_Download_MAL.Click += new System.EventHandler(this.Manga_Download_MAL_Click);
            // 
            // Manga_Download_MU
            // 
            this.Manga_Download_MU.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Manga_Download_MU.BackgroundImage")));
            this.Manga_Download_MU.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Manga_Download_MU.Enabled = false;
            this.Manga_Download_MU.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Manga_Download_MU.ForeColor = System.Drawing.Color.Black;
            this.Manga_Download_MU.Location = new System.Drawing.Point(468, 121);
            this.Manga_Download_MU.Name = "Manga_Download_MU";
            this.Manga_Download_MU.Size = new System.Drawing.Size(23, 23);
            this.Manga_Download_MU.TabIndex = 0;
            this.Manga_Download_MU.UseVisualStyleBackColor = true;
            this.Manga_Download_MU.Click += new System.EventHandler(this.Manga_Download_MU_Click);
            // 
            // Manga_Download_MugiMugi
            // 
            this.Manga_Download_MugiMugi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Manga_Download_MugiMugi.BackgroundImage")));
            this.Manga_Download_MugiMugi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Manga_Download_MugiMugi.Enabled = false;
            this.Manga_Download_MugiMugi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Manga_Download_MugiMugi.ForeColor = System.Drawing.Color.Black;
            this.Manga_Download_MugiMugi.Location = new System.Drawing.Point(468, 199);
            this.Manga_Download_MugiMugi.Name = "Manga_Download_MugiMugi";
            this.Manga_Download_MugiMugi.Size = new System.Drawing.Size(23, 23);
            this.Manga_Download_MugiMugi.TabIndex = 0;
            this.Manga_Download_MugiMugi.UseVisualStyleBackColor = true;
            this.Manga_Download_MugiMugi.Click += new System.EventHandler(this.Manga_Download_MugiMugi_Click);
            // 
            // Manga_Download
            // 
            this.Manga_Download.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Manga_Download.BackgroundImage")));
            this.Manga_Download.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Manga_Download.Enabled = false;
            this.Manga_Download.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Manga_Download.ForeColor = System.Drawing.Color.Black;
            this.Manga_Download.Location = new System.Drawing.Point(468, 147);
            this.Manga_Download.Name = "Manga_Download";
            this.Manga_Download.Size = new System.Drawing.Size(23, 23);
            this.Manga_Download.TabIndex = 0;
            this.Manga_Download.UseVisualStyleBackColor = true;
            this.Manga_Download.Click += new System.EventHandler(this.Manga_Download_Click);
            // 
            // Manga_Obr
            // 
            this.Manga_Obr.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Manga_Obr.BackgroundImage")));
            this.Manga_Obr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Manga_Obr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Manga_Obr.ForeColor = System.Drawing.Color.Black;
            this.Manga_Obr.Location = new System.Drawing.Point(468, 328);
            this.Manga_Obr.Name = "Manga_Obr";
            this.Manga_Obr.Size = new System.Drawing.Size(23, 23);
            this.Manga_Obr.TabIndex = 0;
            this.Manga_Obr.UseVisualStyleBackColor = true;
            this.Manga_Obr.Click += new System.EventHandler(this.Manga_Obr_Click);
            // 
            // Add_Add
            // 
            this.Add_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Add_Add.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Add_Add.BackgroundImage")));
            this.Add_Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Add_Add.ForeColor = System.Drawing.Color.Black;
            this.Add_Add.Location = new System.Drawing.Point(315, 619);
            this.Add_Add.Name = "Add_Add";
            this.Add_Add.Size = new System.Drawing.Size(23, 23);
            this.Add_Add.TabIndex = 0;
            this.Add_Add.UseVisualStyleBackColor = true;
            this.Add_Add.Click += new System.EventHandler(this.Add_Add_Click);
            // 
            // LogTasksDelAll
            // 
            this.LogTasksDelAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LogTasksDelAll.BackgroundImage = global::AniDBClient.Properties.Resources.i_Cancel;
            this.LogTasksDelAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.LogTasksDelAll.ForeColor = System.Drawing.Color.Black;
            this.LogTasksDelAll.Location = new System.Drawing.Point(373, 619);
            this.LogTasksDelAll.Name = "LogTasksDelAll";
            this.LogTasksDelAll.Size = new System.Drawing.Size(23, 23);
            this.LogTasksDelAll.TabIndex = 0;
            this.LogTasksDelAll.UseVisualStyleBackColor = true;
            this.LogTasksDelAll.Click += new System.EventHandler(this.LogTasksDelAll_Click);
            // 
            // LogTasksDel
            // 
            this.LogTasksDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LogTasksDel.BackgroundImage = global::AniDBClient.Properties.Resources.i_Delete;
            this.LogTasksDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.LogTasksDel.ForeColor = System.Drawing.Color.Black;
            this.LogTasksDel.Location = new System.Drawing.Point(344, 619);
            this.LogTasksDel.Name = "LogTasksDel";
            this.LogTasksDel.Size = new System.Drawing.Size(23, 23);
            this.LogTasksDel.TabIndex = 0;
            this.LogTasksDel.UseVisualStyleBackColor = true;
            this.LogTasksDel.Click += new System.EventHandler(this.LogTasksDel_Click);
            // 
            // DataSQL_Select
            // 
            this.DataSQL_Select.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DataSQL_Select.BackgroundImage = global::AniDBClient.Properties.Resources.i_Burn_Disk;
            this.DataSQL_Select.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DataSQL_Select.ForeColor = System.Drawing.Color.Black;
            this.DataSQL_Select.Location = new System.Drawing.Point(1078, 3);
            this.DataSQL_Select.Name = "DataSQL_Select";
            this.DataSQL_Select.Size = new System.Drawing.Size(23, 23);
            this.DataSQL_Select.TabIndex = 0;
            this.DataSQL_Select.UseVisualStyleBackColor = true;
            this.DataSQL_Select.Click += new System.EventHandler(this.DataSQL_Select_Click);
            // 
            // Main
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1151, 747);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.MainTab);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1024, 786);
            this.Name = "Main";
            this.ShowInTaskbar = false;
            this.Text = "AniSub";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Hash_Nazvy_Souboru_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Hash_Nazvy_Souboru_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.MainTab.ResumeLayout(false);
            this.MainTab_IndexPage.ResumeLayout(false);
            this.MainTab_SettinsPage.ResumeLayout(false);
            this.MainTab_SettinsPage.PerformLayout();
            this.Options_GR06.ResumeLayout(false);
            this.Options_GR06.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WebServer_MPCHC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WebServer_Port)).EndInit();
            this.Options_GR05.ResumeLayout(false);
            this.Options_GR05.PerformLayout();
            this.Options_GR03.ResumeLayout(false);
            this.Options_GR02.ResumeLayout(false);
            this.Options_GR01.ResumeLayout(false);
            this.Options_GR01.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Options_Delay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Options_Reset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Options_ServerPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Options_Backup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Options_LocalPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Options_TimeOut)).EndInit();
            this.MainTab_RulesPage.ResumeLayout(false);
            this.MainTab_RulesPage.PerformLayout();
            this.Rules_RulesForCharacterReplacingGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Rules_Replace)).EndInit();
            this.Rules_ExportInfoGroupBox.ResumeLayout(false);
            this.Rules_ExportInfoGroupBox.PerformLayout();
            this.Rules_RulesForGeneratingDirectoriesGroupBox.ResumeLayout(false);
            this.Rules_RulesForGeneratingDirectoriesGroupBox.PerformLayout();
            this.Rules_RulesForFileRenamingGroupBox.ResumeLayout(false);
            this.Rules_RulesForFileRenamingGroupBox.PerformLayout();
            this.MainTab_HashPage.ResumeLayout(false);
            this.Hash_GR01.ResumeLayout(false);
            this.Hash_GR01.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Hash_Waiting)).EndInit();
            this.MainTab_AnimePage.ResumeLayout(false);
            this.MainTabData.ResumeLayout(false);
            this.MainTabData_MyListTabPage.ResumeLayout(false);
            this.Options_GR04.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MyListAnime)).EndInit();
            this.MainTabData_FilesTabPage.ResumeLayout(false);
            this.MainTabData_FilesTabPage.PerformLayout();
            this.DataFilesTree_Menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataFiles_Year)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataFiles_Month)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataFiles_Day)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataFiles_Page)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataFiles_Rows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataFiles)).EndInit();
            this.DataFiles_Menu.ResumeLayout(false);
            this.MainTabData_AnimeTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataAnime_Page)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataAnime_Rows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataAnime)).EndInit();
            this.DataAnime_Menu.ResumeLayout(false);
            this.MainTabData_Anime2TabPage.ResumeLayout(false);
            this.MainTabData_Anime2TabPage.PerformLayout();
            this.Anime_GR01.ResumeLayout(false);
            this.Anime_GR01.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Anime_Rat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnimeData)).EndInit();
            this.AnimeTree_Menu.ResumeLayout(false);
            this.MainTabData_GenresTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGenres_Page)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGenres_Rows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGenres)).EndInit();
            this.MainTabData_GroupsTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGroups_Page)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGroups_Rows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGroups)).EndInit();
            this.MainTabData_SearchTabPage.ResumeLayout(false);
            this.MainTabData_SearchTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataSearch_NM05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSearch_NM04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSearch_NM03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSearch_NM02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSearch_NM01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSearch)).EndInit();
            this.MainTabData_OthersTabPage.ResumeLayout(false);
            this.MainTabData_GraphsTabPage.ResumeLayout(false);
            this.MainTabData_GraphsTabPage.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.MainTabData_ExportTabPage.ResumeLayout(false);
            this.MainTabData_ExportTabPage.PerformLayout();
            this.MainTab_MangaPage.ResumeLayout(false);
            this.MainTabManga.ResumeLayout(false);
            this.MainTabManga_Mn01.ResumeLayout(false);
            this.MainTabManga_Mn01.PerformLayout();
            this.Manga_Gr04.ResumeLayout(false);
            this.Manga_Gr04.PerformLayout();
            this.Manga_Gr01.ResumeLayout(false);
            this.Manga_Gr01.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Manga_Data)).EndInit();
            this.Manga_Tree_Menu.ResumeLayout(false);
            this.MainTabManga_Mn02.ResumeLayout(false);
            this.Manga_Gr03.ResumeLayout(false);
            this.Manga_Gr03.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Manga_Tx20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Manga_ChaptersDT)).EndInit();
            this.Manga_Gr02.ResumeLayout(false);
            this.Manga_Gr02.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Manga_Tx07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Manga_Tx04)).EndInit();
            this.MainTabManga_Mn03.ResumeLayout(false);
            this.MainTabManga_Mn03.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MangaSearch_NM04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MangaSearch_NM03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MangaSearch_NM02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MangaSearch_NM01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MangaSearch)).EndInit();
            this.MainTab_LogPage.ResumeLayout(false);
            this.MainTabLog.ResumeLayout(false);
            this.MainTabLog_AniDbTabPage.ResumeLayout(false);
            this.MainTabLog_AniDbTabPage.PerformLayout();
            this.MainTabLog_SqlTabPage.ResumeLayout(false);
            this.MainTabLog_SqlTabPage.PerformLayout();
            this.MainTabLog_ErrorTabPage.ResumeLayout(false);
            this.MainTabLog_ErrorTabPage.PerformLayout();
            this.MainTabLog_TasksTabPage.ResumeLayout(false);
            this.MainTabLog_TasksTabPage.PerformLayout();
            this.MainTab_SqlPage.ResumeLayout(false);
            this.DataSql_CheckGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataSQL)).EndInit();
            this.AnimeData_Menu.ResumeLayout(false);
            this.Manga_Data_Menu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Anime_Rel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Anime_DateOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Anime_RatImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Anime_Img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Manga_Picture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTab;
        private System.Windows.Forms.TabPage MainTab_SettinsPage;
        private System.Windows.Forms.TabPage MainTab_RulesPage;
        private System.Windows.Forms.TabPage MainTab_AnimePage;
        private System.Windows.Forms.TabPage MainTab_LogPage;
        private System.Windows.Forms.TextBox Log;
        private System.Windows.Forms.Button Options_StartComunication;
        private System.Windows.Forms.TextBox Options_Password;
        private System.Windows.Forms.TextBox Options_User;
        private System.ComponentModel.BackgroundWorker ComunicationW;
        private System.Windows.Forms.TextBox Options_ServerName;
        private System.Windows.Forms.GroupBox Options_GR01;
        private System.Windows.Forms.Label Options_PasswordLabel;
        private System.Windows.Forms.Label Options_UserNameLabel;
        private System.Windows.Forms.Label Options_PortLabel;
        private System.Windows.Forms.Label Options_ServerLabel;
        private System.Windows.Forms.NumericUpDown Options_Delay;
        private System.Windows.Forms.NumericUpDown Options_TimeOut;
        private System.Windows.Forms.Label Options_DelayLabel;
        private System.Windows.Forms.Label Options_TimeoutLabel;
        private System.Windows.Forms.Button Options_ExtensionAdd;
        private System.Windows.Forms.Label Options_StorageLabel;
        private System.Windows.Forms.Label Options_SourceLabel;
        private System.Windows.Forms.Label Options_StatusLabel;
        private System.Windows.Forms.TextBox Options_MylistOther;
        private System.Windows.Forms.TextBox Options_MylistStorage;
        private System.Windows.Forms.TextBox Options_MylistSource;
        private System.Windows.Forms.ComboBox Options_MylistState;
        private System.Windows.Forms.CheckBox Options_AutoAddToMyListCheckBox;
        private System.Windows.Forms.Label Options_OtherLabel;
        private System.Windows.Forms.CheckBox Options_WatchedCheckbox;
        private System.Windows.Forms.GroupBox Rules_RulesForCharacterReplacingGroupBox;
        private System.Windows.Forms.GroupBox Rules_RulesForGeneratingDirectoriesGroupBox;
        private System.Windows.Forms.GroupBox Rules_RulesForFileRenamingGroupBox;
        private System.Windows.Forms.Button Rules_FilesRulesMoveAdd;
        private System.Windows.Forms.ComboBox Rules_FilesRulesMoveC;
        private System.Windows.Forms.TextBox Rules_FilesRulesMove;
        private System.Windows.Forms.Button Rules_FilesRulesRenameAdd;
        private System.Windows.Forms.ComboBox Rules_FilesRulesRenameC;
        private System.Windows.Forms.TextBox Rules_FilesRulesRename;
        private System.Windows.Forms.DataGridView Rules_Replace;
        private System.Windows.Forms.Button Options_AccountChange;
        private System.Windows.Forms.Button Options_SetingsLoad;
        private System.Windows.Forms.Button Options_SetingsSave;
        private System.Windows.Forms.ContextMenuStrip DataAnime_Menu;
        private System.Windows.Forms.ToolStripMenuItem DataAnime_Menu_Expand;
        private System.Windows.Forms.ToolStripMenuItem DataAnime_Menu_MyList;
        private System.Windows.Forms.ToolStripMenuItem DataAnime_Menu_Database;
        private System.Windows.Forms.ToolStripMenuItem DataAnime_Menu_Expand_Anime;
        private System.Windows.Forms.ToolStripMenuItem DataAnime_Menu_Expand_Episodes;
        private System.Windows.Forms.ToolStripMenuItem DataAnime_Menu_Expand_All;
        private System.Windows.Forms.ToolStripMenuItem DataAnime_Menu_Expand_CollapseEpisodes;
        private System.Windows.Forms.ToolStripMenuItem DataAnime_Menu_Expand_CollapseAllEpisodes;
        private System.Windows.Forms.ToolStripMenuItem DataAnime_Menu_Expand_CollapseAll;
        private System.Windows.Forms.Button Rules_FilesRulesRenameDel;
        private System.Windows.Forms.Label Options_LocalPortLabel;
        private System.Windows.Forms.Timer ComunicationRec;
        private System.Windows.Forms.TabControl MainTabData;
        private System.Windows.Forms.TabPage MainTabData_FilesTabPage;
        private System.Windows.Forms.TabPage MainTabData_AnimeTabPage;
        private System.Windows.Forms.TabPage MainTabData_Anime2TabPage;
        private System.Windows.Forms.TabPage MainTabData_GenresTabPage;
        private System.Windows.Forms.TabPage MainTabData_GroupsTabPage;
        private System.Windows.Forms.DataGridView DataAnime;
        private System.Windows.Forms.TabControl MainTabLog;
        private System.Windows.Forms.TabPage MainTabLog_AniDbTabPage;
        private System.Windows.Forms.TabPage MainTabLog_SqlTabPage;
        private System.Windows.Forms.TextBox LogSQL;
        private System.Windows.Forms.ListBox LogTasks;
        private System.Windows.Forms.DataGridView DataFiles;
        private System.Windows.Forms.TreeView AnimeTree;
        private System.Windows.Forms.GroupBox Anime_GR01;
        private System.Windows.Forms.DataGridView AnimeData;
        private System.Windows.Forms.LinkLabel Anime_LB01;
        private System.Windows.Forms.Label Anime_LB04;
        private System.Windows.Forms.Label Anime_LB07;
        private System.Windows.Forms.Label Anime_LB05;
        private System.Windows.Forms.Label Anime_LB06;
        private System.Windows.Forms.Label Anime_LB03;
        private System.Windows.Forms.LinkLabel Anime_LB02;
        private System.Windows.Forms.ToolStripMenuItem DataAnime_Menu_MyList_AddModify;
        private System.Windows.Forms.ToolStripMenuItem DataAnime_Menu_MyList_Delete;
        private System.Windows.Forms.ToolStripMenuItem DataAnime_Menu_MyList_Watched;
        private System.Windows.Forms.TabPage MainTabLog_TasksTabPage;
        private System.Windows.Forms.Button LogTasksDel;
        private System.Windows.Forms.NumericUpDown DataAnime_Rows;
        private System.Windows.Forms.NumericUpDown DataAnime_Page;
        private System.Windows.Forms.ContextMenuStrip DataFiles_Menu;
        private System.Windows.Forms.ToolStripMenuItem DataFiles_Menu_Mn01;
        private System.Windows.Forms.ToolStripMenuItem DataFiles_Menu_Mn01_Mn01;
        private System.Windows.Forms.ToolStripMenuItem DataFiles_Menu_Mn01_Mn02;
        private System.Windows.Forms.ToolStripMenuItem DataFiles_Menu_Mn01_Mn03;
        private System.Windows.Forms.ToolStripMenuItem DataFiles_Menu_Mn02;
        private System.Windows.Forms.NumericUpDown DataFiles_Page;
        private System.Windows.Forms.NumericUpDown DataFiles_Rows;
        private System.Windows.Forms.Label Anime_OP04;
        private System.Windows.Forms.Label Anime_OP03;
        private System.Windows.Forms.Label Anime_OP02;
        private System.Windows.Forms.Label Anime_OP01;
        private System.Windows.Forms.ToolStripMenuItem DataAnime_Menu_Database_Delete;
        private System.Windows.Forms.ToolStripMenuItem DataFiles_Menu_Mn02_Mn01;
        private System.Windows.Forms.ToolStripMenuItem DataFiles_Menu_Mn03;
        private System.Windows.Forms.RadioButton Rules_FilesRulesMove_RB01;
        private System.Windows.Forms.RadioButton Rules_FilesRulesMove_RB02;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rules_Replace_Mn01;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rules_Replace_Mn02;
        private System.Windows.Forms.TabPage MainTab_HashPage;
        private System.Windows.Forms.ProgressBar Hash_ProgressBar_Total;
        private System.Windows.Forms.Button Hash_Stop_Total;
        private System.Windows.Forms.ProgressBar Hash_ProgressBar;
        private System.Windows.Forms.Button Hash;
        private System.Windows.Forms.Button Hash_Cesta;
        private System.Windows.Forms.ListBox Hash_Nazvy_Souboru;
        private System.ComponentModel.BackgroundWorker Hash_W;
        private System.Windows.Forms.FolderBrowserDialog Adresar_Broswer;
        private System.Windows.Forms.DataGridView DataGenres;
        private System.Windows.Forms.DataGridView DataGroups;
        private System.Windows.Forms.RadioButton DataFiles_RB03;
        private System.Windows.Forms.RadioButton DataFiles_RB02;
        private System.Windows.Forms.RadioButton DataFiles_RB01;
        private System.Windows.Forms.NumericUpDown DataFiles_Year;
        private System.Windows.Forms.NumericUpDown DataFiles_Month;
        private System.Windows.Forms.NumericUpDown DataFiles_Day;
        private System.Windows.Forms.ContextMenuStrip AnimeData_Menu;
        private System.Windows.Forms.ToolStripMenuItem AnimeData_Menu_Mn01;
        private System.Windows.Forms.ToolStripMenuItem AnimeData_Menu_Mn02;
        private System.Windows.Forms.ToolStripMenuItem AnimeData_Menu_Mn03;
        private System.Windows.Forms.ToolStripMenuItem AnimeData_Menu_Mn01_Mn01;
        private System.Windows.Forms.ToolStripMenuItem AnimeData_Menu_Mn01_Mn02;
        private System.Windows.Forms.ToolStripMenuItem AnimeData_Menu_Mn02_Mn01;
        private System.Windows.Forms.ToolStripMenuItem AnimeData_Menu_Mn02_Mn02;
        private System.Windows.Forms.ToolStripMenuItem AnimeData_Menu_Mn03_Mn01;
        private System.Windows.Forms.ToolStripMenuItem AnimeData_Menu_Mn02_Mn03;
        private System.Windows.Forms.RadioButton DataFiles_RB04;
        private System.Windows.Forms.PictureBox Anime_Img;
        private System.Windows.Forms.NumericUpDown DataGenres_Page;
        private System.Windows.Forms.NumericUpDown DataGenres_Rows;
        private System.Windows.Forms.NumericUpDown DataGroups_Page;
        private System.Windows.Forms.NumericUpDown DataGroups_Rows;
        private System.Windows.Forms.Button Anime_Lang03;
        private System.Windows.Forms.Button Anime_Lang02;
        private System.Windows.Forms.Button Anime_Lang01;
        private System.Windows.Forms.Button DataFiles_Bt04;
        private System.Windows.Forms.Button DataFiles_Bt03;
        private System.Windows.Forms.Button DataFiles_Bt02;
        private System.Windows.Forms.Button DataFiles_Bt01;
        private System.Windows.Forms.Button DataFiles_Bt07;
        private System.Windows.Forms.Button DataFiles_Bt06;
        private System.Windows.Forms.Button DataFiles_Bt05;
        private System.Windows.Forms.Button DataFiles_Bt11;
        private System.Windows.Forms.Button DataFiles_Bt10;
        private System.Windows.Forms.Button DataFiles_Bt09;
        private System.Windows.Forms.Button DataFiles_Bt08;
        private System.Windows.Forms.Button DataFiles_Bt16;
        private System.Windows.Forms.Button DataFiles_Bt15;
        private System.Windows.Forms.Button DataFiles_Bt14;
        private System.Windows.Forms.Button DataFiles_Bt13;
        private System.Windows.Forms.Button DataFiles_Bt12;
        private System.Windows.Forms.Button DataFiles_Bt00;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Button DataFiles_Bt18;
        private System.Windows.Forms.Button DataFiles_Bt17;
        private System.Windows.Forms.TabPage MainTabData_SearchTabPage;
        private System.Windows.Forms.CheckedListBox DataSearch_Genres;
        private System.Windows.Forms.Button DataSearch_Select;
        private System.Windows.Forms.DataGridView DataSearch;
        private System.Windows.Forms.TextBox DataSearch_TX05;
        private System.Windows.Forms.TextBox DataSearch_TX04;
        private System.Windows.Forms.TextBox DataSearch_TX03;
        private System.Windows.Forms.TextBox DataSearch_TX02;
        private System.Windows.Forms.TextBox DataSearch_TX01;
        private System.Windows.Forms.Label DataSearch_LB05;
        private System.Windows.Forms.Label DataSearch_LB04;
        private System.Windows.Forms.Label DataSearch_LB03;
        private System.Windows.Forms.Label DataSearch_LB02;
        private System.Windows.Forms.Label DataSearch_LB01;
        private System.Windows.Forms.Label DataSearch_LB16;
        private System.Windows.Forms.TextBox DataSearch_TX08;
        private System.Windows.Forms.TextBox DataSearch_TX07;
        private System.Windows.Forms.TextBox DataSearch_TX06;
        private System.Windows.Forms.Label DataSearch_LB15;
        private System.Windows.Forms.Label DataSearch_LB10;
        private System.Windows.Forms.Label DataSearch_LB14;
        private System.Windows.Forms.Label DataSearch_LB09;
        private System.Windows.Forms.Label DataSearch_LB13;
        private System.Windows.Forms.Label DataSearch_LB08;
        private System.Windows.Forms.Label DataSearch_LB12;
        private System.Windows.Forms.Label DataSearch_LB07;
        private System.Windows.Forms.Label DataSearch_LB06;
        private System.Windows.Forms.ComboBox DataSearch_CB01;
        private System.Windows.Forms.ComboBox DataSearch_CB02;
        private System.Windows.Forms.Label DataSearch_LB11;
        private System.Windows.Forms.NumericUpDown DataSearch_NM03;
        private System.Windows.Forms.NumericUpDown DataSearch_NM02;
        private System.Windows.Forms.NumericUpDown DataSearch_NM01;
        private System.Windows.Forms.NumericUpDown DataSearch_NM05;
        private System.Windows.Forms.NumericUpDown DataSearch_NM04;
        private System.Windows.Forms.CheckBox DataSearch_CH02;
        private System.Windows.Forms.CheckBox DataSearch_CH01;
        private System.Windows.Forms.Button DataSearch_Clear;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataSearch_Mn01;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataSearch_Mn02;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataSearch_Mn03;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataSearch_Mn04;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataSearch_Mn05;
        private System.Windows.Forms.Button StatusBar_Connect;
        private System.Windows.Forms.RadioButton Rules_FilesRulesMove_RB03;
        private System.Windows.Forms.Button Hash_Files;
        private System.Windows.Forms.Button Hash_Delete;
        private System.Windows.Forms.RadioButton Rules_FilesRulesRename_DoNothingRadioButton;
        private System.Windows.Forms.RadioButton Rules_FilesRulesRename_RenameRadioButton;
        private System.Windows.Forms.CheckBox Rules_ReplaceExistingCheckBox;
        private System.Windows.Forms.CheckBox Rules_DontCopyToAnotherDiskCheckBox;
        private System.Windows.Forms.CheckBox Rules_AutomaticRenamingCheckBox;
        private System.ComponentModel.BackgroundWorker FRename_W;
        private System.Windows.Forms.ToolStripMenuItem DataFiles_Menu_Mn04;
        private System.Windows.Forms.ToolStripMenuItem AnimeData_Menu_Mn04;
        private System.Windows.Forms.TreeView DataFilesTree;
        private System.Windows.Forms.Button DataFiles_Bt19;
        private System.Windows.Forms.ContextMenuStrip DataFilesTree_Menu;
        private System.Windows.Forms.ToolStripMenuItem DataFilesTree_Mn01;
        private System.Windows.Forms.ToolStripMenuItem DataFilesTree_Mn02;
        private System.Windows.Forms.ToolStripMenuItem DataFilesTree_Mn03;
        private System.Windows.Forms.ToolStripMenuItem DataFilesTree_Mn01_Mn01;
        private System.Windows.Forms.ToolStripMenuItem DataFilesTree_Mn01_Mn02;
        private System.Windows.Forms.ToolStripMenuItem DataFilesTree_Mn02_Mn01;
        private System.Windows.Forms.ToolStripMenuItem DataFilesTree_Mn02_Mn02;
        private System.Windows.Forms.ToolStripMenuItem DataFilesTree_Mn02_Mn03;
        private System.Windows.Forms.ToolStripMenuItem DataFilesTree_Mn04;
        private System.Windows.Forms.ToolStripMenuItem DataFilesTree_Mn05;
        private System.Windows.Forms.ToolStripMenuItem DataFilesTree_Mn03_Mn01;
        private System.Windows.Forms.ImageList DataFilesTreeImages;
        private System.Windows.Forms.ToolStripMenuItem DataFilesTree_Mn06;
        private System.Windows.Forms.TextBox DataFiles_Filtr01;
        private System.Windows.Forms.TabPage MainTabLog_ErrorTabPage;
        private System.Windows.Forms.TextBox LogError;
        private System.Windows.Forms.ComboBox Options_Language;
        private System.Windows.Forms.ToolStripMenuItem DataFiles_Menu_Mn05;
        private System.Windows.Forms.ToolStripMenuItem DataFiles_Menu_Mn05_Mn01;
        private System.Windows.Forms.ToolStripMenuItem DataFiles_Menu_Mn05_Mn02;
        private System.Windows.Forms.ToolStripMenuItem DataFiles_Menu_Mn05_Mn03;
        private System.Windows.Forms.ToolStripMenuItem DataFiles_Menu_Mn05_Mn04;
        private System.Windows.Forms.ToolStripMenuItem DataFiles_Menu_Mn05_Mn05;
        private System.Windows.Forms.ToolStripMenuItem DataFilesTree_Mn07;
        private System.Windows.Forms.ToolStripMenuItem DataFilesTree_Mn07_Mn01;
        private System.Windows.Forms.ToolStripMenuItem DataFilesTree_Mn07_Mn02;
        private System.Windows.Forms.ToolStripMenuItem DataFilesTree_Mn07_Mn03;
        private System.Windows.Forms.ToolStripMenuItem DataFilesTree_Mn07_Mn04;
        private System.Windows.Forms.ToolStripMenuItem DataFilesTree_Mn07_Mn05;
        private System.Windows.Forms.ToolStripMenuItem DataAnime_Menu_Mn04;
        private System.Windows.Forms.ToolStripMenuItem DataAnime_Menu_Mn04_Mn01;
        private System.Windows.Forms.ToolStripMenuItem DataAnime_Menu_Mn04_Mn02;
        private System.Windows.Forms.ToolStripMenuItem DataAnime_Menu_Mn04_Mn03;
        private System.Windows.Forms.ToolStripMenuItem DataAnime_Menu_Mn04_Mn04;
        private System.Windows.Forms.ToolStripMenuItem DataAnime_Menu_Mn04_Mn05;
        private System.Windows.Forms.ToolStripMenuItem AnimeData_Menu_Mn05;
        private System.Windows.Forms.ToolStripMenuItem AnimeData_Menu_Mn05_Mn01;
        private System.Windows.Forms.ToolStripMenuItem AnimeData_Menu_Mn05_Mn02;
        private System.Windows.Forms.ToolStripMenuItem AnimeData_Menu_Mn05_Mn03;
        private System.Windows.Forms.ToolStripMenuItem AnimeData_Menu_Mn05_Mn04;
        private System.Windows.Forms.ToolStripMenuItem AnimeData_Menu_Mn05_Mn05;
        private System.Windows.Forms.Button Rules_TagsButton;
        private System.Windows.Forms.LinkLabel Anime_LB08;
        private System.Windows.Forms.TreeView Anime_RelationTree;
        private System.Windows.Forms.ToolStripMenuItem DataFiles_Menu_Mn06;
        private System.Windows.Forms.ToolStripMenuItem DataFiles_Menu_Mn06_Mn01;
        private System.Windows.Forms.ToolStripMenuItem DataFiles_Menu_Mn06_Mn02;
        private System.Windows.Forms.ToolStripMenuItem DataFiles_Menu_Mn06_Mn03;
        private System.Windows.Forms.Label Anime_OP06;
        private System.Windows.Forms.Label Anime_LB09;
        private System.Windows.Forms.CheckBox Hash_CH01;
        private System.Windows.Forms.CheckBox Hash_CH03;
        private System.Windows.Forms.CheckBox Hash_CH02;
        private System.Windows.Forms.ComboBox Rules_Position;
        private System.Windows.Forms.Label Rules_RulesNumberPositionLabel;
        private System.Windows.Forms.ToolStripMenuItem DataFiles_Menu_Mn06_Mn04;
        private System.Windows.Forms.NumericUpDown Hash_Waiting;
        private System.Windows.Forms.Label Hash_LB02;
        private System.Windows.Forms.Label Hash_LB03;
        private System.Windows.Forms.Label DataFiles_LB04;
        private System.Windows.Forms.Label DataFiles_LB03;
        private System.Windows.Forms.Label DataFiles_LB02;
        private System.Windows.Forms.Label DataFiles_LB01;
        private System.Windows.Forms.TextBox DataFiles_Filtr04;
        private System.Windows.Forms.TextBox DataFiles_Filtr03;
        private System.Windows.Forms.TextBox DataFiles_Filtr02;
        private System.Windows.Forms.CheckBox Options_SaveSettingsOnExitCheckBox;
        private System.Windows.Forms.Button Options_CH07BT;
        private System.Windows.Forms.Button Options_CH06BT;
        private System.Windows.Forms.Button Options_CH05BT;
        private System.Windows.Forms.Button Options_CH04BT;
        private System.Windows.Forms.Button Options_CH03BT;
        private System.Windows.Forms.ToolStripMenuItem DataFiles_Menu_Mn07;
        private System.Windows.Forms.CheckBox DataFilesTree_CH02;
        private System.Windows.Forms.CheckBox DataFilesTree_CH01;
        private System.Windows.Forms.ToolStripMenuItem DataFilesTree_Mn08;
        private System.Windows.Forms.ToolStripMenuItem AnimeData_Menu_Mn06;
        private System.Windows.Forms.Button Hash_DeleteAll;
        private System.Windows.Forms.Button LogTasksDelAll;
        private System.Windows.Forms.ContextMenuStrip AnimeTree_Menu;
        private System.Windows.Forms.ToolStripMenuItem AnimeTree_Menu_Mn01;
        private System.Windows.Forms.ToolStripMenuItem AnimeTree_Menu_Mn01_Mn01;
        private System.Windows.Forms.ToolStripMenuItem AnimeTree_Menu_Mn01_Mn02;
        private System.Windows.Forms.ToolStripMenuItem AnimeTree_Menu_Mn01_Mn03;
        private System.Windows.Forms.ToolStripMenuItem AnimeTree_Menu_Mn01_Mn04;
        private System.Windows.Forms.ToolStripMenuItem AnimeTree_Menu_Mn01_Mn05;
        private System.Windows.Forms.CheckBox DataFilesTree_CH03;
        private System.Windows.Forms.RadioButton DataFiles_RB05;
        private System.Windows.Forms.CheckBox AnimeTree_CH01;
        private System.Windows.Forms.TabPage MainTab_MangaPage;
        private System.Windows.Forms.TabControl MainTabManga;
        private System.Windows.Forms.TabPage MainTabManga_Mn01;
        private System.Windows.Forms.TabPage MainTabManga_Mn02;
        private System.Windows.Forms.CheckBox MangaTree_CH01;
        private System.Windows.Forms.Button Manga_Lang03;
        private System.Windows.Forms.Button Manga_Lang02;
        private System.Windows.Forms.Button Manga_Lang01;
        private System.Windows.Forms.GroupBox Manga_Gr01;
        private System.Windows.Forms.LinkLabel Manga_LB13;
        private System.Windows.Forms.PictureBox Manga_Picture;
        private System.Windows.Forms.Label Manga_LB10;
        private System.Windows.Forms.Label Manga_LB12;
        private System.Windows.Forms.Label Manga_LB08;
        private System.Windows.Forms.Label Manga_LB06;
        private System.Windows.Forms.Label Manga_LB04;
        private System.Windows.Forms.Label Manga_LB05;
        private System.Windows.Forms.Label Manga_LB15;
        private System.Windows.Forms.Label Manga_LB07;
        private System.Windows.Forms.Label Manga_LB01;
        private System.Windows.Forms.Label Manga_LB09;
        private System.Windows.Forms.Label Manga_LB03;
        private System.Windows.Forms.DataGridView Manga_Data;
        private System.Windows.Forms.TreeView Manga_Tree;
        private System.Windows.Forms.LinkLabel Manga_LB14;
        private System.Windows.Forms.TabPage MainTabData_MyListTabPage;
        private System.Windows.Forms.GroupBox Options_GR04;
        private System.Windows.Forms.Button Options_MyListRefresh;
        private System.Windows.Forms.Button Options_MyListRefreshMin;
        private System.Windows.Forms.GroupBox Manga_Gr03;
        private System.Windows.Forms.GroupBox Manga_Gr02;
        private System.Windows.Forms.Label Manga_LB16;
        private System.Windows.Forms.TextBox Manga_Tx01;
        private System.Windows.Forms.Button Manga_Update;
        private System.Windows.Forms.Button Manga_Insert;
        private System.Windows.Forms.Button Manga_Obr;
        private System.Windows.Forms.Label Manga_LB23;
        private System.Windows.Forms.Label Manga_LB22;
        private System.Windows.Forms.Label Manga_LB21;
        private System.Windows.Forms.Label Manga_LB20;
        private System.Windows.Forms.Label Manga_LB19;
        private System.Windows.Forms.Label Manga_LB18;
        private System.Windows.Forms.Label Manga_LB17;
        private System.Windows.Forms.TextBox Manga_Tx08;
        private System.Windows.Forms.TextBox Manga_Tx06;
        private System.Windows.Forms.TextBox Manga_Tx05;
        private System.Windows.Forms.TextBox Manga_Tx03;
        private System.Windows.Forms.TextBox Manga_Tx02;
        private System.Windows.Forms.CheckedListBox Manga_Genres;
        private System.Windows.Forms.CheckBox Manga_CH01;
        private System.Windows.Forms.Label Manga_LB24;
        private System.Windows.Forms.TextBox Manga_Tx00;
        private System.Windows.Forms.CheckedListBox Manga_Anime;
        private System.Windows.Forms.Label Manga_LB25;
        private System.Windows.Forms.Button Manga_Edit;
        private System.Windows.Forms.TextBox Manga_Tx12;
        private System.Windows.Forms.Button Manga_Chapter;
        private System.Windows.Forms.TabPage MainTab_SqlPage;
        private System.Windows.Forms.GroupBox DataSql_CheckGroupBox;
        private System.Windows.Forms.Button DataSql_FilesButton;
        private System.Windows.Forms.Button DataSql_MyListButton;
        private System.Windows.Forms.Button DataSql_EpisodesButton;
        private System.Windows.Forms.Button DataSql_AnimeButton;
        private System.Windows.Forms.ComboBox DataSQL_Text;
        private System.Windows.Forms.ListBox DataSQL_Columns;
        private System.Windows.Forms.ListBox DataSQL_Tables;
        private System.Windows.Forms.Button DataSQL_Select;
        private System.Windows.Forms.DataGridView DataSQL;
        private System.Windows.Forms.TextBox Add_Text01;
        private System.Windows.Forms.Button Add_Add;
        private System.Windows.Forms.Label Add_LB01;
        private System.Windows.Forms.ComboBox Add_Text02;
        private System.Windows.Forms.Button Manga_Delete;
        private System.Windows.Forms.ContextMenuStrip Manga_Data_Menu;
        private System.Windows.Forms.TreeView Manga_RelationTree;
        private System.Windows.Forms.Label Manga_LB36;
        private System.Windows.Forms.Label Manga_LB35;
        private System.Windows.Forms.TextBox Manga_Tx18;
        private System.Windows.Forms.TextBox Manga_Tx17;
        private System.Windows.Forms.Label Manga_LB40;
        private System.Windows.Forms.Label Manga_LB38;
        private System.Windows.Forms.Label Manga_LB39;
        private System.Windows.Forms.Label Manga_LB37;
        private System.Windows.Forms.Label Anime_LB10;
        private System.Windows.Forms.Label Anime_OP07;
        private System.Windows.Forms.ToolStripMenuItem AnimeTree_Menu_Mn02;
        private System.Windows.Forms.Label Options_CompactAndRepairDbLabel;
        private System.Windows.Forms.Label Options_DeleteDuplicatesLabel;
        private System.Windows.Forms.Label Options_DownloadAllFilesLabel;
        private System.Windows.Forms.Label Options_DownloadAllAnimeEpisodesLabel;
        private System.Windows.Forms.Label Options_CheckUnknownFilesLabel;
        private System.ComponentModel.BackgroundWorker Database_W;
        private System.Windows.Forms.Label DataFiles_LB05;
        private System.Windows.Forms.Button DataFiles_Bt20;
        private System.Windows.Forms.Button DataFiles_Bt21;
        private System.Windows.Forms.Button Manga_Download;
        private System.Windows.Forms.TextBox Manga_Tx19;
        private System.Windows.Forms.Label Manga_LB41;
        private System.Windows.Forms.Button Manga_Obr_CHD;
        private System.Windows.Forms.ComboBox Manga_Tx21;
        private System.Windows.Forms.Label Manga_LB42;
        private System.Windows.Forms.Label Manga_LB43;
        private System.Windows.Forms.Button Manga_Insert_CHD;
        private System.Windows.Forms.ToolStripMenuItem Manga_Data_Menu_Mn02;
        private System.Windows.Forms.ToolStripMenuItem Manga_Data_Menu_Mn03;
        private System.Windows.Forms.ToolStripMenuItem Manga_Data_Menu_Mn04;
        private System.Windows.Forms.CheckBox AnimeTree_CH02;
        private System.Windows.Forms.ContextMenuStrip Manga_Tree_Menu;
        private System.Windows.Forms.ToolStripMenuItem Manga_Tree_Menu_Mn01;
        private System.Windows.Forms.Label Options_RestoreBackupLabel;
        private System.Windows.Forms.Label Options_CreateBackupLabel;
        private System.Windows.Forms.Button Options_CH09BT;
        private System.Windows.Forms.Button Options_CH08BT;
        private System.Windows.Forms.TabPage MainTabManga_Mn03;
        private System.Windows.Forms.NumericUpDown MangaSearch_NM04;
        private System.Windows.Forms.NumericUpDown MangaSearch_NM03;
        private System.Windows.Forms.NumericUpDown MangaSearch_NM02;
        private System.Windows.Forms.NumericUpDown MangaSearch_NM01;
        private System.Windows.Forms.TextBox MangaSearch_TX05;
        private System.Windows.Forms.TextBox MangaSearch_TX04;
        private System.Windows.Forms.TextBox MangaSearch_TX03;
        private System.Windows.Forms.TextBox MangaSearch_TX02;
        private System.Windows.Forms.TextBox MangaSearch_TX01;
        private System.Windows.Forms.Label MangaSearch_LB10;
        private System.Windows.Forms.Label MangaSearch_LB05;
        private System.Windows.Forms.Label MangaSearch_LB04;
        private System.Windows.Forms.Label MangaSearch_LB09;
        private System.Windows.Forms.Label MangaSearch_LB03;
        private System.Windows.Forms.Label MangaSearch_LB08;
        private System.Windows.Forms.Label MangaSearch_LB02;
        private System.Windows.Forms.Label MangaSearch_LB07;
        private System.Windows.Forms.Label MangaSearch_LB01;
        private System.Windows.Forms.Label MangaSearch_LB06;
        private System.Windows.Forms.CheckedListBox MangaSearch_Genres;
        private System.Windows.Forms.Button MangaSearch_New;
        private System.Windows.Forms.Button MangaSearch_Search;
        private System.Windows.Forms.DataGridView MangaSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn MangaSearch_Mn01;
        private System.Windows.Forms.DataGridViewTextBoxColumn MangaSearch_Mn02;
        private System.Windows.Forms.DataGridViewTextBoxColumn MangaSearch_Mn03;
        private System.Windows.Forms.DataGridViewTextBoxColumn MangaSearch_Mn04;
        private System.Windows.Forms.Button Anime_BT01;
        private System.Windows.Forms.Label Anime_LB11;
        private System.Windows.Forms.TabPage MainTabData_OthersTabPage;
        private System.Windows.Forms.TreeView AnimeTags;
        private System.Windows.Forms.TreeView AnimeSeen;
        private System.Windows.Forms.TreeView AnimeRating;
        private System.Windows.Forms.PictureBox Anime_RatImg;
        private System.Windows.Forms.NumericUpDown Anime_Rat;
        private System.Windows.Forms.MaskedTextBox Anime_Seen;
        private System.Windows.Forms.PictureBox Anime_Rel;
        private System.Windows.Forms.GroupBox Hash_GR01;
        private System.Windows.Forms.Label Hash_ProgressBar_Total_Percent;
        private System.Windows.Forms.Label Hash_ProgressBar_Percent;
        private System.Windows.Forms.TabPage MainTab_IndexPage;
        private System.Windows.Forms.WebBrowser WEB;
        private System.Windows.Forms.Label Options_DeleteDbLabel;
        private System.Windows.Forms.Label Options_ForceDbUpdateLabel;
        private System.Windows.Forms.Button Options_CH11BT;
        private System.Windows.Forms.Button Options_CH10BT;
        private System.Windows.Forms.Label StatusBar_ConnectLabel;
        private System.Windows.Forms.Button StatusBar_Hash;
        private System.Windows.Forms.TabPage MainTabData_GraphsTabPage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Zgc_GraphB03;
        private System.Windows.Forms.Button Zgc_GraphB02;
        private System.Windows.Forms.Button Zgc_GraphB01;
        private ZedGraphControl Zgc_Graph;
        private System.Windows.Forms.Button Zgc_GraphB04;
        private System.Windows.Forms.Button Zgc_GraphB06;
        private System.Windows.Forms.Button Zgc_GraphB05;
        private System.Windows.Forms.CheckedListBox Manga_Manga;
        private System.Windows.Forms.CheckBox DataFilesTree_CH04;
        private System.Windows.Forms.Button Anime_RelDel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ProgressBar StatusBar_ProgressBar;
        private System.Windows.Forms.Label StatusBar_Mn06;
        private System.Windows.Forms.Label StatusBar_Mn05;
        private System.Windows.Forms.Label StatusBar_Mn04;
        private System.Windows.Forms.Label StatusBar_Mn03;
        private System.Windows.Forms.Label StatusBar_Mn02;
        private System.Windows.Forms.Label StatusBar_TasksRemainingLabel;
        private System.Windows.Forms.NumericUpDown Manga_Tx20;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manga_Data_Mn01;
        private System.Windows.Forms.DataGridViewImageColumn Manga_Data_Mn02;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manga_Data_Mn03;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manga_Data_Mn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manga_Data_Mn04;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manga_Data_Mn05;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manga_Data_Mn08;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manga_Data_Mn09;
        private System.Windows.Forms.DataGridViewImageColumn Manga_Data_Mn06;
        private System.Windows.Forms.DataGridViewImageColumn Manga_Data_Mn07;
        private System.Windows.Forms.TabPage MainTabData_ExportTabPage;
        private System.Windows.Forms.Button Anime_ExportBT02;
        private System.Windows.Forms.Button Anime_ExportBT01;
        private System.Windows.Forms.CheckBox Anime_ExportCH18;
        private System.Windows.Forms.CheckBox Anime_ExportCH17;
        private System.Windows.Forms.CheckBox Anime_ExportCH16;
        private System.Windows.Forms.CheckBox Anime_ExportCH15;
        private System.Windows.Forms.CheckBox Anime_ExportCH14;
        private System.Windows.Forms.CheckBox Anime_ExportCH13;
        private System.Windows.Forms.CheckBox Anime_ExportCH12;
        private System.Windows.Forms.CheckBox Anime_ExportCH11;
        private System.Windows.Forms.CheckBox Anime_ExportCH10;
        private System.Windows.Forms.CheckBox Anime_ExportCH09;
        private System.Windows.Forms.CheckBox Anime_ExportCH08;
        private System.Windows.Forms.CheckBox Anime_ExportCH07;
        private System.Windows.Forms.CheckBox Anime_ExportCH06;
        private System.Windows.Forms.CheckBox Anime_ExportCH05;
        private System.Windows.Forms.CheckBox Anime_ExportCH04;
        private System.Windows.Forms.CheckBox Anime_ExportCH03;
        private System.Windows.Forms.CheckBox Anime_ExportCH02;
        private System.Windows.Forms.CheckBox Anime_ExportCH01;
        private System.Windows.Forms.Label Anime_ExportLB01;
        private System.Windows.Forms.NumericUpDown Options_Reset;
        private System.Windows.Forms.Label Options_ResetCountLabel;
        private System.Windows.Forms.NumericUpDown Options_ServerPort;
        private System.Windows.Forms.NumericUpDown Options_LocalPort;
        private System.Windows.Forms.CheckBox Options_ClassicFolderSelectDialogCheckBox;
        private System.Windows.Forms.Button Options_ExtensionRem;
        private System.Windows.Forms.Button Rules_FilesRulesMoveDel;
        private System.Windows.Forms.ToolTip ToolTipAnimeRel;
        private System.Windows.Forms.DataGridView Manga_ChaptersDT;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Manga_ChaptersCM01;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manga_ChaptersCM02;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manga_ChaptersCM03;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Manga_ChaptersCM04;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manga_ChaptersCM05;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manga_ChaptersCM06;
        private System.Windows.Forms.GroupBox Rules_ExportInfoGroupBox;
        private System.Windows.Forms.Button Rules_InfoDell;
        private System.Windows.Forms.RadioButton Rules_InfoRenameDoNothingRadioButton;
        private System.Windows.Forms.RadioButton Rules_InfoExportRadioButton;
        private System.Windows.Forms.Button Rules_InfoAdd;
        private System.Windows.Forms.ComboBox Rules_InfoC;
        private System.Windows.Forms.TextBox Rules_Info;
        private System.Windows.Forms.Button Manga_EditCh;
        private System.Windows.Forms.NumericUpDown Manga_Tx07;
        private System.Windows.Forms.NumericUpDown Manga_Tx04;
        private System.Windows.Forms.GroupBox Manga_Gr04;
        private System.Windows.Forms.Label Options_MangaLabel;
        private System.Windows.Forms.Label Options_LB65;
        private System.Windows.Forms.Label Options_VolumesLabel;
        private System.Windows.Forms.Label Options_LB54;
        private System.Windows.Forms.Label Options_ReadLabel;
        private System.Windows.Forms.Label Options_LB56;
        private System.Windows.Forms.Label Options_ChaptersLabel;
        private System.Windows.Forms.Label Options_LB64;
        private System.Windows.Forms.Label Options_TotalPagesLabel;
        private System.Windows.Forms.Label Options_LB62;
        private System.Windows.Forms.Label Options_AdultLabel;
        private System.Windows.Forms.Label Options_LB58;
        private System.Windows.Forms.Label Options_ReadLabel2;
        private System.Windows.Forms.Label Options_LB60;
        private System.Windows.Forms.Label Options_FileSizeLabel;
        private System.Windows.Forms.Label Options_LB52;
        private System.Windows.Forms.Button Options_MyListRefreshManga;
        private System.Windows.Forms.CheckBox Options_ShowAdultOnWelcomeScreenCheckBox;
        private System.Windows.Forms.CheckBox Options_AddSameFilesMultipleTimesCheckBox;
        private System.Windows.Forms.Label Manga_LB44;
        private System.Windows.Forms.TextBox Manga_Tx22;
        private System.Windows.Forms.LinkLabel Manga_LB45;
        private System.Windows.Forms.Button Options_Color04;
        private System.Windows.Forms.Button Options_Color03;
        private System.Windows.Forms.Button Options_Color02;
        private System.Windows.Forms.Button Options_Color01;
        private System.Windows.Forms.Button StatusBar_Refresh;
        private System.Windows.Forms.Button Options_Color05;
        private System.Windows.Forms.Button Options_Color09;
        private System.Windows.Forms.Button Options_Color08;
        private System.Windows.Forms.Button Options_Color07;
        private System.Windows.Forms.Button Options_Color06;
        private System.Windows.Forms.Button Options_Color10;
        private System.Windows.Forms.CheckBox Options_FlatStyleCheckBox;
        private System.Windows.Forms.CheckBox Options_MinimizeToTrayCheckBox;
        private System.Windows.Forms.NotifyIcon Notify;
        private System.Windows.Forms.CheckBox Rules_DeleteSourceIfEmptyCheckBox;
        private System.Windows.Forms.Label DataFiles_LB06;
        private System.Windows.Forms.CheckBox Options_DontGenerateWelcomeSceenCheckBox;
        private System.Windows.Forms.Button DataFiles_Bt22;
        private System.Windows.Forms.NumericUpDown Options_Backup;
        private System.Windows.Forms.Label Options_DbBackupCountLabel;
        private System.Windows.Forms.ComboBox Anime_CB01;
        private System.Windows.Forms.ComboBox Anime_CB02;
        private System.Windows.Forms.ComboBox Manga_CB01;
        private System.Windows.Forms.Label Manga_LB47;
        private System.Windows.Forms.Label Manga_LB46;
        private System.Windows.Forms.Button Manga_Download_MU;
        private System.Windows.Forms.Label Manga_LB48;
        private System.Windows.Forms.Label Manga_LB49;
        private System.Windows.Forms.Label Manga_LB51;
        private System.Windows.Forms.Button Manga_Download_MAL;
        private System.Windows.Forms.Button Manga_Download_MugiMugi;
        private System.Windows.Forms.Label Manga_LB50;
        private System.Windows.Forms.TextBox Manga_Tx24;
        private System.Windows.Forms.TextBox Manga_Tx23;
        private System.Windows.Forms.LinkLabel Manga_LB53;
        private System.Windows.Forms.LinkLabel Manga_LB52;
        private System.Windows.Forms.Label Options_CheckNewMangaChaptersLabel;
        private System.Windows.Forms.Button Options_CH12BT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataFiles_Mn00;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataFiles_Mn01;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataFiles_Mn02;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataFiles_Mn03;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataFiles_Mn04;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataFiles_Mn05;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataFiles_Mn06;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataFiles_Mn07;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataFiles_Mn08;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataFiles_Mn09;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataFiles_Mn10;
        private System.Windows.Forms.DataGridViewImageColumn DataFiles_Mn11;
        private System.Windows.Forms.DataGridViewImageColumn DataFiles_Mn12;
        private System.Windows.Forms.DataGridViewImageColumn DataFiles_Mn13;
        private System.Windows.Forms.DataGridViewImageColumn DataFiles_Mn14;
        private System.Windows.Forms.DataGridViewImageColumn DataFiles_Mn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataFiles_Mn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataFiles_Mn17;
        private System.Windows.Forms.DataGridView MyListAnime;
        private System.Windows.Forms.PictureBox Anime_DateOK;
        private System.Windows.Forms.ComboBox Options_Network;
        private System.Windows.Forms.Label Options_NetworkLabel;
        private System.Windows.Forms.ComboBox Options_ExtensionList;
        private System.Windows.Forms.Label Options_FileTypesLabel;
        private System.Windows.Forms.ComboBox Watcher_List;
        private System.Windows.Forms.CheckBox Watcher_CH01;
        private System.Windows.Forms.Button Watcher_Delete;
        private System.Windows.Forms.Button Watcher_Add;
        private System.Windows.Forms.Label Options_Hash_WatcherLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataAnime_Mn00;
        private System.Windows.Forms.DataGridViewImageColumn DataAnime_Mn01;
        private System.Windows.Forms.DataGridViewImageColumn DataAnime_Mn02;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataAnime_Mn03;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataAnime_Mn04;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataAnime_Mn05;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataAnime_Mn06;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataAnime_Mn08;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataAnime_Mn09;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataAnime_Mn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataAnime_Mn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataAnime_Mn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataAnime_Mn13;
        private System.Windows.Forms.DataGridViewImageColumn DataAnime_Mn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataAnime_Mn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataAnime_Mn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnimeData_Mn01;
        private System.Windows.Forms.DataGridViewImageColumn AnimeData_Mn02;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnimeData_Mn03;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnimeData_Mn04;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnimeData_Mn05;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnimeData_Mn06;
        private System.Windows.Forms.DataGridViewImageColumn AnimeData_Mn07;
        private System.Windows.Forms.DataGridViewImageColumn AnimeData_Mn08;
        private System.Windows.Forms.DataGridViewImageColumn AnimeData_Mn09;
        private System.Windows.Forms.DataGridViewImageColumn AnimeData_Mn10;
        private System.Windows.Forms.DataGridViewImageColumn AnimeData_Mn11;
        private System.Windows.Forms.DataGridViewImageColumn AnimeData_Mn12;
        private System.Windows.Forms.DataGridViewImageColumn AnimeData_Mn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGenres_Mn01;
        private System.Windows.Forms.DataGridViewImageColumn DataGenres_Mn02;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGenres_Mn03;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGenres_Mn04;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGenres_Mn05;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGenres_Mn06;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGenres_Mn07;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGroups_Mn01;
        private System.Windows.Forms.DataGridViewImageColumn DataGroups_Mn02;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGroups_Mn03;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGroups_Mn04;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGroups_Mn05;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGroups_Mn06;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGroups_Mn07;
        private System.Windows.Forms.GroupBox Options_GR05;
        private System.Windows.Forms.GroupBox Options_GR03;
        private System.Windows.Forms.GroupBox Options_GR02;
        private System.Windows.Forms.CheckBox Options_DetectMyListStatusCheckBox;
        private System.Windows.Forms.Button Options_SetingsDefault;
        private System.Windows.Forms.CheckBox Options_SaveLogsToFilesCheckBox;
        private System.Windows.Forms.GroupBox Options_GR06;
        private System.Windows.Forms.CheckBox Options_LaunchWebServerOnStartupCheckBox;
        private System.Windows.Forms.Label Options_MpcHcPortLabel;
        private System.Windows.Forms.Label Options_WebServerPortLabel;
        private System.Windows.Forms.Button Options_CH13BT;
        private System.Windows.Forms.NumericUpDown WebServer_MPCHC;
        private System.Windows.Forms.NumericUpDown WebServer_Port;
        private System.Windows.Forms.Button Options_w8Hack;
    }
}

