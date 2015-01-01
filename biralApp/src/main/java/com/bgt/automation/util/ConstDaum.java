package com.bgt.automation.util;

public enum ConstDaum {

	CAFE("http://cafe.daum.net"),
	BLOG("http://blog.daum.net"),
	SHOPPING("http://shopping.daum.net"),
	DEFAULT("http://www.daum.net"),
	MAP("http://map.daum.net"),
	
	SEARCH_INPUT("q") //id
	,SEARCH_BUTTON("searchSubmit") //id
	,SEARCH_BUTTON_ON_SEARCHED_PAGE("daumBtnSearch") //id
	//스크롤관련
	,DEFAULT_BODY("body")
	,INTRO_CONTAINER("daumContent") //id
	,SEARCHED_CONTAINER("daumContent") //id
	,BLOG_LIST_CONTAINER("daumWrap") //id
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
	
	,SEARCHED_MENU_MORE_CLICK("gnbToggleBtn")//id

	,SEARCHED_MENU_MORE_SITE(".tab.tab_site") //class
	//랜덤 서핑용
	,SECTION_LIST_BLOG("f_link_bu") //class
	,SECTION_LIST_KIN("") //css
	,SECTION_LIST_CAFE(".f_link_bu.f_l") //css
	,SECTION_LIST_SITE(".f_link_bu.f_l") //css
	,SECTION_LIST_WEBDOC(".f_link_bu.f_l") //css
	,SECTION_LIST_BOARD("f_link_bu") //class
	,SECTION_LIST_NEWS(".f_link_bu.f_l") //css
	
	,SECTION_MORE("section_more")
	,BLOG_SECTION_MORE("blogExtMore") //id
	,KIN_SECTION_MORE("knowledgeExtMore")
	,CAFE_SECTION_MORE("cafeExtMore")
	,SITE_SECTION_MORE("siteExtMore")
	,WEBDOC_SECTION_MORE("webExtMore")
	//블로그리스트페이징
	,SEARCHED_BLOG_FIRST("f_link_bu") //class
	,SEARCHED_BLOG_PAGE("paging_inner") //class
	,SEARCHED_BLOG_PAGE_PREV(".ico_comm1.btn_page.btn_prev") //css
	,SEARCHED_BLOG_PAGE_NEXT(".ico_comm1.btn_page.btn_next") //css
	,SEARCH_BLOG_OPTION("sourceOption") //id  tistory, daum, naver
	,SEARCH_BLOG_OPTION_DAUM("SA=daumsec") //linkText 다음
	,SEARCH_BLOG_OPTION_TISTORY("SA=tistory") //linkText 티스토리
	
	,BLOG_FRAME("BlogMain")//name       "if_b_%s") //if_b_15976830
	//,BLOG_LIKE_TAG("Sympathy%s")
	,BLOG_LIKE_BUTTON(".img_empathy.btn_empathy.uoc-button")
	,BLOG_LIKE_COUNT(".num_empathy.uoc-count")
	//,BLOG_LIKE_BUTTON("공감하기")

	//웹사이트리스트페이징
	,SEARCHED_SITE_FIRST(".f_link_bu.f_l")
	,SEARCHED_SITE_PAGE("paging_inner")
	,SEARCHED_SITE_PAGE_NEXT(".ico_comm1.btn_page.btn_next")

	
	,POPUP_LOGIN_ID("id")  //id
	,POPUP_LOGIN_PWD("inputPwd") //id
	,POPUP_LOGIN_BUTTON("loginBtn") //id 
	;	

	private ConstDaum(String str) {
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