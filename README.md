# Reality

### The universe is running in production. We are inside it.

> **What if conscious observers, themselves products of an unknown implementation, attempted to reconstruct that implementation using only the information available from within it?**

That is the question at the heart of **Reality**.

We did not design the universe. We cannot step outside it, examine its source code, or compare its behavior with an independently accessible implementation. We are participants in the very system we are trying to understand.

Yet the system has produced organisms capable of observing it, discovering regularities, building mathematical descriptions, testing explanations, and asking what — if anything — lies beneath everything they observe.

**This repository is an exploration of that extraordinary situation, expressed through C# and .NET.**

```csharp
// TODO: Discover the actual implementation.
// Source code unavailable.
```

## The idea

Imagine trying to reverse-engineer a running program without access to its source code.

You can observe inputs and outputs. You can experiment, discover patterns, construct predictive models, and reject models that disagree with the evidence. You may even learn enough to make remarkably accurate predictions.

But those successes do not necessarily tell you which underlying implementation produced the behavior.

Now imagine that **you, your instruments, your experiments, your reasoning, and your scientific theories are all processes running inside that same program**.

That is the analogy we are exploring.

The analogy is not an assertion that the universe is literally software, a simulation, or designed by a programmer. It is a way to frame the limits and possibilities of knowledge from the inside.

## Three questions, three different responsibilities

### 1. What is actually there?

`IReality` names the underlying reality — whatever it ultimately is.

Its true implementation is **unknown**. We deliberately do not implement it with a favorite metaphysical theory, and we do not claim that our C# code reproduces existence.

### 2. What can we observe and model?

`IObservableUniverse` represents the observer-accessible world as described by scientific inquiry. `ObservedUniverse` contains our revisable, intentionally simplified examples.

Physics tells us about measurable regularities. Cosmology investigates cosmic history. Chemistry and biology investigate how organized systems arise and change. Neuroscience investigates cognition and the neural correlates of conscious experience. Cultural evolution helps explain how the observers themselves accumulate knowledge.

These are different domains of investigation, not proof of any single underlying ontology.

### 3. What might explain it?

`ITheoryOfReality` describes competing philosophical accounts of what underlies the observations.

The initial four are:

| Theory | Central proposal | Persistent challenge |
| --- | --- | --- |
| **Panpsychism** | Experiential aspects may be fundamental and widespread | How, if at all, do they relate to unified human experience? |
| **Physicalism** | Mental facts are physical or wholly fixed by physical facts | How does a physical account explain subjective experience? |
| **Idealism** | Mind or experience is metaphysically fundamental | What explains a stable, shared, law-governed world? |
| **Substance dualism** | Mental and physical substances are fundamentally distinct | How do they relate, and can they interact consistently with physical evidence? |

These are broad families of philosophical views, not completed scientific theories or confirmed implementations. They must answer to the **same observable evidence**. Selecting a theory must never rewrite the observations to make that theory appear correct.

## Architecture: one universe, many possible explanations

```text
               IReality
       underlying implementation
                 unknown
                    |
          observable interface
                    |
          IObservableUniverse
                    |
             ObservedUniverse
                    |
       +------------+------------+
       |            |            |
    Physics       Biology      Cognition
    Cosmos        Genetics     Neuroscience
    Spacetime     Evolution    Consciousness
       |            |            |
       +------------+------------+
                    |
       Emergence and cultural evolution
                    |
        Observation and investigation
                    |
             ScientificCatalog
        Findings + reasoning trails
                    |
             TheoryComparisonService
                    |
             ITheoryOfReality
       +------------+-------------+
       |            |             |
   Panpsychism  Physicalism    Idealism
                    |
             Substance dualism
```

This is a map of the *code's responsibilities*, not a claim that these phenomena form one simple, inevitable causal ladder. Scientific domains interact, and the relation between physical processes and first-person experience remains an open question.

Most importantly, **theories are attempts to explain the system, not alternate universes instantiated by the application**.

## How can an observer know anything about the system?

This is where the project moves beyond a collection of analogies.

It is not enough to record what we currently believe. We also want to examine **why** we believe it, what supports it, and where the limits of that support lie.

A scientific investigation asks:

1. **Observation:** What was actually measured or experienced?
2. **Inference:** What conclusion do we draw from those observations?
3. **Assumptions:** What models, background beliefs, and measurement conditions does that inference rely on?
4. **Alternatives:** What other explanations could be compatible with the observations?
5. **Potential tests:** What would distinguish the competing explanations?
6. **Provenance:** Where did the evidence come from, and has it been independently checked?

`ScientificCatalog` captures scientific findings and their `EvidenceStatus`. `ScientificInvestigation` begins connecting selected findings to these reasoning steps.

### An evidence and reasoning graph

Milestone 1 adds `Epistemology/Reasoning/`: a directed graph of **publications, reported observations, methodological assumptions, inferences, scientific models, and open questions**. Each typed connection explains why one claim documents, supports, challenges, requires an assumption for, or raises a question about another. The `TraceReasons` operation follows upstream links from a conclusion toward its reported observations and provenance; it terminates even if the graph contains cycles.

