package com.bgt.automation.util;

public enum CommonConst {
	
	URL_NAVER_COM("http://www.naver.com"),
	URL_NAVER_CAFE("http://cafe.naver.com"),
	SERVICE_NAVER("N"),
	SERVICE_DAUM("D"),
	BLOG_DAUM("blog.daum.net"),
	BLOG_TISTORY("tistory.com"),
	BLOG_NAVER("blog.naver.com"),
	SERVICE_GOOGLE("google"),
	DUMMY_TIME(60),
	TASK_LIST_DELIMITER(":"),
	DEVICE_MOBILE("M"),
	DEVICE_WEB("W"),
	MAX_TASK_ACTIVITY_PER_MIN(60),
	MAX_HIT_ACTIVITY_PER_MIN(25),
	SITE_NAVER("N"),
	SITE_DAUM("D"),
	 TASK_KEYWORD("K"),//'keyword:K, topsite:T, blog:B',
	TASK_TOPSITE("T"),
	TASK_BLOG("B"),
	TASK_AUTOCOMP("A"),
	TASK_ROBOT("R"),
	
	BROWSER_IEXPLORER("I"),
	BROWSER_CHROME("C"),
	BROWSER_FIREFOX("F"),
	BROWSER_SAFARI("S"),
	
	WEB_DEFAULT_WAITING_SEC(20),
	
	TASK_ID_WEB_NAVER_00(88100),
	TASK_ID_WEB_NAVER_01(88101),
	TASK_ID_WEB_NAVER_02(88102),
	TASK_ID_WEB_NAVER_03(88103),
	TASK_ID_WEB_NAVER_04(88104),

	TASK_ID_MOBILE_NAVER_00(88200),
	TASK_ID_MOBILE_NAVER_01(88201),
	TASK_ID_MOBILE_NAVER_02(88202),
	TASK_ID_MOBILE_NAVER_03(88203),
	TASK_ID_MOBILE_NAVER_04(88204),
	
	TASK_ID_WEB_DAUM_00(88300),
	TASK_ID_WEB_DAUM_01(88301),
	TASK_ID_WEB_DAUM_02(88302),
	TASK_ID_WEB_DAUM_03(88303),
	TASK_ID_WEB_DAUM_04(88304),

	TASK_ID_MOBILE_DAUM_00(88400),
	TASK_ID_MOBILE_DAUM_01(88401),
	TASK_ID_MOBILE_DAUM_02(88402),
	TASK_ID_MOBILE_DAUM_03(88403),
	TASK_ID_MOBILE_DAUM_04(88404),
	
	
	 ;
	
	
	private CommonConst(String str) {
		value = str;
	}
	
	private CommonConst(int val) {
		intValue = val;
	}
	
	private int intValue;
	private String value;

	public boolean equalValues(String str) {
		return (str == null)? false:value.equals(str);
	}
	
	public String get() {
		return value;
	}
	
	public int val() {
		return intValue;
	}

}
