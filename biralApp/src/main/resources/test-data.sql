INSERT INTO person (name) VALUES ('person-1')
INSERT INTO person (name) VALUES ('person-2')
INSERT INTO person (name) VALUES ('person-3')
INSERT INTO person (name) VALUES ('person-4')
INSERT INTO person (name) VALUES ('person-5')
INSERT INTO person (name) VALUES ('person-6')


insert into biraldb.ipinfo( ip_address,browser_type,mobile_yn,use_type,login_id_naver,login_pwd_naver,login_id_daum,login_pwd_daum )
values( '192.168.0.1' /*ip_address*/,
'I' /*browser_type 'ie:I, chrome:C, firefox:F, safari:S'*/,
'W'  /*mobile_yn*/,
'N' /*use_type 'normal:N, login:L'*/,
'' /*login_id_naver,,,*/,
'' /*login_pwd_naver*/,
'' /*login_id_daum*/,
''/*login_pwd_daum*/
);
	
insert into biraldb.ipinfo( ip_address,browser_type,device_type,use_type,login_id_naver,login_pwd_naver,login_id_daum,login_pwd_daum )
values( '192.168.0.2','I','W','N','naverid01','naverpwd01','daumlogin01','daumpwd01');
insert into biraldb.ipinfo( ip_address,browser_type,device_type,use_type,login_id_naver,login_pwd_naver,login_id_daum,login_pwd_daum )
values( '192.168.0.3','C','W','N','naverid02','naverpwd02','daumlogin02','daumpwd02');
insert into biraldb.ipinfo( ip_address,browser_type,device_type,use_type,login_id_naver,login_pwd_naver,login_id_daum,login_pwd_daum )
values( '192.168.0.4','C','W','L','naverid03','naverpwd03','daumlogin03','daumpwd03');
insert into biraldb.ipinfo( ip_address,browser_type,device_type,use_type,login_id_naver,login_pwd_naver,login_id_daum,login_pwd_daum )
values( '192.168.0.5','F','M','L','naverid04','naverpwd04','daumlogin04','daumpwd04');
insert into biraldb.ipinfo( ip_address,browser_type,device_type,use_type,login_id_naver,login_pwd_naver,login_id_daum,login_pwd_daum )
values( '192.168.0.6','F','M','L','naverid05','naverpwd05','daumlogin05','daumpwd05');
insert into biraldb.ipinfo( ip_address,browser_type,device_type,use_type,login_id_naver,login_pwd_naver,login_id_daum,login_pwd_daum )
values( '192.168.0.7','F','M','L','naverid06','naverpwd06','daumlogin06','daumpwd06');


insert into biraldb.loginid( login_id,passwd,userid,id_type,create_date,update_date )
values( 'admin' /*login_id*/, 
'admin' /*passwd*/ ,
'userid02' /*userid*/,
'N' /*id_type naver:N, daum:D,google:G, youtube:Y*/,
'20141025122510' /*create_date*/,
'20141025122510'/*update_date*/)

/*topsite mobile TOPSITEM, topsite web TOPSITEW, 
   keyword mobile KEYWORDM, keyword web KEYWORDW, 
   blog mobile BLOGM, blog web BLOGW*/
INSERT INTO biraldb.product
  (product_id, product_name, price, device_type, site_type, create_date, update_date)
VALUES
  ('AUTODM', '키워드자동완성 다음 모바일사이트', 1000, 'M', 'D', '20141122114552', '20141122114552');

INSERT INTO biraldb.product
  (product_id, product_name, price, device_type, site_type, create_date, update_date)
VALUES
  ('AUTODW', '키워드자동완성 다음 웹사이트', 1000, 'W', 'D', '20141122114538', '20141122114538');

INSERT INTO biraldb.product
  (product_id, product_name, price, device_type, site_type, create_date, update_date)
VALUES
  ('AUTONM', '키워드자동완성 네이버 모바일사이트', 1000, 'M', 'N', '20141122114512', '20141122114512');

INSERT INTO biraldb.product
  (product_id, product_name, price, device_type, site_type, create_date, update_date)
VALUES
  ('AUTONW', '키워드자동완성 네이버 웹사이트', 0, 'W', 'N', '20141122114455', '20141122114455');

INSERT INTO biraldb.product
  (product_id, product_name, price, device_type, site_type, create_date, update_date)
VALUES
  ('BLOGDM', '블로그 순위 올리기 다음 모바일', 1000, 'M', 'D', '20141122112646', '20141122112646');

INSERT INTO biraldb.product
  (product_id, product_name, price, device_type, site_type, create_date, update_date)
VALUES
  ('BLOGNM', '블로그 순위 올리기 네이버 모바일', 1000, 'M', 'N', '20141122112610', '20141122112610');

INSERT INTO biraldb.product
  (product_id, product_name, price, device_type, site_type, create_date, update_date)
VALUES
  ('BLOGDW', '블로그 순위 올리기 다음 웹', 1000, 'W', 'D', '20141122112716', '20141122112716');

INSERT INTO biraldb.product
  (product_id, product_name, price, device_type, site_type, create_date, update_date)
VALUES
  ('BLOGNW', '블로그 순위 올리기 네이버 웹', 3000, 'W', 'N', '20141122114146', '20141122114146');

INSERT INTO biraldb.product
  (product_id, product_name, price, device_type, site_type, create_date, update_date)
VALUES
  ('KEYWDM', '연관키워드 다음 모바일사이트', 1000, 'M', 'D', '20141122114339', '20141122114339');

INSERT INTO biraldb.product
  (product_id, product_name, price, device_type, site_type, create_date, update_date)
VALUES
  ('KEYWNM', '연관키워드 네이버 모바일사이트', 1000, 'M', 'N', '20141122114326', '20141122114326');

