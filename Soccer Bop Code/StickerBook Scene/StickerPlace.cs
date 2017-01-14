using UnityEngine;
using System.Collections.Generic;

// Neil Byrne - 2015

// Here the data structures containing team players, and their place in each team is defined

public class StickerPlace : MonoBehaviour {

	public static IDictionary<string, teamLineup> teamLineUps = new Dictionary<string, teamLineup>();
	public static string[] teamOrder = new string[32] {"aBilbao", "aFCAjax", "aMadrid", "anderlecht", "aPOELNikosia", "aSMonaco", "aSRoma", "bateBorisov",
		"bDortmund", "benfica", "bLeverkusen", "cataloniaFC", "chelsea", "cSKAMoskva", "fCBasel", "hollowayRoad", "istanbulFC", "juventus" ,"ludogoretsRazgrad" ,"madridCity",
		"malmo", "manCityFC", "maribor", "MerseysideRed", "munichFC", "olympiakos", "parisSG", "porto", "schalkeFC", "shakhtarDonetsk", "sportingLisbon", "zenit"};

	void Start () {
		try{

		teamLineUps.Add ("aBilbao", new teamLineup{ teamPlayers = new string[6] {"main_Iturraspe", "main_MikelRico", "main_OscarDeMarcos", "main_Susaeta", "main_Muniain", "main_Laporte"} } );
		teamLineUps.Add ("aFCAjax", new teamLineup{ teamPlayers = new string[6] {"main_RichairoZivkovic", "main_KolbeinnSigthorsson", "main_DavyKlaassen", "main_Schone", "main_Fischer", "main_Moisander"} } );
		teamLineUps.Add ("aMadrid", new teamLineup{ teamPlayers = new string[6] {"main_Godin", "main_Griezemann", "main_Koke", "main_Mandzukic", "main_Miranda", "main_Turan"} } );
		teamLineUps.Add ("anderlecht", new teamLineup{ teamPlayers = new string[6] {"main_MatiasSuarez", "main_Mitrovic", "main_Praet", "main_Tielemans", "main_ChancelMbembaMangulu", "main_StevenDefour"} } );
		teamLineUps.Add ("aPOELNikosia", new teamLineup{ teamPlayers = new string[6] {"main_Gomes", "main_Guilherme", "main_Kaka", "main_JohnArneRiise", "main_TomasDeVincenti", "main_Vinicius"} } );

		teamLineUps.Add ("aSMonaco", new teamLineup{ teamPlayers = new string[6] {"main_Toulalan", "main_Traore", "main_BernardoSilva", "main_Fabinho", "main_Moutinho", "main_GeoffreyKondogbia"} } );
		teamLineUps.Add ("aSRoma", new teamLineup{ teamPlayers = new string[6] {"main_Benatia", "main_Pjanic", "main_Ashley_Cole", "main_Strootman", "main_DeRossi", "main_FrancescoTotti"} } );
		teamLineUps.Add ("bateBorisov", new teamLineup{ teamPlayers = new string[6] {"main_Krivets", "main_Polyakov", "main_Rodionov", "main_Tubic", "main_AleksandrVolodko", "main_EgorFilipenko"} } );
		teamLineUps.Add ("bDortmund", new teamLineup{ teamPlayers = new string[6] {"main_Gundogan", "main_Hummels", "main_Subotic", "main_ShinjiKagawa", "main_Bender", "main_Reus"} } );

		teamLineUps.Add ("benfica", new teamLineup{ teamPlayers = new string[6] {"main_Cardoza", "main_Gaiton", "main_Lima", "main_Pereira", "main_Perez", "main_Salvio"} } );
		teamLineUps.Add ("bLeverkusen", new teamLineup{ teamPlayers = new string[6] {"main_Calhanoglu", "main_Castro", "main_Toprak", "main_Leno", "main_StefanKiessling", "main_BenderL"} } );
		teamLineUps.Add ("cataloniaFC", new teamLineup{ teamPlayers = new string[6] {"main_Busquets", "main_Iniesta", "main_pique", "main_Suarez", "main_neymar", "main_Messi"} } );
		teamLineUps.Add ("chelsea", new teamLineup{ teamPlayers = new string[6] {"main_Willian", "main_Ramires", "main_Oscar", "main_Fabregas", "main_Hazard", "main_Costa"} } );

		teamLineUps.Add ("cSKAMoskva", new teamLineup{ teamPlayers = new string[6] {"main_Doumbia", "main_Dzadoev", "main_Elm", "main_Fernandes", "main_Eremenko", "main_AhmedMusa"} } );
		teamLineUps.Add ("fCBasel", new teamLineup{ teamPlayers = new string[6] {"main_Frei", "main_Ivanov", "main_Schar", "main_Suchy", "main_Samuel", "main_ShkelzenGashi"} } );
		teamLineUps.Add ("hollowayRoad", new teamLineup{ teamPlayers = new string[6] {"main_Sanchez", "main_Walcott", "main_Wilshere", "main_Cazorla", "main_Wellbeck", "main_Ozil"} } );
		teamLineUps.Add ("istanbulFC", new teamLineup{ teamPlayers = new string[6] {"main_FelipeMelo", "main_Muselera", "main_Yilmaz", "main_GoranPandev", "main_OlcanAdin", "main_Sneijder"} } );

		teamLineUps.Add ("juventus", new teamLineup{ teamPlayers = new string[6] {"main_Chiellini", "main_Llorente", "main_Marchisio", "main_Tevez", "main_Vidal", "main_Pogba"} } );
		teamLineUps.Add ("ludogoretsRazgrad", new teamLineup{ teamPlayers = new string[6]  {"main_Bezjak", "main_Dyakov", "main_Marcelino", "main_Vura", "main_JuniorCaicara", "main_Marcelinho"} } );
		teamLineUps.Add ("madridCity", new teamLineup{ teamPlayers = new string[6] {"main_Kroos", "main_Ramos", "main_Benzema", "main_Rodriguez", "main_Bale", "main_Ronaldo"} } );
		teamLineUps.Add ("malmo", new teamLineup{ teamPlayers = new string[6] {"main_KofiAdu", "main_Molins", "main_ricardinho", "main_Thern", "main_MagnusEriksson", "main_Mehmeti"}} );
		teamLineUps.Add ("manCityFC", new teamLineup{ teamPlayers = new string[6] {"main_Dzeko", "main_Kompany", "main_Fernando", "main_Toure", "main_Silva", "main_Aguero"} } );

		teamLineUps.Add ("maribor", new teamLineup{ teamPlayers = new string[6]  {"main_Filipovic", "main_Ibraimi", "main_Rajcevic", "main_Tavares", "main_DamjanBohar", "main_DuduBiton"} } );
		
		teamLineUps.Add ("MerseysideRed", new teamLineup{ teamPlayers = new string[6] {"main_Coutinho", "main_Lallana", "main_Markovic", "main_Gerrard", "main_Sterling", "main_Sturridge"} } );
		teamLineUps.Add ("munichFC", new teamLineup{ teamPlayers = new string[6] {"main_Schweinsteiger", "main_Alaba", "main_Lewandowski", "main_Gotze", "main_Muller", "main_Ribery"} } );

		teamLineUps.Add ("olympiakos", new teamLineup{ teamPlayers = new string[6] {"main_papadopolous", "main_Roberto", "main_Salino", "main_KonstantinosMitroglou", "main_PajtimKasami", "main_IbrahimAfellay"} } );

		teamLineUps.Add ("parisSG", new teamLineup{ teamPlayers = new string[6] {"main_David_Luiz", "main_Marquinhos", "main_Silva", "main_Lucas", "main_Cavani", "main_Ibrahimovic"} } );
		teamLineUps.Add ("porto", new teamLineup{ teamPlayers = new string[6] {"main_Danilo", "main_HectorHerrera", "main_JacksonMartinez", "main_Sandro", "main_BrunoMartinsInd", "main_CristianTello"} } );
		
		teamLineUps.Add ("schalkeFC", new teamLineup{ teamPlayers = new string[6] {"main_Boateng", "main_Howedes", "main_Matip", "main_Huntelaar", "main_Farfan", "main_Draxler"} } );
		teamLineUps.Add ("shakhtarDonetsk", new teamLineup{ teamPlayers = new string[6] {"main_Bernard", "main_Douglas_Costa", "main_Rakitsky", "main_Srna", "main_Taison", "main_Teixeira"} } );

		teamLineUps.Add ("sportingLisbon", new teamLineup{ teamPlayers = new string[6] {"main_Carvalho", "main_Montero", "main_Patricio", "main_Silva", "main_AndreMartins", "main_Nani"} } );
		teamLineUps.Add ("zenit", new teamLineup{ teamPlayers = new string[6] {"main_Danny", "main_Rondon", "main_JaviGarcia", "main_Garay", "main_Witsel", "main_Hulk"} } );
			
		}
		catch{}
	}
    
	
}

public class teamLineup
{
	public string[] teamPlayers { get; set; }
}
