package com.bgt.automation.framework.pattern;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;

import org.apache.log4j.Logger;

public class Hangul {

	static Logger Log = Logger.getLogger(Hangul.class);

	// ㄱ     ㄲ      ㄴ      ㄷ        ㄸ     ㄹ    
	// ㅁ     ㅂ      ㅃ      ㅅ        ㅆ     ㅇ    
	// ㅈ     ㅉ      ㅊ      ㅋ        ㅌ     ㅍ 
	// ㅎ
	final static char[] ChoSung   = { 0x3131, 0x3132, 0x3134, 0x3137, 0x3138, 0x3139,
		0x3141, 0x3142, 0x3143, 0x3145, 0x3146, 0x3147,
		0x3148, 0x3149, 0x314a, 0x314b, 0x314c, 0x314d,
		0x314e };

	final static String[] ChoSungEng = {"r", "R", "s", "e", "E", "f",
		"a", "q", "Q", "t", "T", "d",
		"w", "W", "c", "z", "x", "v", "g"};

	// ㅏ     ㅐ      ㅑ       ㅒ    ㅓ        ㅔ    
	// ㅕ     ㅖ      ㅗ       ㅘ    ㅙ        ㅚ  
	// ㅛ     ㅜ      ㅝ       ㅞ    ㅟ        ㅠ
	// ㅡ     ㅢ      ㅣ
	final static char[] JwungSung = { 0x314f, 0x3150, 0x3151, 0x3152, 0x3153, 0x3154,
		0x3155, 0x3156, 0x3157, 0x3158, 0x3159, 0x315a,
		0x315b, 0x315c, 0x315d, 0x315e, 0x315f, 0x3160,
		0x3161, 0x3162, 0x3163 };

	final static String[] JwungSungEng = {"k", "o", "i", "O", "j", "p",
		"u", "P", "h", "hk", "ho", "hl",
		"y", "n", "nj", "np", "nl", "b",
		"m", "ml", "l"};

	//         ㄱ      ㄲ       ㄳ     ㄴ     ㄵ     
	// ㄶ      ㄷ      ㄹ       ㄺ     ㄻ     ㄼ
	// ㄽ      ㄾ      ㄿ       ㅀ     ㅁ     ㅂ
	// ㅄ      ㅅ      ㅆ       ㅇ     ㅈ       ㅊ 
	// ㅋ      ㅌ      ㅍ       ㅎ
	final static char[] JongSung  = { 0,      0x3131, 0x3132, 0x3133, 0x3134, 0x3135,
		0x3136, 0x3137, 0x3139, 0x313a, 0x313b, 0x313c,
		0x313d, 0x313e, 0x313f, 0x3140, 0x3141, 0x3142,
		0x3144, 0x3145, 0x3146, 0x3147, 0x3148, 0x314a,
		0x314b, 0x314c, 0x314d, 0x314e };

	final static String[] JongSungEng = {"", "r", "R", "rt", "s", "sw",
		"sg", "e", "f", "fr", "fa", "fq",
		"ft", "fx", "fv", "fg", "a", "q",
		"qt", "t", "T", "d", "w", "c",
		"z", "x", "v", "g"};


	public static String hangulToJaso(String s) {

		int a, b, c; // 자소 버퍼: 초성/중성/종성 순
		String result = "";

		for (int i = 0; i < s.length(); i++) {
			char ch = s.charAt(i);

			if (ch >= 0xAC00 && ch <= 0xD7A3) { // "AC00:가" ~ "D7A3:힣" 에 속한 글자면 분해
				c = ch - 0xAC00;
				a = c / (21 * 28);
				c = c % (21 * 28);
				b = c / 28;
				c = c % 28;

				result = result + ChoSung[a] + JwungSung[b];
				if (c != 0) result = result + JongSung[c] ; // c가 0이 아니면, 즉 받침이 있으면
			} else {
				result = result + ch;
			}
		}
		return result;
	}

	/**
	 * 한글기준의 문자열을 입력받아서 한글의 경우에는 영타기준으로 변경한다.
	 * @param s 한글/영문/특수문자가 합쳐진 문자열
	 * @return 영타기준으로 변경된 문자열값
	 */
	public static String convertToEnglish(String s) {
		// *****************************************
		// 0xAC00 + ( (초성순서 * 21) + 중성순서 ) * 28 + 종성순서 = 한글유니코드값
		// ( (초성순서 * 21) + 중성순서 ) * 28 + 종성순서 = 순수한글코드
		// 순수한글코드 % 28 = 종성
		// ( (순수한글코드 - 종성) / 28 ) % 21 = 중성
		// ( ( ( 순수한글코드 - 종성) / 28) - 중성) ) / 21 = 초성
		// *******************************************

		int a, b, c; // 자소 버퍼: 초성/중성/종성 순
		String result = "";

		for (int i = 0; i < s.length(); i++) {
			char ch = s.charAt(i);

			if (ch >= 0xAC00 && ch <= 0xD7A3) { // "AC00:가" ~ "D7A3:힣" 에 속한 글자면 분해
				c = ch - 0xAC00;
				a = c / (21 * 28);
				c = c % (21 * 28);
				b = c / 28;
				c = c % 28;

				result = result + ChoSungEng[a] + JwungSungEng[b];
				if (c != 0) result = result + JongSungEng[c] ; // c가 0이 아니면, 즉 받침이 있으면
			} else {
				result = result + ch;
			}
		}

		return result;
	}

