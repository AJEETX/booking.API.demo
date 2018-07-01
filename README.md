# Acme Remote Flights ![GitHub release](https://img.shields.io/github/release/ajeetx/Demo.API.svg?style=for-the-badge) ![Maintenance](https://img.shields.io/maintenance/yes/2018.svg?style=for-the-badge)


![GitHub Release Date](https://img.shields.io/github/release-date/ajeetx/Demo.API.svg) | [![.Net Framework](https://img.shields.io/badge/DotNet-2.0-blue.svg?style=plastic)](https://www.microsoft.com/en-au/download/details.aspx?id=1639) | ![GitHub language count](https://img.shields.io/github/languages/count/ajeetx/Demo.API.svg) | ![GitHub top language](https://img.shields.io/github/languages/top/ajeetx/Demo.API.svg) |![GitHub repo size in bytes](https://img.shields.io/github/repo-size/ajeetx/Demo.API.svg) 
| ---     | ---          | ---        | ---      | ---        | 

---------------------------------------
## Introduction

Rest API : booking search functionality


## Repository 
 
The repository consists of 2 project:
1) Asp.Net Core2 webapi 
2) Unit Test 

## Features

- Open the solution file in VS2017
- run the application 
- provide the search request parameters in uri as below:
- the response object[ResponseBooking] contain true if booking is available or otherwise
```
	http://localhost:5000/api/booking/4-07-2018/5-07-2018/2

	host = http://localhost:5000/
	path = api/booking/
	parameters =  4-07-2018/5-07-2018/2 		
	first parameter is start date 4-07-2018
	second parameter is end date 5-07-2018
	last parameter is no of pax  2
```
> Sample data created in datasource is for 10 next days. Modify "noOfDays" in appsetting.json to change.

### Support or Contact

Having any trouble? Check out our [documentation](https://github.com/AJEETX/Demo.API/blob/master/README.md) or [contact support](mailto:ajeetkumar@email.com) and we’ll help you sort it out.


[![HitCount](http://hits.dwyl.io/ajeetx/Demo.API/projects/1.svg)](http://hits.dwyl.io/ajeetx/Demo.API/projects/1) | ![GitHub contributors](https://img.shields.io/github/contributors/ajeetx/Demo.API.svg?style=plastic)|![license](https://img.shields.io/github/license/ajeetx/Demo.API.svg?style=plastic)|
 | --- | --- | ---|
