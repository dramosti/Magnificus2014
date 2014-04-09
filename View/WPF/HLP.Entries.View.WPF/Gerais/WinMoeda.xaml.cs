using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HLP.Comum.View.Formularios;
using HLP.Entries.ViewModel.ViewModels.Gerais;
using System.Collections.ObjectModel;
using HLP.Resources.View.WPF.Classes;
using System.ComponentModel;

namespace HLP.Entries.View.WPF.Gerais
{
    /// <summary>
    /// Interaction logic for WinMoeda.xaml
    /// </summary>
    public partial class WinMoeda : WindowsBase, INotifyPropertyChanged
    {
        public WinMoeda()
        {
            InitializeComponent();
            this.ViewModel = new MoedaViewModel();

            lMoedaPadrao = new ObservableCollection<padraoMoeda>
            {
#region inclusão de itens
                new padraoMoeda{xCodigo="	AED	", nNumero=	784	,dCasasDecimais=	2	,xMoeda="	Dirham dos Emirados	", xPais="	 Emirados Árabes Unidos	"},
                new padraoMoeda{xCodigo="	AFN	", nNumero=	971	,dCasasDecimais=	2	,xMoeda="	Afegane	", xPais="	 Afeganistão	"},
                new padraoMoeda{xCodigo="	ALL	", nNumero=	8	,dCasasDecimais=	2	,xMoeda="	Lek	", xPais="	 Albânia	"},
                new padraoMoeda{xCodigo="	AMD	", nNumero=	51	,dCasasDecimais=	0	,xMoeda="	Dram	", xPais="	 Arménia	"},
                new padraoMoeda{xCodigo="	ANG	", nNumero=	532	,dCasasDecimais=	2	,xMoeda="	Florim	", xPais="	 Antilhas Holandesas	"},
                new padraoMoeda{xCodigo="	AOA	", nNumero=	973	,dCasasDecimais=	1	,xMoeda="	Kwanza	", xPais="	 Angola	"},
                new padraoMoeda{xCodigo="	ARS	", nNumero=	32	,dCasasDecimais=	2	,xMoeda="	Peso Argentino	", xPais="	 Argentina	"},
                new padraoMoeda{xCodigo="	AUD	", nNumero=	36	,dCasasDecimais=	2	,xMoeda="	Dólar australiano	", xPais="	 Austrália, Território Antárctico Australiano, Ilha Christmas, Ilhas Cocos (Keeling), Ilha Heard e Ilhas McDonald,Kiribati, Nauru, Ilha Norfolk, Tuvalu	"},
                new padraoMoeda{xCodigo="	AWG	", nNumero=	533	,dCasasDecimais=	2	,xMoeda="	Florim de Aruba	", xPais="	 Aruba	"},
                new padraoMoeda{xCodigo="	AZN	", nNumero=	944	,dCasasDecimais=	2	,xMoeda="	Manat do Azerbaijão	", xPais="	 Azerbaijão	"},
                new padraoMoeda{xCodigo="	BAM	", nNumero=	977	,dCasasDecimais=	2	,xMoeda="	Marco convertível	", xPais="	 Bósnia e Herzegovina	"},
                new padraoMoeda{xCodigo="	BBD	", nNumero=	52	,dCasasDecimais=	2	,xMoeda="	Dólar de Barbados	", xPais="	 Barbados	"},
                new padraoMoeda{xCodigo="	BDT	", nNumero=	50	,dCasasDecimais=	2	,xMoeda="	Taka	", xPais="	 Bangladesh	"},
                new padraoMoeda{xCodigo="	BGN	", nNumero=	975	,dCasasDecimais=	2	,xMoeda="	Lev	", xPais="	 Bulgária	"},
                new padraoMoeda{xCodigo="	BHD	", nNumero=	48	,dCasasDecimais=	3	,xMoeda="	Dinar do Bahrein	", xPais="	 Bahrein	"},
                new padraoMoeda{xCodigo="	BIF	", nNumero=	108	,dCasasDecimais=	0	,xMoeda="	Franco do Burundi	", xPais="	 Burundi	"},
                new padraoMoeda{xCodigo="	BMD	", nNumero=	60	,dCasasDecimais=	2	,xMoeda="	Dólar de Bermuda	", xPais="	 Bermudas	"},
                new padraoMoeda{xCodigo="	BND	", nNumero=	96	,dCasasDecimais=	2	,xMoeda="	Dólar do Brunei	", xPais="	 Brunei, Singapura	"},
                new padraoMoeda{xCodigo="	BOB	", nNumero=	68	,dCasasDecimais=	2	,xMoeda="	Boliviano	", xPais="	 Bolívia	"},
                new padraoMoeda{xCodigo="	BOV	", nNumero=	984	,dCasasDecimais=	2	,xMoeda="	Boliviano Mvdol	", xPais="	 Bolívia	"},
                new padraoMoeda{xCodigo="	BRL	", nNumero=	986	,dCasasDecimais=	2	,xMoeda="	Real	", xPais="	 Brasil	"},
                new padraoMoeda{xCodigo="	BSD	", nNumero=	44	,dCasasDecimais=	2	,xMoeda="	Dólar das Bahamas	", xPais="	 Bahamas	"},
                new padraoMoeda{xCodigo="	BTN	", nNumero=	64	,dCasasDecimais=	2	,xMoeda="	Ngultrum	", xPais="	 Butão	"},
                new padraoMoeda{xCodigo="	BWP	", nNumero=	72	,dCasasDecimais=	2	,xMoeda="	Pula	", xPais="	 Botswana	"},
                new padraoMoeda{xCodigo="	BYR	", nNumero=	974	,dCasasDecimais=	0	,xMoeda="	Rublo bielorrusso	", xPais="	 Bielorrússia	"},
                new padraoMoeda{xCodigo="	BZD	", nNumero=	84	,dCasasDecimais=	2	,xMoeda="	Dólar do Belize	", xPais="	 Belize	"},
                new padraoMoeda{xCodigo="	CAD	", nNumero=	124	,dCasasDecimais=	2	,xMoeda="	Dólar canadense	", xPais="	 Canadá	"},
                new padraoMoeda{xCodigo="	CDF	", nNumero=	976	,dCasasDecimais=	2	,xMoeda="	Franco congolês	", xPais="	 República Democrática do Congo	"},
                new padraoMoeda{xCodigo="	CHE	", nNumero=	947	,dCasasDecimais=	2	,xMoeda="	WIR euro (moeda complementar)	", xPais="	 Suíça	"},
                new padraoMoeda{xCodigo="	CHF	", nNumero=	756	,dCasasDecimais=	2	,xMoeda="	Franco suíço	", xPais="	 Suíça	"},
                new padraoMoeda{xCodigo="	CHW	", nNumero=	948	,dCasasDecimais=	2	,xMoeda="	WIR franc (moeda complementar)	", xPais="	 Suíça	"},
                new padraoMoeda{xCodigo="	CLF	", nNumero=	990	,dCasasDecimais=	0	,xMoeda="	Unidade de Fomento (código de fundos)	", xPais="	 Chile	"},
                new padraoMoeda{xCodigo="	CLP	", nNumero=	152	,dCasasDecimais=	0	,xMoeda="	Peso chileno	", xPais="	 Chile	"},
                new padraoMoeda{xCodigo="	CNY	", nNumero=	156	,dCasasDecimais=	1	,xMoeda="	Renminbi	", xPais="	 República Popular da China	"},
                new padraoMoeda{xCodigo="	COP	", nNumero=	170	,dCasasDecimais=	0	,xMoeda="	Peso colombiano	", xPais="	 Colômbia	"},
                new padraoMoeda{xCodigo="	COU	", nNumero=	970	,dCasasDecimais=	2	,xMoeda="	Unidade de Valor Real	", xPais="	 Colômbia	"},
                new padraoMoeda{xCodigo="	CRC	", nNumero=	188	,dCasasDecimais=	2	,xMoeda="	Colon da Costa Rica	", xPais="	 Costa Rica	"},
                new padraoMoeda{xCodigo="	CUC	", nNumero=	931	,dCasasDecimais=	2	,xMoeda="	Cuban convertible peso	", xPais="	 Cuba	"},
                new padraoMoeda{xCodigo="	CUP	", nNumero=	192	,dCasasDecimais=	2	,xMoeda="	Peso cubano	", xPais="	 Cuba	"},
                new padraoMoeda{xCodigo="	CVE	", nNumero=	132	,dCasasDecimais=	0	,xMoeda="	Escudo cabo-verdiano	", xPais="	 Cabo Verde	"},
                new padraoMoeda{xCodigo="	CZK	", nNumero=	203	,dCasasDecimais=	2	,xMoeda="	Coroa	", xPais="	 República Checa	"},
                new padraoMoeda{xCodigo="	DJF	", nNumero=	262	,dCasasDecimais=	0	,xMoeda="	Franco do Djibouti	", xPais="	 Djibouti	"},
                new padraoMoeda{xCodigo="	DKK	", nNumero=	208	,dCasasDecimais=	2	,xMoeda="	Coroa dinamarquesa	", xPais="	 Dinamarca, incluindo as 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Ilhas Feroé, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Gronelândia	"},
                new padraoMoeda{xCodigo="	DOP	", nNumero=	214	,dCasasDecimais=	2	,xMoeda="	Peso	", xPais="	 República Dominicana	"},
                new padraoMoeda{xCodigo="	DZD	", nNumero=	12	,dCasasDecimais=	2	,xMoeda="	Dinar argelino	", xPais="	 Argélia	"},
                new padraoMoeda{xCodigo="	ECS	", nNumero=	895	,dCasasDecimais=	2	,xMoeda="	Sucre (O dólar americano USD é a moeda corrente no país)	", xPais="	 Equador	"},
                new padraoMoeda{xCodigo="	EGP	", nNumero=	818	,dCasasDecimais=	2	,xMoeda="	Libra egípcia	", xPais="	 Egito	"},
                new padraoMoeda{xCodigo="	ERN	", nNumero=	232	,dCasasDecimais=	2	,xMoeda="	Nakfa	", xPais="	 Eritreia	"},
                new padraoMoeda{xCodigo="	ETB	", nNumero=	230	,dCasasDecimais=	2	,xMoeda="	Birr etíope	", xPais="	 Etiópia	"},
                new padraoMoeda{xCodigo="	EUR	", nNumero=	978	,dCasasDecimais=	2	,xMoeda="	Euro	", xPais="	 Itália, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Vaticano, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Áustria, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Bélgica, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Espanha, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Estónia, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Finlândia, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Alemanha, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Grécia, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Irlanda, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Andorra, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Luxemburgo, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Mónaco, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Mónaco, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Países Baixos, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Portugal, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 São Marino, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 França incl. Guiana Francesa, Guadalupe, Martinica, Mayotte, Reunião, Saint Pierre e Miquelon e Terras Austrais e Antárticas Francesas.	"},
                new padraoMoeda{xCodigo="	FJD	", nNumero=	242	,dCasasDecimais=	2	,xMoeda="	Dólar das Fiji	", xPais="	 Fiji	"},
                new padraoMoeda{xCodigo="	FKP	", nNumero=	238	,dCasasDecimais=	2	,xMoeda="	Libra das Malvinas	", xPais="	 Ilhas Malvinas	"},
                new padraoMoeda{xCodigo="	GBP	", nNumero=	826	,dCasasDecimais=	2	,xMoeda="	Libra Esterlina	", xPais="	 Reino Unido, Dependências da Coroa (a Ilha de Man e as Ilhas Channel), determinado Territórios britânicos ultramarinos (Ilhas Geórgia do Sul e Sandwich do Sul, Território Antártico Britânico e Território Britânico do Oceano Índico)	"},
                new padraoMoeda{xCodigo="	GEL	", nNumero=	981	,dCasasDecimais=	2	,xMoeda="	Lari	", xPais="	 Geórgia	"},
                new padraoMoeda{xCodigo="	GHS	", nNumero=	936	,dCasasDecimais=	2	,xMoeda="	Cedi	", xPais="	 Gana	"},
                new padraoMoeda{xCodigo="	GIP	", nNumero=	292	,dCasasDecimais=	2	,xMoeda="	Libra de Gibraltar	", xPais="	 Gibraltar	"},
                new padraoMoeda{xCodigo="	GMD	", nNumero=	270	,dCasasDecimais=	2	,xMoeda="	Dalasi	", xPais="	 Gâmbia	"},
                new padraoMoeda{xCodigo="	GNF	", nNumero=	324	,dCasasDecimais=	0	,xMoeda="	Franco da Guiné	", xPais="	 Guiné	"},
                new padraoMoeda{xCodigo="	GTQ	", nNumero=	320	,dCasasDecimais=	2	,xMoeda="	Quetzal guatemalteco	", xPais="	 Guatemala	"},
                new padraoMoeda{xCodigo="	GWP	", nNumero=	624	,dCasasDecimais=	0	,xMoeda="	Peso da Guiné-Bissau	", xPais="	 Guiné-Bissau	"},
                new padraoMoeda{xCodigo="	GYD	", nNumero=	328	,dCasasDecimais=	2	,xMoeda="	Dólar da Guiana	", xPais="	 Guiana	"},
                new padraoMoeda{xCodigo="	HKD	", nNumero=	344	,dCasasDecimais=	2	,xMoeda="	Dólar de Hong Kong	", xPais="	 Hong Kong Região Administrativa Especial	"},
                new padraoMoeda{xCodigo="	HNL	", nNumero=	340	,dCasasDecimais=	2	,xMoeda="	Lempira	", xPais="	 Honduras	"},
                new padraoMoeda{xCodigo="	HRK	", nNumero=	191	,dCasasDecimais=	2	,xMoeda="	Kuna	", xPais="	 Croácia	"},
                new padraoMoeda{xCodigo="	HTG	", nNumero=	332	,dCasasDecimais=	2	,xMoeda="	Gourde	", xPais="	 Haiti	"},
                new padraoMoeda{xCodigo="	HUF	", nNumero=	348	,dCasasDecimais=	2	,xMoeda="	Forint	", xPais="	 Hungria	"},
                new padraoMoeda{xCodigo="	IDR	", nNumero=	360	,dCasasDecimais=	0	,xMoeda="	Rupia indonésia	", xPais="	 Indonésia	"},
                new padraoMoeda{xCodigo="	ILS	", nNumero=	376	,dCasasDecimais=	2	,xMoeda="	Shekel	", xPais="	 Israel	"},
                new padraoMoeda{xCodigo="	INR	", nNumero=	356	,dCasasDecimais=	2	,xMoeda="	Rupia indiana	", xPais="	 Brunei, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Índia	"},
                new padraoMoeda{xCodigo="	IQD	", nNumero=	368	,dCasasDecimais=	0	,xMoeda="	Dinar iraquiano	", xPais="	 Iraque	"},
                new padraoMoeda{xCodigo="	IRR	", nNumero=	364	,dCasasDecimais=	0	,xMoeda="	Rial iraniano	", xPais="	 Irã	"},
                new padraoMoeda{xCodigo="	ISK	", nNumero=	352	,dCasasDecimais=	0	,xMoeda="	Coroa islandesa	", xPais="	 Islândia	"},
                new padraoMoeda{xCodigo="	JMD	", nNumero=	388	,dCasasDecimais=	2	,xMoeda="	Dólar jamaicano	", xPais="	 Jamaica	"},
                new padraoMoeda{xCodigo="	JOD	", nNumero=	400	,dCasasDecimais=	3	,xMoeda="	Dinar jordano	", xPais="	 Jordânia	"},
                new padraoMoeda{xCodigo="	JPY	", nNumero=	392	,dCasasDecimais=	0	,xMoeda="	Iene	", xPais="	 Japão	"},
                new padraoMoeda{xCodigo="	KES	", nNumero=	404	,dCasasDecimais=	2	,xMoeda="	Xelim queniano	", xPais="	 Quênia	"},
                new padraoMoeda{xCodigo="	KGS	", nNumero=	417	,dCasasDecimais=	2	,xMoeda="	Som	", xPais="	 Quirguistão	"},
                new padraoMoeda{xCodigo="	KHR	", nNumero=	116	,dCasasDecimais=	0	,xMoeda="	Riel	", xPais="	 Camboja	"},
                new padraoMoeda{xCodigo="	KMF	", nNumero=	174	,dCasasDecimais=	0	,xMoeda="	Franco das Comoros	", xPais="	 Comores	"},
                new padraoMoeda{xCodigo="	KPW	", nNumero=	408	,dCasasDecimais=	0	,xMoeda="	Won norte coreano	", xPais="	 Coreia do Norte	"},
                new padraoMoeda{xCodigo="	KRW	", nNumero=	410	,dCasasDecimais=	0	,xMoeda="	Won sul coreano	", xPais="	 Coreia do Sul	"},
                new padraoMoeda{xCodigo="	KWD	", nNumero=	414	,dCasasDecimais=	3	,xMoeda="	Dinar do Kuwait	", xPais="	 Kuwait	"},
                new padraoMoeda{xCodigo="	KYD	", nNumero=	136	,dCasasDecimais=	2	,xMoeda="	Dólar das Ilhas Caimão	", xPais="	 Ilhas Cayman	"},
                new padraoMoeda{xCodigo="	KZT	", nNumero=	398	,dCasasDecimais=	2	,xMoeda="	Tenge	", xPais="	 Cazaquistão	"},
                new padraoMoeda{xCodigo="	LAK	", nNumero=	418	,dCasasDecimais=	0	,xMoeda="	Kip	", xPais="	 Laos	"},
                new padraoMoeda{xCodigo="	LBP	", nNumero=	422	,dCasasDecimais=	0	,xMoeda="	Libra libanesa	", xPais="	 Líbano	"},
                new padraoMoeda{xCodigo="	LKR	", nNumero=	144	,dCasasDecimais=	2	,xMoeda="	Rupia do Sri Lanka	", xPais="	 Sri Lanka	"},
                new padraoMoeda{xCodigo="	LRD	", nNumero=	430	,dCasasDecimais=	2	,xMoeda="	Dólar da Libéria	", xPais="	 Libéria	"},
                new padraoMoeda{xCodigo="	LSL	", nNumero=	426	,dCasasDecimais=	2	,xMoeda="	Loti	", xPais="	 Lesoto	"},
                new padraoMoeda{xCodigo="	LTL	", nNumero=	440	,dCasasDecimais=	2	,xMoeda="	Litas	", xPais="	 Lituânia	"},
                new padraoMoeda{xCodigo="	LVL	", nNumero=	428	,dCasasDecimais=	2	,xMoeda="	Lats	", xPais="	 Letônia	"},
                new padraoMoeda{xCodigo="	LYD	", nNumero=	434	,dCasasDecimais=	3	,xMoeda="	Dinar da Líbia	", xPais="	 Líbia	"},
                new padraoMoeda{xCodigo="	MAD	", nNumero=	504	,dCasasDecimais=	2	,xMoeda="	Dirham marroquino	", xPais="	 Marrocos, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Saara Ocidental	"},
                new padraoMoeda{xCodigo="	MDL	", nNumero=	498	,dCasasDecimais=	2	,xMoeda="	Leu	", xPais="	 Moldávia	"},
                new padraoMoeda{xCodigo="	MGA	", nNumero=	969	,dCasasDecimais=	0.7M	,xMoeda="	Ariary	", xPais="	 Madagáscar	"},
                new padraoMoeda{xCodigo="	MKD	", nNumero=	807	,dCasasDecimais=	2	,xMoeda="	Denar	", xPais="	 Macedónia	"},
                new padraoMoeda{xCodigo="	MMK	", nNumero=	104	,dCasasDecimais=	0	,xMoeda="	Kyat	", xPais="	 Myanmar	"},
                new padraoMoeda{xCodigo="	MNT	", nNumero=	496	,dCasasDecimais=	2	,xMoeda="	Tugrik	", xPais="	 Mongólia	"},
                new padraoMoeda{xCodigo="	MOP	", nNumero=	446	,dCasasDecimais=	1	,xMoeda="	Pataca	", xPais="	 Macau Região Administrativa Especial	"},
                new padraoMoeda{xCodigo="	MRO	", nNumero=	478	,dCasasDecimais=	0.7M	,xMoeda="	Ouguiya	", xPais="	 Mauritânia	"},
                new padraoMoeda{xCodigo="	MUR	", nNumero=	480	,dCasasDecimais=	2	,xMoeda="	Rupia da Maurícia	", xPais="	 Maurícia	"},
                new padraoMoeda{xCodigo="	MVR	", nNumero=	462	,dCasasDecimais=	2	,xMoeda="	Rufiyaa	", xPais="	 Maldivas	"},
                new padraoMoeda{xCodigo="	MWK	", nNumero=	454	,dCasasDecimais=	2	,xMoeda="	Kwacha	", xPais="	 Malawi	"},
                new padraoMoeda{xCodigo="	MXN	", nNumero=	484	,dCasasDecimais=	2	,xMoeda="	Peso mexicano	", xPais="	 México	"},
                new padraoMoeda{xCodigo="	MXV	", nNumero=	979	,dCasasDecimais=	2	,xMoeda="	Unidade Mexicana de Investimento	", xPais="	 México	"},
                new padraoMoeda{xCodigo="	MYR	", nNumero=	458	,dCasasDecimais=	2	,xMoeda="	Ringgit	", xPais="	 Malásia	"},
                new padraoMoeda{xCodigo="	MZN	", nNumero=	943	,dCasasDecimais=	2	,xMoeda="	Metical	", xPais="	 Moçambique	"},
                new padraoMoeda{xCodigo="	NAD	", nNumero=	516	,dCasasDecimais=	2	,xMoeda="	Dólar da Namíbia	", xPais="	 Namíbia	"},
                new padraoMoeda{xCodigo="	NGN	", nNumero=	566	,dCasasDecimais=	2	,xMoeda="	Naira	", xPais="	 Nigéria	"},
                new padraoMoeda{xCodigo="	NIO	", nNumero=	558	,dCasasDecimais=	2	,xMoeda="	Cordoba Oro	", xPais="	 Nicarágua	"},
                new padraoMoeda{xCodigo="	NOK	", nNumero=	578	,dCasasDecimais=	2	,xMoeda="	Coroa norueguesa	", xPais="	 Noruega, Ilha Bouvet, Queen Maud Land, Ilha Peter I	"},
                new padraoMoeda{xCodigo="	NPR	", nNumero=	524	,dCasasDecimais=	2	,xMoeda="	Rupia nepalesa	", xPais="	 Nepal	"},
                new padraoMoeda{xCodigo="	NZD	", nNumero=	554	,dCasasDecimais=	2	,xMoeda="	Dólar da Nova Zelândia	", xPais="	 Nova Zelândia, incl. 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Ilhas Cook, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Niue, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Pitcairn, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Toquelau	"},
                new padraoMoeda{xCodigo="	OMR	", nNumero=	512	,dCasasDecimais=	3	,xMoeda="	Rial Omani	", xPais="	 Omã	"},
                new padraoMoeda{xCodigo="	PAB	", nNumero=	590	,dCasasDecimais=	2	,xMoeda="	Balboa (O dólar americano USD é a moeda corrente no país)	", xPais="	 Panamá	"},
                new padraoMoeda{xCodigo="	PEN	", nNumero=	604	,dCasasDecimais=	2	,xMoeda="	Nuevo Sol	", xPais="	 Peru	"},
                new padraoMoeda{xCodigo="	PGK	", nNumero=	598	,dCasasDecimais=	2	,xMoeda="	Kina	", xPais="	 Papua-Nova Guiné	"},
                new padraoMoeda{xCodigo="	PHP	", nNumero=	608	,dCasasDecimais=	2	,xMoeda="	Peso filipino	", xPais="	 Filipinas	"},
                new padraoMoeda{xCodigo="	PKR	", nNumero=	586	,dCasasDecimais=	2	,xMoeda="	Rupia paquistanesa	", xPais="	 Paquistão	"},
                new padraoMoeda{xCodigo="	PLN	", nNumero=	985	,dCasasDecimais=	2	,xMoeda="	Zloty	", xPais="	 Polónia	"},
                new padraoMoeda{xCodigo="	PYG	", nNumero=	600	,dCasasDecimais=	0	,xMoeda="	Guarani	", xPais="	 Paraguai	"},
                new padraoMoeda{xCodigo="	QAR	", nNumero=	634	,dCasasDecimais=	2	,xMoeda="	Rial do Qatar	", xPais="	 Catar	"},
                new padraoMoeda{xCodigo="	RON	", nNumero=	946	,dCasasDecimais=	2	,xMoeda="	RON	", xPais="	 Roménia	"},
                new padraoMoeda{xCodigo="	RSD	", nNumero=	941	,dCasasDecimais=	2	,xMoeda="	Dinar Sérvio	", xPais="	 Sérvia	"},
                new padraoMoeda{xCodigo="	RUB	", nNumero=	643	,dCasasDecimais=	2	,xMoeda="	Rublo	", xPais="	 Rússia, Abkhazia, Ossétia do Sul	"},
                new padraoMoeda{xCodigo="	RWF	", nNumero=	646	,dCasasDecimais=	0	,xMoeda="	Franco do Ruanda	", xPais="	 Ruanda	"},
                new padraoMoeda{xCodigo="	SAR	", nNumero=	682	,dCasasDecimais=	2	,xMoeda="	Riyal	", xPais="	 Arábia Saudita	"},
                new padraoMoeda{xCodigo="	SBD	", nNumero=	90	,dCasasDecimais=	2	,xMoeda="	Dólar das Ilhas Salomão	", xPais="	 Ilhas Salomão	"},
                new padraoMoeda{xCodigo="	SCR	", nNumero=	690	,dCasasDecimais=	2	,xMoeda="	Rupia das Seychelles	", xPais="	 Seychelles	"},
                new padraoMoeda{xCodigo="	SDG	", nNumero=	938	,dCasasDecimais=	2	,xMoeda="	Dinar sudanês	", xPais="	 Sudão	"},
                new padraoMoeda{xCodigo="	SEK	", nNumero=	752	,dCasasDecimais=	2	,xMoeda="	Coroa Sueca	", xPais="	 Suécia	"},
                new padraoMoeda{xCodigo="	SGD	", nNumero=	702	,dCasasDecimais=	2	,xMoeda="	Dólar de Cingapura	", xPais="	 Singapura	"},
                new padraoMoeda{xCodigo="	SHP	", nNumero=	654	,dCasasDecimais=	2	,xMoeda="	Libra de Santa Helena	", xPais="	 Santa Helena, Ascensão e Tristão da Cunha	"},
                new padraoMoeda{xCodigo="	SLL	", nNumero=	694	,dCasasDecimais=	0	,xMoeda="	Leone	", xPais="	 Serra Leoa	"},
                new padraoMoeda{xCodigo="	SOS	", nNumero=	706	,dCasasDecimais=	2	,xMoeda="	Xelim somali	", xPais="	 Somália	"},
                new padraoMoeda{xCodigo="	SRD	", nNumero=	968	,dCasasDecimais=	2	,xMoeda="	Dólar do Suriname	", xPais="	 Suriname	"},
                new padraoMoeda{xCodigo="	STD	", nNumero=	678	,dCasasDecimais=	0	,xMoeda="	Dobra	", xPais="	 São Tomé e Príncipe	"},
                new padraoMoeda{xCodigo="	SVC	", nNumero=	222	,dCasasDecimais=	0	,xMoeda="	Colon de El Salvador	", xPais="	 El Salvador	"},
                new padraoMoeda{xCodigo="	SYP	", nNumero=	760	,dCasasDecimais=	2	,xMoeda="	Libra da Síria	", xPais="	 Síria	"},
                new padraoMoeda{xCodigo="	SZL	", nNumero=	748	,dCasasDecimais=	2	,xMoeda="	Lilangeni	", xPais="	 Suazilândia	"},
                new padraoMoeda{xCodigo="	THB	", nNumero=	764	,dCasasDecimais=	2	,xMoeda="	Baht	", xPais="	 Tailândia	"},
                new padraoMoeda{xCodigo="	TJS	", nNumero=	972	,dCasasDecimais=	2	,xMoeda="	Somoni	", xPais="	 Tajiquistão	"},
                new padraoMoeda{xCodigo="	TMT	", nNumero=	934	,dCasasDecimais=	2	,xMoeda="	Manat turcomano	", xPais="	 Turquemenistão	"},
                new padraoMoeda{xCodigo="	TND	", nNumero=	788	,dCasasDecimais=	3	,xMoeda="	Dinar tunisino	", xPais="	 Tunísia	"},
                new padraoMoeda{xCodigo="	TOP	", nNumero=	776	,dCasasDecimais=	2	,xMoeda="	Pa'anga	", xPais="	 Tonga	"},
                new padraoMoeda{xCodigo="	TRY	", nNumero=	949	,dCasasDecimais=	2	,xMoeda="	Nova Lira turca	", xPais="	 Turquia	"},
                new padraoMoeda{xCodigo="	TTD	", nNumero=	780	,dCasasDecimais=	2	,xMoeda="	Dólar de Trindade e Tobago	", xPais="	 Trinidad e Tobago	"},
                new padraoMoeda{xCodigo="	TWD	", nNumero=	901	,dCasasDecimais=	1	,xMoeda="	Novo Dólar de Taiwan	", xPais="	 Taiwan and other islands that are under the effective control of the Republic of China (ROC)	"},
                new padraoMoeda{xCodigo="	TZS	", nNumero=	834	,dCasasDecimais=	2	,xMoeda="	Xelim da Tanzânia	", xPais="	 Tanzânia	"},
                new padraoMoeda{xCodigo="	UAH	", nNumero=	980	,dCasasDecimais=	2	,xMoeda="	Grívnia	", xPais="	 Ucrânia	"},
                new padraoMoeda{xCodigo="	UGX	", nNumero=	800	,dCasasDecimais=	0	,xMoeda="	Xelim do Uganda	", xPais="	 Uganda	"},
                new padraoMoeda{xCodigo="	USD	", nNumero=	840	,dCasasDecimais=	2	,xMoeda="	Dólar Americano	", xPais="	 Estados Unidos e também: 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Equador, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 El Salvador, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Guam, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Haiti, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Ilhas Marshall, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	Estados Federados da Micronésia, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Marianas Setentrionais, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Palau, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Panamá, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Timor-Leste, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Turcas e Caicos, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Ilhas Virgens Americanas, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Samoa, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Samoa Americana, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Território Britânico do Oceano Índico	"},
                new padraoMoeda{xCodigo="	USN	", nNumero=	997	,dCasasDecimais=	2	,xMoeda="	United States dollar (next day) (funds code)	", xPais="	 Estados Unidos	"},
                new padraoMoeda{xCodigo="	USS	", nNumero=	998	,dCasasDecimais=	2	,xMoeda="	United States dollar (same day) (funds code) (one source claims it is no longer used, but it is still on the ISO 4217-MA list)	", xPais="	 Estados Unidos	"},
                new padraoMoeda{xCodigo="	UYI	", nNumero=	940	,dCasasDecimais=	0	,xMoeda="	Peso do Uruguay em Unidades Indexadas	", xPais="	 Uruguai	"},
                new padraoMoeda{xCodigo="	UYU	", nNumero=	858	,dCasasDecimais=	2	,xMoeda="	Peso Uruguaio	", xPais="	 Uruguai	"},
                new padraoMoeda{xCodigo="	UZS	", nNumero=	860	,dCasasDecimais=	2	,xMoeda="	Som Uzbeque	", xPais="	 Uzbequistão	"},
                new padraoMoeda{xCodigo="	VEF	", nNumero=	937	,dCasasDecimais=	2	,xMoeda="	Venezuelan bolívar fuerte	", xPais="	 Venezuela	"},
                new padraoMoeda{xCodigo="	VND	", nNumero=	704	,dCasasDecimais=	0	,xMoeda="	Dong	", xPais="	 Vietname	"},
                new padraoMoeda{xCodigo="	VUV	", nNumero=	548	,dCasasDecimais=	0	,xMoeda="	Vatu	", xPais="	 Vanuatu	"},
                new padraoMoeda{xCodigo="	WST	", nNumero=	882	,dCasasDecimais=	2	,xMoeda="	Tala	", xPais="	 Samoa	"},
                new padraoMoeda{xCodigo="	XAF	", nNumero=	950	,dCasasDecimais=	0	,xMoeda="	Franco CFA BEAC	", xPais="	 Camarões, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 República Centro-Africana, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 República do Congo, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Chade, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Guiné Equatorial, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	Gabão	"},
                new padraoMoeda{xCodigo="	XAG	", nNumero=	961	,dCasasDecimais=	0	,xMoeda="	Prata	", xPais="	uma onça Troy	"},
                new padraoMoeda{xCodigo="	XAU	", nNumero=	959	,dCasasDecimais=	0	,xMoeda="	Ouro	", xPais="	uma onça Troy	"},
                new padraoMoeda{xCodigo="	XBA	", nNumero=	955	,dCasasDecimais=	0	,xMoeda="	European Composite Unit (EURCO) (bond market unit)	", xPais="		"},
                new padraoMoeda{xCodigo="	XBB	", nNumero=	956	,dCasasDecimais=	0	,xMoeda="	European Monetary Unit (E.M.U.-6) (bond market unit)	", xPais="		"},
                new padraoMoeda{xCodigo="	XBC	", nNumero=	957	,dCasasDecimais=	0	,xMoeda="	European Unit of Account 9(E.U.A.-9) (bond market unit)	", xPais="		"},
                new padraoMoeda{xCodigo="	XBD	", nNumero=	958	,dCasasDecimais=	0	,xMoeda="	European Unit of Account 17(E.U.A.-17) (bond market unit)	", xPais="		"},
                new padraoMoeda{xCodigo="	XCD	", nNumero=	951	,dCasasDecimais=	2	,xMoeda="	Dólar das Caraíbas Orientais	", xPais="	 Anguilla, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0 	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Antígua e Barbuda, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Dominica, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Granada, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Montserrat, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 São Cristóvão e Nevis, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	Santa Lúcia, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 São Vicente e Granadinas	"},
                new padraoMoeda{xCodigo="	XDR	", nNumero=	960	,dCasasDecimais=	0	,xMoeda="	Special Drawing Rights	", xPais="	International Monetary Fund	"},
                new padraoMoeda{xCodigo="	XFU	", nNumero=	0	,dCasasDecimais=	0	,xMoeda="	UIC franc (special settlement currency)	", xPais="	International Union of Railways	"},
                new padraoMoeda{xCodigo="	XOF	", nNumero=	952	,dCasasDecimais=	0	,xMoeda="	Franco CFA BCEAO	", xPais="	 Benim, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Burkina Faso, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Costa do Marfim, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Guiné-Bissau, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Mali, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Níger, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Senegal, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	Togo	"},
                new padraoMoeda{xCodigo="	XPD	", nNumero=	964	,dCasasDecimais=	0	,xMoeda="	Paládio	", xPais="	uma onça Troy	"},
                new padraoMoeda{xCodigo="	XPF	", nNumero=	953	,dCasasDecimais=	0	,xMoeda="	Franco CFP	", xPais="	 Polinésia Francesa, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Nova Caledônia, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Wallis e Futuna	"},
                new padraoMoeda{xCodigo="	XPT	", nNumero=	962	,dCasasDecimais=	0	,xMoeda="	Platina	", xPais="	uma onça Troy	"},
                new padraoMoeda{xCodigo="	XTS	", nNumero=	963	,dCasasDecimais=	0	,xMoeda="	Reservado para efeitos de teste	", xPais="		"},
                new padraoMoeda{xCodigo="	XXX	", nNumero=	999	,dCasasDecimais=	0	,xMoeda="	No currency	", xPais="		"},
                new padraoMoeda{xCodigo="	YER	", nNumero=	886	,dCasasDecimais=	0	,xMoeda="	Rial do Iémene	", xPais="	 Iémen/Iêmen	"},
                new padraoMoeda{xCodigo="	ZAR	", nNumero=	710	,dCasasDecimais=	2	,xMoeda="	Rand	", xPais="	 Lesoto, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 Namíbia, 	"},
                //new padraoMoeda{xCodigo="		", nNumero=	0	,dCasasDecimais=	0	,xMoeda="		", xPais="	 África do Sul	"},
                new padraoMoeda{xCodigo="	ZMW	", nNumero=	894	,dCasasDecimais=	0	,xMoeda="	Kwacha	", xPais="	 Zâmbia	"},
                new padraoMoeda{xCodigo="	ZWL	", nNumero=	932	,dCasasDecimais=	2	,xMoeda="	Zimbabwe dollar	", xPais="	 Zimbabwe	"}
#endregion
            };
        }


        private ObservableCollection<padraoMoeda> _lMoedaPadrao;

        public ObservableCollection<padraoMoeda> lMoedaPadrao
        {
            get { return _lMoedaPadrao; }
            set
            {
                _lMoedaPadrao = value;
                this.NotifyPropertyChanged(propertyName: "lMoedaPadrao");
            }
        }


        public MoedaViewModel ViewModel
        {
            get
            {
                return this.DataContext as MoedaViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        #region NotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