INSERT INTO biraldb.product
  (product_id, product_name, price, device_type, site_type, create_date, update_date)
VALUES
  ('KEYWDW', '연관키워드 다음 웹사이트', 1000, 'W', 'D', '20141122114300', '20141122114300');

INSERT INTO biraldb.product
  (product_id, product_name, price, device_type, site_type, create_date, update_date)
VALUES
  ('KEYWNW', '연관키워드 네이버 웹사이트', 1000, 'W', 'N', '20141122114239', '20141122114239');

INSERT INTO biraldb.product
  (product_id, product_name, price, device_type, site_type, create_date, update_date)
VALUES
  ('SITEDM', '순위 올리기 다음 모바일사이트', 1000, 'M', 'D', '20141122112831', '20141122112831');

INSERT INTO biraldb.product
  (product_id, product_name, price, device_type, site_type, create_date, update_date)
VALUES
  ('SITENM', '순위 올리기 네이버 모바일사이트', 1000, 'W', 'N', '20141122113053', '20141122113053');

INSERT INTO biraldb.product
  (product_id, product_name, price, device_type, site_type, create_date, update_date)
VALUES
  ('SITEDW', '순위 올리기 다음 웹사이트', 1000, 'W', 'D', '20141122112744', '20141122112744');

INSERT INTO biraldb.product
  (product_id, product_name, price, device_type, site_type, create_date, update_date)
VALUES
  ('SITENW', '순위 올리기 네이버 웹사이트', 1000, 'W', 'N', '20141122112809', '20141122113110');




insert into biraldb.purchase( purchase_id,user_id,product_id,device_type,site_type,purchase_date,purchase_amount,purchase_type,used_flag,create_date,update_date )
values( 
1/*purchase_id,*/, 
'customer01'/*user_id,*/, 
'BLOGW'/*product_id,*/, 
'W',
'N',
'20141025'/*purchase_date,*/, 
500/*purchase_amount,*/, 
'C'/*purchase_type 'card:C, bank:B'*/, 
'N'/*used_flag 'not used:N, used:Y'*/,
'20141025122510' /*create_date*/,
'20141025122510'/*update_date*/)

insert into biraldb.server_info( server_id,server_name,real_ip_address, run_status )
values('001' , 'server01',  '192.168.0.1', 'S');
insert into biraldb.server_info( server_id,server_name,real_ip_address, run_status )
values('002' , 'server02',  '192.168.1.1', 'S');
insert into biraldb.server_info( server_id,server_name,real_ip_address, run_status )
values('003' , 'server03',  '192.168.2.1', 'S');
insert into biraldb.server_info( server_id,server_name,real_ip_address, run_status )
values('004' , 'server04',  '192.168.3.1', 'S');
insert into biraldb.server_info( server_id,server_name,real_ip_address, run_status )
values('005' , 'server05',  '192.168.4.1', 'S');
insert into biraldb.server_info( server_id,server_name,real_ip_address, run_status )
values('006' , 'server06',  '192.168.5.1', 'S');


insert into biraldb.task( task_id,purchase_id,device_type,site_type,start_date,end_date,task_type,target_url,target_name,page_id,keyword1,keyword2,keyword3,keyword4,daily_hit_count,hour00_hit_count,hour01_hit_count,hour02_hit_count,hour03_hit_count,hour04_hit_count,hour05_hit_count,hour06_hit_count,hour07_hit_count,hour08_hit_count,hour09_hit_count,hour10_hit_count,hour11_hit_count,hour12_hit_count,hour13_hit_count,hour14_hit_count,hour15_hit_count,hour16_hit_count,hour17_hit_count,hour18_hit_count,hour19_hit_count,hour20_hit_count,hour21_hit_count,hour22_hit_count,hour23_hit_count,create_date,update_date )
values(11/*task_id*/,
11/*purchase_id*/,
'W',
'N',
'20141025'/*start_date*/,
'20141125'/*end_date*/,
'B'/*task_type*/,
'http://blog.naver.com/exo___exo/220150309696'/*target_url*/,
'[신의탑 포지션]전장의 무법자, 낚시꾼'/*target_name*/,
'220150309696','신의탑'/*keyword1*/,
''/*keyword2*/,
''/*keyword3*/,
''/*keyword4*/,
720/*daily_hit_count*/,
1/*hour01_hit_count*/,
3/*hour02_hit_count*/,
5/*hour03_hit_count*/,
7/*hour04_hit_count*/,
2/*hour05_hit_count*/,
1/*hour06_hit_count*/,
8/*hour07_hit_count*/,
2/*hour08_hit_count*/,
3/*hour09_hit_count*/,
30/*hour10_hit_count*/,
10/*hour11_hit_count*/,
0/*hour12_hit_count*/,
2/*hour13_hit_count*/,
1/*hour14_hit_count*/,
5/*hour15_hit_count*/,
3/*hour16_hit_count*/,
6/*hour17_hit_count*/,
8/*hour18_hit_count*/,
7/*hour19_hit_count*/,
2/*hour20_hit_count*/,
3/*hour21_hit_count*/,
4/*hour22_hit_count*/,
0/*hour23_hit_count*/,
3/*hour24_hit_count*/,
'20141025122510' /*create_date*/,
'20141025122510'/*update_date*/);

