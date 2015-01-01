package com.bgt.mybatis;

import java.util.List;

import javax.annotation.Resource;

import org.apache.log4j.Logger;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.ApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;

import com.bgt.mybatis.service.IpInfoDao;
import com.bgt.mybatis.service.Service;
import com.bgt.mybatis.service.TaskDao;
import com.bgt.mybatis.vo.Person;

public class App 
{
	static Logger LOGGER = Logger.getLogger(AppMain.class);
	@Autowired ApplicationContext cxt = new ClassPathXmlApplicationContext("config/launch-config.xml");

	@Resource(name = "taskDao")
	public TaskDao taskDao;
	
	//@Resource(name = "ipInfoDao")
	public IpInfoDao ipInfoDao;

	public void doTask() {
		taskDao = (TaskDao)cxt.getBean("taskDao");
		List<com.bgt.mybatis.vo.Task> taskList =  taskDao.selectAllTask();
		for (com.bgt.mybatis.vo.Task task : taskList) {
			LOGGER.info(task.toString());
		}
		
		List<com.bgt.mybatis.vo.Task> taskList2 =  taskDao.selectAvailWebList(3);
		for (com.bgt.mybatis.vo.Task task : taskList2) {
			LOGGER.info(task.toString());
		}
	}
	
	public void doQueryIpInfo() {
		ipInfoDao = (IpInfoDao)cxt.getBean("ipInfoDao");
		List<com.bgt.mybatis.vo.IpInfo> IpList = ipInfoDao.selectAllIpInfo();
		for (com.bgt.mybatis.vo.IpInfo ipInfo : IpList) {
			LOGGER.info(ipInfo.toString());
		}
	}
	
	public static void main( String[] args )
	{

		//Service service = (Service) cxt.getBean("service");

		LOGGER.info("Running App...");

//		System.out.println("List<Person> persons = service.selectAllPerson()");
//		List<Person> persons = service.selectAllPerson();
//		System.out.println("-> "+persons+"\n");
//
//		System.out.println("Person person = service.selectPerson(2)");
//		Person person = service.selectPerson(2);
//		System.out.println("-> "+person+"\n");
//
//		System.out.println("service.insertPerson(person)");
//		person.setName("Inserted person");
//		service.insertPerson(person);
//		System.out.println("-> inserted..."+"\n");
//
//		System.out.println("List<Person> persons = service.selectAllPerson()");
//		persons = service.selectAllPerson();
//		System.out.println("-> "+persons+"\n");
		
		//2.대상작업 목록
		//(서버ID - 사용자ID - 구매정보 - 설정정보(활동시간))
		//select * from task;

		App app = new App();
		app.doTask();

		//3.활동시간 확인
		//한시간단위로 확인 목표hit수>0

		//(4개의 작업 조회됨)
		//작업목록은 모두 동일 내용이어야 한다.
		
		//4.IP목록 조회
		//4.1.IP그룹맵생성
		//-모바일비로그인, 피시비로그인,
		//  모바일로그인,피시로그인
		//  ,     
		//5.스케쥴루프시작
		//
		//5.1.작업선택
		//-목표hit수감안 작업id선택
		//-모바일여부
		//-로그인작업여부
		//-IP선택설정
		//
		app.doQueryIpInfo();
		//5.2.작업수행
		//-브라우저기동
		//-action rule대로 수행
		//-브라우저종료

		System.out.println(534*20/100);
	}
}