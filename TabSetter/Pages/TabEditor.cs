using Microsoft.AspNetCore.Components;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TabSetter.Model;
using TabSetter.Service.IService;

namespace TabSetter.Pages
{
    public partial class TabEditor
    {
        [Inject]
        private IFormService formService { get; set; }

        [Inject]
        private NavigationManager navigationManager { get; set; }

        [Parameter]
        public int FormId { get; set; }
        public int TabCount { get; set; }

        public PageMode Mode { get; set; }

        public string Heading => Mode == PageMode.TabPreview ? "Form Preview" : "Tab Editor";

        public List<InputDto> Fields { get; set; } = new List<InputDto>();

        public bool Invalid { get; set; }

        public bool IsProcessing { get; set; } = false;

        public enum PageMode
        {
            TabPreview = 1,
            TabEdit = 2
        }

        public void UpdateTabIndex(TabUpdate tabUpdateInfo)
        {
            var field = Fields.Single(f => f.InputId == tabUpdateInfo.InputId);
            field.TabIndex = tabUpdateInfo.TabIndex;
        }

        protected async override Task OnInitializedAsync()
        {
            IsProcessing = true;
            var form = await formService.GetForm(FormId);
            if (navigationManager.Uri.Contains("tab-editor"))
            {
                Mode = PageMode.TabEdit;
                if (form.Fields.Any(f => f.TabIndex.HasValue))
                {
                    Fields = form.Fields.Where(f => f.TabIndex.HasValue).OrderBy(o => o.TabIndex).ToList();
                    Fields.ForEach(f => f.TabIndex = null);
                }
                else
                {
                    Fields = form.Fields;
                }

            }
            else if (navigationManager.Uri.Contains("tab-preview"))
            {
                Mode = PageMode.TabPreview;
                if (form.Fields.Any(f => f.TabIndex.HasValue))
                {
                    Fields = form.Fields.Where(f => f.TabIndex.HasValue).OrderBy(o => o.TabIndex).ToList();
                    Fields.ForEach(f => f.TabIndex = null);
                }
                else
                {
                    Fields = form.Fields;
                }
            }

            IsProcessing = false;
        }

        public void EditTabs()
        {
            navigationManager.NavigateTo($"tab-editor/{FormId}", true);
        }

        public async Task ResetTabs()
        {
            await formService.ResetForm(FormId);
            navigationManager.NavigateTo($"tab-preview/{FormId}", true);
        }

        public void ClearTabs()
        {
            TabCount = 0;
            Fields.ForEach(f => f.TabIndex = null);
        }

        public async Task SaveTabs()
        {
            if (Fields.Any(f => f.Required && !f.TabIndex.HasValue))
            {
                Invalid = true;
            }
            else
            {
                await formService.SaveForm(new FormDto(FormId, Fields));
                navigationManager.NavigateTo($"tab-preview/{FormId}", true);
            }

        }
    }
}