insert into biraldb.task( task_id,purchase_id,device_type,site_type,start_date,end_date,task_type,target_url,target_name,page_id, keyword1,keyword2,keyword3,keyword4,daily_hit_count,hour00_hit_count,hour01_hit_count,hour02_hit_count,hour03_hit_count,hour04_hit_count,hour05_hit_count,hour06_hit_count,hour07_hit_count,hour08_hit_count,hour09_hit_count,hour10_hit_count,hour11_hit_count,hour12_hit_count,hour13_hit_count,hour14_hit_count,hour15_hit_count,hour16_hit_count,hour17_hit_count,hour18_hit_count,hour19_hit_count,hour20_hit_count,hour21_hit_count,hour22_hit_count,hour23_hit_count,create_date,update_date )
                         values(12,12,'W','N','20141025','20141125','B',
                         'http://lov2kang.blog.me/220166550234'/*target_url*/,
						'갤럭시노트4 & 아이폰6플러스 구경하고 왔죵~~'/*target_name*/,
'220166550234','아이폰6 플러스'/*keyword1*/,''/*keyword2*/,''/*keyword3*/,''/*keyword4*/,
84,0,6,1,4,2,2,7,7,0,1,2,2,7,5,5,7,6,0,1,5,2,5,3,4,
'20141025122510' /*create_date*/,'20141025122510'/*update_date*/);
insert into biraldb.task( task_id,purchase_id,device_type,site_type,start_date,end_date,task_type,target_url,target_name,page_id, keyword1,keyword2,keyword3,keyword4,daily_hit_count,hour00_hit_count,hour01_hit_count,hour02_hit_count,hour03_hit_count,hour04_hit_count,hour05_hit_count,hour06_hit_count,hour07_hit_count,hour08_hit_count,hour09_hit_count,hour10_hit_count,hour11_hit_count,hour12_hit_count,hour13_hit_count,hour14_hit_count,hour15_hit_count,hour16_hit_count,hour17_hit_count,hour18_hit_count,hour19_hit_count,hour20_hit_count,hour21_hit_count,hour22_hit_count,hour23_hit_count,create_date,update_date )
                         values(13,13,'W','N','20141025','20141125','B',
                         'http://blog.naver.com/jacky0315?Redirect=Log&logNo=220169426460'/*target_url*/,
						'천사의 손길 - 동물농장(준팔이/배다해)'/*target_name*/,
'220169426460','동물농장 배다해'/*keyword1*/,''/*keyword2*/,''/*keyword3*/,''/*keyword4*/,
77,5,5,4,3,0,3,7,5,6,3,1,7,3,1,0,4,1,2,1,7,7,1,5,1,
'20141025122510' /*create_date*/,'20141025122510'/*update_date*/);
insert into biraldb.task( task_id,purchase_id,device_type,site_type,start_date,end_date,task_type,target_url,target_name,page_id, keyword1,keyword2,keyword3,keyword4,daily_hit_count,hour00_hit_count,hour01_hit_count,hour02_hit_count,hour03_hit_count,hour04_hit_count,hour05_hit_count,hour06_hit_count,hour07_hit_count,hour08_hit_count,hour09_hit_count,hour10_hit_count,hour11_hit_count,hour12_hit_count,hour13_hit_count,hour14_hit_count,hour15_hit_count,hour16_hit_count,hour17_hit_count,hour18_hit_count,hour19_hit_count,hour20_hit_count,hour21_hit_count,hour22_hit_count,hour23_hit_count,create_date,update_date )
                         values(14,14,'M','N','20141025','20141125','B',
                         'http://blog.naver.com/stormchelsea/220169197994'/*target_url*/,
						'맨시티vs맨유 프리뷰'/*target_name*/,
'220169197994' ,'맨유 맨시티'/*keyword1*/,''/*keyword2*/,''/*keyword3*/,''/*keyword4*/,
86,0,6,4,6,2,1,1,2,7,6,6,3,2,5,0,6,5,6,4,4,0,3,5,2,
'20141025122510' /*create_date*/,'20141025122510'/*update_date*/);
insert into biraldb.task( task_id,purchase_id,device_type,site_type,start_date,end_date,task_type,target_url,target_name,page_id, keyword1,keyword2,keyword3,keyword4,daily_hit_count,hour00_hit_count,hour01_hit_count,hour02_hit_count,hour03_hit_count,hour04_hit_count,hour05_hit_count,hour06_hit_count,hour07_hit_count,hour08_hit_count,hour09_hit_count,hour10_hit_count,hour11_hit_count,hour12_hit_count,hour13_hit_count,hour14_hit_count,hour15_hit_count,hour16_hit_count,hour17_hit_count,hour18_hit_count,hour19_hit_count,hour20_hit_count,hour21_hit_count,hour22_hit_count,hour23_hit_count,create_date,update_date )
                         values(15,15,'M','N','20141025','20141125','K',
                         'http://blog.naver.com/cupitter/220163960495'/*target_url*/,
						'[형영당 일기] 햇살 좋은 날~ 이재윤, 임주환, 이원근, 손은서, 안내상과 함께한 <형영당 일기> 대본리딩! '/*target_name*/,
'220163960495','형영당일기'/*keyword1*/,'손은서'/*keyword2*/,''/*keyword3*/,''/*keyword4*/,
82,0,2,4,7,2,2,6,2,7,4,1,1,6,7,7,6,3,3,1,4,1,2,2,2,
'20141025122510' /*create_date*/,'20141025122510'/*update_date*/);
insert into biraldb.task( task_id,purchase_id,device_type,site_type,start_date,end_date,task_type,target_url,target_name,page_id, keyword1,keyword2,keyword3,keyword4,daily_hit_count,hour00_hit_count,hour01_hit_count,hour02_hit_count,hour03_hit_count,hour04_hit_count,hour05_hit_count,hour06_hit_count,hour07_hit_count,hour08_hit_count,hour09_hit_count,hour10_hit_count,hour11_hit_count,hour12_hit_count,hour13_hit_count,hour14_hit_count,hour15_hit_count,hour16_hit_count,hour17_hit_count,hour18_hit_count,hour19_hit_count,hour20_hit_count,hour21_hit_count,hour22_hit_count,hour23_hit_count,create_date,update_date )
                         values(16,16,'W','N','20141025','20141125','K',
                         'http://t_ot93.blog.me/220163249206'/*target_url*/,
						'김우빈:: 연애세포 촬영 현장 스틸컷'/*target_name*/,
'220163249206','연애세포'/*keyword1*/,'모솔남의 걸그룹 스타 꼬시기'/*keyword2*/,''/*keyword3*/,''/*keyword4*/,
89,7,7,4,6,2,1,5,6,4,6,1,4,1,4,7,2,6,2,2,0,7,6,5,1,
'20141025122510' /*create_date*/,'20141025122510'/*update_date*/);
insert into biraldb.task( task_id,purchase_id,device_type,site_type,start_date,end_date,task_type,target_url,target_name,page_id, keyword1,keyword2,keyword3,keyword4,daily_hit_count,hour00_hit_count,hour01_hit_count,hour02_hit_count,hour03_hit_count,hour04_hit_count,hour05_hit_count,hour06_hit_count,hour07_hit_count,hour08_hit_count,hour09_hit_count,hour10_hit_count,hour11_hit_count,hour12_hit_count,hour13_hit_count,hour14_hit_count,hour15_hit_count,hour16_hit_count,hour17_hit_count,hour18_hit_count,hour19_hit_count,hour20_hit_count,hour21_hit_count,hour22_hit_count,hour23_hit_count,create_date,update_date )
                         values(17,17,'W','D','20141025','20141125','B',
                         'http://tvshowdictionary.tistory.com/3368'/*target_url*/,
						'이효리 제주도집 관광객 초인종 고충 토로! 이효리 제주집 위치 어디? 소길댁 블로그, 이효리 제주도 별장 사진, 이효리 집내부 사진 보기!'/*target_name*/,
'3368','이효리 집'/*keyword1*/,''/*keyword2*/,''/*keyword3*/,''/*keyword4*/,
69,5,4,2,1,0,3,4,7,5,2,4,1,0,2,0,3,7,4,6,1,5,1,7,0,
'20141025122510' /*create_date*/,'20141025122510'/*update_date*/);
insert into biraldb.task( task_id,purchase_id,device_type,site_type,start_date,end_date,task_type,target_url,target_name,page_id, keyword1,keyword2,keyword3,keyword4,daily_hit_count,hour00_hit_count,hour01_hit_count,hour02_hit_count,hour03_hit_count,hour04_hit_count,hour05_hit_count,hour06_hit_count,hour07_hit_count,hour08_hit_count,hour09_hit_count,hour10_hit_count,hour11_hit_count,hour12_hit_count,hour13_hit_count,hour14_hit_count,hour15_hit_count,hour16_hit_count,hour17_hit_count,hour18_hit_count,hour19_hit_count,hour20_hit_count,hour21_hit_count,hour22_hit_count,hour23_hit_count,create_date,update_date )
                         values(18,18,'W','D','20141025','20141125','B',
                         'http://blog.daum.net/gangseo/17977374',
						'김혜자 27년 CF모델 기록 누가 깰 수 있을까?'/*target_name*/,
'17977374','김혜자'/*keyword1*/,''/*keyword2*/,''/*keyword3*/,''/*keyword4*/,
91,3,6,7,5,4,0,5,4,0,6,5,5,4,6,6,5,7,0,2,3,3,0,2,6,
'20141025122510' /*create_date*/,'20141025122510'/*update_date*/);
insert into biraldb.task( task_id,purchase_id,device_type,site_type,start_date,end_date,task_type,target_url,target_name,page_id, keyword1,keyword2,keyword3,keyword4,daily_hit_count,hour00_hit_count,hour01_hit_count,hour02_hit_count,hour03_hit_count,hour04_hit_count,hour05_hit_count,hour06_hit_count,hour07_hit_count,hour08_hit_count,hour09_hit_count,hour10_hit_count,hour11_hit_count,hour12_hit_count,hour13_hit_count,hour14_hit_count,hour15_hit_count,hour16_hit_count,hour17_hit_count,hour18_hit_count,hour19_hit_count,hour20_hit_count,hour21_hit_count,hour22_hit_count,hour23_hit_count,create_date,update_date )
                         values(19,19,'W','D','20141025','20141125','B',
                         'http://jsdian.tistory.com/92'/*target_url*/,
						'키아누 리브스는 왜 노숙생활을 하게 된 것일까?'/*target_name*/,
'92','키아누리브스'/*keyword1*/,''/*keyword2*/,''/*keyword3*/,''/*keyword4*/,
68,5,6,1,4,7,2,0,6,7,0,1,7,0,3,2,6,3,2,1,2,2,0,4,2,
'20141025122510' /*create_date*/,'20141025122510'/*update_date*/);
insert into biraldb.task( task_id,purchase_id,device_type,site_type,start_date,end_date,task_type,target_url,target_name,page_id, keyword1,keyword2,keyword3,keyword4,daily_hit_count,hour00_hit_count,hour01_hit_count,hour02_hit_count,hour03_hit_count,hour04_hit_count,hour05_hit_count,hour06_hit_count,hour07_hit_count,hour08_hit_count,hour09_hit_count,hour10_hit_count,hour11_hit_count,hour12_hit_count,hour13_hit_count,hour14_hit_count,hour15_hit_count,hour16_hit_count,hour17_hit_count,hour18_hit_count,hour19_hit_count,hour20_hit_count,hour21_hit_count,hour22_hit_count,hour23_hit_count,create_date,update_date )
                         values(20,23,'W','D','20141025','20141125','K',
                         ''/*target_url*/,
						''/*target_name*/,
'','톰크루즈'/*keyword1*/,'케이티홈즈'/*keyword2*/,''/*keyword3*/,''/*keyword4*/,
66,4,6,3,0,1,4,1,2,0,4,3,3,6,3,4,6,0,6,0,2,6,2,0,4,
'20141025122510' /*create_date*/,'20141025122510'/*update_date*/);
insert into biraldb.task( task_id,purchase_id,device_type,site_type,start_date,end_date,task_type,target_url,target_name,page_id, keyword1,keyword2,keyword3,keyword4,daily_hit_count,hour00_hit_count,hour01_hit_count,hour02_hit_count,hour03_hit_count,hour04_hit_count,hour05_hit_count,hour06_hit_count,hour07_hit_count,hour08_hit_count,hour09_hit_count,hour10_hit_count,hour11_hit_count,hour12_hit_count,hour13_hit_count,hour14_hit_count,hour15_hit_count,hour16_hit_count,hour17_hit_count,hour18_hit_count,hour19_hit_count,hour20_hit_count,hour21_hit_count,hour22_hit_count,hour23_hit_count,create_date,update_date )
                         values(21,24,'M','D','20141025','20141125','T',
                         'http://dg.cnbnews.com/news/article.html?no=164832'/*target_url*/,
						'케이티 홈즈 위자료 "0원 전망...혼전 계약서 때문"'/*target_name*/,
'164832','케이티홈즈 위자료'/*keyword1*/,''/*keyword2*/,''/*keyword3*/,''/*keyword4*/,
65,4,7,5,7,3,0,1,6,2,4,1,4,0,4,0,1,1,4,1,1,2,6,2,3,
'20141025122510' /*create_date*/,'20141025122510'/*update_date*/);

