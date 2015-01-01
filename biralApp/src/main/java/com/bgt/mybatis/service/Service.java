package com.bgt.mybatis.service;

import java.util.HashMap;
import java.util.List;
import java.util.Map;



import org.springframework.beans.factory.annotation.Autowired;

import com.bgt.mybatis.mapper.Mapper;
import com.bgt.mybatis.vo.Person;
import com.bgt.mybatis.vo.Task;

public class Service {

	//@Autowired 
	private Mapper mapper;


	public List<Person> selectAllPerson() {
		return mapper.selectAllPerson();
	}
	public Person selectPerson(int id) {
		return mapper.selectPerson(id);
	}
	public int insertPerson(Person person){
		return mapper.insertPerson(person);
	}
	
	
}