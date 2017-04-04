using System.CodeDom.Compiler;
using System.Linq;
using System.Xml.Linq;

namespace XmlToolsTest
{
    [GeneratedCode("XmlTools", "0.1.0")]
    public class SchemaCorrector
    {
        public SchemaCorrector(XDocument document)
        {
            _document = document;
        }
        private readonly XDocument _document;
        public XDocument CorrectDocument()
        {
            var rootElement = _document.Root;
            switch (rootElement.Name.LocalName.ToUpperInvariant())
            {
                case "GAEB":
                    if (rootElement.Name.LocalName != "GAEB")
                    {
                        rootElement.Name = rootElement.Name.Namespace + "GAEB";
                    }
                    CheckElementType_tgGAEB(rootElement);
                    break;
            }
            return _document;
        }
        private void CheckElementType_ds_Signature(XElement element)
        {
            // The Xml type "ds:Signature" could not be analyzed, no checks can be made.
            // This might be the case for externally referenced types.
        }
        private void CheckElementType_InlineComplexType_c393af0f_d89e_4806_b950_4e4bc58797f9(XElement element)
        {
            foreach (var attribute in element.Attributes())
            {
                switch (attribute.Name.LocalName.ToUpperInvariant())
                {
                    case "TYPEOFDAYS":
                        CheckAttributeType_InlineSimpleType_61f68c17_133a_46f4_93cb_a0e398950fd5(attribute);
                        if (attribute.Name.LocalName != "TypeOfDays")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "TypeOfDays", attribute.Value);
                        }
                        break;
                    case "DAYS":
                        CheckAttributeType_tgPositiveInteger(attribute);
                        if (attribute.Name.LocalName != "Days")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "Days", attribute.Value);
                        }
                        break;
                }
            }
        }
        private void CheckElementType_InlineSimpleType_0e2c21e1_d7e8_4b91_8bb9_1faa08b9abe3(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_InlineSimpleType_21581649_1a06_4fc1_be24_1c4428befca9(XElement element)
        {
            switch (element.Value.ToUpperInvariant())
            {
                case "DISPLPERS":
                    if (element.Value != "DisplPers")
                    {
                        element.Value = "DisplPers";
                    }
                    break;
                case "OTHER":
                    if (element.Value != "Other")
                    {
                        element.Value = "Other";
                    }
                    break;
                case "PERSECUTEE":
                    if (element.Value != "Persecutee")
                    {
                        element.Value = "Persecutee";
                    }
                    break;
                case "REFUGEE":
                    if (element.Value != "Refugee")
                    {
                        element.Value = "Refugee";
                    }
                    break;
                case "WRKSHOPFORBLI":
                    if (element.Value != "WrkShopForBli")
                    {
                        element.Value = "WrkShopForBli";
                    }
                    break;
                case "WRKSHOPFORDIS":
                    if (element.Value != "WrkShopForDis")
                    {
                        element.Value = "WrkShopForDis";
                    }
                    break;
                default:
                    element.Remove();
                    break;
            }
        }
        private void CheckElementType_InlineSimpleType_26b99855_0cdc_47c9_a6c8_b3708b16343d(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_InlineSimpleType_31b78963_2f79_4cf6_8ef9_1e2a148bb747(XElement element)
        {
            switch (element.Value.ToUpperInvariant())
            {
                case "CANCELORDER":
                    if (element.Value != "Cancelorder")
                    {
                        element.Value = "Cancelorder";
                    }
                    break;
                case "MAINT":
                    if (element.Value != "Maint")
                    {
                        element.Value = "Maint";
                    }
                    break;
                case "MODERN":
                    if (element.Value != "Modern")
                    {
                        element.Value = "Modern";
                    }
                    break;
                case "REPAIR":
                    if (element.Value != "Repair")
                    {
                        element.Value = "Repair";
                    }
                    break;
                case "WARR":
                    if (element.Value != "Warr")
                    {
                        element.Value = "Warr";
                    }
                    break;
                default:
                    element.Remove();
                    break;
            }
        }
        private void CheckElementType_InlineSimpleType_55a86d2a_59f3_43b4_85c4_f1ede88f4f71(XElement element)
        {
            switch (element.Value.ToUpperInvariant())
            {
                case "3.0":
                    if (element.Value != "3.0")
                    {
                        element.Value = "3.0";
                    }
                    break;
                case "3.1":
                    if (element.Value != "3.1")
                    {
                        element.Value = "3.1";
                    }
                    break;
                default:
                    element.Remove();
                    break;
            }
        }
        private void CheckElementType_InlineSimpleType_58009169_4e79_46a9_90fb_e33cd44f3da9(XElement element)
        {
            switch (element.Value.ToUpperInvariant())
            {
                case "OWNFOROWN":
                    if (element.Value != "OwnForOwn")
                    {
                        element.Value = "OwnForOwn";
                    }
                    break;
                case "OWNFORTHI":
                    if (element.Value != "OwnForThi")
                    {
                        element.Value = "OwnForThi";
                    }
                    break;
                case "THIFORTHI":
                    if (element.Value != "ThiForThi")
                    {
                        element.Value = "ThiForThi";
                    }
                    break;
                default:
                    element.Remove();
                    break;
            }
        }
        private void CheckElementType_InlineSimpleType_5e147ef0_d626_4268_a491_44dd6fe52f97(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_InlineSimpleType_5f1a877a_e1fa_473a_a48b_1e62fe5c7e3b(XElement element)
        {
            switch (element.Value.ToUpperInvariant())
            {
                case "APPROX":
                    if (element.Value != "approx")
                    {
                        element.Value = "approx";
                    }
                    break;
                case "LUMP":
                    if (element.Value != "lump")
                    {
                        element.Value = "lump";
                    }
                    break;
                case "SCOPE":
                    if (element.Value != "scope")
                    {
                        element.Value = "scope";
                    }
                    break;
                case "TO":
                    if (element.Value != "to")
                    {
                        element.Value = "to";
                    }
                    break;
                default:
                    element.Remove();
                    break;
            }
        }
        private void CheckElementType_InlineSimpleType_6c279709_a7bd_4b53_953b_498072177191(XElement element)
        {
            switch (element.Value.ToUpperInvariant())
            {
                case "2009-12":
                    if (element.Value != "2009-12")
                    {
                        element.Value = "2009-12";
                    }
                    break;
                default:
                    element.Remove();
                    break;
            }
        }
        private void CheckElementType_InlineSimpleType_714540bc_1b85_470e_bca9_849b9c59177d(XElement element)
        {
            switch (element.Value.ToUpperInvariant())
            {
                case "ASARR":
                    if (element.Value != "AsArr")
                    {
                        element.Value = "AsArr";
                    }
                    break;
                case "IMM":
                    if (element.Value != "Imm")
                    {
                        element.Value = "Imm";
                    }
                    break;
                case "RUSH":
                    if (element.Value != "Rush")
                    {
                        element.Value = "Rush";
                    }
                    break;
                default:
                    element.Remove();
                    break;
            }
        }
        private void CheckElementType_InlineSimpleType_71ea5dd8_98d9_4b85_8538_fe1ddabda711(XElement element)
        {
            switch (element.Value.ToUpperInvariant())
            {
                case "DESPINHOUSECAP":
                    if (element.Value != "DespInHouseCap")
                    {
                        element.Value = "DespInHouseCap";
                    }
                    break;
                case "INHOUSEWRK":
                    if (element.Value != "InHouseWrk")
                    {
                        element.Value = "InHouseWrk";
                    }
                    break;
                case "LACKOFINHOUSECAP":
                    if (element.Value != "LackOfInHouseCap")
                    {
                        element.Value = "LackOfInHouseCap";
                    }
                    break;
                default:
                    element.Remove();
                    break;
            }
        }
        private void CheckElementType_InlineSimpleType_7229fd10_efaa_42c3_89ee_1c6d572b38fa(XElement element)
        {
            switch (element.Value.ToUpperInvariant())
            {
                case "ALLINCAT":
                    if (element.Value != "AllInCat")
                    {
                        element.Value = "AllInCat";
                    }
                    break;
                case "IDENTASMARK":
                    if (element.Value != "IdentAsMark")
                    {
                        element.Value = "IdentAsMark";
                    }
                    break;
                case "LISTINSUBQTY":
                    if (element.Value != "ListInSubQty")
                    {
                        element.Value = "ListInSubQty";
                    }
                    break;
                default:
                    element.Remove();
                    break;
            }
        }
        private void CheckElementType_InlineSimpleType_73ff0675_632a_4a43_b806_db852fbb4062(XElement element)
        {
            switch (element.Value.ToUpperInvariant())
            {
                case "ALLTXT":
                    if (element.Value != "AllTxt")
                    {
                        element.Value = "AllTxt";
                    }
                    break;
                case "DETAILTXT":
                    if (element.Value != "DetailTxt")
                    {
                        element.Value = "DetailTxt";
                    }
                    break;
                case "OUTTXT":
                    if (element.Value != "OutTxt")
                    {
                        element.Value = "OutTxt";
                    }
                    break;
                default:
                    element.Remove();
                    break;
            }
        }
        private void CheckElementType_InlineSimpleType_7b235e6b_8b93_4949_9325_695fbdf088e1(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_InlineSimpleType_807da388_5ad3_4662_b3a0_70711fe5c499(XElement element)
        {
            switch (element.Value.ToUpperInvariant())
            {
                case "AVAILABLE":
                    if (element.Value != "Available")
                    {
                        element.Value = "Available";
                    }
                    break;
                default:
                    element.Remove();
                    break;
            }
        }
        private void CheckElementType_InlineSimpleType_8cec7720_9f32_40ec_969e_1c45e16a1495(XElement element)
        {
            switch (element.Value.ToUpperInvariant())
            {
                case "FINAPARTINSP":
                    if (element.Value != "FinApartInsp")
                    {
                        element.Value = "FinApartInsp";
                    }
                    break;
                case "INSURCLAIM":
                    if (element.Value != "InsurClaim")
                    {
                        element.Value = "InsurClaim";
                    }
                    break;
                case "INVOICTOTEN":
                    if (element.Value != "InvoicToTen")
                    {
                        element.Value = "InvoicToTen";
                    }
                    break;
                case "STANDCON":
                    if (element.Value != "StandCon")
                    {
                        element.Value = "StandCon";
                    }
                    break;
                case "THIRDPARTYBILL":
                    if (element.Value != "ThirdPartyBill")
                    {
                        element.Value = "ThirdPartyBill";
                    }
                    break;
                default:
                    element.Remove();
                    break;
            }
        }
        private void CheckElementType_InlineSimpleType_90bb8e06_6ca4_4eb4_89fb_ffef89355ec8(XElement element)
        {
            switch (element.Value.ToUpperInvariant())
            {
                case "CRAFTS":
                    if (element.Value != "Crafts")
                    {
                        element.Value = "Crafts";
                    }
                    break;
                case "DEALER":
                    if (element.Value != "Dealer")
                    {
                        element.Value = "Dealer";
                    }
                    break;
                case "INDUSTRY":
                    if (element.Value != "Industry")
                    {
                        element.Value = "Industry";
                    }
                    break;
                case "OTHER":
                    if (element.Value != "Other")
                    {
                        element.Value = "Other";
                    }
                    break;
                case "UTILITYCOMP":
                    if (element.Value != "UtilityComp")
                    {
                        element.Value = "UtilityComp";
                    }
                    break;
                default:
                    element.Remove();
                    break;
            }
        }
        private void CheckElementType_InlineSimpleType_91e4e14b_9560_4958_a24b_ccd79f94a925(XElement element)
        {
            switch (element.Value.ToUpperInvariant())
            {
                case "REF":
                    if (element.Value != "Ref")
                    {
                        element.Value = "Ref";
                    }
                    break;
                case "REP":
                    if (element.Value != "Rep")
                    {
                        element.Value = "Rep";
                    }
                    break;
                default:
                    element.Remove();
                    break;
            }
        }
        private void CheckElementType_InlineSimpleType_9983c68c_f1cf_4f5a_a1a3_a1df8cc7065e(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_InlineSimpleType_a48342f5_265a_4f9f_86cb_749fcab1f7cb(XElement element)
        {
            switch (element.Value.ToUpperInvariant())
            {
                case "MAINT":
                    if (element.Value != "Maint")
                    {
                        element.Value = "Maint";
                    }
                    break;
                case "MASTAGREE":
                    if (element.Value != "MastAgree")
                    {
                        element.Value = "MastAgree";
                    }
                    break;
                case "MASTMAINTAGREE":
                    if (element.Value != "MastMaintAgree")
                    {
                        element.Value = "MastMaintAgree";
                    }
                    break;
                default:
                    element.Remove();
                    break;
            }
        }
        private void CheckElementType_InlineSimpleType_ab7f0ad8_4b6e_43a9_939e_25c67c5e63b3(XElement element)
        {
            switch (element.Value.ToUpperInvariant())
            {
                case "0":
                    if (element.Value != "0")
                    {
                        element.Value = "0";
                    }
                    break;
                case "2":
                    if (element.Value != "2")
                    {
                        element.Value = "2";
                    }
                    break;
                case "3":
                    if (element.Value != "3")
                    {
                        element.Value = "3";
                    }
                    break;
                case "4":
                    if (element.Value != "4")
                    {
                        element.Value = "4";
                    }
                    break;
                case "5":
                    if (element.Value != "5")
                    {
                        element.Value = "5";
                    }
                    break;
                case "6":
                    if (element.Value != "6")
                    {
                        element.Value = "6";
                    }
                    break;
                default:
                    element.Remove();
                    break;
            }
        }
        private void CheckElementType_InlineSimpleType_abe52456_73f1_438b_bc9e_0ac8898720ae(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_InlineSimpleType_aef2a78d_a48c_45fa_a4a9_b7a38ea33dd6(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_InlineSimpleType_c7977909_d167_4c1c_b7cb_5c139803c294(XElement element)
        {
            switch (element.Value.ToUpperInvariant())
            {
                case "CONTRACTOR":
                    if (element.Value != "Contractor")
                    {
                        element.Value = "Contractor";
                    }
                    break;
                case "OWNER":
                    if (element.Value != "Owner")
                    {
                        element.Value = "Owner";
                    }
                    break;
                default:
                    element.Remove();
                    break;
            }
        }
        private void CheckElementType_InlineSimpleType_ce6f25a9_1f64_466f_9aae_000acb376bcb(XElement element)
        {
            switch (element.Value.ToUpperInvariant())
            {
                case "CLOSEDPROC":
                    if (element.Value != "ClosedProc")
                    {
                        element.Value = "ClosedProc";
                    }
                    break;
                case "INTNATO":
                    if (element.Value != "IntNATO")
                    {
                        element.Value = "IntNATO";
                    }
                    break;
                case "NEGCONT":
                    if (element.Value != "NegCont")
                    {
                        element.Value = "NegCont";
                    }
                    break;
                case "NEGPROC":
                    if (element.Value != "NegProc")
                    {
                        element.Value = "NegProc";
                    }
                    break;
                case "OPENCALL":
                    if (element.Value != "OpenCall")
                    {
                        element.Value = "OpenCall";
                    }
                    break;
                case "OPENPROC":
                    if (element.Value != "OpenProc")
                    {
                        element.Value = "OpenProc";
                    }
                    break;
                case "SELECTCALL":
                    if (element.Value != "SelectCall")
                    {
                        element.Value = "SelectCall";
                    }
                    break;
                default:
                    element.Remove();
                    break;
            }
        }
        private void CheckElementType_InlineSimpleType_d2bf5672_f089_4841_9ffe_3267a4e04445(XElement element)
        {
            switch (element.Value.ToUpperInvariant())
            {
                case "81":
                    if (element.Value != "81")
                    {
                        element.Value = "81";
                    }
                    break;
                case "82":
                    if (element.Value != "82")
                    {
                        element.Value = "82";
                    }
                    break;
                case "83":
                    if (element.Value != "83")
                    {
                        element.Value = "83";
                    }
                    break;
                case "84":
                    if (element.Value != "84")
                    {
                        element.Value = "84";
                    }
                    break;
                case "85":
                    if (element.Value != "85")
                    {
                        element.Value = "85";
                    }
                    break;
                case "86":
                    if (element.Value != "86")
                    {
                        element.Value = "86";
                    }
                    break;
                case "87":
                    if (element.Value != "87")
                    {
                        element.Value = "87";
                    }
                    break;
                default:
                    element.Remove();
                    break;
            }
        }
        private void CheckElementType_InlineSimpleType_e03cfb08_9ade_4669_bd18_785245e1ac65(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_InlineSimpleType_ee8fef25_d48f_4694_aabb_e127816c5e41(XElement element)
        {
            switch (element.Value.ToUpperInvariant())
            {
                case "MONTHS":
                    if (element.Value != "Months")
                    {
                        element.Value = "Months";
                    }
                    break;
                case "YEARS":
                    if (element.Value != "Years")
                    {
                        element.Value = "Years";
                    }
                    break;
                default:
                    element.Remove();
                    break;
            }
        }
        private void CheckElementType_InlineSimpleType_f1745c91_24d5_415a_be3b_c19e52894e52(XElement element)
        {
            switch (element.Value.ToUpperInvariant())
            {
                case "BOQLEVEL":
                    if (element.Value != "BoQLevel")
                    {
                        element.Value = "BoQLevel";
                    }
                    break;
                case "INDEX":
                    if (element.Value != "Index")
                    {
                        element.Value = "Index";
                    }
                    break;
                case "ITEM":
                    if (element.Value != "Item")
                    {
                        element.Value = "Item";
                    }
                    break;
                case "LOT":
                    if (element.Value != "Lot")
                    {
                        element.Value = "Lot";
                    }
                    break;
                default:
                    element.Remove();
                    break;
            }
        }
        private void CheckElementType_tgAccepted(XElement element)
        {
            switch (element.Value.ToUpperInvariant())
            {
                case "ALTACCEPT":
                    if (element.Value != "AltAccept")
                    {
                        element.Value = "AltAccept";
                    }
                    break;
                case "BASREJECT":
                    if (element.Value != "BasReject")
                    {
                        element.Value = "BasReject";
                    }
                    break;
                default:
                    element.Remove();
                    break;
            }
        }
        private void CheckElementType_tgAddress(XElement element)
        {
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "ILN":
                        if (child.Name.LocalName != "ILN")
                        {
                            child.Name = child.Name.Namespace + "ILN";
                        }
                        CheckElementType_tgNormalizedString20(child);
                        break;
                    case "CTLGASSIGN":
                        if (child.Name.LocalName != "CtlgAssign")
                        {
                            child.Name = child.Name.Namespace + "CtlgAssign";
                        }
                        CheckElementType_tgCtlgAssign(child);
                        break;
                    case "NAME1":
                        if (child.Name.LocalName != "Name1")
                        {
                            child.Name = child.Name.Namespace + "Name1";
                        }
                        CheckElementType_tgNormalizedString40(child);
                        break;
                    case "NAME2":
                        if (child.Name.LocalName != "Name2")
                        {
                            child.Name = child.Name.Namespace + "Name2";
                        }
                        CheckElementType_tgNormalizedString40(child);
                        break;
                    case "NAME3":
                        if (child.Name.LocalName != "Name3")
                        {
                            child.Name = child.Name.Namespace + "Name3";
                        }
                        CheckElementType_tgNormalizedString40(child);
                        break;
                    case "NAME4":
                        if (child.Name.LocalName != "Name4")
                        {
                            child.Name = child.Name.Namespace + "Name4";
                        }
                        CheckElementType_tgNormalizedString40(child);
                        break;
                    case "STREET":
                        if (child.Name.LocalName != "Street")
                        {
                            child.Name = child.Name.Namespace + "Street";
                        }
                        CheckElementType_tgNormalizedString40(child);
                        break;
                    case "PCODE":
                        if (child.Name.LocalName != "PCode")
                        {
                            child.Name = child.Name.Namespace + "PCode";
                        }
                        CheckElementType_tgNormalizedString20(child);
                        break;
                    case "CITY":
                        if (child.Name.LocalName != "City")
                        {
                            child.Name = child.Name.Namespace + "City";
                        }
                        CheckElementType_tgNormalizedString40(child);
                        break;
                    case "COUNTRY":
                        if (child.Name.LocalName != "Country")
                        {
                            child.Name = child.Name.Namespace + "Country";
                        }
                        CheckElementType_tgNormalizedString40(child);
                        break;
                    case "CONTACT":
                        if (child.Name.LocalName != "Contact")
                        {
                            child.Name = child.Name.Namespace + "Contact";
                        }
                        CheckElementType_tgNormalizedString40(child);
                        break;
                    case "PHONE":
                        if (child.Name.LocalName != "Phone")
                        {
                            child.Name = child.Name.Namespace + "Phone";
                        }
                        CheckElementType_tgNormalizedString20(child);
                        break;
                    case "FAX":
                        if (child.Name.LocalName != "Fax")
                        {
                            child.Name = child.Name.Namespace + "Fax";
                        }
                        CheckElementType_tgNormalizedString20(child);
                        break;
                    case "EMAIL":
                        if (child.Name.LocalName != "Email")
                        {
                            child.Name = child.Name.Namespace + "Email";
                        }
                        CheckElementType_tgNormalizedString256(child);
                        break;
                    case "VATID":
                        if (child.Name.LocalName != "VATID")
                        {
                            child.Name = child.Name.Namespace + "VATID";
                        }
                        CheckElementType_tgNormalizedString80(child);
                        break;
                    case "BANK":
                        if (child.Name.LocalName != "Bank")
                        {
                            child.Name = child.Name.Namespace + "Bank";
                        }
                        CheckElementType_tgBank(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgAddText(XElement element)
        {
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "OUTLINEADDTEXT":
                        if (child.Name.LocalName != "OutlineAddText")
                        {
                            child.Name = child.Name.Namespace + "OutlineAddText";
                        }
                        CheckElementType_tgMLText(child);
                        break;
                    case "DETAILADDTEXT":
                        if (child.Name.LocalName != "DetailAddText")
                        {
                            child.Name = child.Name.Namespace + "DetailAddText";
                        }
                        CheckElementType_tgFText(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgALNGroupNo(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_tgALNSerNo(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_tgAlterBidStatus(XElement element)
        {
            switch (element.Value.ToUpperInvariant())
            {
                case "IDENTICAL":
                    if (element.Value != "Identical")
                    {
                        element.Value = "Identical";
                    }
                    break;
                case "MODIFIED":
                    if (element.Value != "Modified")
                    {
                        element.Value = "Modified";
                    }
                    break;
                case "N/A":
                    if (element.Value != "N/A")
                    {
                        element.Value = "N/A";
                    }
                    break;
                case "NEW":
                    if (element.Value != "New")
                    {
                        element.Value = "New";
                    }
                    break;
                default:
                    element.Remove();
                    break;
            }
        }
        private void CheckElementType_tgArticle(XElement element)
        {
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "BRAND":
                        if (child.Name.LocalName != "Brand")
                        {
                            child.Name = child.Name.Namespace + "Brand";
                        }
                        CheckElementType_tgNormalizedString60(child);
                        break;
                    case "ARTNO":
                        if (child.Name.LocalName != "ArtNo")
                        {
                            child.Name = child.Name.Namespace + "ArtNo";
                        }
                        CheckElementType_tgNormalizedString15(child);
                        break;
                    case "QTY":
                        if (child.Name.LocalName != "Qty")
                        {
                            child.Name = child.Name.Namespace + "Qty";
                        }
                        CheckElementType_tgDecimal_11_3(child);
                        break;
                    case "QU":
                        if (child.Name.LocalName != "QU")
                        {
                            child.Name = child.Name.Namespace + "QU";
                        }
                        CheckElementType_tgNormalizedString4(child);
                        break;
                    case "ARTOUTLINE":
                        if (child.Name.LocalName != "ArtOutline")
                        {
                            child.Name = child.Name.Namespace + "ArtOutline";
                        }
                        CheckElementType_tgMLText(child);
                        break;
                    case "ADDTEXT":
                        if (child.Name.LocalName != "AddText")
                        {
                            child.Name = child.Name.Namespace + "AddText";
                        }
                        CheckElementType_tgAddText(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgAward(XElement element)
        {
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "CNSTSITE":
                        if (child.Name.LocalName != "CnstSite")
                        {
                            child.Name = child.Name.Namespace + "CnstSite";
                        }
                        CheckElementType_tgCnstSite(child);
                        break;
                    case "NOTIFSITE":
                        if (child.Name.LocalName != "NotifSite")
                        {
                            child.Name = child.Name.Namespace + "NotifSite";
                        }
                        CheckElementType_tgNotifSite(child);
                        break;
                    case "DP":
                        if (child.Name.LocalName != "DP")
                        {
                            child.Name = child.Name.Namespace + "DP";
                        }
                        CheckElementType_InlineSimpleType_d2bf5672_f089_4841_9ffe_3267a4e04445(child);
                        break;
                    case "AWARDINFO":
                        if (child.Name.LocalName != "AwardInfo")
                        {
                            child.Name = child.Name.Namespace + "AwardInfo";
                        }
                        CheckElementType_tgAwardInfo(child);
                        break;
                    case "OWN":
                        if (child.Name.LocalName != "OWN")
                        {
                            child.Name = child.Name.Namespace + "OWN";
                        }
                        CheckElementType_tgOWN(child);
                        break;
                    case "REQUESTER":
                        if (child.Name.LocalName != "Requester")
                        {
                            child.Name = child.Name.Namespace + "Requester";
                        }
                        CheckElementType_tgRequester(child);
                        break;
                    case "CTR":
                        if (child.Name.LocalName != "CTR")
                        {
                            child.Name = child.Name.Namespace + "CTR";
                        }
                        CheckElementType_tgCTR(child);
                        break;
                    case "ADDTEXT":
                        if (child.Name.LocalName != "AddText")
                        {
                            child.Name = child.Name.Namespace + "AddText";
                        }
                        CheckElementType_tgAddText(child);
                        break;
                    case "BOQ":
                        if (child.Name.LocalName != "BoQ")
                        {
                            child.Name = child.Name.Namespace + "BoQ";
                        }
                        CheckElementType_tgBoQ(child);
                        break;
                    case "WGCHANGE":
                        if (child.Name.LocalName != "WgChange")
                        {
                            child.Name = child.Name.Namespace + "WgChange";
                        }
                        CheckElementType_tgWgChange(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgAwardInfo(XElement element)
        {
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "CUR":
                        if (child.Name.LocalName != "Cur")
                        {
                            child.Name = child.Name.Namespace + "Cur";
                        }
                        CheckElementType_tgCur(child);
                        break;
                    case "CURLBL":
                        if (child.Name.LocalName != "CurLbl")
                        {
                            child.Name = child.Name.Namespace + "CurLbl";
                        }
                        CheckElementType_tgCurLbl(child);
                        break;
                    case "OPENDATE":
                        if (child.Name.LocalName != "OpenDate")
                        {
                            child.Name = child.Name.Namespace + "OpenDate";
                        }
                        CheckElementType_tgDate(child);
                        break;
                    case "OPENTIME":
                        if (child.Name.LocalName != "OpenTime")
                        {
                            child.Name = child.Name.Namespace + "OpenTime";
                        }
                        CheckElementType_tgTime(child);
                        break;
                    case "CAT":
                        if (child.Name.LocalName != "Cat")
                        {
                            child.Name = child.Name.Namespace + "Cat";
                        }
                        CheckElementType_InlineSimpleType_ce6f25a9_1f64_466f_9aae_000acb376bcb(child);
                        break;
                    case "SPECIALTYPE":
                        if (child.Name.LocalName != "SpecialType")
                        {
                            child.Name = child.Name.Namespace + "SpecialType";
                        }
                        CheckElementType_InlineSimpleType_a48342f5_265a_4f9f_86cb_749fcab1f7cb(child);
                        break;
                    case "BIDDATE":
                        if (child.Name.LocalName != "BidDate")
                        {
                            child.Name = child.Name.Namespace + "BidDate";
                        }
                        CheckElementType_tgDate(child);
                        break;
                    case "EVALEND":
                        if (child.Name.LocalName != "EvalEnd")
                        {
                            child.Name = child.Name.Namespace + "EvalEnd";
                        }
                        CheckElementType_tgDate(child);
                        break;
                    case "SUBMLOC":
                        if (child.Name.LocalName != "SubmLoc")
                        {
                            child.Name = child.Name.Namespace + "SubmLoc";
                        }
                        CheckElementType_tgNormalizedString60(child);
                        break;
                    case "CNSTSTART":
                        if (child.Name.LocalName != "CnstStart")
                        {
                            child.Name = child.Name.Namespace + "CnstStart";
                        }
                        CheckElementType_tgDate(child);
                        break;
                    case "CNSTEND":
                        if (child.Name.LocalName != "CnstEnd")
                        {
                            child.Name = child.Name.Namespace + "CnstEnd";
                        }
                        CheckElementType_tgDate(child);
                        break;
                    case "CONTRNO":
                        if (child.Name.LocalName != "ContrNo")
                        {
                            child.Name = child.Name.Namespace + "ContrNo";
                        }
                        CheckElementType_tgNormalizedString20(child);
                        break;
                    case "CONTRDATE":
                        if (child.Name.LocalName != "ContrDate")
                        {
                            child.Name = child.Name.Namespace + "ContrDate";
                        }
                        CheckElementType_tgDate(child);
                        break;
                    case "ACCEPTTYPE":
                        if (child.Name.LocalName != "AcceptType")
                        {
                            child.Name = child.Name.Namespace + "AcceptType";
                        }
                        CheckElementType_tgNormalizedString60(child);
                        break;
                    case "ACCEPTDATE":
                        if (child.Name.LocalName != "AcceptDate")
                        {
                            child.Name = child.Name.Namespace + "AcceptDate";
                        }
                        CheckElementType_tgDate(child);
                        break;
                    case "WARRDUR":
                        if (child.Name.LocalName != "WarrDur")
                        {
                            child.Name = child.Name.Namespace + "WarrDur";
                        }
                        CheckElementType_InlineSimpleType_abe52456_73f1_438b_bc9e_0ac8898720ae(child);
                        break;
                    case "WARRUNIT":
                        if (child.Name.LocalName != "WarrUnit")
                        {
                            child.Name = child.Name.Namespace + "WarrUnit";
                        }
                        CheckElementType_InlineSimpleType_ee8fef25_d48f_4694_aabb_e127816c5e41(child);
                        break;
                    case "WARREND":
                        if (child.Name.LocalName != "WarrEnd")
                        {
                            child.Name = child.Name.Namespace + "WarrEnd";
                        }
                        CheckElementType_tgDate(child);
                        break;
                    case "PERFORMPCNT":
                        if (child.Name.LocalName != "PerformPcnt")
                        {
                            child.Name = child.Name.Namespace + "PerformPcnt";
                        }
                        CheckElementType_tgDecimal_5_2(child);
                        break;
                    case "WARRANTPCNT":
                        if (child.Name.LocalName != "WarrantPcnt")
                        {
                            child.Name = child.Name.Namespace + "WarrantPcnt";
                        }
                        CheckElementType_tgDecimal_5_2(child);
                        break;
                    case "COINFO":
                        if (child.Name.LocalName != "COInfo")
                        {
                            child.Name = child.Name.Namespace + "COInfo";
                        }
                        CheckElementType_tgCOInfo(child);
                        break;
                    case "MAINTINFO":
                        if (child.Name.LocalName != "MaintInfo")
                        {
                            child.Name = child.Name.Namespace + "MaintInfo";
                        }
                        CheckElementType_tgMaintInfo(child);
                        break;
                    case "MASTAGRINFO":
                        if (child.Name.LocalName != "MastAgrInfo")
                        {
                            child.Name = child.Name.Namespace + "MastAgrInfo";
                        }
                        CheckElementType_tgMastAgrInfo(child);
                        break;
                    case "CASHDISCOUNT":
                        if (child.Name.LocalName != "CashDiscount")
                        {
                            child.Name = child.Name.Namespace + "CashDiscount";
                        }
                        CheckElementType_tgCashDiscount(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgBank(XElement element)
        {
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "LBLBANK":
                        if (child.Name.LocalName != "LblBank")
                        {
                            child.Name = child.Name.Namespace + "LblBank";
                        }
                        CheckElementType_tgNormalizedString80(child);
                        break;
                    case "BRNO":
                        if (child.Name.LocalName != "BRNo")
                        {
                            child.Name = child.Name.Namespace + "BRNo";
                        }
                        CheckElementType_tgNormalizedString30(child);
                        break;
                    case "ACCTNO":
                        if (child.Name.LocalName != "AcctNo")
                        {
                            child.Name = child.Name.Namespace + "AcctNo";
                        }
                        CheckElementType_tgNormalizedString20(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgBoQ(XElement element)
        {
            foreach (var attribute in element.Attributes())
            {
                switch (attribute.Name.LocalName.ToUpperInvariant())
                {
                    case "ID":
                        CheckAttributeType_xs_ID(attribute);
                        if (attribute.Name.LocalName != "ID")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "ID", attribute.Value);
                        }
                        break;
                }
            }
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "BOQINFO":
                        if (child.Name.LocalName != "BoQInfo")
                        {
                            child.Name = child.Name.Namespace + "BoQInfo";
                        }
                        CheckElementType_tgBoQInfo(child);
                        break;
                    case "BOQBODY":
                        if (child.Name.LocalName != "BoQBody")
                        {
                            child.Name = child.Name.Namespace + "BoQBody";
                        }
                        CheckElementType_tgBoQBody(child);
                        break;
                    case "LOTGRP":
                        if (child.Name.LocalName != "LotGrp")
                        {
                            child.Name = child.Name.Namespace + "LotGrp";
                        }
                        CheckElementType_tgLotGrp(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgBoQBkdn(XElement element)
        {
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "TYPE":
                        if (child.Name.LocalName != "Type")
                        {
                            child.Name = child.Name.Namespace + "Type";
                        }
                        CheckElementType_InlineSimpleType_f1745c91_24d5_415a_be3b_c19e52894e52(child);
                        break;
                    case "LBLBOQBKDN":
                        if (child.Name.LocalName != "LblBoQBkdn")
                        {
                            child.Name = child.Name.Namespace + "LblBoQBkdn";
                        }
                        CheckElementType_tgNormalizedString40(child);
                        break;
                    case "LENGTH":
                        if (child.Name.LocalName != "Length")
                        {
                            child.Name = child.Name.Namespace + "Length";
                        }
                        CheckElementType_InlineSimpleType_0e2c21e1_d7e8_4b91_8bb9_1faa08b9abe3(child);
                        break;
                    case "NUM":
                        if (child.Name.LocalName != "Num")
                        {
                            child.Name = child.Name.Namespace + "Num";
                        }
                        CheckElementType_tgYesNo(child);
                        break;
                    case "ALIGNMENT":
                        if (child.Name.LocalName != "Alignment")
                        {
                            child.Name = child.Name.Namespace + "Alignment";
                        }
                        CheckElementType_tgLeftRight(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgBoQBody(XElement element)
        {
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "REMARK":
                        if (child.Name.LocalName != "Remark")
                        {
                            child.Name = child.Name.Namespace + "Remark";
                        }
                        CheckElementType_tgRemark(child);
                        break;
                    case "PERFDESCR":
                        if (child.Name.LocalName != "PerfDescr")
                        {
                            child.Name = child.Name.Namespace + "PerfDescr";
                        }
                        CheckElementType_tgPerfDescr(child);
                        break;
                    case "BOQCTGY":
                        if (child.Name.LocalName != "BoQCtgy")
                        {
                            child.Name = child.Name.Namespace + "BoQCtgy";
                        }
                        CheckElementType_tgBoQCtgy(child);
                        break;
                    case "ITEMLIST":
                        if (child.Name.LocalName != "Itemlist")
                        {
                            child.Name = child.Name.Namespace + "Itemlist";
                        }
                        CheckElementType_tgItemlist(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgBoQCtgy(XElement element)
        {
            foreach (var attribute in element.Attributes())
            {
                switch (attribute.Name.LocalName.ToUpperInvariant())
                {
                    case "ID":
                        CheckAttributeType_xs_ID(attribute);
                        if (attribute.Name.LocalName != "ID")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "ID", attribute.Value);
                        }
                        break;
                    case "RNOPART":
                        CheckAttributeType_tgRNoPart(attribute);
                        if (attribute.Name.LocalName != "RNoPart")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "RNoPart", attribute.Value);
                        }
                        break;
                }
            }
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "CONO":
                        if (child.Name.LocalName != "CONo")
                        {
                            child.Name = child.Name.Namespace + "CONo";
                        }
                        CheckElementType_tgCONo(child);
                        break;
                    case "COSTATUS":
                        if (child.Name.LocalName != "COStatus")
                        {
                            child.Name = child.Name.Namespace + "COStatus";
                        }
                        CheckElementType_tgCOStatus(child);
                        break;
                    case "ALNBGROUPNO":
                        if (child.Name.LocalName != "ALNBGroupNo")
                        {
                            child.Name = child.Name.Namespace + "ALNBGroupNo";
                        }
                        CheckElementType_tgALNGroupNo(child);
                        break;
                    case "ALNBSERNO":
                        if (child.Name.LocalName != "ALNBSerNo")
                        {
                            child.Name = child.Name.Namespace + "ALNBSerNo";
                        }
                        CheckElementType_tgALNSerNo(child);
                        break;
                    case "ACCEPTED":
                        if (child.Name.LocalName != "Accepted")
                        {
                            child.Name = child.Name.Namespace + "Accepted";
                        }
                        CheckElementType_tgAccepted(child);
                        break;
                    case "LBLTX":
                        if (child.Name.LocalName != "LblTx")
                        {
                            child.Name = child.Name.Namespace + "LblTx";
                        }
                        CheckElementType_tgMLText(child);
                        break;
                    case "CPVCODE":
                        if (child.Name.LocalName != "CPVCode")
                        {
                            child.Name = child.Name.Namespace + "CPVCode";
                        }
                        CheckElementType_tgCPVCode(child);
                        break;
                    case "NOTAPPLBOQ":
                        if (child.Name.LocalName != "NotApplBoQ")
                        {
                            child.Name = child.Name.Namespace + "NotApplBoQ";
                        }
                        CheckElementType_tgNotAppl(child);
                        break;
                    case "CTLGASSIGN":
                        if (child.Name.LocalName != "CtlgAssign")
                        {
                            child.Name = child.Name.Namespace + "CtlgAssign";
                        }
                        CheckElementType_tgCtlgAssign(child);
                        break;
                    case "BOQBODY":
                        if (child.Name.LocalName != "BoQBody")
                        {
                            child.Name = child.Name.Namespace + "BoQBody";
                        }
                        CheckElementType_tgBoQBody(child);
                        break;
                    case "TOTALS":
                        if (child.Name.LocalName != "Totals")
                        {
                            child.Name = child.Name.Namespace + "Totals";
                        }
                        CheckElementType_tgTotals(child);
                        break;
                    case "ALTERBIDSTATUS":
                        if (child.Name.LocalName != "AlterBidStatus")
                        {
                            child.Name = child.Name.Namespace + "AlterBidStatus";
                        }
                        CheckElementType_tgAlterBidStatus(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgBoQInfo(XElement element)
        {
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "CONO":
                        if (child.Name.LocalName != "CONo")
                        {
                            child.Name = child.Name.Namespace + "CONo";
                        }
                        CheckElementType_tgCONo(child);
                        break;
                    case "COSTATUS":
                        if (child.Name.LocalName != "COStatus")
                        {
                            child.Name = child.Name.Namespace + "COStatus";
                        }
                        CheckElementType_tgCOStatus(child);
                        break;
                    case "NOUPCOMPS":
                        if (child.Name.LocalName != "NoUPComps")
                        {
                            child.Name = child.Name.Namespace + "NoUPComps";
                        }
                        CheckElementType_InlineSimpleType_ab7f0ad8_4b6e_43a9_939e_25c67c5e63b3(child);
                        break;
                    case "LBLUPCOMP1":
                        if (child.Name.LocalName != "LblUPComp1")
                        {
                            child.Name = child.Name.Namespace + "LblUPComp1";
                        }
                        CheckElementType_tgNormalizedString20(child);
                        break;
                    case "LBLUPCOMP2":
                        if (child.Name.LocalName != "LblUPComp2")
                        {
                            child.Name = child.Name.Namespace + "LblUPComp2";
                        }
                        CheckElementType_tgNormalizedString20(child);
                        break;
                    case "LBLUPCOMP3":
                        if (child.Name.LocalName != "LblUPComp3")
                        {
                            child.Name = child.Name.Namespace + "LblUPComp3";
                        }
                        CheckElementType_tgNormalizedString20(child);
                        break;
                    case "LBLUPCOMP4":
                        if (child.Name.LocalName != "LblUPComp4")
                        {
                            child.Name = child.Name.Namespace + "LblUPComp4";
                        }
                        CheckElementType_tgNormalizedString20(child);
                        break;
                    case "LBLUPCOMP5":
                        if (child.Name.LocalName != "LblUPComp5")
                        {
                            child.Name = child.Name.Namespace + "LblUPComp5";
                        }
                        CheckElementType_tgNormalizedString20(child);
                        break;
                    case "LBLUPCOMP6":
                        if (child.Name.LocalName != "LblUPComp6")
                        {
                            child.Name = child.Name.Namespace + "LblUPComp6";
                        }
                        CheckElementType_tgNormalizedString20(child);
                        break;
                    case "NAME":
                        if (child.Name.LocalName != "Name")
                        {
                            child.Name = child.Name.Namespace + "Name";
                        }
                        CheckElementType_tgNormalizedString20(child);
                        break;
                    case "LBLBOQ":
                        if (child.Name.LocalName != "LblBoQ")
                        {
                            child.Name = child.Name.Namespace + "LblBoQ";
                        }
                        CheckElementType_tgNormalizedString60(child);
                        break;
                    case "CPVCODE":
                        if (child.Name.LocalName != "CPVCode")
                        {
                            child.Name = child.Name.Namespace + "CPVCode";
                        }
                        CheckElementType_tgCPVCode(child);
                        break;
                    case "DATE":
                        if (child.Name.LocalName != "Date")
                        {
                            child.Name = child.Name.Namespace + "Date";
                        }
                        CheckElementType_tgDate(child);
                        break;
                    case "OUTLCOMPL":
                        if (child.Name.LocalName != "OutlCompl")
                        {
                            child.Name = child.Name.Namespace + "OutlCompl";
                        }
                        CheckElementType_InlineSimpleType_73ff0675_632a_4a43_b806_db852fbb4062(child);
                        break;
                    case "BOQBKDN":
                        if (child.Name.LocalName != "BoQBkdn")
                        {
                            child.Name = child.Name.Namespace + "BoQBkdn";
                        }
                        CheckElementType_tgBoQBkdn(child);
                        break;
                    case "LBLTIME":
                        if (child.Name.LocalName != "LblTime")
                        {
                            child.Name = child.Name.Namespace + "LblTime";
                        }
                        CheckElementType_tgNormalizedString20(child);
                        break;
                    case "CTLGASSIGN":
                        if (child.Name.LocalName != "CtlgAssign")
                        {
                            child.Name = child.Name.Namespace + "CtlgAssign";
                        }
                        CheckElementType_tgCtlgAssign(child);
                        break;
                    case "TOTALS":
                        if (child.Name.LocalName != "Totals")
                        {
                            child.Name = child.Name.Namespace + "Totals";
                        }
                        CheckElementType_tgTotals(child);
                        break;
                    case "CTLG":
                        if (child.Name.LocalName != "Ctlg")
                        {
                            child.Name = child.Name.Namespace + "Ctlg";
                        }
                        CheckElementType_tgCtlg(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgBoQText(XElement element)
        {
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "TEXT":
                        if (child.Name.LocalName != "Text")
                        {
                            child.Name = child.Name.Namespace + "Text";
                        }
                        CheckElementType_tgFText(child);
                        break;
                    case "TEXTCOMPLEMENT":
                        if (child.Name.LocalName != "TextComplement")
                        {
                            child.Name = child.Name.Namespace + "TextComplement";
                        }
                        CheckElementType_tgTextComplement(child);
                        break;
                    case "ATTACHMENT":
                        if (child.Name.LocalName != "attachment")
                        {
                            child.Name = child.Name.Namespace + "attachment";
                        }
                        CheckElementType_tgNormalizedString(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgbr(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_tgCashDiscount(XElement element)
        {
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "CASHDISCDAYS":
                        if (child.Name.LocalName != "CashDiscDays")
                        {
                            child.Name = child.Name.Namespace + "CashDiscDays";
                        }
                        CheckElementType_InlineComplexType_c393af0f_d89e_4806_b950_4e4bc58797f9(child);
                        break;
                    case "CASHDISCDATE":
                        if (child.Name.LocalName != "CashDiscDate")
                        {
                            child.Name = child.Name.Namespace + "CashDiscDate";
                        }
                        CheckElementType_tgDate(child);
                        break;
                    case "DISCOUNTPCNT":
                        if (child.Name.LocalName != "DiscountPcnt")
                        {
                            child.Name = child.Name.Namespace + "DiscountPcnt";
                        }
                        CheckElementType_tgDecimal_5_2(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgCnstSite(XElement element)
        {
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "ADDRESS":
                        if (child.Name.LocalName != "Address")
                        {
                            child.Name = child.Name.Namespace + "Address";
                        }
                        CheckElementType_tgAddress(child);
                        break;
                    case "CNSTSITEIDNO":
                        if (child.Name.LocalName != "CnstSiteIDNo")
                        {
                            child.Name = child.Name.Namespace + "CnstSiteIDNo";
                        }
                        CheckElementType_tgNormalizedString20(child);
                        break;
                    case "CNSTSITENAME":
                        if (child.Name.LocalName != "CnstSiteName")
                        {
                            child.Name = child.Name.Namespace + "CnstSiteName";
                        }
                        CheckElementType_tgNormalizedString60(child);
                        break;
                    case "ADDTEXT":
                        if (child.Name.LocalName != "AddText")
                        {
                            child.Name = child.Name.Namespace + "AddText";
                        }
                        CheckElementType_tgAddText(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgCntryName(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_tgCntryType(XElement element)
        {
            switch (element.Value.ToUpperInvariant())
            {
                case "EEA":
                    if (element.Value != "EEA")
                    {
                        element.Value = "EEA";
                    }
                    break;
                case "OTHER":
                    if (element.Value != "Other")
                    {
                        element.Value = "Other";
                    }
                    break;
                default:
                    element.Remove();
                    break;
            }
        }
        private void CheckElementType_tgCOInfo(XElement element)
        {
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "CONO":
                        if (child.Name.LocalName != "CONo")
                        {
                            child.Name = child.Name.Namespace + "CONo";
                        }
                        CheckElementType_tgCONo(child);
                        break;
                    case "COPHASE":
                        if (child.Name.LocalName != "COPhase")
                        {
                            child.Name = child.Name.Namespace + "COPhase";
                        }
                        CheckElementType_tgCOPhase(child);
                        break;
                    case "COSTATUS":
                        if (child.Name.LocalName != "COStatus")
                        {
                            child.Name = child.Name.Namespace + "COStatus";
                        }
                        CheckElementType_tgCOStatus(child);
                        break;
                    case "COINIT":
                        if (child.Name.LocalName != "COInit")
                        {
                            child.Name = child.Name.Namespace + "COInit";
                        }
                        CheckElementType_InlineSimpleType_c7977909_d167_4c1c_b7cb_5c139803c294(child);
                        break;
                    case "COREAS":
                        if (child.Name.LocalName != "COReas")
                        {
                            child.Name = child.Name.Namespace + "COReas";
                        }
                        CheckElementType_tgFText(child);
                        break;
                    case "REFBOQCOINFO":
                        if (child.Name.LocalName != "RefBoQCOInfo")
                        {
                            child.Name = child.Name.Namespace + "RefBoQCOInfo";
                        }
                        CheckElementType_tgNormalizedString60(child);
                        break;
                    case "CODATE":
                        if (child.Name.LocalName != "CODate")
                        {
                            child.Name = child.Name.Namespace + "CODate";
                        }
                        CheckElementType_tgDate(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgCommunication(XElement element)
        {
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "QUESTION":
                        if (child.Name.LocalName != "Question")
                        {
                            child.Name = child.Name.Namespace + "Question";
                        }
                        CheckElementType_tgNormalizedString80(child);
                        break;
                    case "RESPONSE":
                        if (child.Name.LocalName != "Response")
                        {
                            child.Name = child.Name.Namespace + "Response";
                        }
                        CheckElementType_tgNormalizedString80(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgComplBodyDec(XElement element)
        {
            foreach (var attribute in element.Attributes())
            {
                switch (attribute.Name.LocalName.ToUpperInvariant())
                {
                    case "VALUE":
                        CheckAttributeType_tgDecimal(attribute);
                        if (attribute.Name.LocalName != "Value")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "Value", attribute.Value);
                        }
                        break;
                }
            }
        }
        private void CheckElementType_tgComplBodyInt(XElement element)
        {
            foreach (var attribute in element.Attributes())
            {
                switch (attribute.Name.LocalName.ToUpperInvariant())
                {
                    case "VALUE":
                        CheckAttributeType_tgInteger(attribute);
                        if (attribute.Name.LocalName != "Value")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "Value", attribute.Value);
                        }
                        break;
                }
            }
        }
        private void CheckElementType_tgCompleteText(XElement element)
        {
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "COMPLTSA":
                        if (child.Name.LocalName != "ComplTSA")
                        {
                            child.Name = child.Name.Namespace + "ComplTSA";
                        }
                        CheckElementType_tgYesNo(child);
                        break;
                    case "COMPLTSB":
                        if (child.Name.LocalName != "ComplTSB")
                        {
                            child.Name = child.Name.Namespace + "ComplTSB";
                        }
                        CheckElementType_tgYesNo(child);
                        break;
                    case "DETAILTXT":
                        if (child.Name.LocalName != "DetailTxt")
                        {
                            child.Name = child.Name.Namespace + "DetailTxt";
                        }
                        CheckElementType_tgBoQText(child);
                        break;
                    case "OUTLINETEXT":
                        if (child.Name.LocalName != "OutlineText")
                        {
                            child.Name = child.Name.Namespace + "OutlineText";
                        }
                        CheckElementType_tgOutlineText(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgCONo(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_tgContrValCode(XElement element)
        {
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "PERCENT":
                        if (child.Name.LocalName != "Percent")
                        {
                            child.Name = child.Name.Namespace + "Percent";
                        }
                        CheckElementType_tgDecimal_5_2(child);
                        break;
                    case "NUMBER":
                        if (child.Name.LocalName != "Number")
                        {
                            child.Name = child.Name.Namespace + "Number";
                        }
                        CheckElementType_InlineSimpleType_e03cfb08_9ade_4669_bd18_785245e1ac65(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgCOPhase(XElement element)
        {
            switch (element.Value.ToUpperInvariant())
            {
                case "CALLCHANGORDER":
                    if (element.Value != "CallChangOrder")
                    {
                        element.Value = "CallChangOrder";
                    }
                    break;
                case "SUPPLAGREE":
                    if (element.Value != "SupplAgree")
                    {
                        element.Value = "SupplAgree";
                    }
                    break;
                case "SUPPLBID":
                    if (element.Value != "SupplBid")
                    {
                        element.Value = "SupplBid";
                    }
                    break;
                default:
                    element.Remove();
                    break;
            }
        }
        private void CheckElementType_tgCOStatus(XElement element)
        {
            switch (element.Value.ToUpperInvariant())
            {
                case "APPROVED":
                    if (element.Value != "Approved")
                    {
                        element.Value = "Approved";
                    }
                    break;
                case "FILED":
                    if (element.Value != "Filed")
                    {
                        element.Value = "Filed";
                    }
                    break;
                case "FORMACKN":
                    if (element.Value != "FormAckn")
                    {
                        element.Value = "FormAckn";
                    }
                    break;
                case "OBJTORECJ":
                    if (element.Value != "ObjToRecj")
                    {
                        element.Value = "ObjToRecj";
                    }
                    break;
                case "OFFERED":
                    if (element.Value != "Offered")
                    {
                        element.Value = "Offered";
                    }
                    break;
                case "RECOG":
                    if (element.Value != "Recog")
                    {
                        element.Value = "Recog";
                    }
                    break;
                case "REJECTED":
                    if (element.Value != "Rejected")
                    {
                        element.Value = "Rejected";
                    }
                    break;
                case "WITHDRAWN":
                    if (element.Value != "Withdrawn")
                    {
                        element.Value = "Withdrawn";
                    }
                    break;
                default:
                    element.Remove();
                    break;
            }
        }
        private void CheckElementType_tgCPVCode(XElement element)
        {
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "CPVNO":
                        if (child.Name.LocalName != "CPVNo")
                        {
                            child.Name = child.Name.Namespace + "CPVNo";
                        }
                        CheckElementType_tgNormalizedString12(child);
                        break;
                    case "CPVTEXT":
                        if (child.Name.LocalName != "CPVText")
                        {
                            child.Name = child.Name.Namespace + "CPVText";
                        }
                        CheckElementType_tgNormalizedString100(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgCtlg(XElement element)
        {
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "CTLGID":
                        if (child.Name.LocalName != "CtlgID")
                        {
                            child.Name = child.Name.Namespace + "CtlgID";
                        }
                        CheckElementType_tgCtlgID(child);
                        break;
                    case "CTLGTYPE":
                        if (child.Name.LocalName != "CtlgType")
                        {
                            child.Name = child.Name.Namespace + "CtlgType";
                        }
                        CheckElementType_tgCtlgType(child);
                        break;
                    case "CTLGNAME":
                        if (child.Name.LocalName != "CtlgName")
                        {
                            child.Name = child.Name.Namespace + "CtlgName";
                        }
                        CheckElementType_tgCtlgName(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgCtlgAssign(XElement element)
        {
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "CTLGID":
                        if (child.Name.LocalName != "CtlgID")
                        {
                            child.Name = child.Name.Namespace + "CtlgID";
                        }
                        CheckElementType_tgNormalizedString100(child);
                        break;
                    case "CTLGCODE":
                        if (child.Name.LocalName != "CtlgCode")
                        {
                            child.Name = child.Name.Namespace + "CtlgCode";
                        }
                        CheckElementType_tgNormalizedString100(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgCtlgID(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_tgCtlgName(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_tgCtlgType(XElement element)
        {
            switch (element.Value.ToUpperInvariant())
            {
                case "COST GROUP DIN 276-06":
                    if (element.Value != "cost group DIN 276-06")
                    {
                        element.Value = "cost group DIN 276-06";
                    }
                    break;
                case "COST GROUP DIN 276-1 2008-12":
                    if (element.Value != "cost group DIN 276-1 2008-12")
                    {
                        element.Value = "cost group DIN 276-1 2008-12";
                    }
                    break;
                case "COST GROUP DIN 276-81":
                    if (element.Value != "cost group DIN 276-81")
                    {
                        element.Value = "cost group DIN 276-81";
                    }
                    break;
                case "COST GROUP DIN 276-93":
                    if (element.Value != "cost group DIN 276-93")
                    {
                        element.Value = "cost group DIN 276-93";
                    }
                    break;
                case "COST UNIT":
                    if (element.Value != "cost unit")
                    {
                        element.Value = "cost unit";
                    }
                    break;
                case "LOCALITY":
                    if (element.Value != "locality")
                    {
                        element.Value = "locality";
                    }
                    break;
                case "MISCELLANEOUS":
                    if (element.Value != "miscellaneous")
                    {
                        element.Value = "miscellaneous";
                    }
                    break;
                case "WORK CATEGORY":
                    if (element.Value != "work category")
                    {
                        element.Value = "work category";
                    }
                    break;
                default:
                    element.Remove();
                    break;
            }
        }
        private void CheckElementType_tgCTR(XElement element)
        {
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "CNTRYTYPE":
                        if (child.Name.LocalName != "CntryType")
                        {
                            child.Name = child.Name.Namespace + "CntryType";
                        }
                        CheckElementType_tgCntryType(child);
                        break;
                    case "CNTRYNAME":
                        if (child.Name.LocalName != "CntryName")
                        {
                            child.Name = child.Name.Namespace + "CntryName";
                        }
                        CheckElementType_tgCntryName(child);
                        break;
                    case "ADDRESS":
                        if (child.Name.LocalName != "Address")
                        {
                            child.Name = child.Name.Namespace + "Address";
                        }
                        CheckElementType_tgAddress(child);
                        break;
                    case "DPNO":
                        if (child.Name.LocalName != "DPNo")
                        {
                            child.Name = child.Name.Namespace + "DPNo";
                        }
                        CheckElementType_tgNormalizedString60(child);
                        break;
                    case "AWARDNO":
                        if (child.Name.LocalName != "AwardNo")
                        {
                            child.Name = child.Name.Namespace + "AwardNo";
                        }
                        CheckElementType_tgNormalizedString60(child);
                        break;
                    case "ACCTSPAYNO":
                        if (child.Name.LocalName != "AcctsPayNo")
                        {
                            child.Name = child.Name.Namespace + "AcctsPayNo";
                        }
                        CheckElementType_tgNormalizedString20(child);
                        break;
                    case "BIDDERNO":
                        if (child.Name.LocalName != "BidderNo")
                        {
                            child.Name = child.Name.Namespace + "BidderNo";
                        }
                        CheckElementType_tgNormalizedString8(child);
                        break;
                    case "SECTORTYPE":
                        if (child.Name.LocalName != "SectorType")
                        {
                            child.Name = child.Name.Namespace + "SectorType";
                        }
                        CheckElementType_InlineSimpleType_90bb8e06_6ca4_4eb4_89fb_ffef89355ec8(child);
                        break;
                    case "PREFBIDTYPE":
                        if (child.Name.LocalName != "PrefBidType")
                        {
                            child.Name = child.Name.Namespace + "PrefBidType";
                        }
                        CheckElementType_InlineSimpleType_21581649_1a06_4fc1_be24_1c4428befca9(child);
                        break;
                    case "SCTYPE":
                        if (child.Name.LocalName != "SCType")
                        {
                            child.Name = child.Name.Namespace + "SCType";
                        }
                        CheckElementType_InlineSimpleType_71ea5dd8_98d9_4b85_8538_fe1ddabda711(child);
                        break;
                    case "INSAS":
                        if (child.Name.LocalName != "InsAs")
                        {
                            child.Name = child.Name.Namespace + "InsAs";
                        }
                        CheckElementType_tgInsAs(child);
                        break;
                    case "ADDTEXT":
                        if (child.Name.LocalName != "AddText")
                        {
                            child.Name = child.Name.Namespace + "AddText";
                        }
                        CheckElementType_tgAddText(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgCur(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_tgCurLbl(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_tgDate(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_tgDecimal_11_3(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_tgDecimal_13_2(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_tgDecimal_13_3(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_tgDecimal_5_2(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_tgDecimal_6_4(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_tgDescription(XElement element)
        {
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "STLBBAU":
                        if (child.Name.LocalName != "STLBBau")
                        {
                            child.Name = child.Name.Namespace + "STLBBau";
                        }
                        CheckElementType_tgSTLBBau(child);
                        break;
                    case "STLNO":
                        if (child.Name.LocalName != "StLNo")
                        {
                            child.Name = child.Name.Namespace + "StLNo";
                        }
                        CheckElementType_tgStLNo(child);
                        break;
                    case "COMPLETETEXT":
                        if (child.Name.LocalName != "CompleteText")
                        {
                            child.Name = child.Name.Namespace + "CompleteText";
                        }
                        CheckElementType_tgCompleteText(child);
                        break;
                    case "OUTLINETEXT":
                        if (child.Name.LocalName != "OutlineText")
                        {
                            child.Name = child.Name.Namespace + "OutlineText";
                        }
                        CheckElementType_tgOutlineText(child);
                        break;
                    case "WICNO":
                        if (child.Name.LocalName != "WICNo")
                        {
                            child.Name = child.Name.Namespace + "WICNo";
                        }
                        CheckElementType_tgNormalizedString40(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgdiv(XElement element)
        {
            foreach (var attribute in element.Attributes())
            {
                switch (attribute.Name.LocalName.ToUpperInvariant())
                {
                    case "STYLE":
                        CheckAttributeType_tgAttStyle(attribute);
                        if (attribute.Name.LocalName != "style")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "style", attribute.Value);
                        }
                        break;
                }
            }
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "SPAN":
                        if (child.Name.LocalName != "span")
                        {
                            child.Name = child.Name.Namespace + "span";
                        }
                        CheckElementType_tgspan(child);
                        break;
                    case "BR":
                        if (child.Name.LocalName != "br")
                        {
                            child.Name = child.Name.Namespace + "br";
                        }
                        CheckElementType_tgbr(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgFText(XElement element)
        {
            foreach (var attribute in element.Attributes())
            {
                switch (attribute.Name.LocalName.ToUpperInvariant())
                {
                    case "TEXTWIDTH":
                        CheckAttributeType_tgNormalizedString(attribute);
                        if (attribute.Name.LocalName != "textWidth")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "textWidth", attribute.Value);
                        }
                        break;
                }
            }
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "P":
                        if (child.Name.LocalName != "p")
                        {
                            child.Name = child.Name.Namespace + "p";
                        }
                        CheckElementType_tgp(child);
                        break;
                    case "DIV":
                        if (child.Name.LocalName != "div")
                        {
                            child.Name = child.Name.Namespace + "div";
                        }
                        CheckElementType_tgdiv(child);
                        break;
                    case "SPAN":
                        if (child.Name.LocalName != "span")
                        {
                            child.Name = child.Name.Namespace + "span";
                        }
                        CheckElementType_tgspan(child);
                        break;
                    case "UL":
                        if (child.Name.LocalName != "ul")
                        {
                            child.Name = child.Name.Namespace + "ul";
                        }
                        CheckElementType_tgul(child);
                        break;
                    case "OL":
                        if (child.Name.LocalName != "ol")
                        {
                            child.Name = child.Name.Namespace + "ol";
                        }
                        CheckElementType_tgol(child);
                        break;
                    case "TABLE":
                        if (child.Name.LocalName != "table")
                        {
                            child.Name = child.Name.Namespace + "table";
                        }
                        CheckElementType_tgtable(child);
                        break;
                    case "BR":
                        if (child.Name.LocalName != "br")
                        {
                            child.Name = child.Name.Namespace + "br";
                        }
                        CheckElementType_tgbr(child);
                        break;
                    case "PAGE":
                        if (child.Name.LocalName != "page")
                        {
                            child.Name = child.Name.Namespace + "page";
                        }
                        CheckElementType_tgpage(child);
                        break;
                    case "IMAGE":
                        if (child.Name.LocalName != "Image")
                        {
                            child.Name = child.Name.Namespace + "Image";
                        }
                        CheckElementType_tgImage(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgGAEB(XElement element)
        {
            foreach (var attribute in element.Attributes())
            {
                switch (attribute.Name.LocalName.ToUpperInvariant())
                {
                    case "XML:SPACE":
                        CheckAttributeType_xml_space(attribute);
                        if (attribute.Name.LocalName != "xml:space")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "xml:space", attribute.Value);
                        }
                        break;
                }
            }
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "GAEBINFO":
                        if (child.Name.LocalName != "GAEBInfo")
                        {
                            child.Name = child.Name.Namespace + "GAEBInfo";
                        }
                        CheckElementType_tgGAEBInfo(child);
                        break;
                    case "PRJINFO":
                        if (child.Name.LocalName != "PrjInfo")
                        {
                            child.Name = child.Name.Namespace + "PrjInfo";
                        }
                        CheckElementType_tgPrjInfo(child);
                        break;
                    case "AWARD":
                        if (child.Name.LocalName != "Award")
                        {
                            child.Name = child.Name.Namespace + "Award";
                        }
                        CheckElementType_tgAward(child);
                        break;
                    case "ADDTEXT":
                        if (child.Name.LocalName != "AddText")
                        {
                            child.Name = child.Name.Namespace + "AddText";
                        }
                        CheckElementType_tgAddText(child);
                        break;
                    case "DS:SIGNATURE":
                        if (child.Name.LocalName != "ds:Signature")
                        {
                            child.Name = child.Name.Namespace + "ds:Signature";
                        }
                        CheckElementType_ds_Signature(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgGAEBInfo(XElement element)
        {
            foreach (var child in element.Elements().ToList())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "VERSION":
                        if (child.Name.LocalName != "Version")
                        {
                            child.Name = child.Name.Namespace + "Version";
                        }
                        CheckElementType_InlineSimpleType_55a86d2a_59f3_43b4_85c4_f1ede88f4f71(child);
                        break;
                    case "VERSDATE":
                        if (child.Name.LocalName != "VersDate")
                        {
                            child.Name = child.Name.Namespace + "VersDate";
                        }
                        CheckElementType_InlineSimpleType_6c279709_a7bd_4b53_953b_498072177191(child);
                        break;
                    case "DATE":
                        if (child.Name.LocalName != "Date")
                        {
                            child.Name = child.Name.Namespace + "Date";
                        }
                        CheckElementType_tgDate(child);
                        break;
                    case "TIME":
                        if (child.Name.LocalName != "Time")
                        {
                            child.Name = child.Name.Namespace + "Time";
                        }
                        CheckElementType_tgTime(child);
                        break;
                    case "PROGSYSTEM":
                        if (child.Name.LocalName != "ProgSystem")
                        {
                            child.Name = child.Name.Namespace + "ProgSystem";
                        }
                        CheckElementType_tgNormalizedString60(child);
                        break;
                    case "PROGNAME":
                        if (child.Name.LocalName != "ProgName")
                        {
                            child.Name = child.Name.Namespace + "ProgName";
                        }
                        CheckElementType_tgNormalizedString60(child);
                        break;
                    case "CERTIFIC":
                        if (child.Name.LocalName != "Certific")
                        {
                            child.Name = child.Name.Namespace + "Certific";
                        }
                        CheckElementType_InlineSimpleType_807da388_5ad3_4662_b3a0_70711fe5c499(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgHourIt(XElement element)
        {
            switch (element.Value.ToUpperInvariant())
            {
                case "NO":
                    if (element.Value != "No")
                    {
                        element.Value = "No";
                    }
                    break;
                case "YES":
                    if (element.Value != "Yes")
                    {
                        element.Value = "Yes";
                    }
                    break;
                default:
                    element.Remove();
                    break;
            }
        }
        private void CheckElementType_tgImage(XElement element)
        {
        }
        private void CheckElementType_tgInsAs(XElement element)
        {
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "INSASNAME":
                        if (child.Name.LocalName != "InsAsName")
                        {
                            child.Name = child.Name.Namespace + "InsAsName";
                        }
                        CheckElementType_tgNormalizedString60(child);
                        break;
                    case "INSASDATE":
                        if (child.Name.LocalName != "InsAsDate")
                        {
                            child.Name = child.Name.Namespace + "InsAsDate";
                        }
                        CheckElementType_tgDate(child);
                        break;
                    case "INSASNO":
                        if (child.Name.LocalName != "InsAsNo")
                        {
                            child.Name = child.Name.Namespace + "InsAsNo";
                        }
                        CheckElementType_tgNormalizedString20(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgInteger(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_tgItem(XElement element)
        {
            foreach (var attribute in element.Attributes())
            {
                switch (attribute.Name.LocalName.ToUpperInvariant())
                {
                    case "ID":
                        CheckAttributeType_xs_ID(attribute);
                        if (attribute.Name.LocalName != "ID")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "ID", attribute.Value);
                        }
                        break;
                    case "RNOPART":
                        CheckAttributeType_tgRNoPart(attribute);
                        if (attribute.Name.LocalName != "RNoPart")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "RNoPart", attribute.Value);
                        }
                        break;
                    case "RNOINDEX":
                        CheckAttributeType_tgRNoIndex(attribute);
                        if (attribute.Name.LocalName != "RNoIndex")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "RNoIndex", attribute.Value);
                        }
                        break;
                }
            }
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "ALNGROUPNO":
                        if (child.Name.LocalName != "ALNGroupNo")
                        {
                            child.Name = child.Name.Namespace + "ALNGroupNo";
                        }
                        CheckElementType_tgALNGroupNo(child);
                        break;
                    case "ALNSERNO":
                        if (child.Name.LocalName != "ALNSerNo")
                        {
                            child.Name = child.Name.Namespace + "ALNSerNo";
                        }
                        CheckElementType_tgALNSerNo(child);
                        break;
                    case "ACCEPTED":
                        if (child.Name.LocalName != "Accepted")
                        {
                            child.Name = child.Name.Namespace + "Accepted";
                        }
                        CheckElementType_tgAccepted(child);
                        break;
                    case "CONO":
                        if (child.Name.LocalName != "CONo")
                        {
                            child.Name = child.Name.Namespace + "CONo";
                        }
                        CheckElementType_tgCONo(child);
                        break;
                    case "COSTATUS":
                        if (child.Name.LocalName != "COStatus")
                        {
                            child.Name = child.Name.Namespace + "COStatus";
                        }
                        CheckElementType_tgCOStatus(child);
                        break;
                    case "UP":
                        if (child.Name.LocalName != "UP")
                        {
                            child.Name = child.Name.Namespace + "UP";
                        }
                        CheckElementType_tgDecimal_13_3(child);
                        break;
                    case "UP110":
                        if (child.Name.LocalName != "UP110")
                        {
                            child.Name = child.Name.Namespace + "UP110";
                        }
                        CheckElementType_tgDecimal_13_3(child);
                        break;
                    case "UPCOMP1":
                        if (child.Name.LocalName != "UPComp1")
                        {
                            child.Name = child.Name.Namespace + "UPComp1";
                        }
                        CheckElementType_tgDecimal_13_3(child);
                        break;
                    case "UPCOMP2":
                        if (child.Name.LocalName != "UPComp2")
                        {
                            child.Name = child.Name.Namespace + "UPComp2";
                        }
                        CheckElementType_tgDecimal_13_3(child);
                        break;
                    case "UPCOMP3":
                        if (child.Name.LocalName != "UPComp3")
                        {
                            child.Name = child.Name.Namespace + "UPComp3";
                        }
                        CheckElementType_tgDecimal_13_3(child);
                        break;
                    case "UPCOMP4":
                        if (child.Name.LocalName != "UPComp4")
                        {
                            child.Name = child.Name.Namespace + "UPComp4";
                        }
                        CheckElementType_tgDecimal_13_3(child);
                        break;
                    case "UPCOMP5":
                        if (child.Name.LocalName != "UPComp5")
                        {
                            child.Name = child.Name.Namespace + "UPComp5";
                        }
                        CheckElementType_tgDecimal_13_3(child);
                        break;
                    case "UPCOMP6":
                        if (child.Name.LocalName != "UPComp6")
                        {
                            child.Name = child.Name.Namespace + "UPComp6";
                        }
                        CheckElementType_tgDecimal_13_3(child);
                        break;
                    case "DISCOUNTPCNT":
                        if (child.Name.LocalName != "DiscountPcnt")
                        {
                            child.Name = child.Name.Namespace + "DiscountPcnt";
                        }
                        CheckElementType_tgDecimal_5_2(child);
                        break;
                    case "SUMDESCR":
                        if (child.Name.LocalName != "SumDescr")
                        {
                            child.Name = child.Name.Namespace + "SumDescr";
                        }
                        CheckElementType_tgYes(child);
                        break;
                    case "SUBDESCR":
                        if (child.Name.LocalName != "SubDescr")
                        {
                            child.Name = child.Name.Namespace + "SubDescr";
                        }
                        CheckElementType_tgSubDescr(child);
                        break;
                    case "REFRNO":
                        if (child.Name.LocalName != "RefRNo")
                        {
                            child.Name = child.Name.Namespace + "RefRNo";
                        }
                        CheckElementType_tgRefItem(child);
                        break;
                    case "REFPERFNO":
                        if (child.Name.LocalName != "RefPerfNo")
                        {
                            child.Name = child.Name.Namespace + "RefPerfNo";
                        }
                        CheckElementType_tgRefItem(child);
                        break;
                    case "QTYTBD":
                        if (child.Name.LocalName != "QtyTBD")
                        {
                            child.Name = child.Name.Namespace + "QtyTBD";
                        }
                        CheckElementType_tgYes(child);
                        break;
                    case "QTY":
                        if (child.Name.LocalName != "Qty")
                        {
                            child.Name = child.Name.Namespace + "Qty";
                        }
                        CheckElementType_tgDecimal_11_3(child);
                        break;
                    case "QTYSPLIT":
                        if (child.Name.LocalName != "QtySplit")
                        {
                            child.Name = child.Name.Namespace + "QtySplit";
                        }
                        CheckElementType_tgQtySplit(child);
                        break;
                    case "PREDQTY":
                        if (child.Name.LocalName != "PredQty")
                        {
                            child.Name = child.Name.Namespace + "PredQty";
                        }
                        CheckElementType_tgDecimal_11_3(child);
                        break;
                    case "BILLQTY":
                        if (child.Name.LocalName != "BillQty")
                        {
                            child.Name = child.Name.Namespace + "BillQty";
                        }
                        CheckElementType_tgDecimal_11_3(child);
                        break;
                    case "PROVIS":
                        if (child.Name.LocalName != "Provis")
                        {
                            child.Name = child.Name.Namespace + "Provis";
                        }
                        CheckElementType_tgProvis(child);
                        break;
                    case "PROVISACCPT":
                        if (child.Name.LocalName != "ProvisAccpt")
                        {
                            child.Name = child.Name.Namespace + "ProvisAccpt";
                        }
                        CheckElementType_tgYesNo(child);
                        break;
                    case "LUMPSUMITEM":
                        if (child.Name.LocalName != "LumpSumItem")
                        {
                            child.Name = child.Name.Namespace + "LumpSumItem";
                        }
                        CheckElementType_tgYesNo(child);
                        break;
                    case "NOTAPPL":
                        if (child.Name.LocalName != "NotAppl")
                        {
                            child.Name = child.Name.Namespace + "NotAppl";
                        }
                        CheckElementType_tgNotAppl(child);
                        break;
                    case "HOURIT":
                        if (child.Name.LocalName != "HourIt")
                        {
                            child.Name = child.Name.Namespace + "HourIt";
                        }
                        CheckElementType_tgHourIt(child);
                        break;
                    case "KEYIT":
                        if (child.Name.LocalName != "KeyIt")
                        {
                            child.Name = child.Name.Namespace + "KeyIt";
                        }
                        CheckElementType_tgKeyIt(child);
                        break;
                    case "UPBKDN":
                        if (child.Name.LocalName != "UPBkdn")
                        {
                            child.Name = child.Name.Namespace + "UPBkdn";
                        }
                        CheckElementType_tgYesNo(child);
                        break;
                    case "MARKUPIT":
                        if (child.Name.LocalName != "MarkupIt")
                        {
                            child.Name = child.Name.Namespace + "MarkupIt";
                        }
                        CheckElementType_tgYesNo(child);
                        break;
                    case "REFDESCR":
                        if (child.Name.LocalName != "RefDescr")
                        {
                            child.Name = child.Name.Namespace + "RefDescr";
                        }
                        CheckElementType_InlineSimpleType_91e4e14b_9560_4958_a24b_ccd79f94a925(child);
                        break;
                    case "QU":
                        if (child.Name.LocalName != "QU")
                        {
                            child.Name = child.Name.Namespace + "QU";
                        }
                        CheckElementType_tgNormalizedString4(child);
                        break;
                    case "CTLGASSIGN":
                        if (child.Name.LocalName != "CtlgAssign")
                        {
                            child.Name = child.Name.Namespace + "CtlgAssign";
                        }
                        CheckElementType_tgCtlgAssign(child);
                        break;
                    case "UPFROM":
                        if (child.Name.LocalName != "UPFrom")
                        {
                            child.Name = child.Name.Namespace + "UPFrom";
                        }
                        CheckElementType_tgDecimal_13_3(child);
                        break;
                    case "UPAVG":
                        if (child.Name.LocalName != "UPAvg")
                        {
                            child.Name = child.Name.Namespace + "UPAvg";
                        }
                        CheckElementType_tgDecimal_13_3(child);
                        break;
                    case "UPTO":
                        if (child.Name.LocalName != "UPTo")
                        {
                            child.Name = child.Name.Namespace + "UPTo";
                        }
                        CheckElementType_tgDecimal_13_3(child);
                        break;
                    case "UPWGFROM":
                        if (child.Name.LocalName != "UPWgFrom")
                        {
                            child.Name = child.Name.Namespace + "UPWgFrom";
                        }
                        CheckElementType_tgDecimal_13_3(child);
                        break;
                    case "UPWGAVG":
                        if (child.Name.LocalName != "UPWgAvg")
                        {
                            child.Name = child.Name.Namespace + "UPWgAvg";
                        }
                        CheckElementType_tgDecimal_13_3(child);
                        break;
                    case "UPWGTO":
                        if (child.Name.LocalName != "UPWgTo")
                        {
                            child.Name = child.Name.Namespace + "UPWgTo";
                        }
                        CheckElementType_tgDecimal_13_3(child);
                        break;
                    case "IT":
                        if (child.Name.LocalName != "IT")
                        {
                            child.Name = child.Name.Namespace + "IT";
                        }
                        CheckElementType_tgDecimal_13_2(child);
                        break;
                    case "VAT":
                        if (child.Name.LocalName != "VAT")
                        {
                            child.Name = child.Name.Namespace + "VAT";
                        }
                        CheckElementType_tgDecimal_5_2(child);
                        break;
                    case "PRICEINFO":
                        if (child.Name.LocalName != "PriceInfo")
                        {
                            child.Name = child.Name.Namespace + "PriceInfo";
                        }
                        CheckElementType_InlineSimpleType_5f1a877a_e1fa_473a_a48b_1e62fe5c7e3b(child);
                        break;
                    case "TIMEQU":
                        if (child.Name.LocalName != "TimeQu")
                        {
                            child.Name = child.Name.Namespace + "TimeQu";
                        }
                        CheckElementType_tgDecimal_13_2(child);
                        break;
                    case "DESCRIPTION":
                        if (child.Name.LocalName != "Description")
                        {
                            child.Name = child.Name.Namespace + "Description";
                        }
                        CheckElementType_tgDescription(child);
                        break;
                    case "BIDCOMM":
                        if (child.Name.LocalName != "BidComm")
                        {
                            child.Name = child.Name.Namespace + "BidComm";
                        }
                        CheckElementType_tgMLText(child);
                        break;
                    case "PRODUCT":
                        if (child.Name.LocalName != "Product")
                        {
                            child.Name = child.Name.Namespace + "Product";
                        }
                        CheckElementType_tgProduct(child);
                        break;
                    case "ALTERBIDSTATUS":
                        if (child.Name.LocalName != "AlterBidStatus")
                        {
                            child.Name = child.Name.Namespace + "AlterBidStatus";
                        }
                        CheckElementType_tgAlterBidStatus(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgItemlist(XElement element)
        {
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "REMARK":
                        if (child.Name.LocalName != "Remark")
                        {
                            child.Name = child.Name.Namespace + "Remark";
                        }
                        CheckElementType_tgRemark(child);
                        break;
                    case "PERFDESCR":
                        if (child.Name.LocalName != "PerfDescr")
                        {
                            child.Name = child.Name.Namespace + "PerfDescr";
                        }
                        CheckElementType_tgPerfDescr(child);
                        break;
                    case "ITEM":
                        if (child.Name.LocalName != "Item")
                        {
                            child.Name = child.Name.Namespace + "Item";
                        }
                        CheckElementType_tgItem(child);
                        break;
                    case "MARKUPITEM":
                        if (child.Name.LocalName != "MarkupItem")
                        {
                            child.Name = child.Name.Namespace + "MarkupItem";
                        }
                        CheckElementType_tgMarkupItem(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgKeyIt(XElement element)
        {
            switch (element.Value.ToUpperInvariant())
            {
                case "NO":
                    if (element.Value != "No")
                    {
                        element.Value = "No";
                    }
                    break;
                case "YES":
                    if (element.Value != "Yes")
                    {
                        element.Value = "Yes";
                    }
                    break;
                default:
                    element.Remove();
                    break;
            }
        }
        private void CheckElementType_tgLeftRight(XElement element)
        {
            switch (element.Value.ToUpperInvariant())
            {
                case "LEFT":
                    if (element.Value != "left")
                    {
                        element.Value = "left";
                    }
                    break;
                case "RIGHT":
                    if (element.Value != "right")
                    {
                        element.Value = "right";
                    }
                    break;
                default:
                    element.Remove();
                    break;
            }
        }
        private void CheckElementType_tgli(XElement element)
        {
            foreach (var attribute in element.Attributes())
            {
                switch (attribute.Name.LocalName.ToUpperInvariant())
                {
                    case "STYLE":
                        CheckAttributeType_tgAttStyle(attribute);
                        if (attribute.Name.LocalName != "style")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "style", attribute.Value);
                        }
                        break;
                }
            }
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "P":
                        if (child.Name.LocalName != "p")
                        {
                            child.Name = child.Name.Namespace + "p";
                        }
                        CheckElementType_tgp(child);
                        break;
                    case "DIV":
                        if (child.Name.LocalName != "div")
                        {
                            child.Name = child.Name.Namespace + "div";
                        }
                        CheckElementType_tgdiv(child);
                        break;
                    case "SPAN":
                        if (child.Name.LocalName != "span")
                        {
                            child.Name = child.Name.Namespace + "span";
                        }
                        CheckElementType_tgspan(child);
                        break;
                    case "BR":
                        if (child.Name.LocalName != "br")
                        {
                            child.Name = child.Name.Namespace + "br";
                        }
                        CheckElementType_tgbr(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgLotGrp(XElement element)
        {
            foreach (var attribute in element.Attributes())
            {
                switch (attribute.Name.LocalName.ToUpperInvariant())
                {
                    case "ID":
                        CheckAttributeType_xs_ID(attribute);
                        if (attribute.Name.LocalName != "ID")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "ID", attribute.Value);
                        }
                        break;
                }
            }
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "LOTGRNO":
                        if (child.Name.LocalName != "LotGrNo")
                        {
                            child.Name = child.Name.Namespace + "LotGrNo";
                        }
                        CheckElementType_tgNormalizedString(child);
                        break;
                    case "REFLOTNO":
                        if (child.Name.LocalName != "RefLotNo")
                        {
                            child.Name = child.Name.Namespace + "RefLotNo";
                        }
                        CheckElementType_tgRefBoQCtgy(child);
                        break;
                    case "TOTALS":
                        if (child.Name.LocalName != "Totals")
                        {
                            child.Name = child.Name.Namespace + "Totals";
                        }
                        CheckElementType_tgTotals(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgMaintInfo(XElement element)
        {
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "CONTRTRANSDATE":
                        if (child.Name.LocalName != "ContrTransDate")
                        {
                            child.Name = child.Name.Namespace + "ContrTransDate";
                        }
                        CheckElementType_tgDate(child);
                        break;
                    case "CONTRTRANSTIME":
                        if (child.Name.LocalName != "ContrTransTime")
                        {
                            child.Name = child.Name.Namespace + "ContrTransTime";
                        }
                        CheckElementType_tgTime(child);
                        break;
                    case "MAINTTYPE":
                        if (child.Name.LocalName != "MaintType")
                        {
                            child.Name = child.Name.Namespace + "MaintType";
                        }
                        CheckElementType_InlineSimpleType_31b78963_2f79_4cf6_8ef9_1e2a148bb747(child);
                        break;
                    case "PROCESSTYPE":
                        if (child.Name.LocalName != "ProcessType")
                        {
                            child.Name = child.Name.Namespace + "ProcessType";
                        }
                        CheckElementType_InlineSimpleType_8cec7720_9f32_40ec_969e_1c45e16a1495(child);
                        break;
                    case "CONTRLAW":
                        if (child.Name.LocalName != "ContrLaw")
                        {
                            child.Name = child.Name.Namespace + "ContrLaw";
                        }
                        CheckElementType_InlineSimpleType_58009169_4e79_46a9_90fb_e33cd44f3da9(child);
                        break;
                    case "DEADLINE":
                        if (child.Name.LocalName != "Deadline")
                        {
                            child.Name = child.Name.Namespace + "Deadline";
                        }
                        CheckElementType_InlineSimpleType_714540bc_1b85_470e_bca9_849b9c59177d(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgMarkupItem(XElement element)
        {
            foreach (var attribute in element.Attributes())
            {
                switch (attribute.Name.LocalName.ToUpperInvariant())
                {
                    case "ID":
                        CheckAttributeType_xs_ID(attribute);
                        if (attribute.Name.LocalName != "ID")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "ID", attribute.Value);
                        }
                        break;
                    case "RNOPART":
                        CheckAttributeType_tgRNoPart(attribute);
                        if (attribute.Name.LocalName != "RNoPart")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "RNoPart", attribute.Value);
                        }
                        break;
                    case "RNOINDEX":
                        CheckAttributeType_tgRNoIndex(attribute);
                        if (attribute.Name.LocalName != "RNoIndex")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "RNoIndex", attribute.Value);
                        }
                        break;
                }
            }
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "ALNGROUPNO":
                        if (child.Name.LocalName != "ALNGroupNo")
                        {
                            child.Name = child.Name.Namespace + "ALNGroupNo";
                        }
                        CheckElementType_tgALNGroupNo(child);
                        break;
                    case "ALNSERNO":
                        if (child.Name.LocalName != "ALNSerNo")
                        {
                            child.Name = child.Name.Namespace + "ALNSerNo";
                        }
                        CheckElementType_tgALNSerNo(child);
                        break;
                    case "ACCEPTED":
                        if (child.Name.LocalName != "Accepted")
                        {
                            child.Name = child.Name.Namespace + "Accepted";
                        }
                        CheckElementType_tgAccepted(child);
                        break;
                    case "CONO":
                        if (child.Name.LocalName != "CONo")
                        {
                            child.Name = child.Name.Namespace + "CONo";
                        }
                        CheckElementType_tgCONo(child);
                        break;
                    case "COSTATUS":
                        if (child.Name.LocalName != "COStatus")
                        {
                            child.Name = child.Name.Namespace + "COStatus";
                        }
                        CheckElementType_tgCOStatus(child);
                        break;
                    case "REFRNO":
                        if (child.Name.LocalName != "RefRNo")
                        {
                            child.Name = child.Name.Namespace + "RefRNo";
                        }
                        CheckElementType_tgRefItem(child);
                        break;
                    case "REFPERFNO":
                        if (child.Name.LocalName != "RefPerfNo")
                        {
                            child.Name = child.Name.Namespace + "RefPerfNo";
                        }
                        CheckElementType_tgRefItem(child);
                        break;
                    case "PROVIS":
                        if (child.Name.LocalName != "Provis")
                        {
                            child.Name = child.Name.Namespace + "Provis";
                        }
                        CheckElementType_tgProvis(child);
                        break;
                    case "PROVISACCPT":
                        if (child.Name.LocalName != "ProvisAccpt")
                        {
                            child.Name = child.Name.Namespace + "ProvisAccpt";
                        }
                        CheckElementType_tgYesNo(child);
                        break;
                    case "NOTAPPL":
                        if (child.Name.LocalName != "NotAppl")
                        {
                            child.Name = child.Name.Namespace + "NotAppl";
                        }
                        CheckElementType_tgNotAppl(child);
                        break;
                    case "HOURIT":
                        if (child.Name.LocalName != "HourIt")
                        {
                            child.Name = child.Name.Namespace + "HourIt";
                        }
                        CheckElementType_tgHourIt(child);
                        break;
                    case "KEYIT":
                        if (child.Name.LocalName != "KeyIt")
                        {
                            child.Name = child.Name.Namespace + "KeyIt";
                        }
                        CheckElementType_tgKeyIt(child);
                        break;
                    case "REFDESCR":
                        if (child.Name.LocalName != "RefDescr")
                        {
                            child.Name = child.Name.Namespace + "RefDescr";
                        }
                        CheckElementType_tgRefDescr(child);
                        break;
                    case "MARKUPTYPE":
                        if (child.Name.LocalName != "MarkupType")
                        {
                            child.Name = child.Name.Namespace + "MarkupType";
                        }
                        CheckElementType_InlineSimpleType_7229fd10_efaa_42c3_89ee_1c6d572b38fa(child);
                        break;
                    case "MARKUPSUBQTY":
                        if (child.Name.LocalName != "MarkupSubQty")
                        {
                            child.Name = child.Name.Namespace + "MarkupSubQty";
                        }
                        CheckElementType_tgMarkupSubQty(child);
                        break;
                    case "ITMARKUP":
                        if (child.Name.LocalName != "ITMarkup")
                        {
                            child.Name = child.Name.Namespace + "ITMarkup";
                        }
                        CheckElementType_tgDecimal_13_2(child);
                        break;
                    case "MARKUP":
                        if (child.Name.LocalName != "Markup")
                        {
                            child.Name = child.Name.Namespace + "Markup";
                        }
                        CheckElementType_tgDecimal_5_2(child);
                        break;
                    case "DISCOUNTPCNT":
                        if (child.Name.LocalName != "DiscountPcnt")
                        {
                            child.Name = child.Name.Namespace + "DiscountPcnt";
                        }
                        CheckElementType_tgDecimal_5_2(child);
                        break;
                    case "IT":
                        if (child.Name.LocalName != "IT")
                        {
                            child.Name = child.Name.Namespace + "IT";
                        }
                        CheckElementType_tgDecimal_13_2(child);
                        break;
                    case "DESCRIPTION":
                        if (child.Name.LocalName != "Description")
                        {
                            child.Name = child.Name.Namespace + "Description";
                        }
                        CheckElementType_tgDescription(child);
                        break;
                    case "CTLGASSIGN":
                        if (child.Name.LocalName != "CtlgAssign")
                        {
                            child.Name = child.Name.Namespace + "CtlgAssign";
                        }
                        CheckElementType_tgCtlgAssign(child);
                        break;
                    case "ALTERBIDSTATUS":
                        if (child.Name.LocalName != "AlterBidStatus")
                        {
                            child.Name = child.Name.Namespace + "AlterBidStatus";
                        }
                        CheckElementType_tgAlterBidStatus(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgMarkupSubQty(XElement element)
        {
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "REFITEM":
                        if (child.Name.LocalName != "RefItem")
                        {
                            child.Name = child.Name.Namespace + "RefItem";
                        }
                        CheckElementType_tgRefItem(child);
                        break;
                    case "SUBQTY":
                        if (child.Name.LocalName != "SubQty")
                        {
                            child.Name = child.Name.Namespace + "SubQty";
                        }
                        CheckElementType_tgDecimal_11_3(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgMastAgrInfo(XElement element)
        {
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "MASTAGRDUR":
                        if (child.Name.LocalName != "MastAgrDur")
                        {
                            child.Name = child.Name.Namespace + "MastAgrDur";
                        }
                        CheckElementType_InlineSimpleType_7b235e6b_8b93_4949_9325_695fbdf088e1(child);
                        break;
                    case "MASTAGREND":
                        if (child.Name.LocalName != "MastAgrEnd")
                        {
                            child.Name = child.Name.Namespace + "MastAgrEnd";
                        }
                        CheckElementType_tgDate(child);
                        break;
                    case "BIDUPDOWN":
                        if (child.Name.LocalName != "BidUpDown")
                        {
                            child.Name = child.Name.Namespace + "BidUpDown";
                        }
                        CheckElementType_tgYesNo(child);
                        break;
                    case "MASTAGRLBL":
                        if (child.Name.LocalName != "MastAgrLbl")
                        {
                            child.Name = child.Name.Namespace + "MastAgrLbl";
                        }
                        CheckElementType_InlineSimpleType_9983c68c_f1cf_4f5a_a1a3_a1df8cc7065e(child);
                        break;
                    case "MASTAGRBEG":
                        if (child.Name.LocalName != "MastAgrBeg")
                        {
                            child.Name = child.Name.Namespace + "MastAgrBeg";
                        }
                        CheckElementType_tgDate(child);
                        break;
                    case "MASTAGRDATE":
                        if (child.Name.LocalName != "MastAgrDate")
                        {
                            child.Name = child.Name.Namespace + "MastAgrDate";
                        }
                        CheckElementType_tgDate(child);
                        break;
                    case "MASTAGRVERS":
                        if (child.Name.LocalName != "MastAgrVers")
                        {
                            child.Name = child.Name.Namespace + "MastAgrVers";
                        }
                        CheckElementType_tgNormalizedString20(child);
                        break;
                    case "TOTCONTRVAL":
                        if (child.Name.LocalName != "TotContrVal")
                        {
                            child.Name = child.Name.Namespace + "TotContrVal";
                        }
                        CheckElementType_tgDecimal_13_2(child);
                        break;
                    case "MINCONTRVAL":
                        if (child.Name.LocalName != "MinContrVal")
                        {
                            child.Name = child.Name.Namespace + "MinContrVal";
                        }
                        CheckElementType_tgDecimal_13_2(child);
                        break;
                    case "MINCONTRAWD":
                        if (child.Name.LocalName != "MinContrAwd")
                        {
                            child.Name = child.Name.Namespace + "MinContrAwd";
                        }
                        CheckElementType_tgDecimal_5_2(child);
                        break;
                    case "MAXCONTRVAL":
                        if (child.Name.LocalName != "MaxContrVal")
                        {
                            child.Name = child.Name.Namespace + "MaxContrVal";
                        }
                        CheckElementType_tgDecimal_13_2(child);
                        break;
                    case "CONTRVALCODE":
                        if (child.Name.LocalName != "ContrValCode")
                        {
                            child.Name = child.Name.Namespace + "ContrValCode";
                        }
                        CheckElementType_tgContrValCode(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgMLText(XElement element)
        {
            foreach (var attribute in element.Attributes())
            {
                switch (attribute.Name.LocalName.ToUpperInvariant())
                {
                    case "TEXTWIDTH":
                        CheckAttributeType_tgNormalizedString(attribute);
                        if (attribute.Name.LocalName != "textWidth")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "textWidth", attribute.Value);
                        }
                        break;
                }
            }
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "P":
                        if (child.Name.LocalName != "p")
                        {
                            child.Name = child.Name.Namespace + "p";
                        }
                        CheckElementType_tgpMLText(child);
                        break;
                    case "DIV":
                        if (child.Name.LocalName != "div")
                        {
                            child.Name = child.Name.Namespace + "div";
                        }
                        CheckElementType_tgdiv(child);
                        break;
                    case "SPAN":
                        if (child.Name.LocalName != "span")
                        {
                            child.Name = child.Name.Namespace + "span";
                        }
                        CheckElementType_tgspan(child);
                        break;
                    case "BR":
                        if (child.Name.LocalName != "br")
                        {
                            child.Name = child.Name.Namespace + "br";
                        }
                        CheckElementType_tgbr(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgNormalizedString(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_tgNormalizedString10(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_tgNormalizedString100(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_tgNormalizedString12(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_tgNormalizedString120(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_tgNormalizedString15(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_tgNormalizedString20(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_tgNormalizedString256(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_tgNormalizedString3(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_tgNormalizedString30(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_tgNormalizedString4(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_tgNormalizedString40(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_tgNormalizedString55(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_tgNormalizedString60(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_tgNormalizedString8(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_tgNormalizedString80(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_tgNotAppl(XElement element)
        {
            switch (element.Value.ToUpperInvariant())
            {
                case "NO":
                    if (element.Value != "No")
                    {
                        element.Value = "No";
                    }
                    break;
                case "YES":
                    if (element.Value != "Yes")
                    {
                        element.Value = "Yes";
                    }
                    break;
                default:
                    element.Remove();
                    break;
            }
        }
        private void CheckElementType_tgNotifSite(XElement element)
        {
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "ADDRESS":
                        if (child.Name.LocalName != "Address")
                        {
                            child.Name = child.Name.Namespace + "Address";
                        }
                        CheckElementType_tgAddress(child);
                        break;
                    case "NOTIFSITEIDNO":
                        if (child.Name.LocalName != "NotifSiteIDNo")
                        {
                            child.Name = child.Name.Namespace + "NotifSiteIDNo";
                        }
                        CheckElementType_tgNormalizedString20(child);
                        break;
                    case "NOTIFSITENAME":
                        if (child.Name.LocalName != "NotifSiteName")
                        {
                            child.Name = child.Name.Namespace + "NotifSiteName";
                        }
                        CheckElementType_tgNormalizedString60(child);
                        break;
                    case "ADDTEXT":
                        if (child.Name.LocalName != "AddText")
                        {
                            child.Name = child.Name.Namespace + "AddText";
                        }
                        CheckElementType_tgAddText(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgol(XElement element)
        {
            foreach (var attribute in element.Attributes())
            {
                switch (attribute.Name.LocalName.ToUpperInvariant())
                {
                    case "STYLE":
                        CheckAttributeType_tgAttStyle(attribute);
                        if (attribute.Name.LocalName != "style")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "style", attribute.Value);
                        }
                        break;
                }
            }
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "LI":
                        if (child.Name.LocalName != "li")
                        {
                            child.Name = child.Name.Namespace + "li";
                        }
                        CheckElementType_tgli(child);
                        break;
                    case "UL":
                        if (child.Name.LocalName != "ul")
                        {
                            child.Name = child.Name.Namespace + "ul";
                        }
                        CheckElementType_tgul(child);
                        break;
                    case "OL":
                        if (child.Name.LocalName != "ol")
                        {
                            child.Name = child.Name.Namespace + "ol";
                        }
                        CheckElementType_tgol(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgOutlineText(XElement element)
        {
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "OUTLTSA":
                        if (child.Name.LocalName != "OutlTSA")
                        {
                            child.Name = child.Name.Namespace + "OutlTSA";
                        }
                        CheckElementType_tgYesNo(child);
                        break;
                    case "OUTLTXT":
                        if (child.Name.LocalName != "OutlTxt")
                        {
                            child.Name = child.Name.Namespace + "OutlTxt";
                        }
                        CheckElementType_tgOutlTxt(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgOutlTxt(XElement element)
        {
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "TEXTOUTLTXT":
                        if (child.Name.LocalName != "TextOutlTxt")
                        {
                            child.Name = child.Name.Namespace + "TextOutlTxt";
                        }
                        CheckElementType_tgMLText(child);
                        break;
                    case "TEXTCOMPLEMENT":
                        if (child.Name.LocalName != "TextComplement")
                        {
                            child.Name = child.Name.Namespace + "TextComplement";
                        }
                        CheckElementType_tgTextComplement(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgOWN(XElement element)
        {
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "CNTRYTYPE":
                        if (child.Name.LocalName != "CntryType")
                        {
                            child.Name = child.Name.Namespace + "CntryType";
                        }
                        CheckElementType_tgCntryType(child);
                        break;
                    case "CNTRYNAME":
                        if (child.Name.LocalName != "CntryName")
                        {
                            child.Name = child.Name.Namespace + "CntryName";
                        }
                        CheckElementType_tgCntryName(child);
                        break;
                    case "ADDRESS":
                        if (child.Name.LocalName != "Address")
                        {
                            child.Name = child.Name.Namespace + "Address";
                        }
                        CheckElementType_tgAddress(child);
                        break;
                    case "DPNO":
                        if (child.Name.LocalName != "DPNo")
                        {
                            child.Name = child.Name.Namespace + "DPNo";
                        }
                        CheckElementType_tgNormalizedString60(child);
                        break;
                    case "AWARDNO":
                        if (child.Name.LocalName != "AwardNo")
                        {
                            child.Name = child.Name.Namespace + "AwardNo";
                        }
                        CheckElementType_tgNormalizedString60(child);
                        break;
                    case "ACCTRECNO":
                        if (child.Name.LocalName != "AcctRecNo")
                        {
                            child.Name = child.Name.Namespace + "AcctRecNo";
                        }
                        CheckElementType_tgNormalizedString20(child);
                        break;
                    case "ADDTEXT":
                        if (child.Name.LocalName != "AddText")
                        {
                            child.Name = child.Name.Namespace + "AddText";
                        }
                        CheckElementType_tgAddText(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgp(XElement element)
        {
            foreach (var attribute in element.Attributes())
            {
                switch (attribute.Name.LocalName.ToUpperInvariant())
                {
                    case "STYLE":
                        CheckAttributeType_tgAttStyle(attribute);
                        if (attribute.Name.LocalName != "style")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "style", attribute.Value);
                        }
                        break;
                }
            }
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "SPAN":
                        if (child.Name.LocalName != "span")
                        {
                            child.Name = child.Name.Namespace + "span";
                        }
                        CheckElementType_tgspan(child);
                        break;
                    case "BR":
                        if (child.Name.LocalName != "br")
                        {
                            child.Name = child.Name.Namespace + "br";
                        }
                        CheckElementType_tgbr(child);
                        break;
                    case "IMAGE":
                        if (child.Name.LocalName != "image")
                        {
                            child.Name = child.Name.Namespace + "image";
                        }
                        CheckElementType_tgImage(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgpage(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_tgPerfDescr(XElement element)
        {
            foreach (var attribute in element.Attributes())
            {
                switch (attribute.Name.LocalName.ToUpperInvariant())
                {
                    case "ID":
                        CheckAttributeType_xs_ID(attribute);
                        if (attribute.Name.LocalName != "ID")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "ID", attribute.Value);
                        }
                        break;
                }
            }
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "PERFNO":
                        if (child.Name.LocalName != "PerfNo")
                        {
                            child.Name = child.Name.Namespace + "PerfNo";
                        }
                        CheckElementType_InlineSimpleType_26b99855_0cdc_47c9_a6c8_b3708b16343d(child);
                        break;
                    case "PERFLBL":
                        if (child.Name.LocalName != "PerfLbl")
                        {
                            child.Name = child.Name.Namespace + "PerfLbl";
                        }
                        CheckElementType_tgNormalizedString55(child);
                        break;
                    case "DESCRIPTION":
                        if (child.Name.LocalName != "Description")
                        {
                            child.Name = child.Name.Namespace + "Description";
                        }
                        CheckElementType_tgDescription(child);
                        break;
                    case "CONO":
                        if (child.Name.LocalName != "CONo")
                        {
                            child.Name = child.Name.Namespace + "CONo";
                        }
                        CheckElementType_tgCONo(child);
                        break;
                    case "ALTERBIDSTATUS":
                        if (child.Name.LocalName != "AlterBidStatus")
                        {
                            child.Name = child.Name.Namespace + "AlterBidStatus";
                        }
                        CheckElementType_tgAlterBidStatus(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgpMLText(XElement element)
        {
            foreach (var attribute in element.Attributes())
            {
                switch (attribute.Name.LocalName.ToUpperInvariant())
                {
                    case "STYLE":
                        CheckAttributeType_tgAttStyle(attribute);
                        if (attribute.Name.LocalName != "style")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "style", attribute.Value);
                        }
                        break;
                }
            }
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "SPAN":
                        if (child.Name.LocalName != "span")
                        {
                            child.Name = child.Name.Namespace + "span";
                        }
                        CheckElementType_tgspan(child);
                        break;
                    case "BR":
                        if (child.Name.LocalName != "br")
                        {
                            child.Name = child.Name.Namespace + "br";
                        }
                        CheckElementType_tgbr(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgPrjInfo(XElement element)
        {
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "CUR":
                        if (child.Name.LocalName != "Cur")
                        {
                            child.Name = child.Name.Namespace + "Cur";
                        }
                        CheckElementType_tgCur(child);
                        break;
                    case "CURLBL":
                        if (child.Name.LocalName != "CurLbl")
                        {
                            child.Name = child.Name.Namespace + "CurLbl";
                        }
                        CheckElementType_tgCurLbl(child);
                        break;
                    case "NAMEPRJ":
                        if (child.Name.LocalName != "NamePrj")
                        {
                            child.Name = child.Name.Namespace + "NamePrj";
                        }
                        CheckElementType_tgNormalizedString60(child);
                        break;
                    case "LBLPRJ":
                        if (child.Name.LocalName != "LblPrj")
                        {
                            child.Name = child.Name.Namespace + "LblPrj";
                        }
                        CheckElementType_tgNormalizedString100(child);
                        break;
                    case "DESCRIP":
                        if (child.Name.LocalName != "Descrip")
                        {
                            child.Name = child.Name.Namespace + "Descrip";
                        }
                        CheckElementType_tgFText(child);
                        break;
                    case "BIDCOMMPERM":
                        if (child.Name.LocalName != "BidCommPerm")
                        {
                            child.Name = child.Name.Namespace + "BidCommPerm";
                        }
                        CheckElementType_tgYesNo(child);
                        break;
                    case "ALTERBIDPERM":
                        if (child.Name.LocalName != "AlterBidPerm")
                        {
                            child.Name = child.Name.Namespace + "AlterBidPerm";
                        }
                        CheckElementType_tgYes(child);
                        break;
                    case "COMMUNICATION":
                        if (child.Name.LocalName != "Communication")
                        {
                            child.Name = child.Name.Namespace + "Communication";
                        }
                        CheckElementType_tgCommunication(child);
                        break;
                    case "ADDTEXT":
                        if (child.Name.LocalName != "AddText")
                        {
                            child.Name = child.Name.Namespace + "AddText";
                        }
                        CheckElementType_tgAddText(child);
                        break;
                    case "UPFRACDIG":
                        if (child.Name.LocalName != "UPFracDig")
                        {
                            child.Name = child.Name.Namespace + "UPFracDig";
                        }
                        CheckElementType_InlineSimpleType_5e147ef0_d626_4268_a491_44dd6fe52f97(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgProduct(XElement element)
        {
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "ADDRESS":
                        if (child.Name.LocalName != "Address")
                        {
                            child.Name = child.Name.Namespace + "Address";
                        }
                        CheckElementType_tgAddress(child);
                        break;
                    case "ADDTEXT":
                        if (child.Name.LocalName != "AddText")
                        {
                            child.Name = child.Name.Namespace + "AddText";
                        }
                        CheckElementType_tgAddText(child);
                        break;
                    case "ARTICLE":
                        if (child.Name.LocalName != "Article")
                        {
                            child.Name = child.Name.Namespace + "Article";
                        }
                        CheckElementType_tgArticle(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgProvis(XElement element)
        {
            switch (element.Value.ToUpperInvariant())
            {
                case "WITHOUTTOTAL":
                    if (element.Value != "WithoutTotal")
                    {
                        element.Value = "WithoutTotal";
                    }
                    break;
                case "WITHTOTAL":
                    if (element.Value != "WithTotal")
                    {
                        element.Value = "WithTotal";
                    }
                    break;
                default:
                    element.Remove();
                    break;
            }
        }
        private void CheckElementType_tgQtySplit(XElement element)
        {
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "QTYPCNT":
                        if (child.Name.LocalName != "QtyPcnt")
                        {
                            child.Name = child.Name.Namespace + "QtyPcnt";
                        }
                        CheckElementType_tgDecimal_5_2(child);
                        break;
                    case "QTY":
                        if (child.Name.LocalName != "Qty")
                        {
                            child.Name = child.Name.Namespace + "Qty";
                        }
                        CheckElementType_tgDecimal_11_3(child);
                        break;
                    case "CTLGASSIGN":
                        if (child.Name.LocalName != "CtlgAssign")
                        {
                            child.Name = child.Name.Namespace + "CtlgAssign";
                        }
                        CheckElementType_tgCtlgAssign(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgRefBoQ(XElement element)
        {
            foreach (var attribute in element.Attributes())
            {
                switch (attribute.Name.LocalName.ToUpperInvariant())
                {
                    case "IDREF":
                        CheckAttributeType_xs_IDREF(attribute);
                        if (attribute.Name.LocalName != "IDRef")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "IDRef", attribute.Value);
                        }
                        break;
                }
            }
        }
        private void CheckElementType_tgRefBoQCtgy(XElement element)
        {
            foreach (var attribute in element.Attributes())
            {
                switch (attribute.Name.LocalName.ToUpperInvariant())
                {
                    case "IDREF":
                        CheckAttributeType_xs_IDREF(attribute);
                        if (attribute.Name.LocalName != "IDRef")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "IDRef", attribute.Value);
                        }
                        break;
                }
            }
        }
        private void CheckElementType_tgRefDescr(XElement element)
        {
            switch (element.Value.ToUpperInvariant())
            {
                case "REF":
                    if (element.Value != "Ref")
                    {
                        element.Value = "Ref";
                    }
                    break;
                case "REP":
                    if (element.Value != "Rep")
                    {
                        element.Value = "Rep";
                    }
                    break;
                default:
                    element.Remove();
                    break;
            }
        }
        private void CheckElementType_tgRefItem(XElement element)
        {
            foreach (var attribute in element.Attributes())
            {
                switch (attribute.Name.LocalName.ToUpperInvariant())
                {
                    case "IDREF":
                        CheckAttributeType_xs_IDREF(attribute);
                        if (attribute.Name.LocalName != "IDRef")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "IDRef", attribute.Value);
                        }
                        break;
                }
            }
        }
        private void CheckElementType_tgRefLotGrp(XElement element)
        {
            foreach (var attribute in element.Attributes())
            {
                switch (attribute.Name.LocalName.ToUpperInvariant())
                {
                    case "IDREF":
                        CheckAttributeType_xs_IDREF(attribute);
                        if (attribute.Name.LocalName != "IDRef")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "IDRef", attribute.Value);
                        }
                        break;
                }
            }
        }
        private void CheckElementType_tgRemark(XElement element)
        {
            foreach (var attribute in element.Attributes())
            {
                switch (attribute.Name.LocalName.ToUpperInvariant())
                {
                    case "ID":
                        CheckAttributeType_xs_ID(attribute);
                        if (attribute.Name.LocalName != "ID")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "ID", attribute.Value);
                        }
                        break;
                }
            }
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "DESCRIPTION":
                        if (child.Name.LocalName != "Description")
                        {
                            child.Name = child.Name.Namespace + "Description";
                        }
                        CheckElementType_tgDescription(child);
                        break;
                    case "CONO":
                        if (child.Name.LocalName != "CONo")
                        {
                            child.Name = child.Name.Namespace + "CONo";
                        }
                        CheckElementType_tgCONo(child);
                        break;
                    case "ALTERBIDSTATUS":
                        if (child.Name.LocalName != "AlterBidStatus")
                        {
                            child.Name = child.Name.Namespace + "AlterBidStatus";
                        }
                        CheckElementType_tgAlterBidStatus(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgRequester(XElement element)
        {
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "ADDRESS":
                        if (child.Name.LocalName != "Address")
                        {
                            child.Name = child.Name.Namespace + "Address";
                        }
                        CheckElementType_tgAddress(child);
                        break;
                    case "REQUESTIDNO":
                        if (child.Name.LocalName != "RequestIDNo")
                        {
                            child.Name = child.Name.Namespace + "RequestIDNo";
                        }
                        CheckElementType_tgNormalizedString20(child);
                        break;
                    case "REQUESTNAME":
                        if (child.Name.LocalName != "RequestName")
                        {
                            child.Name = child.Name.Namespace + "RequestName";
                        }
                        CheckElementType_tgNormalizedString60(child);
                        break;
                    case "ADDTEXT":
                        if (child.Name.LocalName != "AddText")
                        {
                            child.Name = child.Name.Namespace + "AddText";
                        }
                        CheckElementType_tgAddText(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgspan(XElement element)
        {
        }
        private void CheckElementType_tgSTLBBau(XElement element)
        {
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "STLBBAUCTLG":
                        if (child.Name.LocalName != "STLBBauCtlg")
                        {
                            child.Name = child.Name.Namespace + "STLBBauCtlg";
                        }
                        CheckElementType_tgSTLBBauCtlg(child);
                        break;
                    case "STLBBAUID":
                        if (child.Name.LocalName != "STLBBauID")
                        {
                            child.Name = child.Name.Namespace + "STLBBauID";
                        }
                        CheckElementType_tgSTLBBauID(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgSTLBBauCtlg(XElement element)
        {
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "CTLGNAME":
                        if (child.Name.LocalName != "CtlgName")
                        {
                            child.Name = child.Name.Namespace + "CtlgName";
                        }
                        CheckElementType_tgNormalizedString10(child);
                        break;
                    case "VERSDATE":
                        if (child.Name.LocalName != "VersDate")
                        {
                            child.Name = child.Name.Namespace + "VersDate";
                        }
                        CheckElementType_tgVersDate(child);
                        break;
                    case "WCTG":
                        if (child.Name.LocalName != "WCtg")
                        {
                            child.Name = child.Name.Namespace + "WCtg";
                        }
                        CheckElementType_tgNormalizedString3(child);
                        break;
                    case "GROUP":
                        if (child.Name.LocalName != "Group")
                        {
                            child.Name = child.Name.Namespace + "Group";
                        }
                        CheckElementType_tgInteger(child);
                        break;
                    case "COSTGRP":
                        if (child.Name.LocalName != "CostGrp")
                        {
                            child.Name = child.Name.Namespace + "CostGrp";
                        }
                        CheckElementType_tgNormalizedString20(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgSTLBBauID(XElement element)
        {
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "ARTCHRIDENT":
                        if (child.Name.LocalName != "ArtChrIdent")
                        {
                            child.Name = child.Name.Namespace + "ArtChrIdent";
                        }
                        CheckElementType_tgInteger(child);
                        break;
                    case "ARTCHIDX":
                        if (child.Name.LocalName != "ArtChIdx")
                        {
                            child.Name = child.Name.Namespace + "ArtChIdx";
                        }
                        CheckElementType_tgInteger(child);
                        break;
                    case "CHVIDENT":
                        if (child.Name.LocalName != "ChVIdent")
                        {
                            child.Name = child.Name.Namespace + "ChVIdent";
                        }
                        CheckElementType_tgInteger(child);
                        break;
                    case "OUTLTEXTPART":
                        if (child.Name.LocalName != "OutlTextPart")
                        {
                            child.Name = child.Name.Namespace + "OutlTextPart";
                        }
                        CheckElementType_tgYes(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgStLNo(XElement element)
        {
        }
        private void CheckElementType_tgSubDescr(XElement element)
        {
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "QTYSPEC":
                        if (child.Name.LocalName != "QtySpec")
                        {
                            child.Name = child.Name.Namespace + "QtySpec";
                        }
                        CheckElementType_tgYes(child);
                        break;
                    case "QTYTBD":
                        if (child.Name.LocalName != "QtyTBD")
                        {
                            child.Name = child.Name.Namespace + "QtyTBD";
                        }
                        CheckElementType_tgYes(child);
                        break;
                    case "QTY":
                        if (child.Name.LocalName != "Qty")
                        {
                            child.Name = child.Name.Namespace + "Qty";
                        }
                        CheckElementType_tgDecimal_11_3(child);
                        break;
                    case "QU":
                        if (child.Name.LocalName != "QU")
                        {
                            child.Name = child.Name.Namespace + "QU";
                        }
                        CheckElementType_tgNormalizedString4(child);
                        break;
                    case "UP":
                        if (child.Name.LocalName != "UP")
                        {
                            child.Name = child.Name.Namespace + "UP";
                        }
                        CheckElementType_tgDecimal_13_3(child);
                        break;
                    case "UPCOMP1":
                        if (child.Name.LocalName != "UPComp1")
                        {
                            child.Name = child.Name.Namespace + "UPComp1";
                        }
                        CheckElementType_tgDecimal_13_3(child);
                        break;
                    case "UPCOMP2":
                        if (child.Name.LocalName != "UPComp2")
                        {
                            child.Name = child.Name.Namespace + "UPComp2";
                        }
                        CheckElementType_tgDecimal_13_3(child);
                        break;
                    case "UPCOMP3":
                        if (child.Name.LocalName != "UPComp3")
                        {
                            child.Name = child.Name.Namespace + "UPComp3";
                        }
                        CheckElementType_tgDecimal_13_3(child);
                        break;
                    case "UPCOMP4":
                        if (child.Name.LocalName != "UPComp4")
                        {
                            child.Name = child.Name.Namespace + "UPComp4";
                        }
                        CheckElementType_tgDecimal_13_3(child);
                        break;
                    case "UPCOMP5":
                        if (child.Name.LocalName != "UPComp5")
                        {
                            child.Name = child.Name.Namespace + "UPComp5";
                        }
                        CheckElementType_tgDecimal_13_3(child);
                        break;
                    case "UPCOMP6":
                        if (child.Name.LocalName != "UPComp6")
                        {
                            child.Name = child.Name.Namespace + "UPComp6";
                        }
                        CheckElementType_tgDecimal_13_3(child);
                        break;
                    case "SUBDNO":
                        if (child.Name.LocalName != "SubDNo")
                        {
                            child.Name = child.Name.Namespace + "SubDNo";
                        }
                        CheckElementType_InlineSimpleType_aef2a78d_a48c_45fa_a4a9_b7a38ea33dd6(child);
                        break;
                    case "DESCRIPTION":
                        if (child.Name.LocalName != "Description")
                        {
                            child.Name = child.Name.Namespace + "Description";
                        }
                        CheckElementType_tgDescription(child);
                        break;
                    case "UPSPEC":
                        if (child.Name.LocalName != "UPSpec")
                        {
                            child.Name = child.Name.Namespace + "UPSpec";
                        }
                        CheckElementType_tgYesNo(child);
                        break;
                    case "UPBKDN":
                        if (child.Name.LocalName != "UPBkdn")
                        {
                            child.Name = child.Name.Namespace + "UPBkdn";
                        }
                        CheckElementType_tgYesNo(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgtable(XElement element)
        {
            foreach (var attribute in element.Attributes())
            {
                switch (attribute.Name.LocalName.ToUpperInvariant())
                {
                    case "ALIGN":
                        CheckAttributeType_tgAttAlignTable(attribute);
                        if (attribute.Name.LocalName != "align")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "align", attribute.Value);
                        }
                        break;
                    case "BORDER":
                        CheckAttributeType_tgAttBorder(attribute);
                        if (attribute.Name.LocalName != "border")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "border", attribute.Value);
                        }
                        break;
                    case "CELLPADDING":
                        CheckAttributeType_tgAttCellpadding(attribute);
                        if (attribute.Name.LocalName != "cellpadding")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "cellpadding", attribute.Value);
                        }
                        break;
                    case "FRAME":
                        CheckAttributeType_tgAttFrame(attribute);
                        if (attribute.Name.LocalName != "frame")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "frame", attribute.Value);
                        }
                        break;
                    case "HEIGHT":
                        CheckAttributeType_tgAttHeight(attribute);
                        if (attribute.Name.LocalName != "height")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "height", attribute.Value);
                        }
                        break;
                    case "STYLE":
                        CheckAttributeType_tgAttStyle(attribute);
                        if (attribute.Name.LocalName != "style")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "style", attribute.Value);
                        }
                        break;
                    case "WIDTH":
                        CheckAttributeType_tgAttWidth(attribute);
                        if (attribute.Name.LocalName != "width")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "width", attribute.Value);
                        }
                        break;
                    case "ORG":
                        CheckAttributeType_tgAttOrg(attribute);
                        if (attribute.Name.LocalName != "org")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "org", attribute.Value);
                        }
                        break;
                }
            }
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "TR":
                        if (child.Name.LocalName != "tr")
                        {
                            child.Name = child.Name.Namespace + "tr";
                        }
                        CheckElementType_tgtr(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgtd(XElement element)
        {
            foreach (var attribute in element.Attributes())
            {
                switch (attribute.Name.LocalName.ToUpperInvariant())
                {
                    case "ALIGN":
                        CheckAttributeType_tgAttAlign(attribute);
                        if (attribute.Name.LocalName != "align")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "align", attribute.Value);
                        }
                        break;
                    case "COLSPAN":
                        CheckAttributeType_tgAttColspan(attribute);
                        if (attribute.Name.LocalName != "colspan")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "colspan", attribute.Value);
                        }
                        break;
                    case "ROWSPAN":
                        CheckAttributeType_tgAttRowspan(attribute);
                        if (attribute.Name.LocalName != "rowspan")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "rowspan", attribute.Value);
                        }
                        break;
                    case "STYLE":
                        CheckAttributeType_tgAttStyle(attribute);
                        if (attribute.Name.LocalName != "style")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "style", attribute.Value);
                        }
                        break;
                    case "VALIGN":
                        CheckAttributeType_tgAttValign(attribute);
                        if (attribute.Name.LocalName != "valign")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "valign", attribute.Value);
                        }
                        break;
                }
            }
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "P":
                        if (child.Name.LocalName != "p")
                        {
                            child.Name = child.Name.Namespace + "p";
                        }
                        CheckElementType_tgp(child);
                        break;
                    case "DIV":
                        if (child.Name.LocalName != "div")
                        {
                            child.Name = child.Name.Namespace + "div";
                        }
                        CheckElementType_tgdiv(child);
                        break;
                    case "SPAN":
                        if (child.Name.LocalName != "span")
                        {
                            child.Name = child.Name.Namespace + "span";
                        }
                        CheckElementType_tgspan(child);
                        break;
                    case "BR":
                        if (child.Name.LocalName != "br")
                        {
                            child.Name = child.Name.Namespace + "br";
                        }
                        CheckElementType_tgbr(child);
                        break;
                    case "TABLE":
                        if (child.Name.LocalName != "table")
                        {
                            child.Name = child.Name.Namespace + "table";
                        }
                        CheckElementType_tgtable(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgTextComplement(XElement element)
        {
            foreach (var attribute in element.Attributes())
            {
                switch (attribute.Name.LocalName.ToUpperInvariant())
                {
                    case "MARKLBL":
                        CheckAttributeType_tgInteger(attribute);
                        if (attribute.Name.LocalName != "MarkLbl")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "MarkLbl", attribute.Value);
                        }
                        break;
                    case "KIND":
                        CheckAttributeType_InlineSimpleType_de94f195_6b90_4789_8afa_c277c849c792(attribute);
                        if (attribute.Name.LocalName != "Kind")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "Kind", attribute.Value);
                        }
                        break;
                    case "EMPTY":
                        CheckAttributeType_tgYes(attribute);
                        if (attribute.Name.LocalName != "Empty")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "Empty", attribute.Value);
                        }
                        break;
                    case "ARTCHRIDENT":
                        CheckAttributeType_tgInteger(attribute);
                        if (attribute.Name.LocalName != "ArtChrIdent")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "ArtChrIdent", attribute.Value);
                        }
                        break;
                }
            }
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "COMPLBODYDEC":
                        if (child.Name.LocalName != "ComplBodyDec")
                        {
                            child.Name = child.Name.Namespace + "ComplBodyDec";
                        }
                        CheckElementType_tgComplBodyDec(child);
                        break;
                    case "COMPLBODYINT":
                        if (child.Name.LocalName != "ComplBodyInt")
                        {
                            child.Name = child.Name.Namespace + "ComplBodyInt";
                        }
                        CheckElementType_tgComplBodyInt(child);
                        break;
                    case "COMPLCAPTION":
                        if (child.Name.LocalName != "ComplCaption")
                        {
                            child.Name = child.Name.Namespace + "ComplCaption";
                        }
                        CheckElementType_tgMLText(child);
                        break;
                    case "COMPLBODY":
                        if (child.Name.LocalName != "ComplBody")
                        {
                            child.Name = child.Name.Namespace + "ComplBody";
                        }
                        CheckElementType_tgMLText(child);
                        break;
                    case "COMPLTAIL":
                        if (child.Name.LocalName != "ComplTail")
                        {
                            child.Name = child.Name.Namespace + "ComplTail";
                        }
                        CheckElementType_tgMLText(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgth(XElement element)
        {
            foreach (var attribute in element.Attributes())
            {
                switch (attribute.Name.LocalName.ToUpperInvariant())
                {
                    case "ALIGN":
                        CheckAttributeType_tgAttAlign(attribute);
                        if (attribute.Name.LocalName != "align")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "align", attribute.Value);
                        }
                        break;
                    case "STYLE":
                        CheckAttributeType_tgAttStyle(attribute);
                        if (attribute.Name.LocalName != "style")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "style", attribute.Value);
                        }
                        break;
                    case "VALIGN":
                        CheckAttributeType_tgAttValign(attribute);
                        if (attribute.Name.LocalName != "valign")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "valign", attribute.Value);
                        }
                        break;
                }
            }
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "P":
                        if (child.Name.LocalName != "p")
                        {
                            child.Name = child.Name.Namespace + "p";
                        }
                        CheckElementType_tgp(child);
                        break;
                    case "DIV":
                        if (child.Name.LocalName != "div")
                        {
                            child.Name = child.Name.Namespace + "div";
                        }
                        CheckElementType_tgdiv(child);
                        break;
                    case "SPAN":
                        if (child.Name.LocalName != "span")
                        {
                            child.Name = child.Name.Namespace + "span";
                        }
                        CheckElementType_tgspan(child);
                        break;
                    case "BR":
                        if (child.Name.LocalName != "br")
                        {
                            child.Name = child.Name.Namespace + "br";
                        }
                        CheckElementType_tgbr(child);
                        break;
                    case "TABLE":
                        if (child.Name.LocalName != "table")
                        {
                            child.Name = child.Name.Namespace + "table";
                        }
                        CheckElementType_tgtable(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgTime(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_tgTotals(XElement element)
        {
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "DISCOUNTPCNT":
                        if (child.Name.LocalName != "DiscountPcnt")
                        {
                            child.Name = child.Name.Namespace + "DiscountPcnt";
                        }
                        CheckElementType_tgDecimal_5_2(child);
                        break;
                    case "DISCOUNTAMT":
                        if (child.Name.LocalName != "DiscountAmt")
                        {
                            child.Name = child.Name.Namespace + "DiscountAmt";
                        }
                        CheckElementType_tgDecimal_13_2(child);
                        break;
                    case "TOTAFTERDISC":
                        if (child.Name.LocalName != "TotAfterDisc")
                        {
                            child.Name = child.Name.Namespace + "TotAfterDisc";
                        }
                        CheckElementType_tgDecimal_13_2(child);
                        break;
                    case "TOTALLSUM":
                        if (child.Name.LocalName != "TotalLSUM")
                        {
                            child.Name = child.Name.Namespace + "TotalLSUM";
                        }
                        CheckElementType_tgDecimal_13_2(child);
                        break;
                    case "TOTAL":
                        if (child.Name.LocalName != "Total")
                        {
                            child.Name = child.Name.Namespace + "Total";
                        }
                        CheckElementType_tgDecimal_13_2(child);
                        break;
                    case "VAT":
                        if (child.Name.LocalName != "VAT")
                        {
                            child.Name = child.Name.Namespace + "VAT";
                        }
                        CheckElementType_tgDecimal_5_2(child);
                        break;
                    case "TOTALGROSS":
                        if (child.Name.LocalName != "TotalGross")
                        {
                            child.Name = child.Name.Namespace + "TotalGross";
                        }
                        CheckElementType_tgDecimal_13_2(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgtr(XElement element)
        {
            foreach (var attribute in element.Attributes())
            {
                switch (attribute.Name.LocalName.ToUpperInvariant())
                {
                    case "ALIGN":
                        CheckAttributeType_tgAttAlign(attribute);
                        if (attribute.Name.LocalName != "align")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "align", attribute.Value);
                        }
                        break;
                    case "STYLE":
                        CheckAttributeType_tgAttStyle(attribute);
                        if (attribute.Name.LocalName != "style")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "style", attribute.Value);
                        }
                        break;
                    case "VALIGN":
                        CheckAttributeType_tgAttValign(attribute);
                        if (attribute.Name.LocalName != "valign")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "valign", attribute.Value);
                        }
                        break;
                }
            }
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "TH":
                        if (child.Name.LocalName != "th")
                        {
                            child.Name = child.Name.Namespace + "th";
                        }
                        CheckElementType_tgth(child);
                        break;
                    case "TD":
                        if (child.Name.LocalName != "td")
                        {
                            child.Name = child.Name.Namespace + "td";
                        }
                        CheckElementType_tgtd(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgul(XElement element)
        {
            foreach (var attribute in element.Attributes())
            {
                switch (attribute.Name.LocalName.ToUpperInvariant())
                {
                    case "STYLE":
                        CheckAttributeType_tgAttStyle(attribute);
                        if (attribute.Name.LocalName != "style")
                        {
                            attribute.Remove();
                            attribute.Parent.SetAttributeValue(attribute.Name.Namespace + "style", attribute.Value);
                        }
                        break;
                }
            }
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "LI":
                        if (child.Name.LocalName != "li")
                        {
                            child.Name = child.Name.Namespace + "li";
                        }
                        CheckElementType_tgli(child);
                        break;
                    case "UL":
                        if (child.Name.LocalName != "ul")
                        {
                            child.Name = child.Name.Namespace + "ul";
                        }
                        CheckElementType_tgul(child);
                        break;
                    case "OL":
                        if (child.Name.LocalName != "ol")
                        {
                            child.Name = child.Name.Namespace + "ol";
                        }
                        CheckElementType_tgol(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgVersDate(XElement element)
        {
            // There's currently no implementations for correcting the content of an Xml simpleType
        }
        private void CheckElementType_tgWgChange(XElement element)
        {
            foreach (var child in element.Elements())
            {
                switch (child.Name.LocalName.ToUpperInvariant())
                {
                    case "REFBOQ":
                        if (child.Name.LocalName != "RefBoQ")
                        {
                            child.Name = child.Name.Namespace + "RefBoQ";
                        }
                        CheckElementType_tgRefBoQ(child);
                        break;
                    case "REFLOTNO":
                        if (child.Name.LocalName != "RefLotNo")
                        {
                            child.Name = child.Name.Namespace + "RefLotNo";
                        }
                        CheckElementType_tgRefBoQCtgy(child);
                        break;
                    case "REFLOTGRNO":
                        if (child.Name.LocalName != "RefLotGrNo")
                        {
                            child.Name = child.Name.Namespace + "RefLotGrNo";
                        }
                        CheckElementType_tgRefLotGrp(child);
                        break;
                    case "REFITEM":
                        if (child.Name.LocalName != "RefItem")
                        {
                            child.Name = child.Name.Namespace + "RefItem";
                        }
                        CheckElementType_tgRefItem(child);
                        break;
                    case "WGCHANGERATE":
                        if (child.Name.LocalName != "WgChangeRate")
                        {
                            child.Name = child.Name.Namespace + "WgChangeRate";
                        }
                        CheckElementType_tgDecimal_6_4(child);
                        break;
                    case "LBLREFWAGE":
                        if (child.Name.LocalName != "LblRefWage")
                        {
                            child.Name = child.Name.Namespace + "LblRefWage";
                        }
                        CheckElementType_tgNormalizedString120(child);
                        break;
                    case "REDPRICECOMP":
                        if (child.Name.LocalName != "RedPriceComp")
                        {
                            child.Name = child.Name.Namespace + "RedPriceComp";
                        }
                        CheckElementType_tgDecimal_5_2(child);
                        break;
                }
            }
        }
        private void CheckElementType_tgYes(XElement element)
        {
            switch (element.Value.ToUpperInvariant())
            {
                case "YES":
                    if (element.Value != "Yes")
                    {
                        element.Value = "Yes";
                    }
                    break;
                default:
                    element.Remove();
                    break;
            }
        }
        private void CheckElementType_tgYesNo(XElement element)
        {
            switch (element.Value.ToUpperInvariant())
            {
                case "NO":
                    if (element.Value != "No")
                    {
                        element.Value = "No";
                    }
                    break;
                case "YES":
                    if (element.Value != "Yes")
                    {
                        element.Value = "Yes";
                    }
                    break;
                default:
                    element.Remove();
                    break;
            }
        }
        private void CheckAttributeType_InlineSimpleType_61f68c17_133a_46f4_93cb_a0e398950fd5(XAttribute attribute)
        {
            switch (attribute.Value.ToUpperInvariant())
            {
                case "WORK DAYS":
                    if (attribute.Value != "work days")
                    {
                        attribute.Value = "work days";
                    }
                    break;
                case "WEEK DAYS":
                    if (attribute.Value != "week days")
                    {
                        attribute.Value = "week days";
                    }
                    break;
                case "CALENDAR DAYS":
                    if (attribute.Value != "calendar days")
                    {
                        attribute.Value = "calendar days";
                    }
                    break;
                default:
                    attribute.Remove();
                    break;
            }
        }
        private void CheckAttributeType_InlineSimpleType_808cfeef_d806_4c10_aa49_ebde9d8cbcef(XAttribute attribute)
        {
            switch (attribute.Value.ToUpperInvariant())
            {
                case "IMAGE/JPEG":
                    if (attribute.Value != "image/jpeg")
                    {
                        attribute.Value = "image/jpeg";
                    }
                    break;
                case "IMAGE/GIF":
                    if (attribute.Value != "image/gif")
                    {
                        attribute.Value = "image/gif";
                    }
                    break;
                case "IMAGE/PNG":
                    if (attribute.Value != "image/png")
                    {
                        attribute.Value = "image/png";
                    }
                    break;
                default:
                    attribute.Remove();
                    break;
            }
        }
        private void CheckAttributeType_InlineSimpleType_80ebeab2_7c8f_4f14_8827_24289f89ae93(XAttribute attribute)
        {
            switch (attribute.Value.ToUpperInvariant())
            {
                case "STLB-BAUZ":
                    if (attribute.Value != "STLB-BauZ")
                    {
                        attribute.Value = "STLB-BauZ";
                    }
                    break;
                case "STLB":
                    if (attribute.Value != "StLB")
                    {
                        attribute.Value = "StLB";
                    }
                    break;
                case "STLK":
                    if (attribute.Value != "StLK")
                    {
                        attribute.Value = "StLK";
                    }
                    break;
                default:
                    attribute.Remove();
                    break;
            }
        }
        private void CheckAttributeType_InlineSimpleType_bc96b108_cf0f_4b65_a5c5_b6dabf854311(XAttribute attribute)
        {
            switch (attribute.Value.ToUpperInvariant())
            {
                case "BASE64":
                    if (attribute.Value != "base64")
                    {
                        attribute.Value = "base64";
                    }
                    break;
                default:
                    attribute.Remove();
                    break;
            }
        }
        private void CheckAttributeType_InlineSimpleType_de94f195_6b90_4789_8afa_c277c849c792(XAttribute attribute)
        {
            switch (attribute.Value.ToUpperInvariant())
            {
                case "BIDDER":
                    if (attribute.Value != "Bidder")
                    {
                        attribute.Value = "Bidder";
                    }
                    break;
                case "OWNER":
                    if (attribute.Value != "Owner")
                    {
                        attribute.Value = "Owner";
                    }
                    break;
                default:
                    attribute.Remove();
                    break;
            }
        }
        private void CheckAttributeType_tgAttAlign(XAttribute attribute)
        {
            switch (attribute.Value.ToUpperInvariant())
            {
                case "LEFT":
                    if (attribute.Value != "left")
                    {
                        attribute.Value = "left";
                    }
                    break;
                case "CENTER":
                    if (attribute.Value != "center")
                    {
                        attribute.Value = "center";
                    }
                    break;
                case "RIGHT":
                    if (attribute.Value != "right")
                    {
                        attribute.Value = "right";
                    }
                    break;
                case "JUSTIFY":
                    if (attribute.Value != "justify")
                    {
                        attribute.Value = "justify";
                    }
                    break;
                default:
                    attribute.Remove();
                    break;
            }
        }
        private void CheckAttributeType_tgAttAlignTable(XAttribute attribute)
        {
            switch (attribute.Value.ToUpperInvariant())
            {
                case "LEFT":
                    if (attribute.Value != "left")
                    {
                        attribute.Value = "left";
                    }
                    break;
                case "CENTER":
                    if (attribute.Value != "center")
                    {
                        attribute.Value = "center";
                    }
                    break;
                case "RIGHT":
                    if (attribute.Value != "right")
                    {
                        attribute.Value = "right";
                    }
                    break;
                default:
                    attribute.Remove();
                    break;
            }
        }
        private void CheckAttributeType_tgAttBorder(XAttribute attribute)
        {
        }
        private void CheckAttributeType_tgAttCellpadding(XAttribute attribute)
        {
        }
        private void CheckAttributeType_tgAttColspan(XAttribute attribute)
        {
        }
        private void CheckAttributeType_tgAttFrame(XAttribute attribute)
        {
            switch (attribute.Value.ToUpperInvariant())
            {
                case "BOX":
                    if (attribute.Value != "box")
                    {
                        attribute.Value = "box";
                    }
                    break;
                case "HSIDES":
                    if (attribute.Value != "hsides")
                    {
                        attribute.Value = "hsides";
                    }
                    break;
                case "VOID":
                    if (attribute.Value != "void")
                    {
                        attribute.Value = "void";
                    }
                    break;
                case "VSIDES":
                    if (attribute.Value != "vsides")
                    {
                        attribute.Value = "vsides";
                    }
                    break;
                default:
                    attribute.Remove();
                    break;
            }
        }
        private void CheckAttributeType_tgAttHeight(XAttribute attribute)
        {
        }
        private void CheckAttributeType_tgAttOrg(XAttribute attribute)
        {
            switch (attribute.Value.ToUpperInvariant())
            {
                case "TAB":
                    if (attribute.Value != "TAB")
                    {
                        attribute.Value = "TAB";
                    }
                    break;
                default:
                    attribute.Remove();
                    break;
            }
        }
        private void CheckAttributeType_tgAttRowspan(XAttribute attribute)
        {
        }
        private void CheckAttributeType_tgAttStyle(XAttribute attribute)
        {
        }
        private void CheckAttributeType_tgAttValign(XAttribute attribute)
        {
            switch (attribute.Value.ToUpperInvariant())
            {
                case "BOTTOM":
                    if (attribute.Value != "bottom")
                    {
                        attribute.Value = "bottom";
                    }
                    break;
                case "MIDDLE":
                    if (attribute.Value != "middle")
                    {
                        attribute.Value = "middle";
                    }
                    break;
                case "TOP":
                    if (attribute.Value != "top")
                    {
                        attribute.Value = "top";
                    }
                    break;
                default:
                    attribute.Remove();
                    break;
            }
        }
        private void CheckAttributeType_tgAttWidth(XAttribute attribute)
        {
        }
        private void CheckAttributeType_tgDecimal(XAttribute attribute)
        {
        }
        private void CheckAttributeType_tgInteger(XAttribute attribute)
        {
        }
        private void CheckAttributeType_tgNormalizedString(XAttribute attribute)
        {
        }
        private void CheckAttributeType_tgPositiveInteger(XAttribute attribute)
        {
        }
        private void CheckAttributeType_tgRNoIndex(XAttribute attribute)
        {
        }
        private void CheckAttributeType_tgRNoPart(XAttribute attribute)
        {
        }
        private void CheckAttributeType_tgYes(XAttribute attribute)
        {
            switch (attribute.Value.ToUpperInvariant())
            {
                case "YES":
                    if (attribute.Value != "Yes")
                    {
                        attribute.Value = "Yes";
                    }
                    break;
                default:
                    attribute.Remove();
                    break;
            }
        }
        private void CheckAttributeType_xml_space(XAttribute attribute)
        {
        }
        private void CheckAttributeType_xs_ID(XAttribute attribute)
        {
        }
        private void CheckAttributeType_xs_IDREF(XAttribute attribute)
        {
        }
    }
}