/*--1.mobile naver robot */
insert into biraldb.task( task_id,purchase_id,device_type,site_type,start_date,end_date,task_type,target_url,target_name,page_id, keyword1,keyword2,keyword3,keyword4,daily_hit_count,hour00_hit_count,hour01_hit_count,hour02_hit_count,hour03_hit_count,hour04_hit_count,hour05_hit_count,hour06_hit_count,hour07_hit_count,hour08_hit_count,hour09_hit_count,hour10_hit_count,hour11_hit_count,hour12_hit_count,hour13_hit_count,hour14_hit_count,hour15_hit_count,hour16_hit_count,hour17_hit_count,hour18_hit_count,hour19_hit_count,hour20_hit_count,hour21_hit_count,hour22_hit_count,hour23_hit_count,create_date,update_date )
                         values(7700101,7700101,'M','N','20141025','20141125','B',
                         'http://blog.daum.net/gangseo/17977374',
						'김혜자 27년 CF모델 기록 누가 깰 수 있을까?'/*target_name*/,
'17977374','김혜자'/*keyword1*/,''/*keyword2*/,''/*keyword3*/,''/*keyword4*/,
91,3,6,7,5,4,0,5,4,0,6,5,5,4,6,6,5,7,0,2,3,3,0,2,6,
'20141025122510' /*create_date*/,'20141025122510'/*update_date*/);
insert into biraldb.task( task_id,purchase_id,device_type,site_type,start_date,end_date,task_type,target_url,target_name,page_id, keyword1,keyword2,keyword3,keyword4,daily_hit_count,hour00_hit_count,hour01_hit_count,hour02_hit_count,hour03_hit_count,hour04_hit_count,hour05_hit_count,hour06_hit_count,hour07_hit_count,hour08_hit_count,hour09_hit_count,hour10_hit_count,hour11_hit_count,hour12_hit_count,hour13_hit_count,hour14_hit_count,hour15_hit_count,hour16_hit_count,hour17_hit_count,hour18_hit_count,hour19_hit_count,hour20_hit_count,hour21_hit_count,hour22_hit_count,hour23_hit_count,create_date,update_date )
                         values(7700102,7700102,'M','N','20141025','20141125','B',
                         'http://jsdian.tistory.com/92'/*target_url*/,
						'키아누 리브스는 왜 노숙생활을 하게 된 것일까?'/*target_name*/,
'92','키아누리브스'/*keyword1*/,''/*keyword2*/,''/*keyword3*/,''/*keyword4*/,
68,5,6,1,4,7,2,0,6,7,0,1,7,0,3,2,6,3,2,1,2,2,0,4,2,
'20141025122510' /*create_date*/,'20141025122510'/*update_date*/);
insert into biraldb.task( task_id,purchase_id,device_type,site_type,start_date,end_date,task_type,target_url,target_name,page_id, keyword1,keyword2,keyword3,keyword4,daily_hit_count,hour00_hit_count,hour01_hit_count,hour02_hit_count,hour03_hit_count,hour04_hit_count,hour05_hit_count,hour06_hit_count,hour07_hit_count,hour08_hit_count,hour09_hit_count,hour10_hit_count,hour11_hit_count,hour12_hit_count,hour13_hit_count,hour14_hit_count,hour15_hit_count,hour16_hit_count,hour17_hit_count,hour18_hit_count,hour19_hit_count,hour20_hit_count,hour21_hit_count,hour22_hit_count,hour23_hit_count,create_date,update_date )
                         values(7700103,7700103,'M','N','20141025','20141125','K',
                         ''/*target_url*/,
						''/*target_name*/,
'','톰크루즈'/*keyword1*/,'케이티홈즈'/*keyword2*/,''/*keyword3*/,''/*keyword4*/,
66,4,6,3,0,1,4,1,2,0,4,3,3,6,3,4,6,0,6,0,2,6,2,0,4,
'20141025122510' /*create_date*/,'20141025122510'/*update_date*/);
insert into biraldb.task( task_id,purchase_id,device_type,site_type,start_date,end_date,task_type,target_url,target_name,page_id, keyword1,keyword2,keyword3,keyword4,daily_hit_count,hour00_hit_count,hour01_hit_count,hour02_hit_count,hour03_hit_count,hour04_hit_count,hour05_hit_count,hour06_hit_count,hour07_hit_count,hour08_hit_count,hour09_hit_count,hour10_hit_count,hour11_hit_count,hour12_hit_count,hour13_hit_count,hour14_hit_count,hour15_hit_count,hour16_hit_count,hour17_hit_count,hour18_hit_count,hour19_hit_count,hour20_hit_count,hour21_hit_count,hour22_hit_count,hour23_hit_count,create_date,update_date )
                         values(7700104,7700104,'M','N','20141025','20141125','T',
                         'http://dg.cnbnews.com/news/article.html?no=164832'/*target_url*/,
						'케이티 홈즈 위자료 "0원 전망...혼전 계약서 때문"'/*target_name*/,
'164832','케이티홈즈 위자료'/*keyword1*/,''/*keyword2*/,''/*keyword3*/,''/*keyword4*/,
65,4,7,5,7,3,0,1,6,2,4,1,4,0,4,0,1,1,4,1,1,2,6,2,3,
'20141025122510' /*create_date*/,'20141025122510'/*update_date*/);

