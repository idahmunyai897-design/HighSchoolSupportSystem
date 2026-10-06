using HighSchoolSupportSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HighSchoolSupportSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SchoolSubject> SchoolSubjects { get; set; }
        public DbSet<SubjectGroup> SubjectGroups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<ParentGuardian> ParentGuardians { get; set; }
        public DbSet<StudentParentGuardian> StudentParentGuardians { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherStudent> TeacherStudents { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<StudentTutor> StudentTutors { get; set; }
        public DbSet<ExternalTutor> ExternalTutors { get; set; }
        public DbSet<TutorSubject> TutorSubjects { get; set; }
        public DbSet<Availability> Availabilities { get; set; }
        public DbSet<TutorApproval> TutorApprovals { get; set; }
        public DbSet<SupportRequest> SupportRequests { get; set; }
        public DbSet<TutorAssignment> TutorAssignments { get; set; }
        public DbSet<SupportSession> SupportSessions { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<StudentFeedback> StudentFeedbacks { get; set; }
        public DbSet<TutorFeedback> TutorFeedbacks { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ==========================================
            // SCHOOL → GRADE
            // One School has many Grades
            // ==========================================
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.School)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.SchoolId)
                .OnDelete(DeleteBehavior.Restrict);


            // ==========================================
            // GRADE → STUDENT
            // One Grade has many Students
            // ==========================================
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Grade)
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.GradeId)
                .OnDelete(DeleteBehavior.Restrict);


            // ==========================================
            // SCHOOL SUBJECT
            // SchoolSubject → School
            // ==========================================
            modelBuilder.Entity<SchoolSubject>()
                .HasOne(ss => ss.School)
                .WithMany(s => s.SchoolSubjects)
                .HasForeignKey(ss => ss.SchoolId)
                .OnDelete(DeleteBehavior.Restrict);


            // ==========================================
            // SCHOOL SUBJECT
            // SchoolSubject → Grade
            // ==========================================
            modelBuilder.Entity<SchoolSubject>()
                .HasOne(ss => ss.Grade)
                .WithMany(g => g.SchoolSubjects)
                .HasForeignKey(ss => ss.GradeId)
                .OnDelete(DeleteBehavior.Restrict);


            // ==========================================
            // SCHOOL SUBJECT
            // SchoolSubject → Subject
            // ==========================================
            modelBuilder.Entity<SchoolSubject>()
                .HasOne(ss => ss.Subject)
                .WithMany(s => s.SchoolSubjects)
                .HasForeignKey(ss => ss.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);


            // ==========================================
            // SUBJECT GROUP
            // SubjectGroup → Grade
            // ==========================================
            modelBuilder.Entity<SubjectGroup>()
                .HasOne(sg => sg.Grade)
                .WithMany(g => g.SubjectGroups)
                .HasForeignKey(sg => sg.GradeId)
                .OnDelete(DeleteBehavior.Restrict);


            // ==========================================
            // SCHOOL SUBJECT → SUBJECT GROUP
            // Optional relationship
            // ==========================================
            modelBuilder.Entity<SchoolSubject>()
                .HasOne(ss => ss.SubjectGroup)
                .WithMany(sg => sg.SchoolSubjects)
                .HasForeignKey(ss => ss.SubjectGroupId)
                .OnDelete(DeleteBehavior.Restrict);


            // ==========================================
            // STUDENT SUBJECT
            // Student → StudentSubject
            // ==========================================
            modelBuilder.Entity<StudentSubject>()
                .HasOne(ss => ss.Student)
                .WithMany(s => s.StudentSubjects)
                .HasForeignKey(ss => ss.StudentId)
                .OnDelete(DeleteBehavior.Restrict);


            // ==========================================
            // STUDENT SUBJECT
            // Subject → StudentSubject
            // ==========================================
            modelBuilder.Entity<StudentSubject>()
                .HasOne(ss => ss.Subject)
                .WithMany(s => s.StudentSubjects)
                .HasForeignKey(ss => ss.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);


            // ==========================================
            // STUDENT ↔ PARENT/GUARDIAN
            // ==========================================
            modelBuilder.Entity<StudentParentGuardian>()
                .HasOne(spg => spg.Student)
                .WithMany(s => s.StudentParentGuardians)
                .HasForeignKey(spg => spg.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StudentParentGuardian>()
                .HasOne(spg => spg.ParentGuardian)
                .WithMany(pg => pg.StudentParentGuardians)
                .HasForeignKey(spg => spg.ParentGuardianId)
                .OnDelete(DeleteBehavior.Restrict);


            // ==========================================
            // TEACHER ↔ STUDENT
            // ==========================================
            modelBuilder.Entity<TeacherStudent>()
                .HasOne(ts => ts.Teacher)
                .WithMany(t => t.TeacherStudents)
                .HasForeignKey(ts => ts.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TeacherStudent>()
                .HasOne(ts => ts.Student)
                .WithMany(s => s.TeacherStudents)
                .HasForeignKey(ts => ts.StudentId)
                .OnDelete(DeleteBehavior.Restrict);


            // ==========================================
            // STUDENT TUTOR
            // StudentTutor → Tutor
            // ==========================================
            modelBuilder.Entity<StudentTutor>()
                .HasOne(st => st.Tutor)
                .WithOne(t => t.StudentTutor)
                .HasForeignKey<StudentTutor>(st => st.TutorId)
                .OnDelete(DeleteBehavior.Restrict);


            // ==========================================
            // STUDENT TUTOR
            // StudentTutor → Student
            // ==========================================
            modelBuilder.Entity<StudentTutor>()
                .HasOne(st => st.Student)
                .WithMany(s => s.StudentTutors)
                .HasForeignKey(st => st.StudentId)
                .OnDelete(DeleteBehavior.Restrict);


            // ==========================================
            // EXTERNAL TUTOR
            // ExternalTutor → Tutor
            // ==========================================
            modelBuilder.Entity<ExternalTutor>()
                .HasOne(et => et.Tutor)
                .WithOne(t => t.ExternalTutor)
                .HasForeignKey<ExternalTutor>(et => et.TutorId)
                .OnDelete(DeleteBehavior.Restrict);


            // ==========================================
            // TUTOR SUBJECT
            // Tutor → TutorSubject
            // ==========================================
            modelBuilder.Entity<TutorSubject>()
                .HasOne(ts => ts.Tutor)
                .WithMany(t => t.TutorSubjects)
                .HasForeignKey(ts => ts.TutorId)
                .OnDelete(DeleteBehavior.Restrict);


            // ==========================================
            // TUTOR SUBJECT
            // Subject → TutorSubject
            // ==========================================
            modelBuilder.Entity<TutorSubject>()
                .HasOne(ts => ts.Subject)
                .WithMany(s => s.TutorSubjects)
                .HasForeignKey(ts => ts.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);


            // ==========================================
            // TUTOR → AVAILABILITY
            // One Tutor has many Availability records
            // ==========================================
            modelBuilder.Entity<Availability>()
                .HasOne(a => a.Tutor)
                .WithMany(t => t.Availabilities)
                .HasForeignKey(a => a.TutorId)
                .OnDelete(DeleteBehavior.Restrict);


            // ==========================================
            // TUTOR APPROVAL
            // Tutor → TutorApproval
            // ==========================================
            modelBuilder.Entity<TutorApproval>()
                .HasOne(ta => ta.Tutor)
                .WithMany(t => t.TutorApprovals)
                .HasForeignKey(ta => ta.TutorId)
                .OnDelete(DeleteBehavior.Restrict);


            // ==========================================
            // TUTOR APPROVAL
            // Teacher → TutorApproval
            // ==========================================
            modelBuilder.Entity<TutorApproval>()
                .HasOne(ta => ta.ApprovedByTeacher)
                .WithMany(t => t.TutorApprovals)
                .HasForeignKey(ta => ta.ApprovedByTeacherId)
                .OnDelete(DeleteBehavior.Restrict);


            // ==========================================
            // SUPPORT REQUEST
            // Student → SupportRequest
            // ==========================================
            modelBuilder.Entity<SupportRequest>()
                .HasOne(sr => sr.Student)
                .WithMany(s => s.SupportRequests)
                .HasForeignKey(sr => sr.StudentId)
                .OnDelete(DeleteBehavior.Restrict);


            // ==========================================
            // SUPPORT REQUEST
            // Subject → SupportRequest
            // ==========================================
            modelBuilder.Entity<SupportRequest>()
                .HasOne(sr => sr.Subject)
                .WithMany()
                .HasForeignKey(sr => sr.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);


            // ==========================================
            // SUPPORT REQUEST
            // User → SupportRequest
            // ==========================================
            modelBuilder.Entity<SupportRequest>()
                .HasOne(sr => sr.CreatedByUser)
                .WithMany(u => u.SupportRequestsCreated)
                .HasForeignKey(sr => sr.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);


            // ==========================================
            // TUTOR ASSIGNMENT
            // SupportRequest → TutorAssignment
            // ==========================================
            modelBuilder.Entity<TutorAssignment>()
                .HasOne(ta => ta.SupportRequest)
                .WithMany(sr => sr.TutorAssignments)
                .HasForeignKey(ta => ta.SupportRequestId)
                .OnDelete(DeleteBehavior.Restrict);


            // ==========================================
            // TUTOR ASSIGNMENT
            // Tutor → TutorAssignment
            // ==========================================
            modelBuilder.Entity<TutorAssignment>()
                .HasOne(ta => ta.Tutor)
                .WithMany(t => t.TutorAssignments)
                .HasForeignKey(ta => ta.TutorId)
                .OnDelete(DeleteBehavior.Restrict);


            // ==========================================
            // TUTOR ASSIGNMENT
            // Teacher → TutorAssignment
            // ==========================================
            modelBuilder.Entity<TutorAssignment>()
                .HasOne(ta => ta.AssignedByTeacher)
                .WithMany(t => t.TutorAssignments)
                .HasForeignKey(ta => ta.AssignedByTeacherId)
                .OnDelete(DeleteBehavior.Restrict);


            // ==========================================
            // SUPPORT SESSION
            // TutorAssignment → SupportSession
            // ==========================================
            modelBuilder.Entity<SupportSession>()
                .HasOne(ss => ss.TutorAssignment)
                .WithMany(ta => ta.SupportSessions)
                .HasForeignKey(ss => ss.TutorAssignmentId)
                .OnDelete(DeleteBehavior.Restrict);


            // ==========================================
            // ATTENDANCE
            // SupportSession → Attendance
            // One Session has one Attendance record
            // ==========================================
            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.SupportSession)
                .WithOne(ss => ss.Attendance)
                .HasForeignKey<Attendance>(a => a.SupportSessionId)
                .OnDelete(DeleteBehavior.Restrict);


            // ==========================================
            // STUDENT FEEDBACK
            // SupportSession → StudentFeedback
            // ==========================================
            modelBuilder.Entity<StudentFeedback>()
                .HasOne(sf => sf.SupportSession)
                .WithOne(ss => ss.StudentFeedback)
                .HasForeignKey<StudentFeedback>(sf => sf.SupportSessionId)
                .OnDelete(DeleteBehavior.Restrict);


            // ==========================================
            // STUDENT FEEDBACK
            // Student → StudentFeedback
            // ==========================================
            modelBuilder.Entity<StudentFeedback>()
                .HasOne(sf => sf.Student)
                .WithMany(s => s.StudentFeedbacks)
                .HasForeignKey(sf => sf.StudentId)
                .OnDelete(DeleteBehavior.Restrict);


            // ==========================================
            // TUTOR FEEDBACK
            // SupportSession → TutorFeedback
            // ==========================================
            modelBuilder.Entity<TutorFeedback>()
                .HasOne(tf => tf.SupportSession)
                .WithOne(ss => ss.TutorFeedback)
                .HasForeignKey<TutorFeedback>(tf => tf.SupportSessionId)
                .OnDelete(DeleteBehavior.Restrict);


            // ==========================================
            // TUTOR FEEDBACK
            // Tutor → TutorFeedback
            // ==========================================
            modelBuilder.Entity<TutorFeedback>()
                .HasOne(tf => tf.Tutor)
                .WithMany(t => t.TutorFeedbacks)
                .HasForeignKey(tf => tf.TutorId)
                .OnDelete(DeleteBehavior.Restrict);


            // ==========================================
            // TUTOR FEEDBACK
            // Student → TutorFeedback
            // ==========================================
            modelBuilder.Entity<TutorFeedback>()
                .HasOne(tf => tf.Student)
                .WithMany()
                .HasForeignKey(tf => tf.StudentId)
                .OnDelete(DeleteBehavior.Restrict);


            // ==========================================
            // NOTIFICATION
            // User → Notification
            // ==========================================
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}