The first worked example is a **2025 preregistered adversarial comparison of Global Neuronal Workspace Theory and Integrated Information Theory** ([Nature, doi:10.1038/s41586-025-08888-1](https://doi.org/10.1038/s41586-025-08888-1)). We identify *reported* neural measurements, an intentionally limited inference about conscious content, a measurement assumption, challenges to specific model predictions, and questions the findings do **not** resolve. The record links to a published article; it is not a replacement for independently examining the full methods and data.

**The graph describes claimed evidential relationships, not proofs.** Its links do not imply causal identification, theory falsification, confidence probabilities, or an inference to a preferred ontology. Metaphysical theories remain separate from the empirical graph; comparing detailed neural mechanisms is distinct from comparing physicalism, panpsychism, idealism and dualism.

The initial conceptual investigations concern **cosmic expansion**, **dark matter**, and **neural correlates of consciousness**. Their observations and inferences are illustrative summaries: primary studies, datasets, and detailed provenance are **not yet attached**. We explicitly mark that gap rather than invent citations or implying a completed literature review.

The aim is a disciplined distinction:

**What we observe is not automatically what we infer. What we infer is not automatically what reality ultimately is.**

## Comparing explanations without pretending to know the answer

The philosophy layer distinguishes:

- `Assumption`: what an account takes for granted.
- `Explanation`: how it proposes to interpret a scientific finding.
- `OpenQuestion`: what it has not resolved.
- `Prediction` and `PredictionTestability`: possible ways a sufficiently specific account might be tested.
- `TheoryAssessment`: a structured inventory of those claims.

`TheoryComparisonService` compares those inventories against the scientific catalog. It does **not** calculate which ontology is true, treat explanatory claims as empirical confirmation, or manufacture precision through arbitrary probability scores.

Some competing philosophical positions may make the same observable predictions. If available evidence cannot discriminate between them, the intellectually responsible output is **underdetermination**, not a winner.

The project's core commitments are therefore methodological, not metaphysical: curiosity, logical consistency, revisability, transparency about assumptions, and respect for evidence.

## The observers are part of the story

One of the most interesting aspects of this project is that the investigators are themselves products of the reality under investigation.

Our models touch on cosmology, chemistry, genetics, evolution, nervous systems, emergence, consciousness, and cultural transmission because they help frame an extraordinary chain of questions:

- How did a universe with regularities come to contain increasingly complex systems?
- How did some living systems become capable of sensing, learning, remembering, and predicting?
- How should we understand subjective experience — the fact that there is something it is like to be an observer?
- How did observers develop language, mathematics, scientific methods, and philosophy?
- What can these observers ultimately know about the system that produced them?

The code does not pretend that answering an earlier question automatically settles a later one. In particular, modeling neural information processing does **not** by itself explain phenomenal experience.

## Try the investigation

Requires **.NET 8 SDK**. No external NuGet packages are required.

```bash
# Compare the available philosophical theories against shared observations.
dotnet run --project src/Reality/Reality.csproj

# Explore one particular account without changing the scientific model.
dotnet run --project src/Reality/Reality.csproj -- Physicalism
dotnet run --project src/Reality/Reality.csproj -- Idealism
dotnet run --project src/Reality/Reality.csproj -- "Substance dualism"

# Run the smoke checks.
dotnet run --project tests/Reality.SmokeTests/Reality.SmokeTests.csproj
```

The console prints the conceptual scientific history, catalog findings, theory comparisons, selected *how-we-know* investigations, and scientific demonstrations. When launched interactively, it prompts **Press Enter to exit**; redirected input/output and CI runs do not block.

### The educational models

The repository includes small demonstrations of DNA transcription and inheritance, seeded evolutionary selection, nervous-system information processing, emergent patterns, cultural transmission, light travel and time dilation, and a celestial-holography research example.

They are deliberately narrow teaching tools, **not** realistic simulations of entire biological systems, brains, spacetime, or quantum gravity. In particular, the celestial Mellin-transform example is not proof of a complete holographic duality.

## How the code is organized

- **One class, record, enum, or interface per file.**
- Interfaces live in an `Interfaces/` folder within their domain.
- Scientific models remain separate from philosophical theories.
- No interface is added merely for the sake of having one.
- The repository's CI checks the file organization, builds the .NET 8 application, and runs smoke tests.

To explore a new philosophical position, implement `ITheoryOfReality` under `Philosophy/Theories/`, register it in `TheoryCatalog`, and state its assumptions, explanations, unresolved problems, and genuinely distinguishable predictions (if any). Do not modify the scientific universe to favor it.

## Where this can go

This is an open-ended research and programming playground, not a plan to finish a theory of everything.

Natural next steps include attaching primary-source provenance to scientific investigations, modeling experimental disagreement and changing evidence, comparing finer-grained versions of philosophical positions, exploring arguments and counterarguments, and distinguishing what is **observable**, **inferable**, **conceivable**, and **knowable**.

A useful scientific model can be successful without revealing ultimate ontology. A philosophical interpretation can be coherent without being empirically confirmed. An unanswered question is not a failure of the investigation.

And an observer embedded within a system may discover extraordinary truths about it while never obtaining the vantage point of an external developer.

---

### The question remains

> **What if conscious observers, themselves products of an unknown implementation, attempted to reconstruct that implementation using only the information available from within it?**

This project is our attempt to explore what that process looks like — through science, philosophy, a little epistemology, and a lot of C#.

```csharp
// TODO: Discover the actual implementation.
// Source code unavailable.
```
