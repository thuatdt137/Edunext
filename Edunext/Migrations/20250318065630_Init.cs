using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Edunext.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    course_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    course_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    course_code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__courses__8F1EF7AE6535509B", x => x.course_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    first_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    role = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__users__B9BE370FA00220FC", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "slots",
                columns: table => new
                {
                    slot_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    course_id = table.Column<int>(type: "int", nullable: false),
                    slot_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    slot_order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__slots__971A01BB20D271D5", x => x.slot_id);
                    table.ForeignKey(
                        name: "FK__slots__course_id__45F365D3",
                        column: x => x.course_id,
                        principalTable: "courses",
                        principalColumn: "course_id");
                });

            migrationBuilder.CreateTable(
                name: "classrooms",
                columns: table => new
                {
                    class_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    course_id = table.Column<int>(type: "int", nullable: false),
                    semester_id = table.Column<int>(type: "int", nullable: false),
                    teacher_id = table.Column<int>(type: "int", nullable: false),
                    class_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__classroo__FDF4798686519007", x => x.class_id);
                    table.ForeignKey(
                        name: "FK__classroom__cours__3D5E1FD2",
                        column: x => x.course_id,
                        principalTable: "courses",
                        principalColumn: "course_id");
                    table.ForeignKey(
                        name: "FK__classroom__teach__3E52440B",
                        column: x => x.teacher_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "class_enrollments",
                columns: table => new
                {
                    enrollment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    class_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    enrollment_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__class_en__6D24AA7A9E6BC9DA", x => x.enrollment_id);
                    table.ForeignKey(
                        name: "FK__class_enr__class__4222D4EF",
                        column: x => x.class_id,
                        principalTable: "classrooms",
                        principalColumn: "class_id");
                    table.ForeignKey(
                        name: "FK__class_enr__user___4316F928",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "class_slot_contents",
                columns: table => new
                {
                    class_slot_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    class_id = table.Column<int>(type: "int", nullable: false),
                    slot_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__class_sl__D3C5C607CDFFC6B0", x => x.class_slot_id);
                    table.ForeignKey(
                        name: "FK__class_slo__class__48CFD27E",
                        column: x => x.class_id,
                        principalTable: "classrooms",
                        principalColumn: "class_id");
                    table.ForeignKey(
                        name: "FK__class_slo__slot___49C3F6B7",
                        column: x => x.slot_id,
                        principalTable: "slots",
                        principalColumn: "slot_id");
                });

            migrationBuilder.CreateTable(
                name: "assignments",
                columns: table => new
                {
                    assignment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    class_slot_id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    due_date = table.Column<DateOnly>(type: "date", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__assignme__DA8918149919EB8D", x => x.assignment_id);
                    table.ForeignKey(
                        name: "FK__assignmen__class__5535A963",
                        column: x => x.class_slot_id,
                        principalTable: "class_slot_contents",
                        principalColumn: "class_slot_id");
                });

            migrationBuilder.CreateTable(
                name: "questions",
                columns: table => new
                {
                    question_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    class_slot_id = table.Column<int>(type: "int", nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    from_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    to_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__question__2EC21549DC7B11A8", x => x.question_id);
                    table.ForeignKey(
                        name: "FK__questions__class__4D94879B",
                        column: x => x.class_slot_id,
                        principalTable: "class_slot_contents",
                        principalColumn: "class_slot_id");
                });

            migrationBuilder.CreateTable(
                name: "assignment_submissions",
                columns: table => new
                {
                    submission_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    assignment_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    submission_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    file_link = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    grade = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    feedback = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__assignme__9B53559592D3C123", x => x.submission_id);
                    table.ForeignKey(
                        name: "FK__assignmen__assig__59063A47",
                        column: x => x.assignment_id,
                        principalTable: "assignments",
                        principalColumn: "assignment_id");
                    table.ForeignKey(
                        name: "FK__assignmen__user___59FA5E80",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    comment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    question_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__comments__E7957687F24BEE12", x => x.comment_id);
                    table.ForeignKey(
                        name: "FK__comments__questi__5070F446",
                        column: x => x.question_id,
                        principalTable: "questions",
                        principalColumn: "question_id");
                    table.ForeignKey(
                        name: "FK__comments__user_i__5165187F",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_assignment_submissions_assignment_id",
                table: "assignment_submissions",
                column: "assignment_id");

            migrationBuilder.CreateIndex(
                name: "IX_assignment_submissions_user_id",
                table: "assignment_submissions",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_assignments_class_slot_id",
                table: "assignments",
                column: "class_slot_id");

            migrationBuilder.CreateIndex(
                name: "IX_class_enrollments_class_id",
                table: "class_enrollments",
                column: "class_id");

            migrationBuilder.CreateIndex(
                name: "IX_class_enrollments_user_id",
                table: "class_enrollments",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_class_slot_contents_class_id",
                table: "class_slot_contents",
                column: "class_id");

            migrationBuilder.CreateIndex(
                name: "IX_class_slot_contents_slot_id",
                table: "class_slot_contents",
                column: "slot_id");

            migrationBuilder.CreateIndex(
                name: "IX_classrooms_course_id",
                table: "classrooms",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_classrooms_teacher_id",
                table: "classrooms",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "IX_comments_question_id",
                table: "comments",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_comments_user_id",
                table: "comments",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "UQ__courses__AB6B45F103E2EF26",
                table: "courses",
                column: "course_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_questions_class_slot_id",
                table: "questions",
                column: "class_slot_id");

            migrationBuilder.CreateIndex(
                name: "IX_slots_course_id",
                table: "slots",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "UQ__users__AB6E6164F23AD1D8",
                table: "users",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "assignment_submissions");

            migrationBuilder.DropTable(
                name: "class_enrollments");

            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "assignments");

            migrationBuilder.DropTable(
                name: "questions");

            migrationBuilder.DropTable(
                name: "class_slot_contents");

            migrationBuilder.DropTable(
                name: "classrooms");

            migrationBuilder.DropTable(
                name: "slots");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "courses");
        }
    }
}
