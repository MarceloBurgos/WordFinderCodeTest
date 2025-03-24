# WordFinder Service Api

This Api service handles word finder process using a matrix and a list of words to find.

# Technical features

    1. Fluent validation used to validate input data
    2. MSTest framework is used to testing implementation
    3. Set up WordFinder.Api as main project and run with F5

# Security

This project does not implement any security

# User imputs

Sample input that could be used to check functionality.

*The expected result should be the following words:*
	
	1. hello
	2. chair
	3. hat
	4. coffee
	5. computer
	6. table
	7. tree
	8. red
	9. black
	10. blue

*Json used as input:*

	{
	  "matrix": [
		"VhelloYchairhatEcoffeeSJcomputerVHLtableYFTOtreeJredVMblackDblue",
		"VhelloYchairhatEcoffeeSJcomputerVHLtableYFTOtreeJredVMblackDblue",
		"VhelloYchairhatEcoffeeSJcomputerVHLtableYFTOtreeJredVMblackDblue",
		"VhelloYchairhatEcoffeeSJcomputerVHLtableYFTOtreeJredVMblackDblue",
		"VhelloYchairhatEcoffeeSJcomputerVHLtableYFTOtreeJredVMblackDblue",
		"VhelloYchairhatEcoffeeSJcomputerVHLtableYFTOtreeJredVMblackDblue",
		"VhelloYchairhatEcoffeeSJcomputerVHLtableYFTOtreeJredVMblackDblue",
		"VhelloYchairhatEcoffeeSJcomputerVHLtableYFTOtreeJredVMblackDblue",
		"VhelloYchairhatEcoffeeSJcomputerVHLtableYFTOtreeJredVMblackDblue",
		"VhelloYchairhatEcoffeeSJcomputerVHLtableYFTOtreeJredVMblackDblue",
		"VhelloYYFUGKKRGEOJUXSCSJPOOQIBQVVHLQYBIUYFTOJUQSJJJUVMDVHQJDAUCG",
		"VhelloYYFUGKKRGEOvideoSJPorangeVVHLQYBIUYFTOJUQSJJJUVMDVHQJDAUCG",
		"VhelloYYFUGKKRGEOJUXSCSJPOOQIBQVVHLQYBIUYFheadsetJJUVMDVHQJDAUCG",
		"VhelloYYFUGKKRGEOJUXSCSJPOOQIBQVVHbookIUYFheadsetJJUVMDVHQJDAUCG",
		"VhelloYYFUGKKRGEOJUXSCSJPOOQIBQVVHLQYBIUYFTOJUQSJJJUVMorangeAUCG",
		"VhelloYYFUGKKRGEOJUXSCSJPOOQIBQVVHLQYBIUYFTOJorangeUVMDVHQJDAUCG",
		"OEMMWFEEOHCOURBTXEYJPJRSJZQYWCKJKJKULLOBINJIARKSXCNHHNEISQXZBHXW",
		"ZFGNGJLBWDAUDEKPUURGKXETNDGCUMIJYQZGSBDVJMFAJFIIBBACACGJFRQSBTBQ",
		"PJCZAQGPFQFCHFRJBBYGSQPLERVMURSFSGQVCHXLLVIDJDEOBQCLEZCQCLZIDIGR",
		"TZMFYGZDVXRNJWBKGIOOEVRBHFQFULYYYWNODWXBMHWBWDGPPVFPLCLCGEWMPNIO",
		"ALMFKJSGKLEWSQDAACMEOVFKKIGSAZEIWLRAZWFUDKTQBMXISGELSIDZAXNJVBNO",
		"YRGFQAZCDRGVKFMEBBECQFUNVFQQGHVTFJKJRFMIKGVNXDQZURBCTXUMVBAHKUWA",
		"PSZCESPYFMVZYVGTBAJBPGFQZHPMJPRSYFDQMQZBJJSNKPBEDEAXSPBRPHDNYEJS",
		"WOFPYNXTGKUWOHHIGWMSNDLONKTRWSBHXZSECELKVKVCRCVCRPLTRZCUYJAESEEU",
		"SJLIWGAGJMHYRZNGIRAXRAROIZXHGHHIAIVMGDCZKMQKBRQPERAVNSBFBJWJNGMJ",
		"TJQTCGXJUKLTKHCPQHCXFYIOQNTZBJVGBBTRCWBZOSBNBRREDYBIUKDXZMTQTPLO",
		"OAZJUGGUPZAZUKZWDKACPIVOZXIMFAIFZFCIFMOIIJFNRBIPJZFPIGLIJVZXQCHC",
		"PFIMJOQXMZVMSLLHTZLFSQUFQBHEVDQQUIWJTCJMWQEUKAJERPDABHWSGYCKBVKK",
		"ZMTITFFUNHMGMRHEDHVFDBPHUZUZSSYYNGWFKQSBMJHDZANPWYYNMBRMUOSBQPRW",
		"HZRJTEQDHCXBJEGCWJJXESZGCLKVZAAUCAVJFBLMUZZQUHIKVBHKPZQVLWIJZRZV",
		"TUYJGDEPKFTXZKYEUCLXGOSKLSJSNMCSJFRCIGDBMZAJZGHWDUUUXUTCZSCFQMLN",
		"EOKHXYNRHUDEJGTAXYAFNVMCAXDKVTYQUBEDKGREKNFEJBYEUJPDWRESINTCXJDM",
		"RBXWPSFSSNMTAHGRCLVPDEPMZXIVDCMGEVTXAPVAIKSDKEZVIZTQWEBCTPFKBFYK",
		"YFSJMDKXDRFZRSVBKBHTNCEDYSILEECWJGKYHNNJKTIQWRZFRZWIMMPLXXDMDITM",
		"EGREHYQNNTWXVSEOXSZEERQVPGOAVJEAHWYBYJMKQFAUMIBKZTWWEBEWFCTVTNUF",
		"BHFLAWGOWRSVHQBJAUZGNRGBBWWAPBBKCXICXBLRFMGEFMBJGPCPWQNMOQLTAPXV",
		"WDKFMHHNIAOPBWQLNLFMFFFUHUCUDQGPATXHUYJEXYEVODBHIWAMOVRLBVAZXZDC",
		"ICPCOEOHDIUYGTTXAYTVPXWGBSFDOKXVYIFKTNMOGEYMSYURTQFYLDLWVMOOMJDN",
		"HDJOZZPLCFDXHOMVKMOHWCYETTEMOPCVHIIZELMLQSRAFWFINNFYRYPDJBJMEOKM",
		"AXNNLSIXINOQSLPFZFJEZIDOVNFPXYMOHQSJZNMUIEGYRJRJLYOIOIQWYUOCHRQT",
		"KDIXWWHDWGRALBOROFCNNSKQUEXWVUOWRZOVETRJZMXDFWWSOGKJFIVFVPGHBUDG",
		"KWDRNMRRMDNPPUXIDFZMHCJMSCVPCLNSJAQUJJJWPYFNGVWLHRPLLQMYKQTAPFHL",
		"FBDTXCCXQYMLZZTRSGWXHJJXNEQLRIQBWUIECCDHGXTDKHBHWLZLZAMLFGMSICMI",
		"NYAEVOYIWDTBPVZSGOLZIJVFMSAXGCUGLRPXZYRWSWOBQQQLSOJDQIDSWTFRFSQE",
		"MFRPEHKEADCRMWQLIDEAKFARAGFFSPGJBHNLSKKCQSVJLIALGQQTRZMIXWUSFVMA",
		"FZRJSVSTXCEEGPRBCVRYAPTIKTTFYJSNCGTOGECQXODGLESOLOVNZZHQMJOLRWVL",
		"PCGWKOISGKHXEXLEKQNUCSHMYNEAKVFKTNQEAHTBUTLTPFMQCXUPIWYPWIQQZEGT",
		"RSPYFXEDYRULHVWWAJXMSPNFMZLBFFXCSRYOCEFPLPCCDKLAAXHGBMOWXHIQRAZP",
		"LWEGPQCOKUIFMBDKZUGWQNTXZJRRLLYJPSKRNILNCHWBABYWRSRXUELRZPWASQPN",
		"GARUOCARSAUIMONMATGODXNVOXHETRJYVPUDSDCTJNLXYEEHDRTMIVZVCTXLTERF",
		"XIIGDKYVNZGDHCECGMFJVHKDNKGBKIWRSVXNEQGIYGJAIUJFEOZATRNKBKGJWVXX",
		"UVZPUPNJMFFEIKSBNXELIJZFCGSMGTIPNVQTTZOWNTDDVCUGIWWHFLBYRRPUSIOQ",
		"TEEESJFYOSWAWQWETCWRFYJMYQWTIRIOMJNBDXLMMALHNJSYSOYQRUSARKEYHXDE",
		"PXQLBPCEIEITQVFVUEHJAHXNNNLFYAHXWDNISNNPCVQGAXTJNVDNFINNTBSKDIOS",
		"BTERVVULKPKNGQRFKKBAOJDJFJEGOZMFDBYSPROKOLGIEDEYJHLYAPFMBRRMUAEH",
		"PBXYBIXQVTWGGAIUGJYFSVJYQWJDLKQIZXZGHUFVHWMRZYKXDSWIMHZAQZUMHYSX",
		"SOMILPHDXNHSJTJRKPCGFMKPZRVSIMXKIVFUDSSCCFZQCTQBFXZBKFHMPQKVFEVP",
		"VVYIPHBBOUFENZCPXUEGEHJNYFHLRFYETEOCFVFLWVTWKQTQUHLYYWXOMTWIDXHH",
		"INVNJNFVPMJVMWJLTXDVRSJJLBLNVZPNOTLOSPRKVNWARSXJMWUANUCSECLAEKBJ",
		"YLVCRYBDEXVBCFFVMQBTHKAKNNXQRWWDVOOATWATEYSFCASYJBCXYNTSVPNUDIBY",
		"EXUXYKMSHMTTUEWHEMZKEWLMORDMJHDPBTYMXWLMLUYZJQUBQGTJIFIWIGOYPTEE",
		"IYBLHSHVMWSVOVUACYUJXPMLOAFOTMMHMKCBSVWXSWKLMLQBGZQOGHZNZKFKVOXZ",
		"CQXQNSPUBRUBTNBUGJPNDOGYHKJMOADPFBMXSWTTTWAJRKSECFWRWACMKMPGQHZY",
		"VIZXMKSYQKSQNRIWSGTWWYSOSDSDJEGGJTPGOCXCCBRRJIUSQBDETFXKWCCTBWOC"
	  ],
	  "wordsToFind": [
		"orange",
		"headset",
		"video",
		"hello", 
		"chair", 
		"hat", 
		"coffee", 
		"computer", 
		"table", 
		"tree", 
		"red", 
		"black", 
		"blue"
	  ]
	}