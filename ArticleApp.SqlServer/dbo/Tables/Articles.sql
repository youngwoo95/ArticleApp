-- 게시판 테이블
CREATE TABLE [dbo].[Articles]
(
	[Id] Int Not Null Primary key Identity(1,1), -- 일련번호
	[Title] Nvarchar(255) Not Null, -- 제목

	-- TODO: Columns Add Region

	-- AuditableBase.cs 참조
	[CreatedBy] Nvarchar(255) Null, -- 등록자(Creator)
	[Created] DateTime Default(GetDate()), -- 생성일
	[ModifiedBy] Nvarchar(255) Null, -- 수정자 (LastModifiedBy)
	[Modified] DateTime null, 
    [IsPinned] BIT NULL DEFAULT 0, -- 수정일 (LastModified)
)
Go
