CREATE TABLE `common_code` (
  `code_key` varchar(200) NOT NULL,
  `code_value` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`code_key`)
) ENGINE=InnoDB DEFAULT CHARSET=euckr;

CREATE TABLE `ipinfo` (
  `ip_address` varchar(20) NOT NULL,
  `browser_type` varchar(1) DEFAULT 'I' COMMENT 'ie:I, chrome:C, firefox:F, safari:S',
  `device_type` varchar(1) DEFAULT 'W' COMMENT 'mobile:M, web:W',
  `use_type` varchar(1) DEFAULT 'N' COMMENT 'normal:N, login:L',
  `login_id_naver` varchar(20) DEFAULT NULL,
  `login_pwd_naver` varchar(20) DEFAULT NULL,
  `login_id_daum` varchar(20) DEFAULT NULL,
  `login_pwd_daum` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`ip_address`),
  KEY `idx_T_ipinfo01` (`browser_type`),
  KEY `idx_T_ipinfo02` (`device_type`),
  KEY `idx_T_ipinfo03` (`use_type`)
) ENGINE=InnoDB DEFAULT CHARSET=euckr;

CREATE TABLE `loginid` (
  `login_id` varchar(20) NOT NULL,
  `passwd` varchar(20) NOT NULL,
  `id_type` varchar(1) NOT NULL DEFAULT '' COMMENT 'naver:N, daum:D,google:G, youtube:Y',
  `userid` varchar(10) NOT NULL,
  `create_date` varchar(14) NOT NULL,
  `update_date` varchar(14) NOT NULL,
  PRIMARY KEY (`login_id`,`id_type`)
) ENGINE=InnoDB DEFAULT CHARSET=euckr;

CREATE TABLE `product` (
  `product_id` varchar(8) NOT NULL,
  `product_name` varchar(200) NOT NULL,
  `price` int(8) NOT NULL,
  `device_type` varchar(1) DEFAULT 'W' COMMENT 'mobile:M, web:W',
  `site_type` varchar(1) DEFAULT 'N' COMMENT 'naver:N, daum:D',
  `task_type` varchar(1) DEFAULT NULL COMMENT 'keyword:K, topsite:T, blog:B, robot:R, auto:A',
  `create_date` varchar(14) NOT NULL,
  `update_date` varchar(14) NOT NULL,
  PRIMARY KEY (`product_id`)
) ENGINE=InnoDB DEFAULT CHARSET=euckr;