/*2.--web naver robot*/
insert into biraldb.task( task_id,purchase_id,device_type,site_type,start_date,end_date,task_type,target_url,target_name,page_id, keyword1,keyword2,keyword3,keyword4,daily_hit_count,hour00_hit_count,hour01_hit_count,hour02_hit_count,hour03_hit_count,hour04_hit_count,hour05_hit_count,hour06_hit_count,hour07_hit_count,hour08_hit_count,hour09_hit_count,hour10_hit_count,hour11_hit_count,hour12_hit_count,hour13_hit_count,hour14_hit_count,hour15_hit_count,hour16_hit_count,hour17_hit_count,hour18_hit_count,hour19_hit_count,hour20_hit_count,hour21_hit_count,hour22_hit_count,hour23_hit_count,create_date,update_date )
                         values(7700201,18,'W','N','20141025','20141125','B',
                         'http://baram4221.blog.me/220168851786',
						'수유커플마사지 마이타이 수유타이마사지 마이타이 '/*target_name*/,
'220168851786','﻿수유커플마사지'/*keyword1*/,''/*keyword2*/,''/*keyword3*/,''/*keyword4*/,
91,3,6,7,5,4,0,5,4,0,6,5,5,4,6,6,5,7,0,2,3,3,0,2,6,
'20141025122510' /*create_date*/,'20141025122510'/*update_date*/);
insert into biraldb.task( task_id,purchase_id,device_type,site_type,start_date,end_date,task_type,target_url,target_name,page_id, keyword1,keyword2,keyword3,keyword4,daily_hit_count,hour00_hit_count,hour01_hit_count,hour02_hit_count,hour03_hit_count,hour04_hit_count,hour05_hit_count,hour06_hit_count,hour07_hit_count,hour08_hit_count,hour09_hit_count,hour10_hit_count,hour11_hit_count,hour12_hit_count,hour13_hit_count,hour14_hit_count,hour15_hit_count,hour16_hit_count,hour17_hit_count,hour18_hit_count,hour19_hit_count,hour20_hit_count,hour21_hit_count,hour22_hit_count,hour23_hit_count,create_date,update_date )
                         values(7700202,19,'W','N','20141025','20141125','B',
                         'http://blog.naver.com/ilovezzangv2/220175100383'/*target_url*/,
						'가을 무로 만드는 맛있는 깍두기~'/*target_name*/,
'220175100383','가을 무'/*keyword1*/,''/*keyword2*/,''/*keyword3*/,''/*keyword4*/,
68,5,6,1,4,7,2,0,6,7,0,1,7,0,3,2,6,3,2,1,2,2,0,4,2,
'20141025122510' /*create_date*/,'20141025122510'/*update_date*/);
insert into biraldb.task( task_id,purchase_id,device_type,site_type,start_date,end_date,task_type,target_url,target_name,page_id, keyword1,keyword2,keyword3,keyword4,daily_hit_count,hour00_hit_count,hour01_hit_count,hour02_hit_count,hour03_hit_count,hour04_hit_count,hour05_hit_count,hour06_hit_count,hour07_hit_count,hour08_hit_count,hour09_hit_count,hour10_hit_count,hour11_hit_count,hour12_hit_count,hour13_hit_count,hour14_hit_count,hour15_hit_count,hour16_hit_count,hour17_hit_count,hour18_hit_count,hour19_hit_count,hour20_hit_count,hour21_hit_count,hour22_hit_count,hour23_hit_count,create_date,update_date )
                         values(7700203,23,'W','N','20141025','20141125','K',
                         ''/*target_url*/,
						''/*target_name*/,
'','톰크루즈'/*keyword1*/,'케이티홈즈'/*keyword2*/,''/*keyword3*/,''/*keyword4*/,
66,4,6,3,0,1,4,1,2,0,4,3,3,6,3,4,6,0,6,0,2,6,2,0,4,
'20141025122510' /*create_date*/,'20141025122510'/*update_date*/);
insert into biraldb.task( task_id,purchase_id,device_type,site_type,start_date,end_date,task_type,target_url,target_name,page_id, keyword1,keyword2,keyword3,keyword4,daily_hit_count,hour00_hit_count,hour01_hit_count,hour02_hit_count,hour03_hit_count,hour04_hit_count,hour05_hit_count,hour06_hit_count,hour07_hit_count,hour08_hit_count,hour09_hit_count,hour10_hit_count,hour11_hit_count,hour12_hit_count,hour13_hit_count,hour14_hit_count,hour15_hit_count,hour16_hit_count,hour17_hit_count,hour18_hit_count,hour19_hit_count,hour20_hit_count,hour21_hit_count,hour22_hit_count,hour23_hit_count,create_date,update_date )
                         values(7700204,24,'W','N','20141025','20141125','T',
                         'http://dg.cnbnews.com/news/article.html?no=164832'/*target_url*/,
						'케이티 홈즈 위자료 "0원 전망...혼전 계약서 때문"'/*target_name*/,
'164832','케이티홈즈 위자료'/*keyword1*/,''/*keyword2*/,''/*keyword3*/,''/*keyword4*/,
65,4,7,5,7,3,0,1,6,2,4,1,4,0,4,0,1,1,4,1,1,2,6,2,3,
'20141025122510' /*create_date*/,'20141025122510'/*update_date*/);

