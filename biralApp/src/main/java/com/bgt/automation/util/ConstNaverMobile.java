package com.bgt.automation.util;

import org.openqa.selenium.By;

public enum ConstNaverMobile {

	CAFE("http://m.cafe.naver.com"),
	BLOG("http://m.blog.naver.com"),
	//KIN("http://kin.naver.com"),
	SHOPPING("http://m.shopping.naver.com"),
	DEFAULT("http://m.naver.com"),
	MAP("http://m.map.naver.com"),
	
	SEARCH_INPUT("query")  //name
	,SEARCH_BUTTON("sch_ext_btn")  //id
	,SEARCH_BUTTON_ON_SEARCHED_PAGE("nx_search_btn")//id
	//스크롤관련
	,DEFAULT_BODY("body")
	,INTRO_CONTAINER("body")
	,SEARCHED_CONTAINER("body")
	,BLOG_LIST_CONTAINER("body")
	,BLOG_CONTAINER("body")
	,SITE_LIST_CONTAINER("body")
	,SITE_CONTAINER("body")
	
	
	//메인페이지 섹션
	,SEARCHED_SECTION(".li1.uni.ntotal") //class

	//메인페이지  섹션메뉴
	,SEARCHED_SCH_TAB("_sch_tab") //id
	,SEARCHED_LST_SCH("lst_sch") //class
	,SEARCHED_BLOG_SECTION("where=m_blog")  //link part   : header > sch_tab > lst_sch > where=m_blog
	,SEARCHED_KIN_SECTION("where=m_kin") //link part   : header > sch_tab > lst_sch > where=m_kin
	,SEARCHED_CAFE_SECTION("where=m_cafe") //link part   : header > sch_tab > lst_sch > where=m_cafe
	,SEARCHED_SITE_SECTION("where=m_site") //link part   : header > sch_tab > lst_sch > where=m_site
	,LINK_MORE_PART("where=m") //link
	,SEARCHED_MAP_SECTION("cs_region") //class
	
	
		//메인페이지 각 섹션
//	,SEARCHED_BLOG_SECTION(".blog.section._blogBase")
//	,SEARCHED_KIN_SECTION(".kinn.section._kinBase")
//	,SEARCHED_CAFE_SECTION("cafe.section._cafeBase")
//	,SEARCHED_SITE_SECTION(".nsite.section._nsiteBase")
//	,SEARCHED_WEBDOC_SECTION(".webdoc.section") //id
//	,SEARCHED_BOARD_SECTION("") //id
//	,SEARCHED_NEWS_SECTION(".news.section") //id
//	,SECTION_MORE("section_more")
	//랜덤 서핑용
	//lk _sp_each_url
	//_sp_each_url
	//_sp_each_url _sp_each_title
	
//	,SECTION_LIST_BLOG(".sh_blog_title._sp_each_url._sp_each_title") //class
//	,SECTION_LIST_KIN("") //css
//	,SECTION_LIST_CAFE("sh_cafe_title") //css
	,SECTION_LIST_SITE("_sp_each_url") //css
//	,SECTION_LIST_WEBDOC(".link.sh_web_title.sh_web_link") //css
//	,SECTION_LIST_BOARD("") //class
	,SECTION_LIST_NEWS("._sp_each_url._sp_each_title") //css

	
	//블로그리스트페이징
	,SEARCHED_BLOG_FIRST(".li1.uni") //css
	//,SEARCHED_BLOG_PAGE("pg2b") //class
	
	,BLOG_LIKE_BUTTON(".btn_sympathy1._btn_sympathy._returnFalse ")
	//,BLOG_LIKE_BUTTON(".btn_ept.btn_atype._sympathy._rosRestrict._param(%s|0|1)._returnFalse")
	//,BLOG_LIKE_BUTTON("공감하기")
	,BLOG_LIKE_COUNT("sympathyCount") //id
	
	
	//웹사이트리스트페이징
	,SEARCHED_SITE_FIRST("surlnk ") //class --> 첫번째 tagName("a")

	,SEARCHED_PAGE_PREV_BTN("pg2b_btn")  //class
	,SEARCHED_PAGE_PREV_BTN_CLS("pg2b_prev")//class
	,SEARCHED_PAGE_NEXT_BTN("pg2b_btn")//class
	,SEARCHED_PAGE_NEXT_BTN_CLS("pg2b_next")//class
	,SEARCHED_PAGE_IDX("pg2b_pg")//class

	
	,POPUP_LOGIN_ID("id")
	,POPUP_LOGIN_PWD("pw")
	,POPUP_LOGIN_BUTTON("int_jogin")
	;	

	private ConstNaverMobile(String str) {
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