CREATE TABLE `purchase` (
  `purchase_id` bigint(8) NOT NULL AUTO_INCREMENT,
  `user_id` varchar(10) NOT NULL,
  `product_id` varchar(8) NOT NULL,
  `device_type` varchar(1) DEFAULT 'W' COMMENT 'mobile:M, web:W',
  `site_type` varchar(1) DEFAULT 'N' COMMENT 'naver:N, daum:D',
  `task_type` varchar(1) DEFAULT NULL COMMENT 'keyword:K, topsite:T, blog:B, robot:R, auto:A',
  `purchase_date` varchar(8) NOT NULL,
  `purchase_amount` int(8) NOT NULL,
  `purchase_type` varchar(1) DEFAULT NULL COMMENT 'card:C, bank:B',
  `used_flag` varchar(1) DEFAULT 'N' COMMENT 'not used:N, used:Y',
  `create_date` varchar(14) NOT NULL,
  `update_date` varchar(14) NOT NULL,
  PRIMARY KEY (`purchase_id`),
  KEY `idx_T_purchase_01` (`product_id`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=euckr;

CREATE TABLE `server_info` (
  `server_id` varchar(3) NOT NULL,
  `server_name` varchar(20) NOT NULL,
  `real_ip_address` varchar(15) NOT NULL,
  `run_status` varchar(1) DEFAULT 'S' COMMENT 'running:R, stop:S',
  PRIMARY KEY (`server_id`)
) ENGINE=InnoDB DEFAULT CHARSET=euckr;

CREATE TABLE `task` (
  `task_id` int(8) NOT NULL AUTO_INCREMENT,
  `purchase_id` bigint(8) NOT NULL,
  `device_type` varchar(1) DEFAULT 'W' COMMENT 'mobile:M, web:W',
  `site_type` varchar(1) DEFAULT 'N' COMMENT 'naver:N, daum:D',
  `start_date` varchar(8) NOT NULL,
  `end_date` varchar(8) NOT NULL,
  `task_type` varchar(1) DEFAULT NULL COMMENT 'keyword:K, topsite:T, blog:B, robot:R',
  `target_url` varchar(4092) DEFAULT NULL,
  `target_name` varchar(200) DEFAULT NULL,
  `page_id` varchar(200) DEFAULT NULL COMMENT 'blog id, cafe page id',
  `keyword1` varchar(200) DEFAULT NULL,
  `keyword2` varchar(200) DEFAULT NULL,
  `keyword3` varchar(200) DEFAULT NULL,
  `keyword4` varchar(200) DEFAULT NULL,
  `blog_like_count` int(4) DEFAULT '0',
  `daily_hit_count` int(5) DEFAULT '0',
  `hour00_hit_count` int(5) DEFAULT '0',
  `hour01_hit_count` int(5) DEFAULT '0',
  `hour02_hit_count` int(5) DEFAULT '0',
  `hour03_hit_count` int(5) DEFAULT '0',
  `hour04_hit_count` int(5) DEFAULT '0',
  `hour05_hit_count` int(5) DEFAULT '0',
  `hour06_hit_count` int(5) DEFAULT '0',
  `hour07_hit_count` int(5) DEFAULT '0',
  `hour08_hit_count` int(5) DEFAULT '0',
  `hour09_hit_count` int(5) DEFAULT '0',
  `hour10_hit_count` int(5) DEFAULT '0',
  `hour11_hit_count` int(5) DEFAULT '0',
  `hour12_hit_count` int(5) DEFAULT '0',
  `hour13_hit_count` int(5) DEFAULT '0',
  `hour14_hit_count` int(5) DEFAULT '0',
  `hour15_hit_count` int(5) DEFAULT '0',
  `hour16_hit_count` int(5) DEFAULT '0',
  `hour17_hit_count` int(5) DEFAULT '0',
  `hour18_hit_count` int(5) DEFAULT '0',
  `hour19_hit_count` int(5) DEFAULT '0',
  `hour20_hit_count` int(5) DEFAULT '0',
  `hour21_hit_count` int(5) DEFAULT '0',
  `hour22_hit_count` int(5) DEFAULT '0',
  `hour23_hit_count` int(5) DEFAULT '0',
  `create_date` varchar(14) NOT NULL,
  `update_date` varchar(14) NOT NULL,
  PRIMARY KEY (`task_id`),
  KEY `idx_T_task01` (`task_id`,`purchase_id`,`task_type`),
  KEY `idx_T_task02` (`device_type`),
  KEY `idx_T_task03` (`task_type`),
  KEY `idx_T_task04` (`purchase_id`)
) ENGINE=InnoDB AUTO_INCREMENT=7700431 DEFAULT CHARSET=euckr;

CREATE TABLE `task_schedule` (
  `server_id` varchar(3) NOT NULL,
  `ip_address` varchar(20) NOT NULL,
  `execute_date` varchar(8) NOT NULL,
  `work_hour` int(2) NOT NULL,
  `browser_type` varchar(1) DEFAULT 'I' COMMENT 'ie:I, chrome:C, firefox:F, safari:S',
  `device_type` varchar(1) DEFAULT 'W' COMMENT 'mobile:M, web:W',
  `job_list` varchar(540) NOT NULL COMMENT '8bytes hexa value for job * 60,  dummyTask(-1), robotTask(0)',
  `update_date` varchar(14) NOT NULL,
  PRIMARY KEY (`server_id`,`ip_address`,`execute_date`,`work_hour`),
  KEY `idx_T_task_schedule01` (`execute_date`,`work_hour`)
) ENGINE=InnoDB DEFAULT CHARSET=euckr;

CREATE TABLE `task_status` (
  `task_id` int(8) NOT NULL,
  `server_id` varchar(3) NOT NULL,
  `work_time` varchar(10) NOT NULL COMMENT 'yyyymmddhh actual execution time',
  `rank` int(4) NOT NULL,
  `day_hit_count` int(5) NOT NULL,
  `cur_hit_count` int(5) NOT NULL COMMENT 'hit count at current hour',
  `ip_address` varchar(20) NOT NULL,
  `update_date` varchar(14) NOT NULL,
  PRIMARY KEY (`task_id`,`server_id`,`work_time`),
  KEY `idx_T_task_status01` (`ip_address`),
  KEY `idx_T_task_status02` (`work_time`)
) ENGINE=InnoDB DEFAULT CHARSET=euckr;

CREATE TABLE `user_info` (
  `user_id` varchar(10) NOT NULL,
  `passwd` varchar(18) NOT NULL,
  `user_type` varchar(1) DEFAULT NULL COMMENT 'admin:A, customer:C',
  `email` varchar(100) NOT NULL,
  `mobile` varchar(11) NOT NULL,
  `phone` varchar(11) NOT NULL,
  `company_name` varchar(200) DEFAULT NULL,
  `etc` varchar(200) DEFAULT NULL,
  `create_date` varchar(14) NOT NULL,
  `update_date` varchar(14) NOT NULL,
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=euckr;

