package com.bgt.automation.util.event;

import java.util.EventObject;

public class TaskEvent extends EventObject {

	TaskResult taskResult;
	public TaskEvent(Object source, TaskResult taskResult) {
		super(source);
		this.taskResult = taskResult;
	}
	
	public TaskResult getTaskResult() {
		return taskResult;
	}
}