/*3.--mobile daum robot*/
insert into biraldb.task( task_id,purchase_id,device_type,site_type,start_date,end_date,task_type,target_url,target_name,page_id, keyword1,keyword2,keyword3,keyword4,daily_hit_count,hour00_hit_count,hour01_hit_count,hour02_hit_count,hour03_hit_count,hour04_hit_count,hour05_hit_count,hour06_hit_count,hour07_hit_count,hour08_hit_count,hour09_hit_count,hour10_hit_count,hour11_hit_count,hour12_hit_count,hour13_hit_count,hour14_hit_count,hour15_hit_count,hour16_hit_count,hour17_hit_count,hour18_hit_count,hour19_hit_count,hour20_hit_count,hour21_hit_count,hour22_hit_count,hour23_hit_count,create_date,update_date )
                         values(7700301,18,'M','D','20141025','20141125','B',
                         'http://blog.daum.net/gangseo/17977374',
						'김혜자 27년 CF모델 기록 누가 깰 수 있을까?'/*target_name*/,
'17977374','김혜자'/*keyword1*/,''/*keyword2*/,''/*keyword3*/,''/*keyword4*/,
91,3,6,7,5,4,0,5,4,0,6,5,5,4,6,6,5,7,0,2,3,3,0,2,6,
'20141025122510' /*create_date*/,'20141025122510'/*update_date*/);
insert into biraldb.task( task_id,purchase_id,device_type,site_type,start_date,end_date,task_type,target_url,target_name,page_id, keyword1,keyword2,keyword3,keyword4,daily_hit_count,hour00_hit_count,hour01_hit_count,hour02_hit_count,hour03_hit_count,hour04_hit_count,hour05_hit_count,hour06_hit_count,hour07_hit_count,hour08_hit_count,hour09_hit_count,hour10_hit_count,hour11_hit_count,hour12_hit_count,hour13_hit_count,hour14_hit_count,hour15_hit_count,hour16_hit_count,hour17_hit_count,hour18_hit_count,hour19_hit_count,hour20_hit_count,hour21_hit_count,hour22_hit_count,hour23_hit_count,create_date,update_date )
                         values(7700302,19,'M','D','20141025','20141125','B',
                         'http://jsdian.tistory.com/92'/*target_url*/,
						'키아누 리브스는 왜 노숙생활을 하게 된 것일까?'/*target_name*/,
'92','키아누리브스'/*keyword1*/,''/*keyword2*/,''/*keyword3*/,''/*keyword4*/,
68,5,6,1,4,7,2,0,6,7,0,1,7,0,3,2,6,3,2,1,2,2,0,4,2,
'20141025122510' /*create_date*/,'20141025122510'/*update_date*/);
insert into biraldb.task( task_id,purchase_id,device_type,site_type,start_date,end_date,task_type,target_url,target_name,page_id, keyword1,keyword2,keyword3,keyword4,daily_hit_count,hour00_hit_count,hour01_hit_count,hour02_hit_count,hour03_hit_count,hour04_hit_count,hour05_hit_count,hour06_hit_count,hour07_hit_count,hour08_hit_count,hour09_hit_count,hour10_hit_count,hour11_hit_count,hour12_hit_count,hour13_hit_count,hour14_hit_count,hour15_hit_count,hour16_hit_count,hour17_hit_count,hour18_hit_count,hour19_hit_count,hour20_hit_count,hour21_hit_count,hour22_hit_count,hour23_hit_count,create_date,update_date )
                         values(7700303,23,'M','D','20141025','20141125','K',
                         ''/*target_url*/,
						''/*target_name*/,
'','톰크루즈'/*keyword1*/,'케이티홈즈'/*keyword2*/,''/*keyword3*/,''/*keyword4*/,
66,4,6,3,0,1,4,1,2,0,4,3,3,6,3,4,6,0,6,0,2,6,2,0,4,
'20141025122510' /*create_date*/,'20141025122510'/*update_date*/);
insert into biraldb.task( task_id,purchase_id,device_type,site_type,start_date,end_date,task_type,target_url,target_name,page_id, keyword1,keyword2,keyword3,keyword4,daily_hit_count,hour00_hit_count,hour01_hit_count,hour02_hit_count,hour03_hit_count,hour04_hit_count,hour05_hit_count,hour06_hit_count,hour07_hit_count,hour08_hit_count,hour09_hit_count,hour10_hit_count,hour11_hit_count,hour12_hit_count,hour13_hit_count,hour14_hit_count,hour15_hit_count,hour16_hit_count,hour17_hit_count,hour18_hit_count,hour19_hit_count,hour20_hit_count,hour21_hit_count,hour22_hit_count,hour23_hit_count,create_date,update_date )
                         values(7700304,24,'M','D','20141025','20141125','T',
                         'http://dg.cnbnews.com/news/article.html?no=164832'/*target_url*/,
						'케이티 홈즈 위자료 "0원 전망...혼전 계약서 때문"'/*target_name*/,
'164832','케이티홈즈 위자료'/*keyword1*/,''/*keyword2*/,''/*keyword3*/,''/*keyword4*/,
65,4,7,5,7,3,0,1,6,2,4,1,4,0,4,0,1,1,4,1,1,2,6,2,3,
'20141025122510' /*create_date*/,'20141025122510'/*update_date*/);

