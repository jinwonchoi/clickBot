package com.bgt.mybatis.mapper;

import java.util.List;

import org.springframework.stereotype.Repository;

import com.bgt.mybatis.vo.CommonCode;

@Repository(value="commonCodeMapper")
public interface CommonCodeMapper {

	public List<CommonCode> selectAll();
	public CommonCode selectOne(String codeKey);
}
