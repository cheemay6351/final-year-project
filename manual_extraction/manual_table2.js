var MongoClient = require("mongodb").MongoClient;
var connect = require("../connect"); // url from connect module
var client = new MongoClient(connect.database.url, {
    useUnifiedTopology: true,
});

var dbName = "Beers_Criteria"; // database name

// used javascript as initial language for manual insertion of data
// 2023 American Geriatrics Society Beers Criteria® for potentially inappropriate medication use in older adults.
async function insertMed(db) {
    var collection = db.collection('Table2');
    var userObjects1 = [
        {
            ID: 1,
            Category: '',
            Drug_Class: 'Antihistamines',
            Drug_Class_Category: 'First-generation antihistamines',
            Drug_Name: ['Brompheniramine', 'Chlorpheniramine', 'Cyproheptadine', 'Dimenhydrinate', 'Diphenhydramine (oral)', 'Doxylamine', 'Hydroxyzine', 'Meclizine', 'Promethazine', 'Triprolidine'],
            Rationale: 'Highly anticholinergic; clearance reduced with advanced age, and tolerance develops when used as hypnotic; risk of confusion, dry mouth, constipation, and other anticholinergic effects or toxicity. Cumulative exposure to anticholinergic drugs is associated with an increased risk of falls, delirium, and dementia, even in younger adults. Consider total anticholinergic burden during regular medication reviews and be cautious in “young-old” as well as “old-old” adults. Use of diphenhydramine in situations such as acute treatment of severe allergic reactions may be appropriate.',
            Recommendation: 'Avoid',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 2,
            Category: 'Anti-infective',
            Drug_Class: '',
            Drug_Class_Category: '',
            Drug_Name: 'Nitrofurantoin',
            Rationale: 'Potential for pulmonary toxicity, hepatoxicity, and peripheral neuropathy, especially with long-term use; safer alternatives available.',
            Recommendation: 'Avoid in individuals with CrCl <30 mL/ min or for long-term suppression.',
            Quality_of_Evidence: 'Low',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 3,
            Category: 'Cardiovascular and antithrombotics',
            Drug_Class: '',
            Drug_Class_Category: 'Aspirin for primary prevention of cardiovascular disease',
            Drug_Name: '',
            Rationale: 'Risk of major bleeding from aspirin increases markedly in older age. Studies suggest a lack of net benefit and potential for net harm when initiated for primary prevention in older adults. There is less evidence about stopping aspirin among long-term users, although similar principles for initiation may apply. Note: Aspirin is generally indicated for secondary prevention in older adults with established cardiovascular disease.',
            Recommendation: 'Avoid initiating aspirin for primary prevention of cardiovascular disease. Consider deprescribing aspirin in older adults already taking it for primary prevention.',
            Quality_of_Evidence: 'High',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 4,
            Category: 'Cardiovascular and antithrombotics',
            Drug_Class: '',
            Drug_Class_Category: 'Warfarin for the treatment of nonvalvular atrial fibrillation or venous thromboembolism (VTE)',
            Drug_Name: '',
            Rationale: 'Compared with DOACs, warfarin has higher risks of major bleeding (particularly intracranial bleeding) and similar or lower effectiveness for the treatment of nonvalvular atrial fibrillation and VTE. DOACs are thus the preferred choice for anticoagulation for most people with these conditions.',
            Recommendation: 'Avoid starting warfarin as initial therapy for the treatment of nonvalvular atrial fibrillation or VTE unless alternative options (i.e., DOACs) are contraindicated or there are substantial barriers to their use. For older adults who have been using warfarin long-term, it may be reasonable to continue this medication, particularly among those with well-controlled INRs (i.e., >70% time in the therapeutic range) and no adverse effects. See also criteria on rivaroxaban (Table 2) and dabigatran (Table 4) and footnote regarding choice among DOACs.',
            Quality_of_Evidence: 'High',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 5,
            Category: 'Cardiovascular and antithrombotics',
            Drug_Class: '',
            Drug_Class_Category: 'Rivaroxaban for long-term treatment of nonvalvular atrial fibrillation or venous thromboembolism (VTE)',
            Drug_Name: '',
            Rationale: 'At doses used for long-term treatment of VTE or nonvalvular atrial fibrillation, rivaroxaban appears to have a higher risk of major bleeding and GI bleeding in older adults than other DOACs, particularly apixaban. Rivaroxaban may be reasonable in special situations, for example when once daily dosing is necessary to facilitate medication adherence. All DOACs confer a lower risk of intracranial hemorrhage than warfarin.',
            Recommendation: 'Avoid for long-term treatment of atrial fibrillation or VTE in favor of safer anticoagulant alternatives. See also criteria on warfarin (Table 2) and dabigatran (Table 4) and footnote regarding the choice between warfarin and DOACs and among DOACs.',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 6,
            Category: 'Cardiovascular and antithrombotics',
            Drug_Class: '',
            Drug_Class_Category: '',
            Drug_Name: 'Dipyridamole, oral short-acting (does not apply to extended-release combination with aspirin)',
            Rationale: 'May cause orthostatic hypotension; more effective alternatives available; IV form acceptable for use in cardiac stress testing.',
            Recommendation: 'Avoid',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 7,
            Category: 'Cardiovascular and antithrombotics',
            Drug_Class: '',
            Drug_Class_Category: 'Non-selective peripheral alpha-1 blockers for the treatment of hypertension',
            Drug_Name: ['Doxazosin', 'Prazosin', 'Terazosin'],
            Rationale: 'High risk of orthostatic hypotension and associated harms, especially in older adults; not recommended as routine treatment for hypertension; alternative agents have superior risk/benefit profile.',
            Recommendation: 'Avoid use as an antihypertensive.',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 8,
            Category: 'Cardiovascular and antithrombotics',
            Drug_Class: '',
            Drug_Class_Category: 'Central alpha-agonists for the treatment of hypertension',
            Drug_Name: ['Clonidine', 'Guanfacine'],
            Rationale: 'High risk of adverse CNS effects; may cause bradycardia and orthostatic hypotension; not recommended as routine treatment for hypertension.',
            Recommendation: 'Avoid clonidine as first-line treatment for hypertension. Avoid other central alpha-agonists for the treatment of hypertension.',
            Quality_of_Evidence: 'Low',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 9,
            Category: 'Cardiovascular and antithrombotics',
            Drug_Class: '',
            Drug_Class_Category: '',
            Drug_Name: 'Nifedipine, immediate release',
            Rationale: 'Potential for hypotension; risk of precipitating myocardial ischemia.',
            Recommendation: 'Avoid',
            Quality_of_Evidence: 'High',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 10,
            Category: 'Cardiovascular and antithrombotics',
            Drug_Class: '',
            Drug_Class_Category: '',
            Drug_Name: 'Amiodarone',
            Rationale: 'Effective for maintaining sinus rhythm but has greater toxicities than other antiarrhythmics used in atrial fibrillation; may be reasonable first-line therapy in patients with concomitant heart failure or substantial left ventricular hypertrophy if rhythm control is preferred over rate control.',
            Recommendation: 'Avoid as first-line therapy for atrial fibrillation unless the patient has heart failure or substantial left ventricular hypertrophy.',
            Quality_of_Evidence: 'High',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 11,
            Category: 'Cardiovascular and antithrombotics',
            Drug_Class: '',
            Drug_Class_Category: '',
            Drug_Name: 'Dronedarone',
            Rationale: 'Worse outcomes in people who have permanent atrial fibrillation or severe or recently decompensated heart failure. In some circumstances, worse outcomes have also been reported in people with HFrEF (e.g., left ventricular ejection fraction ≤35%) who have milder symptoms (NYHA class I or II).',
            Recommendation: 'Avoid in individuals with permanent atrial fibrillation or severe or recently decompensated heart failure. Use caution in patients with HFrEF with less severe symptoms (NYHA class I or II).',
            Quality_of_Evidence: 'High',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 12,
            Category: 'Cardiovascular and antithrombotics',
            Drug_Class: '',
            Drug_Class_Category: 'Digoxin for first-line treatment of atrial fibrillation or heart failure',
            Drug_Name: '',
            Rationale: 'Use in atrial fibrillation: should not be used as a first-line agent because there are safer and more effective alternatives for rate control. Use in heart failure: evidence for benefits and harms of digoxin is conflicting and of lower quality; most (but not all) evidence concerns use in HFrEF. There is strong evidence for other agents as first- line therapy to reduce hospitalizations and mortality in adults with HFrEF. In heart failure, higher dosages are not associated with additional benefits and may increase the risk of toxicity. Use caution in discontinuing digoxin among current users with HFrEF, given limited evidence suggesting worse clinical outcomes after discontinuation. Decreased renal clearance of digoxin may lead to an increased risk of toxic effects; further dose reduction may be necessary for those with Stage 4 or 5 chronic kidney disease.',
            Recommendation: 'Avoid this rate control agent as first-line therapy for atrial fibrillation. Avoid as first-line therapy for heart failure. See rationale for caution about withdrawal in long-term users with HFrEF. If used for atrial fibrillation or heart failure, avoid dosages >0.125 mg/day.',
            Quality_of_Evidence: 'Atrial fibrillation; heart failure: low. Dosage > 0.125 mg/day: moderate.',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 13,
            Category: 'Central nervous system',
            Drug_Class: '',
            Drug_Class_Category: 'Antidepressants with strong anticholinergic activity, alone or in combination',
            Drug_Name: ['Amitriptyline', 'Amoxapine', 'Clomipramine', 'Desipramine', 'Doxepin >6 mg/day', 'Imipramine', 'Nortriptyline', 'Paroxetine'],
            Rationale: 'Highly anticholinergic, sedating, and cause orthostatic hypotension; the safety profile of low-dose doxepin (≤6 mg/day) is comparable to that of placebo.',
            Recommendation: 'Avoid',
            Quality_of_Evidence: 'High',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 14,
            Category: 'Central nervous system',
            Drug_Class: '',
            Drug_Class_Category: 'Antiparkinsonian agents with strong anticholinergic activity',
            Drug_Name: ['Benztropine (oral)', 'Trihexyphenidyl'],
            Rationale: 'Not recommended for prevention or treatment of extrapyramidal symptoms due to antipsychotics; more effective agents available for the treatment of Parkinson disease.',
            Recommendation: 'Avoid',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 15,
            Category: 'Central nervous system',
            Drug_Class: '',
            Drug_Class_Category: 'Antipsychotics, first- (typical) and second- (atypical) generation',
            Drug_Name: ['Aripiprazole', 'Haloperidol', 'Olanzapine', 'Quetiapine', 'Risperidone','Others'],
            Rationale: 'Increased risk of stroke and greater rate of cognitive decline and mortality in persons with dementia. Additional evidence suggests an association of increased risk between antipsychotic medication and mortality independent of dementia. Avoid antipsychotics for behavioral problems of dementia or delirium unless documented nonpharmacologic options (e.g., behavioral interventions) have failed and/or the patient is threatening substantial harm to self or others. If used, periodic deprescribing attempts should be considered to assess ongoing need and/or the lowest effective dose.',
            Recommendation: 'Avoid, except in FDA-approved indications such as schizophrenia, bipolar disorder, Parkinson disease psychosis (see Table 3), adjunctive treatment of major depressive disorder, or for short-term use as an antiemetic.',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 16,
            Category: 'Central nervous system',
            Drug_Class: 'Barbiturates',
            Drug_Class_Category: '',
            Drug_Name: ['Butalbital', 'Phenobarbital', 'Primidone'],
            Rationale: 'High rate of physical dependence, tolerance to sleep benefits, greater risk of overdose at low dosages.',
            Recommendation: 'Avoid',
            Quality_of_Evidence: 'High',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 17,
            Category: 'Central nervous system',
            Drug_Class: 'Benzodiazepines',
            Drug_Class_Category: '',
            Drug_Name: ['Alprazolam', 'Chlordiazepoxide (alone or in combination with amitriptyline or clidinium)', 'Clobazam', 'Clonazepam', 'Clorazepate', 'Diazepam', 'Estazolam', 'Lorazepam', 'Midazolam', 'Oxazepam', 'Temazepam', 'Triazolam'],
            Rationale: 'The use of benzodiazepines exposes users to risks of abuse, misuse, and addiction. Concomitant use of opioids may result in profound sedation, respiratory depression, coma, and death. Older adults have increased sensitivity to benzodiazepines and decreased metabolism of long-acting agents; the continued use of benzodiazepines may lead to clinically significant physical dependence. In general, all benzodiazepines increase the risk of cognitive impairment, delirium, falls, fractures, and motor vehicle crashes in older adults. May be appropriate for seizure disorders, rapid eye movement sleep behavior disorder, benzodiazepine withdrawal, ethanol withdrawal, severe generalized anxiety disorder, and periprocedural anesthesia.',
            Recommendation: 'Avoid',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 18,
            Category: 'Central nervous system',
            Drug_Class: '',
            Drug_Class_Category: 'Nonbenzodiazepine benzodiazepine receptor agonist hypnotics (“Z-drugs”)',
            Drug_Name: ['Eszopiclone', 'Zaleplon', 'Zolpidem'],
            Rationale: 'Nonbenzodiazepine benzodiazepine receptor agonist hypnotics (“Z-drugs”) have adverse events similar to those of benzodiazepines in older adults (e.g., delirium, falls, fractures, increased emergency room visits/ hospitalizations, motor vehicle crashes); minimal improvement in sleep latency and duration.',
            Recommendation: 'Avoid',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 19,
            Category: 'Central nervous system',
            Drug_Class: '',
            Drug_Class_Category: '',
            Drug_Name: 'Meprobamate',
            Rationale: 'High rate of physical dependence; very sedating.',
            Recommendation: 'Avoid',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 20,
            Category: 'Central nervous system',
            Drug_Class: '',
            Drug_Class_Category: '',
            Drug_Name: 'Ergoloid mesylates (dehydrogenated ergot alkaloids)',
            Rationale: 'Lack of efficacy.',
            Recommendation: 'Avoid',
            Quality_of_Evidence: 'High',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 21,
            Category: 'Endocrine',
            Drug_Class: 'Androgens',
            Drug_Class_Category: '',
            Drug_Name: ['Methyltestosterone', 'Testosterone'],
            Rationale: 'Potential for cardiac problems; potential risks in men with prostate cancer.',
            Recommendation: 'Avoid unless indicated for confirmed hypogonadism with clinical symptoms.',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Weak',
        },
        {
            ID: 22,
            Category: 'Endocrine',
            Drug_Class: '',
            Drug_Class_Category: 'Estrogens with or without progestins (includes natural and synthetic estrogen preparations)',
            Drug_Name: '',
            Rationale: 'Evidence of carcinogenic potential (breast and endometrium); lack of cardioprotective effect and cognitive protection in older women. For women who start HRT at age 60 and older, the risks of HRT are greater than the benefits, as HRT is linked to a higher risk of heart disease, stroke, blood clots, and dementia. Evidence indicates that vaginal estrogens for the treatment of vaginal dryness are safe and effective; women with a history of breast cancer who do not respond to nonhormonal therapies are advised to discuss the risks and benefits of low-dose vaginal estrogen (e.g., dosages of estradiol <25 mcg twice weekly) with their healthcare provider.',
            Recommendation: 'Do not initiate systemic estrogen (e.g., oral tablets or transdermal patches). Consider deprescribing among older women already using this medication. Vaginal cream or vaginal tablets: acceptable to use low-dose intravaginal estrogen for the management of dyspareunia, recurrent lower urinary tract infections, and other vaginal symptoms.',
            Quality_of_Evidence: 'Oral and patch: high. Vaginal cream or vaginal tablets: moderate',
            Strength_of_Recommendation: 'Oral and patch: strong. Topical vaginal cream or tablets: weak',
        },
        {
            ID: 23,
            Category: 'Endocrine',
            Drug_Class: '',
            Drug_Class_Category: 'Insulin, sliding scale (insulin regimens containing only short- or rapid-acting insulin dosed according to current blood glucose levels without concurrent use of basal or long-acting insulin)',
            Drug_Name: '',
            Rationale: 'Higher risk of hypoglycemia without improvement in hyperglycemia management regardless of care setting. Avoid insulin regimens that include only short- or rapid- acting insulin dosed according to current blood glucose levels without concurrent use of basal or long-acting insulin. This recommendation does not apply to regimens that contain basal insulin or long-acting insulin.',
            Recommendation: 'Avoid',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 24,
            Category: 'Endocrine',
            Drug_Class: 'Sulfonylureas (all, including short- and longer-acting)',
            Drug_Class_Category: '',
            Drug_Name: ['Gliclazide', 'Glimepiride', 'Glipizide', 'Glyburide (Glibenclamide)'],
            Rationale: 'Sulfonylureas have a higher risk of cardiovascular events, all-cause mortality, and hypoglycemia than alternative agents. Sulfonylureas may increase the risk of cardiovascular death and ischemic stroke. Among sulfonylureas, long-acting agents (e.g., glyburide, glimepiride) confer a higher risk of prolonged hypoglycemia than short-acting agents (e.g., glipizide).',
            Recommendation: 'Avoid sulfonylureas as first- or second-line monotherapy or add-on therapy unless there are substantial barriers to the use of safer and more effective agents. If a sulfonylurea is used, choose short-acting agents (e.g., glipizide) over long-acting agents (e.g., glyburide, glimepiride).',
            Quality_of_Evidence: 'Hypoglycemia: High. CV events and all-cause mortality: Moderate. CV death and ischemic stroke: Low',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 25,
            Category: 'Endocrine',
            Drug_Class: '',
            Drug_Class_Category: '',
            Drug_Name: 'Desiccated thyroid',
            Rationale: 'Concerns about cardiac effects; safer alternatives available.',
            Recommendation: 'Avoid',
            Quality_of_Evidence: 'Low',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 26,
            Category: 'Endocrine',
            Drug_Class: '',
            Drug_Class_Category: '',
            Drug_Name: 'Megestrol',
            Rationale: 'Minimal effect on weight; increases the risk of thrombotic events and possibly death in older adults.',
            Recommendation: 'Avoid',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 27,
            Category: 'Endocrine',
            Drug_Class: '',
            Drug_Class_Category: '',
            Drug_Name: 'Growth hormone',
            Rationale: 'Impact on body composition is small and associated with edema, arthralgia, carpal tunnel syndrome, gynecomastia, and impaired fasting glucose.',
            Recommendation: 'Avoid, except for patients rigorously diagnosed by evidence-based criteria with growth hormone deficiency due to an established etiology.',
            Quality_of_Evidence: 'High',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 28,
            Category: 'Gastrointestinal',
            Drug_Class: 'Proton-pump inhibitors',
            Drug_Class_Category: '',
            Drug_Name: ['Dexlansoprazole', 'Esomeprazole', 'Lansoprazole', 'Omeprazole', 'Pantoprazole', 'Rabeprazole'],
            Rationale: 'Risk of C. difficile infection, pneumonia, GI malignancies, bone loss, and fractures.',
            Recommendation: 'Avoid scheduled use for >8 weeks unless for high-risk patients (e.g., oral corticosteroids or chronic NSAID use), erosive esophagitis, Barretts esophagitis, pathologic hypersecretory condition, or demonstrated need for maintenance treatment (e.g., because of failure of drug discontinuation trial or H2-receptor antagonists).',
            Quality_of_Evidence: 'C. difficile, bone loss, and fractures: High. Pneumonia and GI malignancies: Moderate.',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 29,
            Category: 'Gastrointestinal',
            Drug_Class: '',
            Drug_Class_Category: '',
            Drug_Name: 'Metoclopramide',
            Rationale: 'Can cause extrapyramidal effects, including tardive dyskinesia; the risk may be greater in frail older adults and with prolonged exposure.',
            Recommendation: 'Avoid, unless for gastroparesis with a duration of use not to exceed 12 weeks except in rare cases.',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 30,
            Category: 'Gastrointestinal',
            Drug_Class: '',
            Drug_Class_Category: 'GI antispasmodics with strong anticholinergic activity',
            Drug_Name: ['Atropine (excludes ophthalmic)', 'Clidinium-chlordiazepoxide', 'Dicyclomine', 'Hyoscyamine', 'Scopolamine'],
            Rationale: 'Highly anticholinergic, uncertain effectiveness.',
            Recommendation: 'Avoid',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 31,
            Category: 'Gastrointestinal',
            Drug_Class: '',
            Drug_Class_Category: '',
            Drug_Name: 'Mineral oil, given orally',
            Rationale: 'Potential for aspiration and adverse effects; safer alternatives available.',
            Recommendation: 'Avoid',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 32,
            Category: 'Genitourinary',
            Drug_Class: '',
            Drug_Class_Category: '',
            Drug_Name: 'Desmopressin',
            Rationale: 'High risk of hyponatremia; safer alternative treatments for nocturia (including non- pharmacologic).',
            Recommendation: 'Avoid for treatment of nocturia or nocturnal polyuria.',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 33,
            Category: 'Pain medications',
            Drug_Class: '',
            Drug_Class_Category: 'Non-COX-2-selective NSAIDs, oral:',
            Drug_Name: ['Aspirin >325 mg/day', 'Diclofenac', 'Diflunisal', 'Etodolac', 'Flurbiprofen', 'Ibuprofen', 'Indomethacin', 'Ketorolac', 'Meloxicam', 'Nabumetone', 'Naproxen', 'Oxaprozin', 'Piroxicam', 'Sulindac'],
            Rationale: 'Increased risk of GI bleeding or peptic ulcer disease in high-risk groups, including those >75 years old or taking oral or parenteral corticosteroids, anticoagulants, or antiplatelet agents; use of proton-pump inhibitor or misoprostol reduces but does not eliminate risk. Upper GI ulcers, gross bleeding, or perforation caused by NSAIDs occur in (cid:3)1% of patients treated for 3–6 months and in (cid:3)2%–4% of patients treated for 1 year; these trends continue with longer duration of use. Also can increase blood pressure and induce kidney injury. Risks are dose-related.',
            Recommendation: 'Avoid chronic use unless otheralternatives are not effective and the patient can take a gastroprotective agent (proton-pump inhibitor or misoprostol). Avoid short-term scheduled use in corticosteroids, anticoagulants, or antiplatelet agents unless other alternatives are not effective and the patient can take a gastroprotective agent (proton-pump inhibitor or misoprostol).',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 34,
            Category: 'Pain medications',
            Drug_Class: 'Indomethacin',
            Drug_Class_Category: '',
            Drug_Name: 'Ketorolac (oral and parenteral)',
            Rationale: 'Increased risk of GI bleeding/peptic ulcer disease and acute kidney injury in older adults. Of all the NSAIDs, indomethacin has the most adverse effects, including a higher risk of adverse CNS effects.',
            Recommendation: 'Avoid',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 35,
            Category: 'Pain medications',
            Drug_Class: '',
            Drug_Class_Category: '',
            Drug_Name: 'Meperidine',
            Rationale: 'Oral analgesic not effective in dosages commonly used; may have a higher risk of neurotoxicity, including delirium, than other opioids; safer alternatives available.',
            Recommendation: 'Avoid',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 36,
            Category: 'Pain medications',
            Drug_Class: '',
            Drug_Class_Category: 'Skeletal muscle relaxants',
            Drug_Name: ['Carisoprodol', 'Chlorzoxazone', 'Cyclobenzaprine', 'Metaxalone', 'Methocarbamol', 'Orphenadrine'],
            Rationale: 'Muscle relaxants typically used to treat musculoskeletal complaints are poorly tolerated by older adults due to anticholinergic adverse effects, sedation, and increased risk of fractures; effectiveness at dosages tolerated by older adults is questionable. This criterion does not apply to skeletal muscle relaxants typically used for the management of spasticity (i.e., baclofen and tizanidine) although these drugs can also cause substantial adverse effects.',
            Recommendation: 'Avoid',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
    ];

    try {
        await collection.insertMany(userObjects1);
        console.log("Medications List Created!");
    } catch (err) {
        console.error("Failed to insert document:", err);
        throw err; // propagate the error
    }
}

async function main() {
    try {
        await client.connect();
        console.log("Connected successfully to server");
        var db = client.db(dbName); // use this database

        await insertMed(db);
    } catch (err) {
        console.error("Failed to connect to the server:", err);
    } finally {
        await client.close();
    }
}

main();