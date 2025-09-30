namespace Dental_Appointment_Manager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointments", "Users_userId", "dbo.Users");
            DropForeignKey("dbo.Patient_Records", "Users_userId", "dbo.Users");
            DropForeignKey("dbo.Payments", "appointment_id", "dbo.Appointments");
            DropIndex("dbo.Appointments", new[] { "Users_userId" });
            DropIndex("dbo.Patient_Records", new[] { "Users_userId" });
            CreateTable(
                "dbo.Appointments",
                c => new
                {
                    appointment_id = c.Int(nullable: false, identity: true),
                    appointment_date = c.DateTime(nullable: false),
                    appointment_time = c.Time(nullable: false, precision: 7),
                    AppointmentStatus = c.Int(nullable: false),
                    reason = c.String(),
                    created_at = c.DateTime(nullable: false),
                    PatientId = c.Long(nullable: false),
                    DoctorId = c.Long(nullable: false),
                    ReceptionistId = c.Long(),
                    User_userId = c.Long(),
                    User_userId1 = c.Long(),
                    User_userId2 = c.Long(),
                    User_userId3 = c.Long(),
                })
                .PrimaryKey(t => t.appointment_id)
                .ForeignKey("dbo.Users", t => t.User_userId)
                .ForeignKey("dbo.Users", t => t.User_userId1)
                .ForeignKey("dbo.Users", t => t.User_userId2)
                .ForeignKey("dbo.Users", t => t.User_userId3)
                .ForeignKey("dbo.Users", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.PatientId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.ReceptionistId)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId)
                .Index(t => t.ReceptionistId)
                .Index(t => t.User_userId)
                .Index(t => t.User_userId1)
                .Index(t => t.User_userId2)
                .Index(t => t.User_userId3);

            CreateTable(
                "dbo.Users",
                c => new
                {
                    userId = c.Long(nullable: false, identity: true),
                    fullName = c.String(nullable: false),
                    dateOfBirth = c.DateTime(nullable: false),
                    gender = c.String(nullable: false),
                    phone = c.String(nullable: false),
                    email = c.String(nullable: false),
                    address = c.String(nullable: false),
                    password = c.String(nullable: false),
                    RoleTitle = c.Int(nullable: false),
                    createdAt = c.DateTime(nullable: false),
                    updatedAt = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.userId);

            CreateTable(
                "dbo.Consulations",
                c => new
                {
                    consulation_id = c.Int(nullable: false, identity: true),
                    appointment_id = c.Int(nullable: false),
                    doctor_id = c.Int(nullable: false),
                    dianoisis = c.String(nullable: false),
                    notes = c.String(),
                    created_at = c.DateTime(),
                    Appointment_id = c.Int(nullable: false),
                    Doctor_id = c.Long(nullable: false),
                })
                .PrimaryKey(t => t.consulation_id)
                .ForeignKey("dbo.Appointments", t => t.Appointment_id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Doctor_id, cascadeDelete: true)
                .Index(t => t.Appointment_id)
                .Index(t => t.Doctor_id);

            CreateTable(
                "dbo.Patient_Record",
                c => new
                {
                    record_id = c.Int(nullable: false, identity: true),
                    medical_history = c.String(nullable: false),
                    allergies = c.String(nullable: false),
                    notes = c.String(),
                    created_at = c.DateTime(nullable: false),
                    updated_at = c.DateTime(nullable: false),
                    PatientId = c.Long(nullable: false),
                    DoctorId = c.Long(nullable: false),
                })
                .PrimaryKey(t => t.record_id)
                .ForeignKey("dbo.Users", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId);

            CreateTable(
                "dbo.Payments",
                c => new
                {
                    payment_id = c.Int(nullable: false, identity: true),
                    appointment_id = c.Int(nullable: false),
                    total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    payment = c.DateTime(nullable: false),
                    payment_method = c.String(nullable: false),
                    PaymentStatus = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.payment_id)
                .ForeignKey("dbo.Appointments", t => t.appointment_id, cascadeDelete: true);

            AddColumn("dbo.Medicines", "Prescription_prescription_id", c => c.Int());
            CreateIndex("dbo.Medicines", "Prescription_prescription_id");
            AddForeignKey("dbo.Medicines", "Prescription_prescription_id", "dbo.Prescriptions", "prescription_id");
            DropTable("dbo.Appointments");
            DropTable("dbo.Users");
            DropTable("dbo.Consulations");
            DropTable("dbo.Patient_Records");
            DropTable("dbo.Payments");
        }

        public override void Down()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                {
                    payment_id = c.Int(nullable: false, identity: true),
                    appointment_id = c.Int(nullable: false),
                    total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    payment = c.DateTime(nullable: false),
                    payment_method = c.String(nullable: false),
                    status = c.String(nullable: false),
                })
                .PrimaryKey(t => t.payment_id);

            CreateTable(
                "dbo.Patient_Records",
                c => new
                {
                    record_id = c.Int(nullable: false, identity: true),
                    patient_id = c.Long(nullable: false),
                    doctor_id = c.Long(nullable: false),
                    medical_history = c.String(),
                    allergies = c.String(),
                    notes = c.String(),
                    created_at = c.DateTime(nullable: false),
                    updated_at = c.DateTime(nullable: false),
                    Users_userId = c.Long(),
                })
                .PrimaryKey(t => t.record_id);

            CreateTable(
                "dbo.Consulations",
                c => new
                {
                    consulation_id = c.Int(nullable: false, identity: true),
                    appointment_id = c.Int(nullable: false),
                    doctor_id = c.Int(nullable: false),
                    dianoisis = c.String(nullable: false),
                    created_at = c.DateTime(),
                })
                .PrimaryKey(t => t.consulation_id);

            CreateTable(
                "dbo.Users",
                c => new
                {
                    userId = c.Long(nullable: false, identity: true),
                    fullName = c.String(nullable: false),
                    dateOfBirth = c.DateTime(nullable: false),
                    gender = c.String(nullable: false),
                    phone = c.String(nullable: false),
                    email = c.String(nullable: false),
                    address = c.String(nullable: false),
                    password = c.String(nullable: false),
                    role = c.String(nullable: false),
                    createdAt = c.DateTime(nullable: false),
                    updatedAt = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.userId);

            CreateTable(
                "dbo.Appointments",
                c => new
                {
                    appointment_id = c.Int(nullable: false, identity: true),
                    patient_id = c.Long(nullable: false),
                    doctor_id = c.Long(nullable: false),
                    receptionist_id = c.Long(nullable: false),
                    appointment_date = c.DateTime(nullable: false),
                    appointment_time = c.Time(nullable: false, precision: 7),
                    status = c.String(),
                    reason = c.String(),
                    created_at = c.DateTime(nullable: false),
                    Users_userId = c.Long(),
                })
                .PrimaryKey(t => t.appointment_id);

            DropForeignKey("dbo.Medicines", "Prescription_prescription_id", "dbo.Prescriptions");
            DropForeignKey("dbo.Payments", "appointment_id", "dbo.Appointments");
            DropForeignKey("dbo.Patient_Record", "PatientId", "dbo.Users");
            DropForeignKey("dbo.Patient_Record", "DoctorId", "dbo.Users");
            DropForeignKey("dbo.Consulations", "Doctor_id", "dbo.Users");
            DropForeignKey("dbo.Consulations", "Appointment_id", "dbo.Appointments");
            DropForeignKey("dbo.Appointments", "ReceptionistId", "dbo.Users");
            DropForeignKey("dbo.Appointments", "PatientId", "dbo.Users");
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.Users");
            DropForeignKey("dbo.Appointments", "User_userId3", "dbo.Users");
            DropForeignKey("dbo.Appointments", "User_userId2", "dbo.Users");
            DropForeignKey("dbo.Appointments", "User_userId1", "dbo.Users");
            DropForeignKey("dbo.Appointments", "User_userId", "dbo.Users");
            DropIndex("dbo.Patient_Record", new[] { "DoctorId" });
            DropIndex("dbo.Patient_Record", new[] { "PatientId" });
            DropIndex("dbo.Medicines", new[] { "Prescription_prescription_id" });
            DropIndex("dbo.Consulations", new[] { "Doctor_id" });
            DropIndex("dbo.Consulations", new[] { "Appointment_id" });
            DropIndex("dbo.Appointments", new[] { "User_userId3" });
            DropIndex("dbo.Appointments", new[] { "User_userId2" });
            DropIndex("dbo.Appointments", new[] { "User_userId1" });
            DropIndex("dbo.Appointments", new[] { "User_userId" });
            DropIndex("dbo.Appointments", new[] { "ReceptionistId" });
            DropIndex("dbo.Appointments", new[] { "DoctorId" });
            DropIndex("dbo.Appointments", new[] { "PatientId" });
            DropColumn("dbo.Medicines", "Prescription_prescription_id");
            DropTable("dbo.Payments");
            DropTable("dbo.Patient_Record");
            DropTable("dbo.Consulations");
            DropTable("dbo.Users");
            DropTable("dbo.Appointments");
            CreateIndex("dbo.Patient_Records", "Users_userId");
            CreateIndex("dbo.Appointments", "Users_userId");
            AddForeignKey("dbo.Payments", "appointment_id", "dbo.Appointments", "appointment_id", cascadeDelete: true);
            AddForeignKey("dbo.Patient_Records", "Users_userId", "dbo.Users", "userId");
            AddForeignKey("dbo.Appointments", "Users_userId", "dbo.Users", "userId");
        }
    }
}
