package com.bgt.automation.framework.pattern;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import org.apache.log4j.Logger;

public class TypingAnalyzer {

	////////////////////////////////////////////////////////////////////////
	// 한글 문자열을 초성/중성/종성으로 분리하여 출력 (UTF-8 버전)
	// v1.0
	////////////////////////////////////////////////////////////////////////


	static Logger Log = Logger.getLogger(TypingAnalyzer.class);
	public TypingAnalyzer() {
		// TODO Auto-generated constructor stub
	}

	// ㄱ      ㄲ      ㄴ      ㄷ      ㄸ      ㄹ      ㅁ      ㅂ      ㅃ      ㅅ      ㅆ      ㅇ      ㅈ      ㅉ      ㅊ      ㅋ      ㅌ      ㅍ      ㅎ
	final static char[] ChoSung   = { 0x3131, 0x3132, 0x3134, 0x3137, 0x3138, 0x3139, 0x3141, 0x3142, 0x3143, 0x3145, 0x3146, 0x3147, 0x3148, 0x3149, 0x314a, 0x314b, 0x314c, 0x314d, 0x314e };
	// ㅏ      ㅐ      ㅑ      ㅒ      ㅓ      ㅔ      ㅕ      ㅖ      ㅗ      ㅘ      ㅙ      ㅚ      ㅛ      ㅜ      ㅝ      ㅞ      ㅟ      ㅠ      ㅡ      ㅢ      ㅣ
	final static char[] JwungSung = { 0x314f, 0x3150, 0x3151, 0x3152, 0x3153, 0x3154, 0x3155, 0x3156, 0x3157, 0x3158, 0x3159, 0x315a, 0x315b, 0x315c, 0x315d, 0x315e, 0x315f, 0x3160, 0x3161, 0x3162, 0x3163 };
	//         ㄱ      ㄲ      ㄳ      ㄴ      ㄵ      ㄶ      ㄷ      ㄹ      ㄺ      ㄻ      ㄼ      ㄽ      ㄾ      ㄿ      ㅀ      ㅁ      ㅂ      ㅄ      ㅅ      ㅆ      ㅇ      ㅈ      ㅊ      ㅋ      ㅌ      ㅍ      ㅎ
	final static char[] JongSung  = { 0,      0x3131, 0x3132, 0x3133, 0x3134, 0x3135, 0x3136, 0x3137, 0x3139, 0x313a, 0x313b, 0x313c, 0x313d, 0x313e, 0x313f, 0x3140, 0x3141, 0x3142, 0x3144, 0x3145, 0x3146, 0x3147, 0x3148, 0x314a, 0x314b, 0x314c, 0x314d, 0x314e };




	public static void main(String[] args) {

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
				System.out.println(hangulToJaso(cmd));
				System.out.println("incorrect command.");
			}
		}

	} // main()

	public static String Han_UnicodeNumberToString(int[] s) throws IllegalArgumentException {
		if (s.length != 3) throw new IllegalArgumentException();
		s[0] -= 0x1100;
		s[1] -= 0x1161;
		s[2] -= 0x11a8;
		char c = (char) ((((s[0] * 588) + s[1] * 28) + s[2]) + 44032);
		return String.valueOf(c);
	}

	public static int[] Han_CharacterToIMFUnicode(char s) {
		int[] result = new int[3];
		int a = s - 44032;
		result[0] = 0x1100 + ((a / 28) / 21);
		result[1] = 0x1161 + ((a / 21) % 21);
		result[2] = 0x11a8 + (a % 28);
		return result;
	}

	
	public static String hangulToJaso(String s) { // 유니코드 한글 문자열을 입력 받음
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


}