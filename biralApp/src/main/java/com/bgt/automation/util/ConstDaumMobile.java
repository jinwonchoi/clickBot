package com.bgt.automation.util;

public enum ConstDaumMobile {

	CAFE("http://m.cafe.daum.net"),
	BLOG("http://m.blog.daum.net"),
	SHOPPING("http://m.shopping.daum.net"),
	DEFAULT("http://m.daum.net"),
	MAP("http://m.map.daum.net"),
	
	SEARCH_INPUT("q") //name
	,SEARCH_BUTTON(".btn_sch.btn_search") //css
	,SEARCH_BUTTON_ON_SEARCHED_PAGE(".btn_sch.btn_search") //css
	//스크롤관련
	,DEFAULT_BODY("body")
	,INTRO_CONTAINER("daumContent") //id
	,SEARCHED_CONTAINER("daumContent") //id
	,BLOG_LIST_CONTAINER("daumContent") //id
	,BLOG_CONTAINER("cContent") //id
	,SITE_LIST_CONTAINER("daumContent") //id
	,SITE_CONTAINER("mainFrame")//
	//메인페이지 각 섹션
	,SEARCHED_BLOG_SECTION("blogColl") //id
	,SEARCHED_KIN_SECTION("knowColl") //id
	,SEARCHED_CAFE_SECTION("cafeColl") //id
	,SEARCHED_SITE_SECTION("siteColl") //id
	,SEARCHED_WEBDOC_SECTION("webdocColl") //id
	,SEARCHED_BOARD_SECTION("boardColl") //id
	,SEARCHED_NEWS_SECTION("newsColl") //id
	,SECTION_MORE("f_link_more") //class
	//랜덤 서핑용
	,SECTION_LIST_BLOG("link_wide") //class
	,SECTION_LIST_KIN("") //css
	,SECTION_LIST_CAFE("link_wide") //css
	,SECTION_LIST_SITE("link_wide") //css
	,SECTION_LIST_WEBDOC("link_wide") //css
	,SECTION_LIST_BOARD("link_wide") //class
	,SECTION_LIST_NEWS("wrap_cont") //css
	
//	,BLOG_SECTION_MORE("blogExtMore") //id
//	,KIN_SECTION_MORE("knowledgeExtMore")
//	,CAFE_SECTION_MORE("cafeExtMore")
//	,SITE_SECTION_MORE("webExtMore")
	//블로그리스트페이징
	,SEARCHED_BLOG_FIRST("link_wide") //class
	,SEARCHED_BLOG_PAGE("paging_rwd") //class
	,SEARCHED_BLOG_PAGE_FIRST(".btn_paging.btn_fst") //css
	,SEARCHED_BLOG_PAGE_PREV(".btn_paging.btn_prev") //css
	,SEARCHED_BLOG_PAGE_NEXT(".btn_paging.btn_next") //css
	
	,BLOG_FRAME("BlogMain")//name       "if_b_%s") //if_b_15976830
	//,BLOG_LIKE_TAG("Sympathy%s")
	,BLOG_LIKE_BUTTON(".btn_empathy.uoc-button")
	,BLOG_LIKE_COUNT(".num_empathy.uoc-count")
	//,BLOG_LIKE_BUTTON("공감하기")

	//웹사이트리스트페이징
	,SEARCHED_SITE_FIRST("link_wide") //class  siteColl
	,SEARCHED_SITE_PAGE("paging_rwd")//id
	,SEARCHED_SITE_PAGE_NEXT(".btn_paging.btn_next")

	
	,POPUP_LOGIN_ID("id")  //id
	,POPUP_LOGIN_PWD("inputPwd") //id
	,POPUP_LOGIN_BUTTON("loginBtn") //id 
	;	

	private ConstDaumMobile(String str) {
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