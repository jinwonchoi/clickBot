package com.bgt.automation.util;

public enum ConstGoogle {

	YOUTUBE("http://www.youtube.com"),
	DEFAULT("https://www.google.com"),
	NEW("https://www.daum.com");

	private ConstGoogle(String str) {
		value = str;
	}

	private String value;

	public boolean equalValues(String str) {
		return (str == null)? false:value.equals(str);
	}

	public String get() {
		return value;
	}

}

/*
카페     :http://cafe.naver.com
블로그  :http://blog.naver.com
지식iN   :http://kin.naver.com
쇼핑     :http://shopping.naver.com
사이트  :http://www.google.com
지도     :http://map.naver.com
웹문서  :

2. 다음
카페     :http://cafe.daum.com
블로그  :http://blog.daum.com
지식iN   :http://kin.daum.com
쇼핑     :http://shopping.daum.com
사이트  :http://www.google.com
지도     :http://map.daum.com
웹문서  :


3. 유투브: http://www.youtube.com

4. 구글:    https://news.google.com

*/