	/*
	 * 완성되지 않은 한글의 경우 영문 변환이 제대로 되지 않는다.
	 * 잘못된 글자인 경우에도 영문으로 변환이 가능하도록 추가적으로 처리하는 함수
	 * 글자가 초성, 중성, 종성을 구성하는 글자 배열을 루프돌면서 같은글자가 있는지
	 * 확인한 후 해당 영문으로 변환함.
	 */
	public static String convertToEnglishforSingleChar(String s) {
		String result = "";
		String temp = null;

		for (int i = 0; i < s.length(); i++) {
			char ch = s.charAt(i);

			if(ch >= 0x3131 && ch <= 0x3163) {
				temp = findChoSung(ch);
				if(temp != null) {
					result = result + temp;
				} else {
					temp = findJwungSung(ch);
					if(temp != null) {
						result = result + temp;
					} else {
						temp = findJongSung(ch);
						if(temp != null) {
							result = result + temp;
						} else {
							result = result + ch;
						}
					}
				}
			} else {
				result = result + ch;
			}

		}

		return result;
	}

	public static List<String> convertToKeys(String s) {
		String result = "";
		String temp = null;
		List<String> resultList = new ArrayList<String>();

		for (int i = 0; i < s.length(); i++) {
			char ch = s.charAt(i);

			if(ch >= 0x3131 && ch <= 0x3163) {
				temp = findChoSung(ch);
				if(temp != null) {
					//result = result + temp;
					resultList.add(temp);
				} else {
					temp = findJwungSung(ch);
					if(temp != null) {
						result = result + temp;
						resultList.add(temp);
					} else {
						temp = findJongSung(ch);
						if(temp != null) {
							result = result + temp;
							resultList.add(temp);
						} else {
							result = result + ch;
							resultList.add(String.valueOf(ch));
						}
					}
				}
			} else {
				result = result + ch;
				resultList.add(String.valueOf(ch));
			}

		}

		return resultList;
	}
	
	public static List<Character> convertToKeys2(String s) {
		String result = "";
		String temp = null;
		List<Character> resultList = new ArrayList<Character>();

		int a, b, c; // 자소 버퍼: 초성/중성/종성 순

		for (int i = 0; i < s.length(); i++) {
			char ch = s.charAt(i);

			if (ch >= 0xAC00 && ch <= 0xD7A3) { // "AC00:가" ~ "D7A3:힣" 에 속한 글자면 분해
				c = ch - 0xAC00;
				a = c / (21 * 28);
				c = c % (21 * 28);
				b = c / 28;
				c = c % 28;

				result = result + ChoSung[a] + JwungSung[b];
				resultList.add(ChoSung[a]);
				resultList.add(JwungSung[b]);
				
				if (c != 0) {
					result = result + JongSung[c] ; // c가 0이 아니면, 즉 받침이 있으면
					resultList.add(JongSung[c]);

				}
			} else {
				result = result + ch;
				resultList.add(ch);
			}
		}
		return resultList;
	}
	
	private static String findChoSung(char c) {
		String result = null;
		for(int i=0; i < ChoSung.length; i++) {
			if(ChoSung[i] == c) {
				result = ChoSungEng[i];
				break;
			}
		}
		return result;
	}

	private static String findJwungSung(char c) {
		String result = null;
		for(int i=0; i < JwungSung.length; i++) {
			if(JwungSung[i] == c) {
				result = JwungSungEng[i];
				break;
			}
		}
		return result;
	}

	private static String findJongSung(char c) {
		String result = null;
		for(int i=0; i < JongSung.length; i++) {
			if(JongSung[i] == c) {
				result = JongSungEng[i];
				break;
			}
		}
		return result;
	}
	
	public static void main(String[] args) {
		Hangul hangule = new Hangul();
		
		while (true) {
			System.out.println("Biral application scheduler is running.");
			System.out.print("To stop it, enter 'quit':");
			BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
			
			String cmd;
			try {
				cmd = br.readLine();
			} catch (IOException e) {
				Log.error("read error",e);
				cmd = null;
			}
			
			if (cmd!=null && "quit".equals(cmd.toLowerCase())) {
				System.out.println("process stopped.");
				System.exit(0);
			} else {
				System.out.println(hangule.hangulToJaso(cmd));
				System.out.println(hangule.convertToEnglish(cmd));
				System.out.println(hangule.convertToEnglishforSingleChar(cmd));
				List<String> resultList = hangule.convertToKeys(cmd);
				String result = "";
				for (String str : resultList) {
					result += str;
				}
				System.out.println(result);
				System.out.println("incorrect command.");
			}
		}
	}
}
