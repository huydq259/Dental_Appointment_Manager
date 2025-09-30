namespace Dental_Appointment_Manager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.appointment_id)
                .ForeignKey("dbo.Users", t => t.Users_userId)
                .Index(t => t.Users_userId);
            
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
                "dbo.Medicines",
                c => new
                    {
                        medicine_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        description = c.String(),
                        dosage_form = c.String(),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.medicine_id);
            
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
                .PrimaryKey(t => t.record_id)
                .ForeignKey("dbo.Users", t => t.Users_userId)
                .Index(t => t.Users_userId);
            
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
                .PrimaryKey(t => t.payment_id)
                .ForeignKey("dbo.Appointments", t => t.appointment_id, cascadeDelete: true)
                .Index(t => t.appointment_id);
            
            CreateTable(
                "dbo.Prescriptions",
                c => new
                    {
                        prescription_id = c.Int(nullable: false, identity: true),
                        consulation_id = c.Int(nullable: false),
                        medicine_id = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                        dosage_instructions = c.String(),
                    })
                .PrimaryKey(t => t.prescription_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "appointment_id", "dbo.Appointments");
            DropForeignKey("dbo.Patient_Records", "Users_userId", "dbo.Users");
            DropForeignKey("dbo.Appointments", "Users_userId", "dbo.Users");
            DropIndex("dbo.Payments", new[] { "appointment_id" });
            DropIndex("dbo.Patient_Records", new[] { "Users_userId" });
            DropIndex("dbo.Appointments", new[] { "Users_userId" });
            DropTable("dbo.Prescriptions");
            DropTable("dbo.Payments");
            DropTable("dbo.Patient_Records");
            DropTable("dbo.Medicines");
            DropTable("dbo.Consulations");
            DropTable("dbo.Users");
            DropTable("dbo.Appointments");
        }
    }
}
