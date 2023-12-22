namespace Educonnect.Common.Service.Application.LeadQualification.Queries
{
    public class GetLeadQuestionAnswersQuery : IRequest<IEnumerable<LeadQualificationQuestionAnswers>>
    {
        public class GetLeadQuestionAnswersQueryHandler : IRequestHandler<GetLeadQuestionAnswersQuery, IEnumerable<LeadQualificationQuestionAnswers>>
        {
            private readonly ICommonDbContext _context;
            public readonly IMapper _mapper;
            public GetLeadQuestionAnswersQueryHandler(ICommonDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<IEnumerable<LeadQualificationQuestionAnswers>> Handle(GetLeadQuestionAnswersQuery request, CancellationToken cancellationToken)
            {
                var finalData = new List<LeadQualificationQuestionAnswers>();
                try
                {
                    var leadQualId = _context.Form.Where(p => p.Title == "Lead Qualification Form").First().Id;
                    var Questions = (from fs in _context.Form.Where(x => x.ParentId == leadQualId)
                                     join
                                     fe in _context.FormEntity on fs.Id equals fe.FormId
                                     join rmd in _context.ReferenceMasterDetail on fe.FieldId equals rmd.ReferenceMasterDetailId
                                     where fe.Status == 1 && fs.Step > 1
                                     select new LeadQualificationQuestionAnswers
                                     {
                                         Id = fe.Id,
                                         Question = fs.Title,
                                         Title = fe.Title,
                                         IsMandatory = fe.Mandatory,
                                         Type = rmd.ReferenceMasterDetailDescription,
                                         Step = fs.Step.ToString(),
                                         NextStep = fs.NextStep == null ? String.Empty : fs.NextStep.ToString(),
                                         Score = fe.Score == null ? String.Empty : fe.Score.ToString(),
                                     }).ToList();

                    var Options = _context.FormEntityOption.Where(x => x.Status == 1).ToList();
                    foreach (var Quest in Questions)
                    {
                        var opt = Options.Where(x => x.FormEntityId == Quest.Id).ToList();
                        if (opt != null && opt.Any())
                        {
                            var optionList = new List<LeadQualificationOptions>();
                            foreach (var item in opt)
                            {
                                var newOption = _mapper.Map<LeadQualificationOptions>(item);
                                Quest.Options.Add(newOption);
                            }
                        }
                    }
                    return Questions.ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

    }
}
