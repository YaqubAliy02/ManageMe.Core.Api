//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using ManageMe.Core.Api.Brokers.DateTimes;
using ManageMe.Core.Api.Brokers.Loggings;
using ManageMe.Core.Api.Brokers.Spreadsheets;
using ManageMe.Core.Api.Brokers.Storages;
using ManageMe.Core.Api.Services.Foundations.Applicants;
using ManageMe.Core.Api.Services.Foundations.Groups;
using ManageMe.Core.Api.Services.Foundations.Spreadsheets;
using ManageMe.Core.Api.Services.Foundations.Users;
using ManageMe.Core.Api.Services.Orchestrations;
using ManageMe.Core.Api.Services.Processings.Applicants;
using ManageMe.Core.Api.Services.Processings.Groups;
using ManageMe.Core.Api.Services.Processings.Spreadsheets;
using ManageMe.Core.Api.Services.Processings.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); // Add MVC services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IStorageBroker, StorageBroker>();
builder.Services.AddTransient<IDateTimeBroker, DateTimeBroker>();
builder.Services.AddTransient<ILoggingBroker, LoggingBroker>();
builder.Services.AddTransient<IOrchestrationService, OrchestrationService>();
builder.Services.AddTransient<IApplicantProcessingService, ApplicantProcessingService>();
builder.Services.AddTransient<IApplicantService, ApplicantService>();
builder.Services.AddTransient<ISpreadsheetProcessingService, SpreadsheetProcessingService>();
builder.Services.AddTransient<ISpreadsheetService, SpreadsheetService>();
builder.Services.AddTransient<ISpreadsheetBroker, SpreadsheetBroker>();
builder.Services.AddTransient<IGroupProcessingService, GroupProcessingService>();
builder.Services.AddTransient<IGroupService, GroupService>();
builder.Services.AddTransient<IUserProcessingService, UserProcessingService>();
builder.Services.AddTransient<IUserService, UserService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
