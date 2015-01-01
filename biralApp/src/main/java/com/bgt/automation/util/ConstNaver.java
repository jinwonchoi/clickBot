package com.bgt.automation.util;

import org.openqa.selenium.By;

public enum ConstNaver {

	CAFE("http://cafe.naver.com"),
	BLOG("http://blog.naver.com"),
	KIN("http://kin.naver.com"),
	SHOPPING("http://shopping.naver.com"),
	DEFAULT("http://www.naver.com"),
	MAP("http://map.naver.com"),
	
	SEARCH_INPUT("query")
	,SEARCH_BUTTON("search_btn")
	,SEARCH_BUTTON_ON_SEARCHED_PAGE(".bt_search.spim")
	//스크롤관련
	,DEFAULT_BODY("body")
	,INTRO_CONTAINER("container")
	,SEARCHED_CONTAINER("container")
	,BLOG_LIST_CONTAINER("container")
	,BLOG_CONTAINER("mainFrame")
	,SITE_LIST_CONTAINER("container")
	,SITE_CONTAINER("mainFrame")
	//메인페이지 각 섹션
	,SEARCHED_BLOG_SECTION(".blog.section._blogBase")
	,SEARCHED_KIN_SECTION(".kinn.section._kinBase")
	,SEARCHED_CAFE_SECTION("cafe.section._cafeBase")
	,SEARCHED_SITE_SECTION(".nsite.section._nsiteBase")
	,SEARCHED_WEBDOC_SECTION(".webdoc.section") //id
	,SEARCHED_BOARD_SECTION("") //id
	,SEARCHED_NEWS_SECTION(".news.section") //id
	,SECTION_MORE("section_more")
	,SEARCHED_MENU_MORE("_nx_lnb_more") //id
	,SEARCHED_MENU_MORE_CLICK("lnb_more") //class
	,SEARCHED_WHERE_SITE("where=site") //linkpart
	
	//랜덤 서핑용
	,SECTION_LIST_BLOG(".sh_blog_title._sp_each_url._sp_each_title") //class
	,SECTION_LIST_KIN("") //css
	,SECTION_LIST_CAFE("sh_cafe_title") //css
	,SECTION_LIST_SITE("") //css
	,SECTION_LIST_WEBDOC(".link.sh_web_title.sh_web_link") //css
	,SECTION_LIST_BOARD("") //class
	,SECTION_LIST_NEWS("._sp_each_url._sp_each_title") //css
	
	//블로그리스트페이징
	,SEARCHED_BLOG_FIRST(".sh_blog_title._sp_each_url._sp_each_title")
	,SEARCHED_BLOG_PAGE("paging")
	,SEARCHED_BLOG_PAGE_NEXT("next")
	,BLOG_LIKE_TAG("Sympathy%s")
	//,BLOG_LIKE_BUTTON(".btn_ept.btn_atype._sympathy._rosRestrict._param(%s|0|1)._returnFalse")
	,BLOG_LIKE_BUTTON("공감하기")

	//웹사이트리스트페이징
	,SEARCHED_SITE_FIRST("url")
	,SEARCHED_SITE_PAGE("paging")
	,SEARCHED_SITE_PAGE_NEXT("next")

	
	,POPUP_LOGIN_ID("id")
	,POPUP_LOGIN_PWD("pw")
	,POPUP_LOGIN_BUTTON("int_jogin")
	;	

	private ConstNaver(String str) {
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