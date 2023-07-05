using ArticleApp.Models.Articles;
using Dul.Domain.Common;
using Dul.Web;
using Microsoft.AspNetCore.Components;

namespace ArticleApp.Articles
{
    /// <summary>
    /// partial class로 생성해줘야 코드 비하인드로 동작한다.
    /// </summary>
    public partial class Index
    {
        /// <summary>
        /// @inject 특성 적용
        /// </summary>
        [Inject]
        public IArticleRepository ArticleRepository { get; set; }

        [Inject]
        public NavigationManager Navigationmanager { get; set; }

        private List<Article> articles;

        // 페이지 기본값 설정 - Dul
        private PagerBase pager = new PagerBase()
        {
            PageNumber = 1,
            PageIndex = 0, // PageNumber -1
            PageSize = 2,
            PagerButtonCount = 3
        };

        protected override async Task OnInitializedAsync()
        {
            // [1] 전체 데이터 모두 출력
            //articles = await ArticleRepository.GetArticlesAsync();

            // [2] 페이징 처리된 데이터만 출력
            PagingResult<Article> pagingData = await ArticleRepository.GetAllAsync(pager.PageIndex, pager.PageSize);
            pager.RecordCount = pagingData.TotalRecords; // 총 레코드 수
            articles = pagingData.Records.ToList(); // 페이징 처리된 레코드

        }

        // Pager 버튼 클릭 콜백 메서드
        private async void PageIndexChanged(int pageIndex)
        {
            pager.PageIndex = pageIndex;
            pager.PageNumber = pageIndex + 1;

            var pagingData = await ArticleRepository.GetAllAsync(pager.PageIndex, pager.PageSize);
            pager.RecordCount = pagingData.TotalRecords; // 총 레코드 수
            articles = pagingData.Records.ToList(); // 페이징 처리된 레코드

            StateHasChanged(); // 현재 컴포넌트 재로드
        }


        /// <summary>
        /// 제목의 td 태그 영역을 클릭했을 때 해당 상세보기 페이지로 이동
        /// </summary>
        /// <param name="id"></param>
        private void btnTitle_Click(int id)
        {
            Navigationmanager.NavigateTo($"/Articles/Details/{id}");
        }


    }
}
