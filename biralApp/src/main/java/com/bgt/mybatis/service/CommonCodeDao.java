package com.bgt.mybatis.service;

import java.util.List;

import com.bgt.mybatis.mapper.CommonCodeMapper;
import com.bgt.mybatis.mapper.IpInfoMapper;
import com.bgt.mybatis.mapper.TaskMapper;
import com.bgt.mybatis.vo.CommonCode;
import com.bgt.mybatis.vo.IpInfo;
import com.bgt.mybatis.vo.Task;

import javax.annotation.Resource;

import org.springframework.stereotype.Service;

@Service(value="commonCodeDao")
public class CommonCodeDao {

	@Resource(name="commonCodeMapper")
	CommonCodeMapper mapper;
	
	public CommonCodeDao() {
		// TODO Auto-generated constructor stub
	}

	public List<CommonCode> selectAll() {
		return mapper.selectAll();
	}

	public CommonCode selectOne(String codeKey) {
		return mapper.selectOne(codeKey);
	}

}

