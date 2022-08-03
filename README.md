# WomenEmpowermentAPI

## ADMIN Controller

```
Route: api/Admin/Register
Method: POST
Action: PostRegisterAdmin
```

```
Route: api/Admin/Login
Method: POST
Action: PostLoginAdmin
```
```
Route: api/Admin/Ngo/Requests
Method: GET
Action: GetNgoRequest
```
```
Route: api/Admin/Trainee/Requests
Method: GET
Action: GetTraineeRequest
```
```
Route: api/Admin/Ngo/Update/Status
Method: PUT
Action: PutUpdateStatus
```
```
Route: api/Admin/Trainee/Update/Status
Method: PUT
Action: PutUpdateStatus
```

Admin Registration and AdminLogin is performed via this controller as well as the status of Ngos and Trainees are accepted or rejected by the admin 

----

## COURSE Controllers

```
Route: api/Course/Add
Method: POST
Action: PostCourse
```
```
Route: api/Course/Courses
Method: GET
Action: GetCourse
```
```
Route: api/Course/Courses/{courseId}
Method: GET
Action: GetCourse
```
```
Route: api/Course/Update
Method: PUT
Action: PutCourse
```
```
Route: api/Course/Delete/{courseId}
Method: DELETE
Action: DeleteCourse
```

Adding,Updating,Getting and Deleting of courses is controlled via this course controller

---
## STEP Controllers

### TraineeController
```
Route: api/Trainee/Register
Method: POST
Action: PostRegister
```
```
Route: api/Trainee/Login
Method: POST
Action: PostLogin
```

Trainee Registration and Login are performed via this controller.

---

### TraineePersonalDetails
```
Route: api/TraineePersonalDetails/Add
Method: POST
Action: PostRegister
```
```
Route: api/Trainee/Login
Method: POST
Action: PostLogin
```

Trainee Registration and Login are performed via this controller.

---

### TraineeFamilyDetails

```
Route: api/TraineeFamilyDetails/Add
Method: POST
Action: PostTraineeFamilyDetails
```
```
Route: api/TraineeFamilyDetails/Get/{traineeId}
Method: GET
Action: GetTraineeFamilyDetails
```
Trainee Family Details are added and fetched by the help of these controllers

---

### TraineeAddressDetails

```
Route: api/TraineeAddressDetails/Add
Method: POST
Action: PostTraineeAddressDetails
```
```
Route: api/TraineeAddressDetails/Get/{traineeId}
Method: GET
Action: GetTraineeAddressDetails
```
Trainee Address details are inserted and fetched from the database via these controllers

---

### TraineeAppplication

```
Route: api/TraineeApplication/Request/{traineeId}
Method: GET
Action: PostTraineeApplicationRequest
```
```
Route: api/TraineeApplication/Get/{traineeId}
Method: GET
Action: GetTraineeApplicationStatus
```

Trainee's application is requested for approval and the status of the application is fetched from these controllers

---

## NGO Contollers

### Ngo

```
Route: api/Ngo/Register
Method: POST
Action: PostRegisterNgo
```
```
Route: api/Ngo/Login
Method: POST
Action: PostLoginNgo
```
Ngo can register and login Via these Ngo controller

---
### NgoContactDetail

```
Route: api/NgoContactDetail/Add
Method: POST
Action: PostNgoContactDetail
```
```
Route: api/NgoContactDetail/{id}
Method: GET
Action: GetNgoContactDetail
```
```
Route: api/NgoContactDetail/{id}
Method: PUT
Action: PutNgoContactDetail
```
Ngos can add,update and get their contact details using these controllers

---

### NgoCourse

```
Route: api/NgoCourse/AddNgoCourse
Method: POST
Action: PostNgoCourseDetail
```
```
Route: api/NgoCourse/DeleteCourse/{id}
Method: DELETE
Action: DeleteNgoCourse
```
Ngo can add courses or remove a course using these controllers

---
### NgoDetail

```
Route: api/NgoDetail/Add
Method: POST
Action: PostNgoDetail
```
```
Route: api/NgoDetail/{id}
Method: GET
Action: GetNgoDetails
```
```
Route: api/NgoDetail/EditDetails/{id}
Method: PUT
Action: PutDetails
```
```
Route: api/NgoDetail/DeleteNgo/{id}
Method: DELETE
Action: DeleteNgo
```
Using above controllers ngos can add,update,get and delete their details

---
### NgoApplication
```
Route: api/NgoApplication/Request/{ngoId}
Method: GET
Action: PostNgoStatusUpdate
```
```
Route: api/NgoApplication/Get/{ngoId}
Method: GET
Action: GetNgoApplicationStatus
```
Ngo's application is requested for approval and the status of the application is fetched from these controllers

---

