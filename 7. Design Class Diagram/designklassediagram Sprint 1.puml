@startuml
' Designklassediagram (DCD) – Vekto
' Opdateret ud fra WPF-programmet ("12. Vekto WPF Application").
' Dækker siderne Hovedvindue, Opret medarbejder, Opret kunde, Opret service og Service kvittering.
' Service oversigt (UC5) er ikke med.
' Stil som undervisningens lagdelte DCD'er (Pr19 Disaheim og Pr20 BookMeeting):
' UI Layer -> Application Layer (use case controllers) -> Domain Layer (repositories + domæneklasser).
' Hver besked i sekvensdiagrammerne ("6. Sekvens Diagrammer") er en operation i modtagerens klasse.
' Klasse- og metodenavne er de samme som i koden (fx Costumer og CostumerRepository).

left to right direction
skinparam linetype ortho
skinparam nodesep 40
skinparam ranksep 60
skinparam shadowing false
skinparam backgroundColor white
skinparam defaultFontName Arial
skinparam defaultFontSize 11
skinparam classAttributeIconSize 0
skinparam packageStyle rectangle
skinparam package {
  BorderStyle dashed
  BorderColor black
  BackgroundColor white
  FontStyle plain
  FontSize 14
}
skinparam class {
  BackgroundColor white
  BorderColor black
  ArrowColor black
  FontStyle plain
  StereotypeFontSize 11
}
skinparam note {
  BackgroundColor white
  BorderColor black
}
hide circle
hide <<enumeration>> methods

title DCD

' =====================================================================
package "UI Layer" {

  class MainWindow {
    - PageArea : ContentControl
    --
    + MainWindow()
    - btnOpretMedarbejder_Click()
    - btnOpretKunde_Click()
    - btnOpretService_Click()
  }

  class CreateEmployee {
    - controller : CreateEmployeeController
    --
    + CreateEmployee()
    - btnCreate_Click()
    - ShowCount()
  }

  class CreateCostumer {
    - controller : CreateCostumerController
    --
    + CreateCostumer()
    - btnCreate_Click()
    - ShowCount()
  }

  class CreateService {
    - controller : CreateServiceController
    --
    + CreateService()
    - tbPhone_TextChanged()
    - btnCreate_Click()
  }

  class CreateReceipt {
    - controller : CreateReceiptController
    --
    + CreateReceipt()
    + ShowService(serviceId : int)
    - btnClose_Click()
  }
}

' =====================================================================
package "Application Layer" {

  class CreateEmployeeController {
    - employeeRepository : EmployeeRepository
    + «get» Employees : Employee[0..*]
    --
    + CreateEmployeeController()
    + CreateEmployee(name : string, initials : string) : Employee
  }

  class CreateCostumerController {
    - costumerRepository : CostumerRepository
    + «get» Costumers : Costumer[0..*]
    --
    + CreateCostumerController()
    + CreateCostumer(name : string, phoneNumber : string) : Costumer
  }

  class CreateServiceController {
    - costumerRepository : CostumerRepository
    - serviceRepository : ServiceRepository
    + «get» ErrorTypes : string[0..*]
    --
    + CreateServiceController()
    + SearchCustomer(phoneNumber : string) : Costumer
    + CreateService(phoneNumber : string,
    <U+2003><U+2003>brand : string, model : string,
    <U+2003><U+2003>errorType : string, description : string) : Service
  }

  class CreateReceiptController {
    - servicerepository : ServiceRepository
    - costumerRepository : CostumerRepository
    - employeeRepository : EmployeeRepository
    --
    + CreateReceiptController()
    + GetService(serviceId : int) : Service
    + GetCostumer(phoneNumber : string) : Costumer
    + GetEmployee(initials : string) : Employee
  }
}

' =====================================================================
package "Domain Layer" {

  class EmployeeRepository {
    - fileName : string = "Employee.csv"
    - employees : Employee[0..*]
    --
    + EmployeeRepository()
    - Load()
    - Save()
    + Add(employee : Employee)
    + Get(initials : string) : Employee
    + GetAll() : Employee[0..*]
  }

  class CostumerRepository {
    - fileName : string = "Costumer.csv"
    - costumers : Costumer[0..*]
    --
    + CostumerRepository()
    - Load()
    - Save()
    + Add(costumer : Costumer)
    + Get(phoneNumber : string) : Costumer
    + GetAll() : Costumer[0..*]
  }

  class ServiceRepository {
    - fileName : string = "Service.csv"
    - services : Service[0..*]
    --
    + ServiceRepository()
    - InitializeRepository()
    - Save()
    + GetNextId() : int
    + Add(serviceId : int, dropOffDate : DateTime,
    <U+2003><U+2003>brand : string, model : string,
    <U+2003><U+2003>errorType : string, description : string,
    <U+2003><U+2003>status : ServiceStatus, costumer : string) : Service
    + Get(serviceId : int) : Service
  }

  class Employee {
    + Name : string
    + Initials : string
    --
    + Employee(name : string, initials : string)
    + ToString() : string
  }

  class Costumer {
    + Name : string
    + PhoneNumber : string
    --
    + Costumer(name : string, phoneNumber : string)
    + ToString() : string
  }

  class Service {
    + ServiceId : int
    + DropOffDate : DateTime
    + Brand : string
    + Model : string
    + ErrorType : string
    + Description : string
    + Status : ServiceStatus
    + Customer : string
    + CompletedWork : string
    + Employee : string
    + ClosedDate : DateTime[0..1]
    --
    + Service(serviceId : int, dropOffDate : DateTime,
    <U+2003><U+2003>brand : string, model : string,
    <U+2003><U+2003>errorType : string, description : string,
    <U+2003><U+2003>customer : string)
  }

  enum ServiceStatus <<enumeration>> {
    Open
    Closed
  }
}

' ---------- UI Layer: hovedvindue -> sider, side -> dialog ----------
MainWindow -- CreateEmployee
MainWindow -- CreateCostumer
MainWindow -- CreateService
CreateService - CreateReceipt

' ---------- UI Layer -> controller ----------
CreateEmployee -- CreateEmployeeController
CreateCostumer -- CreateCostumerController
CreateService  -- CreateServiceController
CreateReceipt  -- CreateReceiptController

' ---------- Controller -> repository ----------
CreateEmployeeController -- EmployeeRepository
CreateCostumerController -- CostumerRepository
CreateServiceController  -- CostumerRepository
CreateServiceController  -- ServiceRepository
CreateReceiptController  -- ServiceRepository
CreateReceiptController  -- CostumerRepository
CreateReceiptController  -- EmployeeRepository

' ---------- Repository -> domæneklasse ----------
EmployeeRepository -- "0..*" Employee
CostumerRepository -- "0..*" Costumer
ServiceRepository  -- "0..*" Service

' ---------- Domænerelationer (gemt som nøgle i Service) ----------
Costumer "1" - "*" Service
note on link : Service.Customer = Costumer.PhoneNumber
Service "*" - "0..1" Employee
note on link : Service.Employee = Employee.Initials
Service .. ServiceStatus
@enduml
