/**
 *@title SelfAspNet / SampleAsp / NT10_FlagmentObject /
 *       PageSubClassDiv / ValidateMessagePage.cs
 *@target ValidSubPageSample.aspx.cs
 *
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 第10章 部品化 / 10.6 Page派生クラス / p545
 *         ◆Page派生クラス
 *         ・System.Web.UI.Pageクラスと「.aspx」ASPページの間に、
 *           Pageを継承したクラスを挿入し、ASPページ共通の処理を記述。
 *         ・例: マスターページ操作, 共通した初期化処理の呼出、メッセージ など
 *         ・複数ページで一貫した処理、変更時も1か所を修正すれば済む。
 *         
 *@inherits System.Web.UI.Page
 *           ↑
 *          ValidateMessagePage.cs
 *           ↑
 *          ValidPageSample.aspx.cs
 *          
 *@subject 「ValidateMessagePage.cs」Page派生クラス
 *          ＊System.Web.UI.Pageクラスを継承
 *              public class ValidateMessagePage : System.Web.UI.Page { }
 *            
 *          ＊const定数でエラーメッセージを定義
 *             ・{0}, {1}, {2} プレースホルダ => String.Format()
 *             ・本来は 「.config」<appSettings>に記述すべき。
 *            
 *          ＊OnPreRenderComplete(EventArgs) 
 *              ・Pageクラスのメソッド(=イベントハンドラー)
 *              ・ページの全ての出力準備ができた時点で呼び出される
 *              ・ASPページに配置されたデータバインドの Templateに配置された
 *                検証コントロールはこの時点まで有効にはならないので注意。
 *              ・overrideする場合は、基底クラス Pageの同メソッドも呼出。
 *                  base.OnPreRenderComplete(e);
 *              ・検証エラーをチェックし、メッセージを定義、
 *                必要な共通プロパティを１か所で定義
 *              ・【前提】ErrorMessageには、
 *                 各項目の文字列が事前に代入されていることが前提
 *                 => 「.aspx」ErrorMessage=""
 *                 
 *          ＊メンバー
 *           ValidatorCollection Page.Validators 〔NT86〕
 *              // ページ内に配置された全検証コントロールのコレクション
 *              // 要素は BaseValidator 
 *              // 各検証コントロールのパラメタにアクセスする場合はキャストして利用する。
 *              
 *           valid.EeeorMessage / Display / SetFocusOnError / Text 〔NT24〕 
 *           valid.Operator 〔ComapereValidator NT26〕
 *            
 *@subject 「ValidPageSample.aspx.cs」ValidateMessagePageを継承
 *          public partial class ValidPageSample : ValidateMessagePage { }
 *          
 *@based    NT03_ServerContorol / ValidSample.aspx
 *@subject 「ValidPageSample.aspx」
 *          検証コントロールの各プロパティを修正
 *          (ページ派生クラスで定義済なので重複しているものはデフォルト値に戻す)
 *          
 *          Display="Static", SetFocusOnError="false", Text=""
 *          ErrorMessage="" 各項目を事前入力
 *          「Name」「Body Weight」「Birthday」「E-Mail」「E-mail,Email(Confirm)」
 *          
 *          【註】CompareValidator は「,」区切りにすること。
 *           => valid.ErrorMessage.Split(',');で分割に利用している
 *
 *@NOTE【実行】ValidPageSample.aspx
 *      不適切な入力 -> [Submit] -> 検証メッセージの出力を確認 
 *      =>〔ValidPageSample_withValidateMessagePage.jpg〕
 *      
 *@see NT03_ServerContorol / ValidSample.aspx
 *@see ValidPageSample_withValidateMessagePage.jpg
 *@author shika
 *@date 2022-05-20
 */
using System;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT10_FlagmentObject.PageSubClassDiv
{
    public class ValidateMessagePage : System.Web.UI.Page
    {
        protected const string REQUIRE_MSG 
            = "{0}は 必ず入力してください。";
        protected const string RANGE_MSG 
            = "{0}は {1}～{2}の範囲で入力してください。";
        protected const string REGEX_MSG 
            = "{0}は 正しい形式で入力してください。";
        protected const string COMPARE_MSG 
            = "{0}と{1}は 同一文字列で入力してください。";
        protected const string TYPE_MSG 
            = "{0}は 正しいデータ型で入力してください。";

        protected override void OnPreRenderComplete(EventArgs e)
        {
            base.OnPreRenderComplete(e);

            foreach (BaseValidator valid in Page.Validators)
            {
                if (!valid.SetFocusOnError)
                {
                    switch (valid.GetType().Name)
                    {
                        case "RequiredFieldValidator":
                            valid.ErrorMessage =
                                String.Format(REQUIRE_MSG, valid.ErrorMessage);
                            break;

                        case "RangeValidator":
                            var range = (RangeValidator)valid;
                            valid.ErrorMessage =
                                String.Format(RANGE_MSG, valid.ErrorMessage,
                                    range.MinimumValue, range.MaximumValue);
                            break;

                        case "RegularExpressionValidator":
                            valid.ErrorMessage =
                                String.Format(REGEX_MSG, valid.ErrorMessage);
                            break;

                        case "CompareValidator":
                            var compare = (CompareValidator)valid;
                            string[] mesAry = valid.ErrorMessage.Split(',');

                            if(compare.Operator == ValidationCompareOperator.DataTypeCheck)
                            {
                                valid.ErrorMessage =
                                   String.Format(TYPE_MSG, mesAry[0]);
                            }
                            else
                            {
                                valid.ErrorMessage =
                                    String.Format(COMPARE_MSG, mesAry[0], mesAry[1]);
                            }
                            break;
                    }//switch

                    valid.Display = ValidatorDisplay.Dynamic;
                    valid.SetFocusOnError = true;
                    valid.Text = "<！>";
                }//if
            }//foreach
        }//OnPreRenderComplete()
    }//class
}