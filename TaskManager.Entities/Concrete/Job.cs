﻿using TaskManager.Entities.Abstract;
using TaskManager.Entities.Enum;

namespace TaskManager.Entities.Concrete;

public class Job : BaseEntity, IEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; } 
    public DateTime EndDate { get; set; }   
    public int UserId { get; set; }
    public JobStatus Status { get; set; }
}