/*4.--web daum robot*/
insert into biraldb.task( task_id,purchase_id,device_type,site_type,start_date,end_date,task_type,target_url,target_name,page_id, keyword1,keyword2,keyword3,keyword4,daily_hit_count,hour00_hit_count,hour01_hit_count,hour02_hit_count,hour03_hit_count,hour04_hit_count,hour05_hit_count,hour06_hit_count,hour07_hit_count,hour08_hit_count,hour09_hit_count,hour10_hit_count,hour11_hit_count,hour12_hit_count,hour13_hit_count,hour14_hit_count,hour15_hit_count,hour16_hit_count,hour17_hit_count,hour18_hit_count,hour19_hit_count,hour20_hit_count,hour21_hit_count,hour22_hit_count,hour23_hit_count,create_date,update_date )
                         values(7700401,18,'W','D','20141025','20141125','B',
                         'http://blog.daum.net/gangseo/17977374',
						'김혜자 27년 CF모델 기록 누가 깰 수 있을까?'/*target_name*/,
'17977374','김혜자'/*keyword1*/,''/*keyword2*/,''/*keyword3*/,''/*keyword4*/,
91,3,6,7,5,4,0,5,4,0,6,5,5,4,6,6,5,7,0,2,3,3,0,2,6,
'20141025122510' /*create_date*/,'20141025122510'/*update_date*/);
insert into biraldb.task( task_id,purchase_id,device_type,site_type,start_date,end_date,task_type,target_url,target_name,page_id, keyword1,keyword2,keyword3,keyword4,daily_hit_count,hour00_hit_count,hour01_hit_count,hour02_hit_count,hour03_hit_count,hour04_hit_count,hour05_hit_count,hour06_hit_count,hour07_hit_count,hour08_hit_count,hour09_hit_count,hour10_hit_count,hour11_hit_count,hour12_hit_count,hour13_hit_count,hour14_hit_count,hour15_hit_count,hour16_hit_count,hour17_hit_count,hour18_hit_count,hour19_hit_count,hour20_hit_count,hour21_hit_count,hour22_hit_count,hour23_hit_count,create_date,update_date )
                         values(7700402,19,'W','D','20141025','20141125','B',
                         'http://jsdian.tistory.com/92'/*target_url*/,
						'키아누 리브스는 왜 노숙생활을 하게 된 것일까?'/*target_name*/,
'92','키아누리브스'/*keyword1*/,''/*keyword2*/,''/*keyword3*/,''/*keyword4*/,
68,5,6,1,4,7,2,0,6,7,0,1,7,0,3,2,6,3,2,1,2,2,0,4,2,
'20141025122510' /*create_date*/,'20141025122510'/*update_date*/);
insert into biraldb.task( task_id,purchase_id,device_type,site_type,start_date,end_date,task_type,target_url,target_name,page_id, keyword1,keyword2,keyword3,keyword4,daily_hit_count,hour00_hit_count,hour01_hit_count,hour02_hit_count,hour03_hit_count,hour04_hit_count,hour05_hit_count,hour06_hit_count,hour07_hit_count,hour08_hit_count,hour09_hit_count,hour10_hit_count,hour11_hit_count,hour12_hit_count,hour13_hit_count,hour14_hit_count,hour15_hit_count,hour16_hit_count,hour17_hit_count,hour18_hit_count,hour19_hit_count,hour20_hit_count,hour21_hit_count,hour22_hit_count,hour23_hit_count,create_date,update_date )
                         values(7700403,23,'W','D','20141025','20141125','K',
                         ''/*target_url*/,
						''/*target_name*/,
'','톰크루즈'/*keyword1*/,'케이티홈즈'/*keyword2*/,''/*keyword3*/,''/*keyword4*/,
66,4,6,3,0,1,4,1,2,0,4,3,3,6,3,4,6,0,6,0,2,6,2,0,4,
'20141025122510' /*create_date*/,'20141025122510'/*update_date*/);
insert into biraldb.task( task_id,purchase_id,device_type,site_type,start_date,end_date,task_type,target_url,target_name,page_id, keyword1,keyword2,keyword3,keyword4,daily_hit_count,hour00_hit_count,hour01_hit_count,hour02_hit_count,hour03_hit_count,hour04_hit_count,hour05_hit_count,hour06_hit_count,hour07_hit_count,hour08_hit_count,hour09_hit_count,hour10_hit_count,hour11_hit_count,hour12_hit_count,hour13_hit_count,hour14_hit_count,hour15_hit_count,hour16_hit_count,hour17_hit_count,hour18_hit_count,hour19_hit_count,hour20_hit_count,hour21_hit_count,hour22_hit_count,hour23_hit_count,create_date,update_date )
                         values(7700404,24,'W','D','20141025','20141125','T',
                         'http://dg.cnbnews.com/news/article.html?no=164832'/*target_url*/,
						'케이티 홈즈 위자료 "0원 전망...혼전 계약서 때문"'/*target_name*/,
'164832','케이티홈즈 위자료'/*keyword1*/,''/*keyword2*/,''/*keyword3*/,''/*keyword4*/,
65,4,7,5,7,3,0,1,6,2,4,1,4,0,4,0,1,1,4,1,1,2,6,2,3,
'20141025122510' /*create_date*/,'20141025122510'/*update_date*/);



insert into biraldb.task_status( task_id, server_id, work_time, rank,day_hit_count, cur_hit_count,ip_address,update_date )
values( 1/*task_id*/, '001',
'2014102511',
-1/*rank*/,
5/*day_hit_count*/,
2/*cur_hit_count*/,
'192.168.0.1'/*ip_address*/,
'20141025122510'/*update_date*/);

insert into biraldb.common_code()
values('SCHEDULE_SERVER_ID','001');
